using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter longitude:");
            double longitude = Convert.ToDouble(Console.ReadLine());

            var getDateTime = DateTime.UtcNow;

        }
    }

    class Place
    {
        public double MyLongitude { get; set; }
    }
}

