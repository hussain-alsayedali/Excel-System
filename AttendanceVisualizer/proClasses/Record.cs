using System;
using System.Diagnostics;

namespace AttendanceVisualizer
{
    public class Record
    {
        private DateTime date;
        private DateTime timeIn;
        private DateTime timeOut;
        public Record(DateTime dateReaded,DateTime timeInReaded , DateTime timeOutReaded) { 
            this.date = dateReaded;
            this.timeIn = timeInReaded;
            this.timeOut = timeOutReaded;
        }
        public double getTimeDifference() {
            if (absentOrError().Equals("Absent") || absentOrError().Equals("Data error")) {
                return 0;
            }
            TimeSpan diff = (timeOut - timeIn).Duration();
            //Trace.WriteLine( "diff in minutes : "+diff + "total mins =" + diff.TotalMinutes);
            return diff.TotalMinutes;
        }
        public double getTimeFromStart() {
            TimeSpan diff = (timeIn - date).Duration();
            //Trace.WriteLine( "diff in minutes : "+diff + "total mins =" + diff.TotalMinutes);
            return diff.TotalMinutes;
        }
        public double getTimeFromEndNextDay()
        {
            //Trace.WriteLine(date.Day + ":" + timeOut.Day);
            if (date.Day == timeOut.Day){
                
                return 0;
            }

            DateTime nextDay = DateTime.Now;
            nextDay = date;
            nextDay = nextDay.AddDays(1);
            TimeSpan diff = (timeOut - nextDay).Duration();
            //Trace.WriteLine( "diff in minutes : "+diff + "total mins =" + diff.TotalMinutes);
            return diff.TotalMinutes;
        }
        public string getStatus() {
            if (timeIn.Equals(new DateTime(1980, 8, 8, 8, 8, 8)) && timeOut.Equals(new DateTime(1980, 8, 8, 8, 8, 8)))
            {
                return "Absent";
            }
            else if (timeIn.Day != date.Day || timeIn.Equals(new DateTime(1980, 8, 8, 8, 8, 8)) || timeOut.Equals(new DateTime(1980, 8, 8, 8, 8, 8))) {
                return "Data error";
            } 
            double duration = getTimeDifference();

            if (duration >= 480)
            {
                return "present";
            }
            else
            {
                return "insuffecient";
            }
        }
        public string toString() {
            string formatedRecord = date.ToString() + " " + timeIn.ToString() + " " + timeOut.ToString() + " diff : " + getTimeDifference() +"  " + getStatus() + "\n";
            return formatedRecord;
        }
        private string absentOrError() {
            if (timeIn.Equals(new DateTime(1980, 8, 8, 8, 8, 8)) && timeOut.Equals(new DateTime(1980, 8, 8, 8, 8, 8)))
            {
                return "Absent";
            }
            else if (timeIn.Day != date.Day || timeIn.Equals(new DateTime(1980, 8, 8, 8, 8, 8)) || timeOut.Equals(new DateTime(1980, 8, 8, 8, 8, 8)))
            {
                return "Data error";
            }
            else return "no";
        }
        public bool isSameDay() {
            if (timeIn.Day == timeOut.Day) {
                return true;
            }
            return false;
        }
    }
}