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

        public OrganizerForm()
        {
            InitializeComponent();

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
            _userEvents = new List<UserEvent>();

            getUserInfo();
            panel.Controls.Add(new UC.Organizer.Organizer(user) { Name = "organizer" });
            panel
                .Controls["organizer"]
                .BringToFront();
            ClientSize = new Size(405, 205);

            timer.Start();
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
                _userEvents = new List<UserEvent>();
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
        private void timer_Tick(object o, EventArgs e)
        {
            DateTime dtNow = DateTime.Now;
            string parseFormat1 = "yyyy-MM-dd HH:mm";
            string parseFormat2 = "dd.MM.yyyy HH:mm:ss";
            string parseFormat3 = "yyyy-MM-dd H:m";
            string parseFormat4 = "yyyy-MM-dd H:mm";
            string parseFormat5 = "yyyy-MM-dd HH:m";
            string[] parseFormats = new string[] {parseFormat1, parseFormat2, parseFormat3, parseFormat4,
                                                    parseFormat5 };
            foreach (UserEvent userEvent in _userEvents)
            {
                string sEventDateTime = userEvent.EventDate.Split(' ')[0] + " " +
                                       userEvent.EventTime;
                DateTime eventDateTime = DateTime.ParseExact(
                    sEventDateTime, parseFormats, null, System.Globalization.DateTimeStyles.None);
                if (eventDateTime <= dtNow && userEvent.HasPassed == false)
                {
                    userEvent.HasPassed = true;
                    (new EventInfo(userEvent)).ShowDialog();
                    (panel.Controls["organizer"] as UC.Organizer.Organizer).GetEvents(
                        dtNow.Year + "-" + dtNow.Month + "-" + dtNow.Day
                    );
                }
            }
        }
    }
}
