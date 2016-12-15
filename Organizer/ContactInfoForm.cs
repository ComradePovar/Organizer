using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Organizer
{
    public partial class ContactInfoForm : Form
    {
        public ContactInfoForm()
        {
            InitializeComponent();
        }

        public ContactInfoForm(UserContact contact)
        {
            InitializeComponent();

            tbName.Text = contact.Name;
            tbSurname.Text = contact.Surname;
            if (contact.Phone.Contains(" "))
            {
                mtbPhone.Mask = "";
            }
            else
            {
                mtbPhone.Text = contact.Phone;
            }
            tbCity.Text = contact.City;
            tbStreet.Text = contact.Street;
            tbHome.Text = contact.Home;
            tbEmail.Text = contact.Email;
        }
    }
}
