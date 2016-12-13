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
    public partial class NewEvent : UserControl
    {
        public NewEvent()
        {
            InitializeComponent();
            
        }

        private void NewEvent_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;
            Console.WriteLine(dateTimePicker.CustomFormat);
            dateTimePicker.CustomFormat = "dd-MM-yyyy HH:mm";
            dateTimePicker.Format = DateTimePickerFormat.Custom;
        }

        private void btnCreateEvent_Click(object sender, EventArgs e)
        {
            string eventDate = GetDate(dateTimePicker.Value);
            string eventTime = GetTime(dateTimePicker.Value);
            UserEvent userEvent = new UserEvent(
                null,
                tbDescription.Text,
                tbCity.Text,
                tbStreet.Text,
                tbHome.Text,
                eventDate,
                eventTime
            );

            insertUserEvent(userEvent);
            (Parent.Controls["calendar"] as Calendar).GetEvents(eventDate);
            (Parent.Controls["calendar"]).BringToFront();
        }

        private void insertUserEvent(UserEvent userEvent)
        {
            SqlCommand insert = new SqlCommand(
                string.Format("INSERT INTO dbo.events (" +
                              "owner, description, city, street, home, event_date, event_time)" +
                              "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');",
                              (Application.OpenForms["OrganizerForm"] as OrganizerForm).CurrentLogin,
                              userEvent.Description,
                              userEvent.City,
                              userEvent.Street,
                              userEvent.Home,
                              userEvent.EventDate,
                              userEvent.EventTime)
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
    }
}
