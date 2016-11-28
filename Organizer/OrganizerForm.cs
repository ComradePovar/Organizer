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

        public OrganizerForm()
        {
            InitializeComponent();

        
            panel.Controls.Add(new UC.Authorization.LogIn() { Name = "login" });
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
    }
}
