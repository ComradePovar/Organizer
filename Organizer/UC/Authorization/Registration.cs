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

namespace Organizer.UC.Authorization
{
    public partial class Registration : UserControl
    {
        private SqlConnection connection
        {
            get
            {
                return (ParentForm as OrganizerForm).Connection;
            }
        }

        public Registration()
        {
            InitializeComponent();
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;
        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            if (checkValues())
            {
                SqlCommand newUserCmd = new SqlCommand("sp_InsertUser", connection);
                newUserCmd.CommandType = CommandType.StoredProcedure;
                newUserCmd.Parameters.Add(new SqlParameter("@login", tbLogin.Text));
                newUserCmd.Parameters.Add(new SqlParameter("@password", mtbPassword.Text));

                try
                {
                    newUserCmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

                (ParentForm as OrganizerForm)
                    .Controls["panel"]
                    .Controls["login"]
                    .BringToFront();
            }
            else
            {
                MessageBox.Show("вронг");
            }
        }

        private bool checkValues()
        {
            if (tbLogin.Text.Length > 0 && tbLogin.Text.Length < 11)
                return true;
            if (mtbPassword.Text == mtbPassConfirmation.Text
                && mtbPassword.Text.Length > 0 && mtbPassword.Text.Length < 11)
                return true;
            return false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            (ParentForm as OrganizerForm)
                .Controls["panel"]
                .Controls["login"]
                .BringToFront();
        }
    }
}
