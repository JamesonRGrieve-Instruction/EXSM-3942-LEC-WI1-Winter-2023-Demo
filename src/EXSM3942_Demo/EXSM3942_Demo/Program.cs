namespace EXSM3942_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pen myPen = new Pen("Bic", "Black", 55.2m);
            try
            {
                myPen.Write(100);
                myPen.Write(42);
                myPen.Write(200);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine(myPen.SummarizeInkLevel());
        }
    }
}