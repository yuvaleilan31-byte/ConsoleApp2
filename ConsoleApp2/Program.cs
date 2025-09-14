using System.Threading.Channels;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 2 numbers:");
            string var = Console.ReadLine();
            int mone = int.Parse(var);
            string var2 = Console.ReadLine();
            int mehane = int.Parse(var2);

            fraction frank = new fraction(mone, mehane);

            Console.WriteLine(frank.Calculate().ToString());            
            Console.WriteLine(frank.Div());



        }
    }
}
