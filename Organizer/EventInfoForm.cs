﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Organizer
{
    public partial class EventInfoForm : Form
    {
        private UserEvent _userEvent;
        public EventInfoForm()
        {
            InitializeComponent();
        }

        public EventInfoForm(UserEvent userEvent)
        {
            InitializeComponent();
            _userEvent = userEvent;

            lbEventDescription.Text = userEvent.Description;
            lbEventCity.Text = userEvent.City;
            lbEventStreet.Text = userEvent.Street;
            lbEventHome.Text = userEvent.Home;
            string[] sDate = userEvent.EventDate.Split(new char[] { '.', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] sTime = userEvent.EventTime.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                dateTimePicker.Value = new DateTime(int.Parse(sDate[2]), int.Parse(sDate[1]), int.Parse(sDate[0]),
                                    int.Parse(sTime[0]), int.Parse(sTime[1]), 0);
            }
            catch (IndexOutOfRangeException)
            {
                sDate = userEvent.EventDate.Split('-');
                dateTimePicker.Value = new DateTime(int.Parse(sDate[0]), int.Parse(sDate[1]), int.Parse(sDate[2]),
                                    int.Parse(sTime[0]), int.Parse(sTime[1]), 0);
            }
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EventInfo_Load(object sender, EventArgs e)
        {
            dateTimePicker.CustomFormat = "dd-MM-yyyy HH:mm";
            dateTimePicker.Format = DateTimePickerFormat.Custom;
        }
    }
}
