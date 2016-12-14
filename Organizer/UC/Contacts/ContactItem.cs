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

namespace Organizer.UC.Contacts
{
    public partial class ContactItem : UserControl
    {
        private UserContact _userContact;

        public ContactItem()
        {
            InitializeComponent();
        }

        public ContactItem(UserContact userContact)
        {
            InitializeComponent();
            _userContact = userContact;
            tslContactName.Text = userContact.Login;
        }

        private void ContactItem_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Top;
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            OrganizerForm mainForm = Application.OpenForms["OrganizerForm"] as OrganizerForm;
            Parent.Controls.Remove(this);

            SqlCommand deleteContact = new SqlCommand(
                string.Format("DELETE FROM Contacts " +
                              "WHERE owner = '{0}' " +
                              "AND contact = '{1}'",
                              mainForm.CurrentLogin,
                              _userContact.Login),
                mainForm.Connection
            );

            try
            {
                deleteContact.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            
            Dispose();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //Отображение инфы о контакте
        }

        private void tslContactName_Click(object sender, EventArgs e)
        {

        }
    }
}
