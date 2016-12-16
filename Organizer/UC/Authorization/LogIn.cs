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
    public partial class LogIn : UserControl
    {
        public delegate void AuthSuccessfulHandler(string login);
        public event AuthSuccessfulHandler AuthSuccessful;

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
                if (reader.HasRows)
                {
                    reader.Close();
                    AuthSuccessful(tbLogin.Text);
                }
                else
                {
                    MessageBox.Show("Неверная комбинация логин-пароль.");
                }
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

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            (ParentForm as OrganizerForm)
                .Controls["panel"]
                .Controls["registration"]
                .BringToFront();
        }
    }

}
