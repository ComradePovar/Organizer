using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Organizer.UC.Contacts
{
    public partial class ContactItem : UserControl
    {
        public ContactItem()
        {
            InitializeComponent();
        }

        private void ContactItem_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Top;
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            //Удаление контакта из БД
            Dispose();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //Отображение инфы о контакте
        }
    }
}
