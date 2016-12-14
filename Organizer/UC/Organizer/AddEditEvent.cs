using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Organizer.UC.Organizer
{
    public partial class AddEditEvent : UserControl
    {
        private UserEvent _userEvent;
        private bool _isEdit;

        public AddEditEvent()
        {
            InitializeComponent();
            
        }

        private void NewEvent_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;
            _isEdit = false;
            Console.WriteLine(dateTimePicker.CustomFormat);
            dateTimePicker.CustomFormat = "dd-MM-yyyy HH:mm";
            dateTimePicker.Format = DateTimePickerFormat.Custom;
        }

        private void btnAddEditEvent_Click(object sender, EventArgs e)
        {
            string eventDate = GetDate(dateTimePicker.Value);
            string eventTime = GetTime(dateTimePicker.Value);
            _userEvent = new UserEvent(
                null,
                tbDescription.Text,
                tbCity.Text,
                tbStreet.Text,
                tbHome.Text,
                eventDate,
                eventTime
            );

            if (_isEdit)
                updateUserEvent();
            else
                insertUserEvent();

            (Parent.Parent as Organizer).GetEvents(eventDate);

            OrganizerForm mainForm = Application.OpenForms["OrganizerForm"] as OrganizerForm;
            mainForm._userEvents.RemoveAll(userEvent => userEvent.EventID == _userEvent.EventID);
            mainForm._userEvents.Add(_userEvent);

            clearTextBoxes();
            (Parent.Controls["calendar"]).BringToFront();
        }

        private void updateUserEvent()
        {
            SqlCommand update = new SqlCommand(
                string.Format("UPDATE dbo.events " +
                              "SET description = '{0}', " +
                              "city = '{1}', " + 
                              "street = '{2}', " +
                              "home = '{3}', " +
                              "event_date = '{4}', " +
                              "event_time = '{5}' " +
                              "WHERE event_id = {6};",
                              _userEvent.Description,
                              _userEvent.City,
                              _userEvent.Street,
                              _userEvent.Home,
                              _userEvent.EventDate,
                              _userEvent.EventTime,
                              _userEvent.EventID),
                (Application.OpenForms["OrganizerForm"] as OrganizerForm).Connection
            );

            try
            {
                update.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        private void insertUserEvent()
        {
            SqlCommand insert = new SqlCommand(
                string.Format("INSERT INTO dbo.events (" +
                              "owner, description, city, street, home, event_date, event_time)" +
                              "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');",
                              (Application.OpenForms["OrganizerForm"] as OrganizerForm).CurrentLogin,
                              _userEvent.Description,
                              _userEvent.City,
                              _userEvent.Street,
                              _userEvent.Home,
                              _userEvent.EventDate,
                              _userEvent.EventTime)
                , (Application.OpenForms["OrganizerForm"] as OrganizerForm).Connection
            );

            try
            {
                insert.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private string GetDate(DateTime date)
        {
            return date.Year + "-" + date.Month + "-" + date.Day;
        }
        private string GetTime(DateTime time)
        {
            return time.Hour + ":" + time.Minute;
        }
        private DateTime GetDateTime(string date, string time)
        {
            string[] sDate = date.Split(new char[] { '.', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] sTime = time.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

            return new DateTime(int.Parse(sDate[2]), int.Parse(sDate[1]), int.Parse(sDate[0]),
                                int.Parse(sTime[0]), int.Parse(sTime[1]), 0);
        }

        public void EditEvent(UserEvent userEvent)
        {
            _userEvent = userEvent;
            _isEdit = true;
            btnAddEditEvent.Text = "Изменить";

            tbDescription.Text = userEvent.Description;
            tbCity.Text = userEvent.City;
            tbStreet.Text = userEvent.Street;
            tbHome.Text = userEvent.Home;
            dateTimePicker.Value = GetDateTime(userEvent.EventDate, userEvent.EventTime);
        }

        private void clearTextBoxes()
        {
            tbDescription.Text = "";
            tbCity.Text = "";
            tbStreet.Text = "";
            tbHome.Text = "";
            _userEvent = null;
            _isEdit = false;
            btnAddEditEvent.Text = "Создать";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            string eventDate = GetDate(dateTimePicker.Value);
            (Parent.Parent as Organizer).GetEvents(eventDate);
            clearTextBoxes();
            (Parent.Controls["calendar"]).BringToFront();
        }
    }
}
