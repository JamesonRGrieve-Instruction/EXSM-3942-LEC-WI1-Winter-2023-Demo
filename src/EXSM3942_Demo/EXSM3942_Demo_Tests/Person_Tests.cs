using EXSM3942_Demo;
namespace EXSM3942_Demo_Tests
{
    public class Person_Tests
    {
        [Theory,
            InlineData("Joe", "Arnold", "Smith", "Joe A. Smith"),
            InlineData("Bob", "Milton", "Coolguy", "Bob M. Coolguy")]
        public void FullName_Test(string firstName, string middleName, string lastName, string fullName)
        {
            Person myPerson = new Person(firstName, middleName, lastName, new DateOnly(2005, 05, 05), "");

            Assert.Equal(fullName, myPerson.FullName);
        }

        [Theory,
            InlineData("Joe", $"Hello, my name is Joe!")]
        public void Introduction_Test(string firstName, string result)
        {
            Person myPerson = new Person();
            myPerson.FirstName = firstName;

            Assert.Equal(result, myPerson.Introduction());
        }
    }
}