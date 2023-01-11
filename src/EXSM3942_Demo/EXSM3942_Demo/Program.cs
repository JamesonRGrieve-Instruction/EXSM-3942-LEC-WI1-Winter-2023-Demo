namespace EXSM3942_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person thePerson = new Person();
            Person secondPerson = new Person("Jane", "Anonymous", "Doe", new DateOnly(1990, 06, 06), "Female");

            Person thirdPerson = new Person(thePerson);
            Person fourthPerson = thePerson.Clone();

            Console.WriteLine("Before Modification");
            Console.WriteLine(thePerson);
            Console.WriteLine(secondPerson);
            Console.WriteLine(thirdPerson);
            Console.WriteLine(fourthPerson);

            thePerson.FirstName = "Potato";

            Console.WriteLine("After Modification");
            Console.WriteLine(thePerson);
            Console.WriteLine(secondPerson);
            Console.WriteLine(thirdPerson);
            Console.WriteLine(fourthPerson);
        }
    }
}