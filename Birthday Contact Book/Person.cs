using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthday_Contact_Book
{
    public class Person
    {
        //variable for the people
        public string _name;
        public string _email;
        public string _address;
        public DateTime _birthday;
        public string _notes;

        public string Name
        {
            get { return _name; }
        }

        private bool _privateExample;

        public Person()
        {
            Initialize();
        }
    

        public void Initialize()
        {
            _privateExample = false;
            _name = "New Person";
            _birthday = DateTime.Today;
        }
       
            
    }
}
