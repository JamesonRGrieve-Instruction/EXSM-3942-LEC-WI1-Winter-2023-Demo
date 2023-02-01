namespace EXSM3942_Demo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            int firstNum, secondNum;
            string ip;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    ip = await client.GetStringAsync("https://api.ipify.org");
                }
            } 
            catch (Exception e)
            {
                ip = "unknown IP address";
            }
           
            Console.WriteLine($"Hello, {Environment.UserName} of {Environment.MachineName} at {ip}!");
            try
            {
                Console.Write("Please enter a number: ");
                firstNum = int.Parse(Console.ReadLine());
                Console.Write("Please enter a second number: ");
                secondNum = int.Parse(Console.ReadLine());
                RecursiveCount(Math.Min(firstNum, secondNum), Math.Max(firstNum, secondNum));
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid Input: "+e.Message);
            }
        }
        static void RecursiveCount(int current, int end)
        {
            Console.WriteLine(current);
            if (current < end) RecursiveCount(current + 1, end);
        }
    }
}