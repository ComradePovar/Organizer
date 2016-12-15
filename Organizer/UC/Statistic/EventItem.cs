using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Organizer.UC.Statistic
{
    public partial class EventItem : UserControl
    {
        private UserEvent _event;
        public EventItem()
        {
            InitializeComponent();
        }

        public EventItem(UserEvent userEvent)
        {
            InitializeComponent();
            _event = userEvent;
            tslTitle.Text = userEvent.Description;
            tslDate.Text = userEvent.EventDate.Substring(0, userEvent.EventDate.Length - 8);
        }

        private void EventItem_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Top;
        }

        private void tsEventItem_Click(object sender, EventArgs e)
        {
            (new EventInfoForm(_event)).ShowDialog();
        }
    }
}
