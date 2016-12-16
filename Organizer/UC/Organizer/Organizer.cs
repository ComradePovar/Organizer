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
            label1.Size = new Size(label1.Size.Width, 271);
            pnlCalendarEvent.Size = new Size(197, 271);

            ParentForm.Size = new Size(ParentForm.Size.Width, 334);
            pnlCalendarEvent.Controls["addeditevent"].BringToFront();
        }
        public void IncreaseSizes()
        {
            label1.Size = new Size(label1.Size.Width, 271);
            pnlCalendarEvent.Size = new Size(197, 271);

            ParentForm.Size = new Size(ParentForm.Size.Width, 334);
            pnlCalendarEvent.Controls["addeditevent"].BringToFront();
        }
        public void RestoreSizes()
        {
            label1.Size = new Size(label1.Size.Width, 181);
            pnlCalendarEvent.Size = new Size(197, 181);
            ParentForm.Size = new Size(ParentForm.Size.Width, 244);
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
            profileForm.ShowDialog();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (ParentForm as OrganizerForm).Init();
        }

        private void статистикаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new StatisticForm()).ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            (ParentForm as OrganizerForm).RefreshList();
        }
    }
}
