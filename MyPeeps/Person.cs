using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPeeps
{
    class Person
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public bool IsAnAdult { get; private set; }
        private int AgeCheck;

        //built the boolean 'adult' method into my get/set
        public int Age
        {
            get { return AgeCheck; }
            set
            {

                if (value >= 18)
                {
                    IsAnAdult = true;
                }
                else
                {
                    IsAnAdult = false;
                }
            }
        }

        public Person(string firstName, string lastName, int age, string emailAddress)
        {
            FirstName = firstName;
            LastName = lastName;
            AgeCheck = age;
            EmailAddress = emailAddress;

        }
    }
}
