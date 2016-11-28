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

namespace Organizer.UC.Authorization
{
    public partial class LogIn : UserControl
    {
        private SqlConnection connection
        {
            get
            {
                return (ParentForm as OrganizerForm).Connection;
            }
        }

        public LogIn()
        {
            InitializeComponent();
        }

        private void AuthorizationUC_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlCommand loginCmd = new SqlCommand("sp_ConfirmUser", connection);
            loginCmd.CommandType = CommandType.StoredProcedure;
            loginCmd.Parameters.Add(new SqlParameter("@login", tbLogin.Text));
            loginCmd.Parameters.Add(new SqlParameter("@password", mtbPassword.Text));

            SqlDataReader reader = null;
            try
            {
                reader = loginCmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            if (reader.HasRows)
            {
                MessageBox.Show("+");
            }
            else
            {
                MessageBox.Show("-");
            }
        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            (ParentForm as OrganizerForm)
                .Controls["panel"]
                .Controls["registration"]
                .BringToFront();
        }
    }

}
