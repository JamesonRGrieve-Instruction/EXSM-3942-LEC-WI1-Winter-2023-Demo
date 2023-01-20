namespace EXSM3942_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Student object reference stores only Students (not Person or other sub-types)
            Student student = new Student();
            student.FirstName = "Bob";
            student.LastName = "Smith";
            student.StudentID = 100001;

            // Employee object reference stores only Employees (not Person or other sub-types)
            Employee employee = new Employee();
            employee.FirstName = "John";
            employee.LastName = "Doe";
            employee.CompanyName = "Cool Company 9000";

            // Person object reference stores Person objects or any sub-type
            // As Person is abstract in this case, only its sub-types can be instantiated
            // A sub-type stored in a polymorphic reference such as this can only implicitly access the properties of that polymorphic type
            // In this case that is FirstName, LastName and FullName
            Person person = new Student()
            {
                // Since this code block is part of the instantiation / constructor, we can define the StudentID here.
                // The object is still a Student (in basic Person clothes, so to speak) - it retains that data even if it can't implicitly access it.
                StudentID = 2001
            };
            // Common properties of the polymorphic class can be assigned / accessed normally.
            person.FirstName = "Jane";
            person.LastName = "Doe";
            // We can check the actual type of the object stored in the polymorphic reference with GetType() and compare it to a class name with typeof().
            if (person.GetType() == typeof(Student))
            {
                // Once we have established the actual type of the object living in the polymorphic reference, we can cast it out to access properties and methods unique to that sub-type.
                // If you attempt to cast to the wrong sub-type, it will throw an invalid cast exception.
                Console.WriteLine(((Student)person).StudentID);
            }
            else if (person.GetType() == typeof(Employee))
            {
                Console.WriteLine(((Employee)person).CompanyName);
            }

            // Polymorphic lists allow us to store multiple polymorphic references.
            // They DO NOT have to be the same type (or even the same level of sub-type - a non abstract parent object can be stored alongside sub-type objects).
            List<Person> list = new List<Person>();
            list.Add(student);
            list.Add(employee);
            list.Add(person);
            // Iterating through the polymorphic list, you typically want to use the polymorphic type as your iterator.
            foreach (Person iPerson in list)
            {
                Console.WriteLine(iPerson.GetType());
                Console.WriteLine(iPerson.FullName);
                if (iPerson.GetType() == typeof(Student))
                {
                    Console.WriteLine(((Student)iPerson).StudentID);
                }
                else if (iPerson.GetType() == typeof(Employee))
                {
                    Console.WriteLine(((Employee)iPerson).CompanyName);
                }
            }


            
        }
    }
}