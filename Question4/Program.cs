using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question4
{
    class Program
    {
        public static List<int> Number = new List<int>();
        public static List<int> pmNumber = new List<int>();
        static void Main(string[] args)
        {
            Console.WriteLine("Enter hexadecimal");
            int res = Int32.Parse(Console.ReadLine());
            Number.Add(res);

            CheckifPrime(res);
        }

        public static void CheckifPrime(int num) //CheckIfPrime
        {
            int i;

            for (i = 2; i <= num - 1; i++)
            {
                if (num % i == 0)
                {
                    //not a PM
                    return;
                }
            }
            if (i == num)
            {
                //is a PM 
                int x = num;
                SaveDisplay(x);
                Console.WriteLine("This is a PM number:" + x);

            }
            return;
        }
        public static void SaveDisplay(int num)
        {
            pmNumber.Add(num);
            foreach(int i in pmNumber)
            {
                Console.WriteLine(i);
            }

        }
    }

}
