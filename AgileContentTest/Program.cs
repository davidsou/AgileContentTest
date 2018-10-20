using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileContentTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int number = Convert.ToInt32(input);

            int output = DecReprSenior.GetLagestSibiling(number);

            string result = $"The highest sibiling of {input} is {output}";

            Console.WriteLine(result);
            Console.ReadKey();
            
        }
    }
}
