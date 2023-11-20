using System;
using System.Collections.Generic;

namespace AttendanceVisualizer
{
    public class RecordList
    {
        private List<Record> records = new List<Record>();
        public RecordList(List<Record> readedRecords) 
        {
            records = readedRecords;
        }
        public RecordList(Record readedRecord)
        {
            records.Add(readedRecord);
        }
        public RecordList()
        {
        } 
        //public void addRecord(Record record)
        //{
        //    records.Add(record);
        //}
        public void addRecordDateTime(DateTime date, DateTime timeIn, DateTime timeOut) {
            records.Add(new Record(date, timeIn, timeOut));
        }
        public List<double> getAllDifferences() {
            List<double> differnces = new List<double>();
            for(int i = 0 ; i < records.Count; i++)
            {
                differnces.Add(records[i].getTimeDifference());
            }
            return differnces;
        }
        public List<double> getAllDiffererncesFromStart()
        {
            List<double> differnces = new List<double>();
            for (int i = 0; i < records.Count; i++)
            {
                differnces.Add(records[i].getTimeFromStart());
            }
            return differnces;
        }
        public List<string> getAllStatus() { 
            List<string> statuses = new List<string>();
            for (int i = 0; i < records.Count; i++) {
                statuses.Add(records[i].getStatus());
            }
            return statuses;
        }
        public double getDifferencebyIndex(int index) {
            return records[index].getTimeDifference();
        }
        public double getDifferenceFromStartbyIndex(int index)
        {
            return records[index].getTimeFromStart();
        }
        public string getStatusByIndex(int index)
        {
            return records[index].getStatus();
        }

        public string toString() {
            string formatedAllRecords = "";
            for(int i = 0 ; i < records.Count; i++)
            {
                formatedAllRecords  += records[i].toString();
            }
            return formatedAllRecords;
        }
        public List<bool> sameDays() {
            List<bool> sameDays = new List<bool>();
            for (int i = 0; i < records.Count; i++)
            {
                sameDays.Add(records[i].isSameDay());
            }
            return sameDays;
        }
        public List<double> getTimeForNextDays() {
            List<double> nextDays = new List<double>();
            for (int i = 0; i < records.Count; i++)
            {
                nextDays.Add(records[i].getTimeFromEndNextDay());
            }
            return nextDays;
        }
    }
}