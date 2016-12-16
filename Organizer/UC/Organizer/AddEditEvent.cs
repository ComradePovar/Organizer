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
            dateTimePicker.CustomFormat = "dd-MM-yyyy HH:mm";
            dateTimePicker.Format = DateTimePickerFormat.Custom;
        }

        private void btnAddEditEvent_Click(object sender, EventArgs e)
        {
            string eventDate = GetDate(dateTimePicker.Value);
            string eventTime = GetTime(dateTimePicker.Value);

            if (_isEdit)
            {
                _userEvent.Init(
                    _userEvent.EventID,
                    tbDescription.Text,
                    tbCity.Text,
                    tbStreet.Text,
                    tbHome.Text,
                    eventDate,
                    eventTime
                );
                updateUserEvent();
            }
            else
            {
                _userEvent = new UserEvent(
                    null,
                    tbDescription.Text,
                    tbCity.Text,
                    tbStreet.Text,
                    tbHome.Text,
                    eventDate,
                    eventTime
                );
                insertUserEvent();
                foreach (UC.Contacts.ContactItem item in pnlContacts.Controls)
                {
                    SqlCommand addEvent = new SqlCommand(
                        string.Format("INSERT INTO event_invites VALUES('{0}', '{1}', NULL);",
                                      _userEvent.EventID, item._userContact.Login),
                        (Application.OpenForms["OrganizerForm"] as OrganizerForm).Connection
                    );

                    addEvent.ExecuteNonQuery();
                }
            }

            clearTextBoxes();
            (ParentForm.Controls["panel"].Controls["organizer"] as Organizer).RestoreSizes();
            (Parent.Controls["calendar"]).BringToFront();
        }

        private void updateUserEvent()
        {
            OrganizerForm mainFOrm = Application.OpenForms["OrganizerForm"] as OrganizerForm;
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
                mainFOrm.Connection
            );
            SqlCommand updateStatus = new SqlCommand(
                string.Format("UPDATE event_invites SET status = NULL WHERE event_id = '{0}' AND " +
                                "[user] = '{1}'", _userEvent.EventID,
                              mainFOrm.CurrentLogin),
                mainFOrm.Connection);
            try
            {
                update.ExecuteNonQuery();
                updateStatus.ExecuteNonQuery();
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
            SqlCommand getID = new SqlCommand(
                string.Format("SELECT MAX(event_id) FROM Events " +
                              "WHERE owner = '{0}'",
                              (Application.OpenForms["OrganizerForm"] as OrganizerForm).CurrentLogin),
                (Application.OpenForms["OrganizerForm"] as OrganizerForm).Connection
            );
            try
            {
                insert.ExecuteNonQuery();
                _userEvent.EventID = (int)getID.ExecuteScalar();
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
            (ParentForm.Controls["panel"].Controls["organizer"] as Organizer).IncreaseSizes();
            _isEdit = true;
            btnAddEditEvent.Text = "Изменить";

            tbDescription.Text = userEvent.Description;
            tbCity.Text = userEvent.City;
            tbStreet.Text = userEvent.Street;
            tbHome.Text = userEvent.Home;
            dateTimePicker.Value = GetDateTime(userEvent.EventDate, userEvent.EventTime);

            SqlDataReader reader = null;
            SqlCommand getContacts = new SqlCommand(
                            string.Format("SELECT * FROM Users_info " +
                                          "WHERE login IN (" +
                                          "SELECT [user] FROM event_invites WHERE "+
                                          "event_id = {0})",
                            _userEvent.EventID),
                            (Application.OpenForms["OrganizerForm"] as OrganizerForm).Connection
            );
            try
            {
                reader = getContacts.ExecuteReader();

                if (reader.HasRows)
                {
                    UserContact userContact;

                    while (reader.Read())
                    {
                        userContact = new UserContact(
                            reader["login"],
                            reader["name"],
                            reader["surname"],
                            reader["phone"],
                            reader["city"],
                            reader["street"],
                            reader["home"],
                            reader["email"]
                        );

                        pnlContacts.Controls.Add(
                            new UC.Contacts.ContactItem(userContact, false)
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Пользователь с таким логином уже добавлен.", "",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button1);
                return;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
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
            pnlContacts.Controls.Clear();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            string eventDate = GetDate(dateTimePicker.Value);
            clearTextBoxes();
            (ParentForm.Controls["panel"].Controls["organizer"] as Organizer).RestoreSizes();
            (Parent.Controls["calendar"]).BringToFront();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            (new ContactsForm(true)).ShowDialog();
        }
    }
}
