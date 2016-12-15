using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace Organizer
{
    public partial class ContactsForm : Form
    {
        public ContactsForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OrganizerForm mainForm = Application.OpenForms["OrganizerForm"] as OrganizerForm;

            string newContactName = tbNewContact.Text;
            SqlCommand getContact = new SqlCommand(
                            string.Format("SELECT * FROM dbo.Users " +
                                            "WHERE login = '{0}'",
                                            newContactName),
                            mainForm.Connection
            );

            SqlDataReader reader = null;
            try
            {
                reader = getContact.ExecuteReader();

                if (reader.HasRows)
                {
                    SqlCommand insertContact = new SqlCommand(
                        string.Format("INSERT INTO dbo.Contacts VALUES " +
                                      "('{0}', '{1}');", mainForm.CurrentLogin, newContactName),
                        mainForm.Connection
                    );

                    reader.Close();
                    insertContact.ExecuteNonQuery();
                    updateContactList();
                }
                else
                {
                    MessageBox.Show("Пользователя с таким логином не существует.", "",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button1);
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

        private void ContactsForm_Load(object sender, EventArgs e)
        {
            updateContactList();
        }

        private void updateContactList()
        {
            OrganizerForm mainForm = Application.OpenForms["OrganizerForm"] as OrganizerForm;
            SqlCommand getContacts;
            string newContactName = tbNewContact.Text;

            getContacts = new SqlCommand(
                            string.Format("SELECT * FROM Users_info " +
                                            "JOIN Contacts " +
                                            "ON login = contact " +
                                            "WHERE owner = '{0}'",
                                            mainForm.CurrentLogin),
                            mainForm.Connection
            );

            foreach (UC.Contacts.ContactItem contactItem in pnlContactList.Controls)
            {
                contactItem.Dispose();
            }
            pnlContactList.Controls.Clear();

            SqlDataReader reader = null;
            try
            {
                reader = getContacts.ExecuteReader();

                if (reader.HasRows)
                {
                    UserContact userContact;

                    while (reader.Read())
                    {
                        userContact = new UserContact(
                            reader["login"],
                            reader["name"],
                            reader["surname"],
                            reader["phone"],
                            reader["city"],
                            reader["street"],
                            reader["home"],
                            reader["email"]
                        );

                        pnlContactList.Controls.Add(
                            new UC.Contacts.ContactItem(userContact)
                        );
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Пользователь с таким логином уже добавлен.", "",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button1);
                return;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
    }
}
