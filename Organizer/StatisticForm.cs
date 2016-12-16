using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Organizer
{
    public partial class StatisticForm : Form
    {
        public StatisticForm()
        {
            InitializeComponent();
        }

        private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerFrom.Value > dateTimePickerUntil.Value)
                dateTimePickerFrom.Value = dateTimePickerUntil.Value;
        }

        private void dateTimePickerUntil_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerUntil.Value < dateTimePickerFrom.Value)
                dateTimePickerUntil.Value = dateTimePickerFrom.Value;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            OrganizerForm mainForm = Application.OpenForms["OrganizerForm"] as OrganizerForm;
            string dateFrom = ToISODateTime(dateTimePickerFrom.Value);
            string dateUntil = ToISODateTime(dateTimePickerUntil.Value);
            string status;
            if (rbCompleted.Checked)
                status = "completed";
            else
                status = "canceled";

            lbCount.Text = "";
            foreach(UC.Statistic.EventItem userEvent in pnlEventList.Controls)
            {
                userEvent.Dispose();
            }         
            pnlEventList.Controls.Clear();

            SqlCommand findEvents = new SqlCommand(
                string.Format("SELECT * FROM Events JOIN Event_invites ON Events.event_id=Event_invites.event_id WHERE " +
                              "[user] = '{0}' AND event_date >= '{1}' AND event_date <= '{2}' "+
                              "AND status = '{3}' ORDER BY event_date ASC",
                              mainForm.CurrentLogin, dateFrom, dateUntil, status),
                mainForm.Connection
            );

            SqlDataReader reader = null;
            try
            {
                reader = findEvents.ExecuteReader();
                int count = 0;

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

                    pnlEventList.Controls.Add(new UC.Statistic.EventItem(userEvent));
                    count++;
                }
                reader.Close();
                lbCount.Text = "Количество мероприятий: " + count;
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

        private string ToISODateTime(DateTime date)
        {
            return date.Year + "-" + date.Month + "-" + date.Day;
        }
    }
}
