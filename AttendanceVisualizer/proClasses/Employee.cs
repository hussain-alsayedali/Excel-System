using System;
using System.Collections.Generic;

namespace AttendanceVisualizer
{
    public class Employee
    {
        private int id;
        private RecordList recordList = new RecordList();
        public Employee(int idReaded , RecordList recordListReaded) {
            
            this.id = idReaded;
            this.recordList = recordListReaded;
        }
        public Employee(int idReaded)
        {
            this.id = idReaded;
        }
        public Employee()
        { 
        }

        public List<double> getDurations() {

            return recordList.getAllDifferences();
        }
        public List<double> getDurationsFromStart()
        {

            return recordList.getAllDiffererncesFromStart();
        }
        public int getId()
        {
            return id;
        }
        //public void addRecord(Record record) {
        //    recordList.addRecord(record);
        //}
        public void addRecordDateTime(DateTime date,DateTime timeIn , DateTime timeOut)
        {
            recordList.addRecordDateTime(date, timeIn, timeOut);
        }
        public List<string> getStatuses() {
            return recordList.getAllStatus();
        }
        public string toString() {

            return id + "\n" + recordList.toString();
        }
        public List<bool> getSameDays() {

            return recordList.sameDays();
        }
        public List<double> getNextDays()
        {

            return recordList.getTimeForNextDays();
        }
    }
}