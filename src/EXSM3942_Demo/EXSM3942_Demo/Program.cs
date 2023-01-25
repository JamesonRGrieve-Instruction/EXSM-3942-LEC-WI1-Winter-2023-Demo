namespace EXSM3942_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            List<Shape> shapes = new List<Shape>();
            string userChoice = "";
            do
            {
                Console.WriteLine("Create A\n1) Rectangle\n2) Triangle\n3) Circle\n4) Exit");
                Console.Write("\tChoice: ");
                userChoice = Console.ReadLine().Trim();
                switch (userChoice)
                {
                    case "1":
                        shapes.Add(new Rectangle(GetInput("Please enter the length of the Rectangle: "), GetInput("Please enter the width of the Rectangle: ")));
                        break;
                    case "2":
                        shapes.Add(new Triangle(GetInput("Please enter the base of the Triangle: "), GetInput("Please enter the height of the Triangle: ")));
                        break;
                    case "3":
                        shapes.Add(new Circle(GetInput("Please enter the radius of the Circle: ")));
                        break;
                    case "4":
                        break;
                    default:
                        Console.WriteLine("Invalid entry, please try again.");
                        break;
                }
                Console.WriteLine($"Total Area: {shapes.Select(x=>x.Area).Sum()}\nTotal Perimeter: {shapes.Select(x => x.Perimeter).Sum()}\nTotal Square Area: {shapes.Select(x => x.Contain().Area).Sum()}");
            } while (userChoice != "4");
           
        }
        static double GetInput(string prompt)
        {
            double toReturn;
            do
            {
                Console.Write(prompt);
            } while (!double.TryParse(Console.ReadLine(), out toReturn));
            return toReturn;
        }
    }
}