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
    public partial class EventItem : UserControl
    {
        private UserEvent _userEvent;

        public EventItem()
        {
            InitializeComponent();
        }

        public EventItem(UserEvent userEvent)
        {
            InitializeComponent();
            _userEvent = userEvent;
            tslEventTitle.Text = _userEvent.Description;
        }

        private void tsbDel_Click(object sender, EventArgs e)
        {
            deleteEvent();
            //занести в статистику как отмененное
            Dispose();
        }

        private void tsbComplete_Click(object sender, EventArgs e)
        {
            deleteEvent();
            //занести в статистику как выполненное
        }

        private void EventItem_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Top;
        }

        private void deleteEvent()
        {
            Parent.Parent.Controls["pnlEventList"].Controls.Remove(this);

            SqlCommand deleteEvent = new SqlCommand(
                string.Format("DELETE FROM dbo.events" +
                              " WHERE event_id = {0}", _userEvent.EventID),
                (Application.OpenForms["OrganizerForm"] as OrganizerForm).Connection
            );

            try
            {
                deleteEvent.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Dispose();
        }
    }
}
