using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXSM3942_Demo
{
    // Student inherits from Person.
    internal class Student : Person
    {
        new public string FullName => $"{FirstName} {LastName[0]}.";

        public override string GoToWork()
        {
            return "I'm going to class now.";
        }
    }
}
