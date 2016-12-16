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
        }

        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            //(Parent.Parent as Organizer).GetEvents(ToISODateTime(e.Start));
        }

        private string ToISODateTime(DateTime date)
        {
            return date.Year + "-" + date.Month + "-" + date.Day;
        }
    }
}
