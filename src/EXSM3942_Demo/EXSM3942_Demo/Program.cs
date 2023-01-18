namespace EXSM3942_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Abstract classes cannot be instantiated, but their derived non-abstract classes can be.
            Student student = new Student();
            student.FirstName = "John";
            student.LastName = "Smith";
            Console.WriteLine(student.FullName);
        }
    }
}