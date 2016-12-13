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
    public partial class Calendar : UserControl
    {
        List<DateTime> boldedDates;
        public Calendar()
        {
            InitializeComponent();
            boldedDates = new List<DateTime>();
        }
        
        private void Calendar_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;
            GetEvents(ToISODateTime(monthCalendar.TodayDate));
        }

        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            GetEvents(ToISODateTime(e.Start));
        }

        private string ToISODateTime(DateTime date)
        {
            return date.Year + "-" + date.Month + "-" + date.Day;
        }

        public void GetEvents(string date)
        {
            foreach (EventItem eventItem in Parent.Parent.Controls["pnlEventList"].Controls)
            {
                eventItem.Dispose();
            }

            Parent.Parent.Controls["pnlEventList"].Controls.Clear();

            SqlCommand getTodayEvents = new SqlCommand(
                string.Format("SELECT * FROM dbo.events" +
                              " WHERE owner = '{0}' AND" +
                              " event_date = '{1}'" +
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

                        Parent.Parent.Controls["pnlEventList"].Controls.Add(
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
