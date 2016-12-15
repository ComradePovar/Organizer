using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizer
{
    public class UserEvent
    {
        public int EventID { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Home { get; set; }
        public string EventDate { get; set; }
        public string EventTime { get; set; }
        public bool isViewed = false;

        public UserEvent() { }
        public UserEvent(object id, object descr, object city, object street,
                         object home, object date, object time)
        {
            if (id != null)
                EventID = int.Parse(id.ToString());
            if (descr != null)
                Description = descr.ToString();
            if (city != null)
                City = city.ToString();
            if (street != null)
                Street = street.ToString();
            if (home != null)
                Home = home.ToString();
            if (date != null)
                EventDate = date.ToString();
            if (time != null)
                EventTime = time.ToString();
        }

        public void Init(object id, object descr, object city, object street,
                         object home, object date, object time)
        {
            if (id != null)
                EventID = int.Parse(id.ToString());
            if (descr != null)
                Description = descr.ToString();
            if (city != null)
                City = city.ToString();
            if (street != null)
                Street = street.ToString();
            if (home != null)
                Home = home.ToString();
            if (date != null)
                EventDate = date.ToString();
            if (time != null)
                EventTime = time.ToString();
        }
    }
}
