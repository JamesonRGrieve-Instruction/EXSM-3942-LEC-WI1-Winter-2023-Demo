namespace EXSM3942_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Rectangle myRect = new Rectangle(GetInput("Please enter the length of the Rectangle: "), GetInput("Please enter the width of the Rectangle: "));
            Triangle myTri = new Triangle(GetInput("Please enter the base of the Triangle: "), GetInput("Please enter the height of the Triangle: "));
            Circle myCircle = new Circle(GetInput("Please enter the radius of the Circle: "));

            Console.WriteLine($"The rectangle has dimensions of {myRect.Length}x{myRect.Width}. It has an area of {myRect.Area} and a perimeter of {myRect.Perimeter}. It {(myRect.IsSquare ? "is" : "is not")} a square.");
            Console.WriteLine($"The triangle has dimensions of {myTri.Base}x{myTri.Height}. It has an area of {myTri.Area}.");
            Console.WriteLine($"The circle has a radius of {myCircle.Radius}. It has a diameter of {myCircle.Diameter}, an area of {myCircle.Area} and a circumference of {myCircle.Circumference}.");

            Rectangle squareBoundingRect = myRect.ContainWithSquare();
            Console.WriteLine($"The square bounding the rectangle has dimensions of {squareBoundingRect.Length}x{squareBoundingRect.Width}. It has an area of {squareBoundingRect.Area} and a perimeter of {squareBoundingRect.Perimeter}. It {(squareBoundingRect.IsSquare ? "is" : "is not")} a square.");
            Rectangle rectBoundingTriangle = myTri.ContainWithRectangle();
            Console.WriteLine($"The rectangle bounding the triangle has dimensions of {rectBoundingTriangle.Length}x{rectBoundingTriangle.Width}. It has an area of {rectBoundingTriangle.Area} and a perimeter of {rectBoundingTriangle.Perimeter}. It {(rectBoundingTriangle.IsSquare ? "is" : "is not")} a square.");

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