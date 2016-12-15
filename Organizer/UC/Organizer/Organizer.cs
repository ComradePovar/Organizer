using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Organizer.UC.Organizer
{
    public partial class Organizer : UserControl
    {
        private UserContact _userInfo;

        public Organizer()
        {
            InitializeComponent();
            pnlCalendarEvent.Controls.Add(new AddEditEvent() { Name = "addeditevent" });
            pnlCalendarEvent.Controls.Add(new Calendar() { Name = "calendar" });
            pnlCalendarEvent.Controls["calendar"].BringToFront();
        }
        public Organizer(UserContact userInfo)
        {
            InitializeComponent();
            pnlCalendarEvent.Controls.Add(new AddEditEvent() { Name = "addeditevent" });
            pnlCalendarEvent.Controls.Add(new Calendar() { Name = "calendar" });
            pnlCalendarEvent.Controls["calendar"].BringToFront();
            _userInfo = userInfo;
        }

        private void Organizer_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            ((pnlCalendarEvent.Controls["addEditEvent"] as AddEditEvent)
                .Controls["dateTimePicker"] as DateTimePicker)
                .Value = (pnlCalendarEvent
                            .Controls["calendar"]
                            .Controls["monthCalendar"] as MonthCalendar)
                            .SelectionStart;
                
            pnlCalendarEvent.Controls["addeditevent"].BringToFront();
        }

        private void contactsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new ContactsForm()).ShowDialog();
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProfileForm profileForm = new ProfileForm(_userInfo);
            profileForm.UserInfoChanged += (Application.OpenForms["OrganizerForm"] as OrganizerForm)
                                           .OnUserInfoChanged;
            profileForm.Show();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ParentForm.Close();
        }

        public void GetEvents(string date)
        {
            foreach (EventItem eventItem in pnlEventList.Controls)
            {
                eventItem.Dispose();
            }

            pnlEventList.Controls.Clear();

            SqlCommand getTodayEvents = new SqlCommand(
                string.Format("SELECT * FROM Events" +
                              " WHERE owner = '{0}' AND" +
                              " event_date = '{1}' AND status IS NULL" +
                              " ORDER BY event_time DESC",
                (ParentForm as OrganizerForm).CurrentLogin, date),
                (ParentForm as OrganizerForm).Connection
            );

            SqlDataReader reader = null;
            try
            {
                reader = getTodayEvents.ExecuteReader();

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


                        pnlEventList.Controls.Add(
                            new EventItem(userEvent)
                        );
                    }
                }
            }

            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
    }
}
