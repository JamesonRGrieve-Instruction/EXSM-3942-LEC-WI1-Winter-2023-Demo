using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXSM3942_Demo
{
    // Tagging the class as abstract also limits what you can do with the class.
    internal abstract class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";

        public int Age { get; set; }

        // Abstract means we can say "All inherited classes must implement this, but I'm not implementing it here."
        public abstract string GoToWork();
    }
}
