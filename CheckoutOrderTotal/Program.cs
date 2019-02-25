using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutOrderTotal
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in Products.Create())
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadKey();
        }
    }

    public class Test
    {
        public string TestString()
        {
            return "1";
        }
    }
}
