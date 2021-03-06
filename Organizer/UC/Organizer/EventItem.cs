﻿using System;
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

        private void EventItem_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Top;
        }

        private void cancelEvent()
        {
            Parent.Parent.Controls["pnlEventList"].Controls.Remove(this);
            (Application.OpenForms["OrganizerForm"] as OrganizerForm)
                ._userEvents
                .RemoveAll(userEvent => userEvent.EventID == _userEvent.EventID);

            SqlCommand cancelEvent = new SqlCommand(
                string.Format("UPDATE Event_invites" +
                              " SET status = 'canceled'" +
                              " WHERE event_id = {0} AND [user] = '{1}'", _userEvent.EventID,
                              (Application.OpenForms["OrganizerForm"] as OrganizerForm).CurrentLogin),
                (Application.OpenForms["OrganizerForm"] as OrganizerForm).Connection
            );

            try
            {
                cancelEvent.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Dispose();
        }
        private void completeEvent()
        {
            Parent.Parent.Controls["pnlEventList"].Controls.Remove(this);
            (Application.OpenForms["OrganizerForm"] as OrganizerForm)
                ._userEvents
                .RemoveAll(userEvent => userEvent.EventID == _userEvent.EventID);

            SqlCommand completeEvent = new SqlCommand(
                string.Format("UPDATE Event_invites" +
                              " SET status = 'completed'" +
                              " WHERE event_id = {0} AND [user] = '{1}'", _userEvent.EventID,
                              (Application.OpenForms["OrganizerForm"] as OrganizerForm).CurrentLogin),
                (Application.OpenForms["OrganizerForm"] as OrganizerForm).Connection
            );

            try
            {
                completeEvent.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Dispose();
        }

        private void eventMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch(e.ClickedItem.Name)
            {
                case "tsbDel":
                    cancelEvent();
                    break;
                case "tsbComplete":
                    completeEvent();
                    break;
                default:
                    AddEditEvent addEditEvent = Parent
                                        .Parent
                                        .Controls["pnlCalendarEvent"]
                                        .Controls["addeditevent"] as AddEditEvent;
                    addEditEvent.EditEvent(_userEvent);
                    addEditEvent.BringToFront();
                    break;
            }
        }
    }
}
