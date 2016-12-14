using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizer
{
    public class UserContact
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Home { get; set; }
        public string Email { get; set; }

        public UserContact() { }
        public UserContact(object login, object name, object surname, object phone,
                           object city, object street, object home, object email)
        {
            if (login != null)
                Login = login.ToString();
            if (name != null)
                Name = name.ToString();
            if (surname != null)
                Surname = surname.ToString();
            if (phone != null)
                Phone = phone.ToString();
            if (city != null)
                City = city.ToString();
            if (street != null)
                Street = street.ToString();
            if (home != null)
                Home = home.ToString();
            if (Email != null)
                Email = email.ToString();
        }

        public void Init(object login, object name, object surname, object phone,
                           object city, object street, object home, object email)
        {
            if (login != null)
                Login = login.ToString();
            if (name != null)
                Name = name.ToString();
            if (surname != null)
                Surname = surname.ToString();
            if (phone != null)
                Phone = phone.ToString();
            if (city != null)
                City = city.ToString();
            if (street != null)
                Street = street.ToString();
            if (home != null)
                Home = home.ToString();
            if (Email != null)
                Email = email.ToString();
        }
    }
}
