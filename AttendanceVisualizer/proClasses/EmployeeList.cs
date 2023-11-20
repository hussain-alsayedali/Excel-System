using AttendanceVisualizer.proClasses;
using System;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;
namespace AttendanceVisualizer
{
    public  class EmployeeList
    {
        private List<Employee> employeesList = new List<Employee>();
        public EmployeeList(List<Employee> employeesList) { 
        
            this.employeesList = employeesList;
        }
        public EmployeeList(Employee employee)
        {
            employeesList.Add(employee);
        }
        public EmployeeList()
        {
            AddEmployeesFromExcels();
        }

        private void AddEmployeesFromExcels()
        {
            int numberOfRows = Reader.getNumberOfRows();
            //Formater formater = new Formater();
            for (int i = 2; i < numberOfRows; i++) {
                List<string> rowReaded = Reader.readLine(i);

                int idFormated = Formater.stringToInt(rowReaded[0]);

                List<DateTime> rowFormated = Formater.rowToRecData(rowReaded);
                DateTime dateFormated = rowFormated[0];
                DateTime timeInFormated = rowFormated[1];
                DateTime timeOutFormated = rowFormated[2];
                Employee currentEmpReaded;
                if (employeesList.Count == 0 || idFormated != employeesList[employeesList.Count - 1].getId())
                {
                    currentEmpReaded = new Employee(idFormated);
                    employeesList.Add(currentEmpReaded);
                }
                else {
                    currentEmpReaded = employeesList[employeesList.Count - 1];
                }
                currentEmpReaded.addRecordDateTime(dateFormated, timeInFormated, timeOutFormated);
                
            }
        }
        public List<double> getDurationsOfEmpByIndex(int index)
        {
            return employeesList[index].getDurations();
        }
        public List<double> getDurationFromStartByIndex(int index)
        {
            return employeesList[index].getDurationsFromStart();
        }
        public List<double> getNextDaysFromEmpByIndex(int index)
        {
            return employeesList[index].getNextDays();
        }


        public List<string> GetStatusesOfEmpByIndex(int index) {
            return employeesList[index].getStatuses();
        }
        public List<bool> getSameDaysEmpByIndex(int index)
        {
            return employeesList[index].getSameDays();
        }
        public List<int> getEmployeesIds() {
            List<int> ids = new List<int>();
            for (int i = 0; i < employeesList.Count; i++) {
                ids.Add(employeesList[i].getId());
            }
            return ids;
        }
        public string toString() {
            string formatedString = "";
            for(int i = 0; i < employeesList.Count ; i++)
            {
                formatedString += employeesList[i].toString();

            }
            return formatedString;
        }
    }
}