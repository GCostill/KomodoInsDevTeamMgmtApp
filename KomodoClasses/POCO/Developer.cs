using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClasses.POCO
{
    public class Developer
    {
        //name, unique ID, bool Pluralsight
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DevID { get; set; }
        public bool Pluralsight { get; set; }

        public Developer() { }

        public Developer(string firstName, string lastName, int devID, bool pluralsight)
        {
            FirstName = firstName;
            LastName = lastName;
            DevID = devID;
            Pluralsight = pluralsight;
        }
    }
}
