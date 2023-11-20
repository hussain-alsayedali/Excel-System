using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceVisualizer.proClasses
{
    public class Formater
    {
        public Formater() { }
        public static  DateTime stringToDate(string readedString) {
            String[] spearator = { "/" };
            Int32 count = 3;
            string[] time = readedString.Split(spearator, count,
               StringSplitOptions.RemoveEmptyEntries);

             

            int year = int.Parse(time[2].ToString());
            int month = int.Parse(time[1].ToString());
            int day = int.Parse(time[0].ToString());
 
            return new DateTime(year, month, day,0,0,0);
        }
        public static DateTime stringToDateTime(string readedString, DateTime readedDate)
        {
            if (readedString.Contains("-"))
            {
                DateTime errorDate = new DateTime(1980, 8, 8, 8, 8, 8);
                return errorDate;
            }
            else {
                // Trace.WriteLine(readedString);
                if (readedString.Contains("(+1)"))
                {
                    //Trace.WriteLine(readedDate.ToString());
                    readedDate = readedDate.AddDays(1);
                    //Trace.WriteLine(readedDate.ToString());

                    readedString = readedString.Replace("(+1)", "");
                };
                String[] spearator = { ":" };
                Int32 count = 3;
                string[] time = readedString.Split(spearator, count,
                   StringSplitOptions.RemoveEmptyEntries);

                //for (int i = 0; i < time.Length; i++)
                //{
                //    Trace.WriteLine(time[i]);
                //}
                
                int hours = int.Parse(time[0].ToString());
                int minutes = int.Parse(time[1].ToString());
                int seconds = int.Parse(time[2].ToString());
                //Trace.WriteLine("hours" + hours + "minutes: " + minutes + "seconds " + seconds);

                return new DateTime(readedDate.Year, readedDate.Month, readedDate.Day, hours, minutes, seconds);
            }
        }
        public static List<DateTime> rowToRecData(List<string> readedRow)
        {
            string dateReaded = readedRow[1];
            string timeInReaded = readedRow[2];
            string timeOutReaded = readedRow[3];

            DateTime dateFormated = stringToDate(dateReaded);
            DateTime timeInFormated = stringToDateTime(timeInReaded, dateFormated);
            DateTime timeOutFormated = stringToDateTime(timeOutReaded, dateFormated);
            List<DateTime> results = new List<DateTime>();

            results.Add(dateFormated);
            results.Add(timeInFormated);
            results.Add(timeOutFormated);
            return results;
        }
        public static int stringToInt(string num) {
            return Convert.ToInt32(num);
        }
    }
}
