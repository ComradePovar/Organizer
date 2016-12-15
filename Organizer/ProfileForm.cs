﻿using System;
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
        private string _phonePattern = @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$";
        public delegate void UserInfoChangedHandler(UserContact userInfo);
        public event UserInfoChangedHandler UserInfoChanged;

        public ProfileForm()
        {
            InitializeComponent();
        }

        public ProfileForm(UserContact userInfo)
        {
            InitializeComponent();
            _user = userInfo;

            tbName.Text = userInfo.Name;
            tbSurname.Text = userInfo.Surname;
            tbPhone.Text = userInfo.Phone;
            tbCity.Text = userInfo.City;
            tbStreet.Text = userInfo.Street;
            tbHome.Text = userInfo.Home;
            tbEmail.Text = userInfo.Email;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _user.Name = tbName.Text;
            _user.Surname = tbSurname.Text;
            _user.Phone = tbPhone.Text;
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

        private void tbPhone_Leave(object sender, EventArgs e)
        {
            Regex regex = new Regex(_phonePattern);

            if (!regex.IsMatch(tbPhone.Text))
                MessageBox.Show("Неверно введен номер телефона.");
        }
    }
}
