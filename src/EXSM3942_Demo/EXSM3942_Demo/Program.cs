namespace EXSM3942_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Please select your utensil.\n1) Pen\n2) Pencil\n\tChoose: ");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    Pen pen = new Pen("Bic", "Black");
                    string userEntry = "";
                    do
                    {
                        Console.Write("Enter a number of letters to write, or 'exit' to quit: ");
                        userEntry = Console.ReadLine();
                        if (userEntry != "exit")
                        {
                            try
                            {
                                pen.Write(int.Parse(userEntry));
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            Console.WriteLine($"Pen has {pen.InkLevel}% ink remaining.");
                        }
                    } while (userEntry != "exit");
                }
                else if (choice == 2)
                {
                    Pencil pencil = new Pencil("Dixon");
                    string userEntry = "";
                    do
                    {
                        Console.Write("Enter a number of letters to write, or 'exit' to quit: ");
                        userEntry = Console.ReadLine();
                        if (userEntry != "exit")
                        {
                            try
                            {
                                pencil.Write(int.Parse(userEntry));
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            Console.WriteLine($"Pencil has {pencil.Length}% length remaining.");
                        }
                    } while (userEntry != "exit");
                }
                else
                {
                    Console.WriteLine("Invalid entry. Ending program.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error, Aborting Program");
                Console.WriteLine(e.Message);
            }
        }
    }
}