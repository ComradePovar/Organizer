using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Organizer
{
    public partial class OrganizerForm : Form
    {
        private string connectionString;
        public SqlConnection Connection { get; private set; }
        public string CurrentLogin { get; private set; }
        public List<UserEvent> _userEvents;
        private UserContact user;

        string parseFormat1 = "dd.MM.yyyy HH:mm:ss";
        string parseFormat2 = "yyyy-MM-dd HH:mm";
        string parseFormat3 = "yyyy-MM-dd H:m";
        string parseFormat4 = "yyyy-MM-dd H:mm";
        string parseFormat5 = "yyyy-MM-dd HH:m";
        string parseFormat6 = "yyyy-M-d H:m";
        string parseFormat7 = "yyyy-M-d HH:mm";
        string parseFormat8 = "yyyy-M-d HH:m";
        string parseFormat9 = "yyyy-M-d H:mm";
        string parseFormat10 = "yyyy-MM-d HH:mm";
        string parseFormat11 = "yyyy-MM-d HH:m";
        string parseFormat12 = "yyyy-MM-d H:m";
        string parseFormat13 = "yyyy-MM-d H:mm";
        string parseFormat14 = "yyyy-M-dd HH:mm";
        string parseFormat15 = "yyyy-M-dd HH:m";
        string parseFormat16 = "yyyy-M-dd H:mm";
        string parseFormat17 = "yyyy-M-dd H:m";

        public OrganizerForm()
        {
            InitializeComponent();

            UC.Authorization.LogIn loginUC = new UC.Authorization.LogIn() { Name = "login" };
            loginUC.AuthSuccessful += OnAuthSuccessful;
            panel.Controls.Add(loginUC);
            panel.Controls.Add(new UC.Authorization.Registration() { Name = "registration" });
            panel.Controls["login"].BringToFront();
        }

        public void Init()
        {
            timer.Stop();
            timerEvents.Stop();
            CurrentLogin = null;
            _userEvents = null;
            user = null;
            UC.Authorization.LogIn login = (panel.Controls["login"] as UC.Authorization.LogIn);
            login.Controls["tbLogin"].Text = "";
            login.Controls["mtbPassword"].Text = "";
            Size = new Size(308, 219);
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                if (Application.OpenForms[i].Name != "OrganizerForm")
                    Application.OpenForms[i--].Close();
            }
            panel.Controls.Clear();
            UC.Authorization.LogIn loginUC = new UC.Authorization.LogIn() { Name = "login" };
            loginUC.AuthSuccessful += OnAuthSuccessful;
            panel.Controls.Add(loginUC);
            panel.Controls.Add(new UC.Authorization.Registration() { Name = "registration" });
            panel.Controls["login"].BringToFront();
        }
        private void OrganizerForm_Load(object sender, EventArgs e)
        {
            connectionString = ConfigurationManager
                                    .ConnectionStrings["OrganizerDB"]
                                    .ConnectionString;
            try
            {
                Connection = new SqlConnection(connectionString);

                Connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void OnUserInfoChanged(UserContact userInfo)
        {
            user = userInfo;
        }
        private void OnAuthSuccessful(string login)
        {
            CurrentLogin = login;

            getUserInfo();
            panel.Controls.Add(new UC.Organizer.Organizer(user) { Name = "organizer" });
            panel
                .Controls["organizer"]
                .BringToFront();
            ClientSize = new Size(405, 205);

            timerEvents_Tick(null, null);
            timerEvents.Start();
            timer.Start();
        }
        
        private void getUserEvents()
        {
            SqlCommand getEvents = new SqlCommand(
                string.Format("SELECT * FROM Events" +
                              " WHERE owner = '{0}' AND" +
                              " status IS NULL",
                CurrentLogin), Connection
            );

            _userEvents = new List<UserEvent>();
            SqlDataReader reader = null;
            try
            {
                reader = getEvents.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        UserEvent userEvent = new UserEvent(
                            reader["event_id"],
                            reader["description"],
                            reader["city"],
                            reader["street"],
                            reader["home"],
                            reader["event_date"],
                            reader["event_time"]
                        );

                        _userEvents.Add(userEvent);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
        private void getUserInfo()
        {
            SqlCommand getUserInfo = new SqlCommand(
                string.Format("SELECT * FROM Users_info WHERE login = '{0}'",
                              CurrentLogin),
                Connection
            );

            SqlDataReader reader = null;
            try
            {
                reader = getUserInfo.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        user = new UserContact(
                            reader["login"],
                            reader["name"],
                            reader["surname"],
                            reader["phone"],
                            reader["city"],
                            reader["street"],
                            reader["home"],
                            reader["email"]
                        );
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
        private void timerEvents_Tick(object o, EventArgs e)
        {
            Panel eventList = ((panel.Controls["organizer"] as UC.Organizer.Organizer)
                              .Controls["pnlEventList"] as Panel);

            for (int i = 0; i < eventList.Controls.Count; i++)
            {
                Control eventItem = eventList.Controls[i];
                if (eventItem is UC.Organizer.EventItem)
                {
                    eventList.Controls.Remove(eventItem);
                    eventItem.Dispose();
                }
            }
            DateTime lastDate = ((((panel.Controls["organizer"] as UC.Organizer.Organizer)
                                .Controls["pnlCalendarEvent"] as Panel)
                                .Controls["calendar"] as UC.Organizer.Calendar)
                                .Controls["monthCalendar"] as MonthCalendar)
                                .SelectionStart;
            string date = lastDate.Year + "-" + lastDate.Month + "-" + lastDate.Day;

            SqlCommand getEvents = new SqlCommand(
                string.Format("SELECT * FROM Events JOIN Event_invites ON Events.Event_id = Event_invites.Event_id" +
                              " WHERE [user] = '{0}' AND" +
                              " event_date = '{1}' AND (status IS NULL OR status = 'viewed')" +
                              " ORDER BY event_time DESC",
                CurrentLogin, date),
                Connection
            );
            SqlCommand getContacts = new SqlCommand(
                string.Format("SELECT contact FROM Contacts WHERE owner = '{0}'",
                CurrentLogin), Connection);
            SqlDataReader reader = null;
            SqlDataReader readercontacts = null;
            try
            {
                List<string> contacts = new List<string>();
                readercontacts = getContacts.ExecuteReader();
                if (readercontacts.HasRows)
                {
                    while(readercontacts.Read())
                        contacts.Add(readercontacts.GetValue(0).ToString());
                }
                readercontacts.Close();
                reader = getEvents.ExecuteReader();
                _userEvents = new List<UserEvent>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        UserEvent userEvent = new UserEvent(
                            reader["event_id"],
                            reader["description"],
                            reader["city"],
                            reader["street"],
                            reader["home"],
                            reader["event_date"],
                            reader["event_time"]
                        );
                        if (contacts.Contains(reader["owner"].ToString()))
                        {
                            if (reader["status"].ToString() == "")
                                _userEvents.Add(userEvent);
                            eventList.Controls.Add(
                                new UC.Organizer.EventItem(userEvent)
                            );
                        }
                    }
                }
            }

            finally
            {
                if (reader != null)
                    reader.Close();
            }


        }
        public void RefreshList()
        {
            timerEvents_Tick(null, null);
        }
    private void timer_Tick(object o, EventArgs e)
        {
            DateTime dtNow = DateTime.Now;

            string[] parseFormats = new string[] { parseFormat1, parseFormat2, parseFormat3, parseFormat4,
                                                   parseFormat5, parseFormat6, parseFormat7, parseFormat8,
                                                   parseFormat9, parseFormat10, parseFormat11, parseFormat12,
                                                   parseFormat13, parseFormat14, parseFormat15,
                                                   parseFormat16, parseFormat17 };
            if (_userEvents == null)
                return;
            foreach (UserEvent userEvent in _userEvents)
            {
                string sEventDateTime = userEvent.EventDate.Split(' ')[0] + " " +
                                       userEvent.EventTime;
                DateTime eventDateTime = DateTime.ParseExact(
                    sEventDateTime, parseFormats, null, System.Globalization.DateTimeStyles.None);
                if (eventDateTime <= dtNow && userEvent.isViewed == false)
                {
                    SqlCommand eventViewed = new SqlCommand(
                        string.Format("UPDATE Event_invites SET status = 'viewed' WHERE event_id = {0} AND [user] = '{1}'",
                                      userEvent.EventID, CurrentLogin),
                        Connection
                    );
                    userEvent.isViewed = true;
                    eventViewed.ExecuteNonQuery();
                    (new EventInfoForm(userEvent)).ShowDialog();
                }
            }
        }
    }
}
