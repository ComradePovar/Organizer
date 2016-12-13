using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Organizer
{
    public partial class OrganizerForm : Form
    {
        private string connectionString;
        public SqlConnection Connection { get; private set; }
        public string CurrentLogin { get; private set; }

        public OrganizerForm()
        {
            InitializeComponent();

            UC.Authorization.LogIn loginUC = new UC.Authorization.LogIn() { Name = "login" };
            loginUC.AuthSuccessful += OnAuthSuccessful;
            panel.Controls.Add(loginUC);
            panel.Controls.Add(new UC.Authorization.Registration() { Name = "registration" });
            panel.Controls["login"].BringToFront();
        }

        private void OrganizerForm_Load(object sender, EventArgs e)
        {
            connectionString = ConfigurationManager
                                    .ConnectionStrings["OrganizerDB"]
                                    .ConnectionString;
            try
            {
                Connection = new SqlConnection(connectionString);

                Connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnAuthSuccessful(string login)
        {
            CurrentLogin = login;
            panel.Controls.Add(new UC.Organizer.Organizer() { Name = "organizer" });
            panel
                .Controls["organizer"]
                .BringToFront();
            ClientSize = new Size(405, 205);
        }
    }
}
