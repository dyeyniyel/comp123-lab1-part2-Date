using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week_01_lab_03_Date_W;

namespace Week_01_lab_03_Date_W
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Date Date1 = new Date(1, 1, 2022); //Initial date is set to January 1, 2022
            Console.WriteLine("Original Date: " + Date1.ToString());

            Date1.Add(30); //adding 30 days to check if it will count 31st of January
            Console.WriteLine("New date after adding 30 days: " + Date1.ToString());

            Date1.Add(29, 0); //adding 29 days to check if it will count leap year for Feb. It should not as 2022 is not a leap year
            Console.WriteLine("New date after adding 29 days and 0 months: " + Date1.ToString());

            Date Date2 = new Date(28, 11, 1); //adding 28 days, 11 months and 1 year and putting it on a single argument Date2. It should count leap year for Feb 2024
            Date1.Add(Date2);
            Console.WriteLine("After adding 28 days, 11 months, and 1 year: " + Date1.ToString());

            Console.ReadKey();
        }
    }
}
