using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXSM3942_Demo
{
    // Create a class called Person with a first name, middle name, last name, birth date and gender property. Derive a full name property from the first name, last name and middle initial. Derive an age property from the birth date. Fully implement the birth date property to ensure the date is in the past. Implement a ToString() method that will describe the person in an English sentence. Implement an Introduction() method that will introduce the person by the first name as an English sentence. Implement a greedy, partial and default constructor.


    // Create a class called Person
    internal class Person
    {
        // Implement a greedy, partial and default constructor.
        public Person()
        {
            FirstName = "John";
            MiddleName = "Anonymous";
            LastName = "Doe";
            BirthDate = new DateOnly(2000, 01, 01);
            Gender = "Male";
        }
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            MiddleName = "Anonymous";
            LastName = lastName;
            BirthDate = new DateOnly(2000, 01, 01);
            Gender = "Male";
        }
        public Person(string firstName, string middleName, string lastName, DateOnly birthDate, string gender)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            BirthDate = birthDate;
            Gender = gender;
        }
        // Copying an object:
        // "new" keyword usage in Main().
        public Person(Person toClone)
        {
            FirstName = toClone.FirstName;
            MiddleName = toClone.MiddleName;
            LastName = toClone.LastName;
            BirthDate = toClone.BirthDate;
            Gender = toClone.Gender;
        }

        // with a first name, middle name, last name, birth date and gender property
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        // Fully implement the birth date property to ensure the date is in the past.
        private DateOnly _birthDate;
        public DateOnly BirthDate {
            get => _birthDate;
            set {
                if (value.ToDateTime(new TimeOnly(0)) > DateTime.Now)
                {
                    throw new Exception("The birthdate must be in the past.");
                }
                // If it throws the exception we break control flow here so we don't need an else.
                _birthDate = value;
            }
        }
        public string Gender { get; set; }

        // Derive a full name property from the first name, last name and middle initial.
        /*
        public string FullName
        {
            get
            {
                return $"{FirstName} {MiddleName[0]}. {LastName}";
            }
        }
        */
        public string FullName => $"{FirstName} {MiddleName[0]}. {LastName}";

        // Derive an age property from the birth date.
        public int Age
        {
            get
            {
                // Subtract their birthdate at midnight from the current date and time, and divide the number of days by 365.
                return DateTime.Now.Subtract(BirthDate.ToDateTime(new TimeOnly(0))).Days / 365;
            }
        }

        // Implement a ToString() method that will describe the person in an English sentence.
        public override string ToString() => $"A {Age} year old person of the {Gender} gender named {FullName}.";

        // Implement an Introduction() method that will introduce the person by the first name as an English sentence.
        public string Introduction() => $"Hello, my name is {FirstName}!";

        // Copying an object:
        // "new" keyword usage in the class.
        public Person Clone() => new Person(FirstName, MiddleName, LastName, BirthDate, Gender);
    }
}
