using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Week_01_lab_03_Date_W
{
    class Date //Defining the date components
    {
        private int year;
        private int month;
        private int day;

        public Date(int day = 1, int month = 1, int year = 2022) //Constructor for the components
        {
            this.day = day;
            this.month = month;
            this.year = year;
            Normalize();
        }
        //setter and getter for the components
        public int Year { get => year; set => year = value; }
        public int Month { get => month; set => month = value; }
        public int Day { get => day; set => day = value; }

        public override string ToString() //to format the date as string. Added MonthInText to replace numerical values to its string counterpart.
        {
            string MonthInText = MonthToText(month);
            return $"{day} {MonthInText} {year}";
        }

        public void Add(int days) //method to add days
        {
            day += days; //day = day + days
            Normalize();
        }

        public void Add(int days, int months) //method to add days and months
        {
            day += days; //day = day + days
            month += months; //month = month + months
            Normalize();
        }

        public void Add(Date other) //method to add days, months, and years which is packed into a single argument.
        {
            year += other.Year; //this.year + other.Year
            month += other.Month; //this.month + other.Month
            day += other.Day; //this.day + other.Day;
            Normalize();
        }


        private void Normalize() //this is to ensure the validity of the date
        {
            while (day > GetDaysInMonth(month, year)) //this will check if day is greater than the max number of days as defined in GetDaysInMonth
            {
                day -= GetDaysInMonth(month, year); //if day is greater, it will subtract the max days of the month to the inputted date, then the month will increase
                month++;
            }

            while (month > 12) //if month entered is more than 12, it will add a year
            {
                month -= 12;
                year++;
            }


        }
        //This is to set the words per specific month, ie. January for month 1, etc.
        private string MonthToText(int month)
        {
            switch (month)
            {
                case 1:
                    return "January";
                case 2:
                    return "February";
                case 3:
                    return "March";
                case 4:
                    return "April";
                case 5:
                    return "May";
                case 6:
                    return "June";
                case 7:
                    return "July";
                case 8:
                    return "August";
                case 9:
                    return "September";
                case 10:
                    return "October";
                case 11:
                    return "November";
                case 12:
                    return "December";
                default:
                    return "";
            }
        }
        //This is to determine if the month has 30 or 31 days (or 28/29 if it's a leap year)
        private int GetDaysInMonth(int month, int year)
        {
            switch (month)
            {
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
                case 2:
                    return ForLeapYear(year) ? 29 : 28;
                default:
                    return 31;
            }
        }
        //This is to determine whether a year is a leap year or not. As per google, A leap year is when a year is divisible by 4 but not by 100, and also if it is divisible by 400.
        private bool ForLeapYear(int year)
        {
            if (year % 4 == 0)
            {
                if (year % 100 != 0)
                {
                    return true; // Leap year
                }
                else
                {
                    if (year % 400 == 0)
                    {
                        return true; // Leap year
                    }
                }
            }

            return false; // Not a leap year
        }

    }
}
