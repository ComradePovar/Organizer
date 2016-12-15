using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Organizer
{
    public partial class ProfileForm : Form
    {
        private UserContact _user;
        public delegate void UserInfoChangedHandler(UserContact userInfo);
        public event UserInfoChangedHandler UserInfoChanged;
        private bool _canBeSaved;

        public ProfileForm()
        {
            InitializeComponent();
            _canBeSaved = true;
        }

        public ProfileForm(UserContact userInfo)
        {
            InitializeComponent();
            _user = userInfo;

            tbName.Text = userInfo.Name;
            tbSurname.Text = userInfo.Surname;
            mtbPhone.Text = userInfo.Phone;
            tbCity.Text = userInfo.City;
            tbStreet.Text = userInfo.Street;
            tbHome.Text = userInfo.Home;
            tbEmail.Text = userInfo.Email;
            _canBeSaved = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_canBeSaved)
            {
                MessageBox.Show("Неверно введен номер телефона.", "",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button1);
                return;
            }
            _user.Name = tbName.Text;
            _user.Surname = tbSurname.Text;
            _user.Phone = mtbPhone.Text;
            _user.City = tbCity.Text;
            _user.Street = tbStreet.Text;
            _user.Home = tbHome.Text;
            _user.Email = tbEmail.Text;
            UserInfoChanged(_user);

            SqlCommand saveUserInfo = new SqlCommand(
                string.Format("UPDATE Users_info " +
                              "SET name = '{0}', " +
                              "surname = '{1}', " +
                              "phone = '{2}', " +
                              "city = '{3}', " +
                              "street = '{4}', " +
                              "home = '{5}', " +
                              "email = '{6}'",
                              _user.Name,
                              _user.Surname,
                              _user.Phone,
                              _user.City,
                              _user.Street,
                              _user.Home,
                              _user.Email),
                (Application.OpenForms["OrganizerForm"] as OrganizerForm).Connection
            );

            try
            {
                saveUserInfo.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            Close();
        }

        private void mtbPhone_Leave(object sender, EventArgs e)
        {
            if (mtbPhone.Text.Contains(" "))
            {
                _canBeSaved = false;
            }
            else
            {
                _canBeSaved = true;
            }
        }
    }
}
