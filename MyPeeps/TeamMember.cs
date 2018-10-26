using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPeeps
{
    class TeamMember : Person
    {

        public int Salary { get; set; }
        public string Address { get; set; }

        public TeamMember(string firstName, string lastName, int age, string emailAddress, int salary, string address) : base(firstName, lastName, age, emailAddress)
        {
            Salary = salary;
            Address = address;
        }



    }
}
