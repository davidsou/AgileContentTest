using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileContentTest
{
    public static class DecReprSenior
    {
        private const int MAXVALUE = 1000000000;
        public static int GetLagestSibiling(int input)
        {        

            List<int> inputarray = GetIntArray(input);
            int result = int.Parse(String.Join("", inputarray.ToArray()));

            return Validate(result);
        }

        private static List<int> GetIntArray(int number)
        {
            List<int> result = new List<int>();
            char[] aux = number.ToString().ToCharArray();

            foreach (var item in aux)
            {
                result.Add(Convert.ToInt32(item.ToString()));
            }
            

            result.Sort();
            result.Reverse();
            return result;

        }
        private static int Validate(int input)
        {

            return input <= MAXVALUE ? input:-1;

        }
    }
}
