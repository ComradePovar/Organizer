using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Organizer.UC.Organizer
{
    public partial class Organizer : UserControl
    {
        public Organizer()
        {
            InitializeComponent();
            pnlCalendarTask.Controls.Add(new NewEvent() { Name = "newevent" });
            pnlCalendarTask.Controls.Add(new Calendar() { Name = "calendar" });
            pnlCalendarTask.Controls["calendar"].BringToFront();
        }

        private void Organizer_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            pnlCalendarTask.Controls["newevent"].BringToFront();
        }

        private void contactsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new ContactsForm()).ShowDialog();
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new ProfileForm()).ShowDialog();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ParentForm.Close();
        }
    }
}
