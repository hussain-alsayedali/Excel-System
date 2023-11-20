using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using  Excel = Microsoft.Office.Interop.Excel;
using static AttendanceVisualizer.Record;
using AttendanceVisualizer.proClasses;
using System.Reflection;
using Microsoft.Office.Interop.Excel;
using Point = System.Drawing.Point;
using ScrollBars = System.Windows.Forms.ScrollBars;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AttendanceVisualizer
{
    public partial class AttendanceVisulizerForm : Form
    {
        
        public AttendanceVisulizerForm()
        {

            InitializeComponent();

            //EmployeeList employees = new EmployeeList();
            //Graphics g = TimeLineDrawingPanel.CreateGraphics();


            //addIds(g, employees.getEmployeesIds());

            //SheetContents_ListBox.Items.Clear();
            //SheetContents_ListBox.Click += new EventHandler(delegate (Object o, EventArgs a)
            //{
            //    g.Clear(Color.White);
            //    int indexOfItem = SheetContents_ListBox.SelectedIndex;
            //    SheetContents_ListBoxClicked(g, employees, indexOfItem);

            //});


        }

        private void ReadSheet_Button_Click(object sender, EventArgs e )
        {
            {
                
                EmployeeList employees = new EmployeeList();
                Graphics g = TimeLineDrawingPanel.CreateGraphics();
                
                

                SheetContents_ListBox.Items.Clear();
                addIds(g, employees.getEmployeesIds());


                SheetContents_ListBox.Click += new EventHandler(delegate (Object o, EventArgs a)
                {
                    g.Clear(Color.White);
                    int indexOfItem = SheetContents_ListBox.SelectedIndex;
                    SheetContents_ListBoxClicked(g , employees ,indexOfItem);

                });


            }

        }
        private void SheetContents_ListBoxClicked(Graphics g , EmployeeList employees , int indexOfItem) {

            createTimes(g);
            createDays(g);
            drawGrayLines(g);
            createLines(g , employees.getDurationsOfEmpByIndex(indexOfItem) ,
                employees.GetStatusesOfEmpByIndex(indexOfItem) , employees.getDurationFromStartByIndex(indexOfItem) ,
                employees.getSameDaysEmpByIndex(indexOfItem) ,  employees.getNextDaysFromEmpByIndex(indexOfItem));
        }


        private void DrawButton_Click(object sender, EventArgs e)
        {
            //g.DrawString("This is a string", DrawButton.Font, txtBrush, p2, sf); //██████████████████████████████
            
            //g.DrawLine(GreenPen, p1, p2); // ██████████████████████████████
            //Graphics g = TimeLineDrawingPanel.CreateGraphics();
            
            //Color timeLineColor = Color.Black;
            //Brush timeLineBrush = new SolidBrush(timeLineColor);
            //Pen timeLinePen = new Pen(timeLineColor);


            //Pen GreenPen = new Pen(Color.Green);
            //Brush txtBrush = new SolidBrush(Color.Black);
            //StringFormat sf = new StringFormat();
            //sf.LineAlignment = StringAlignment.Center;
            //sf.Alignment = StringAlignment.Center;


            //Point changingPoint = new Point(80, 10);
            //Point startingPoint = new Point(80, 10);
            //Point endingPoint = new Point(560, 10);

            ////createTimes(g);
            ////createDays(g);
            ////createLines(g);


            



            //DateTime startingDate = new DateTime(2016, 6, 5);
            //RectangleF myRectangleF = new RectangleF(30, 30, 40, 10);

        }
        private void createTimes(Graphics g)
        {
            Brush txtBrush = new SolidBrush(Color.Black);
            StringFormat sf = new StringFormat();
            Point changingPoint = new Point(80, 10);
            for (int i = 0; i < 24; i++)
            {
                string drawnString = "0" + i;
                if (i >= 10)
                {
                    drawnString = i + "";
                }
                g.DrawString(drawnString, DrawButton.Font, txtBrush, changingPoint, sf);
                changingPoint.Offset(20, 0);
            }
        }
        private void createDays(Graphics g)
        {
            Point startingPoint = new Point(80, 10);
            Brush txtBrush = new SolidBrush(Color.Black);
            StringFormat sf = new StringFormat();
            for (int i = 1; i <= 90; i++)
            {
                RectangleF currentRec = new RectangleF(30, 20 + i * 10, 40, 20);
                g.DrawString("Day " + i, DrawButton.Font, txtBrush, 10 , 20 + 20*i , sf); //██████████████████████████████
            }
        }

        private void createLines(Graphics g ,  List<double> allMinutes ,  List<string> allStatus 
            , List<double> minutesFromStart , List<bool> sameDays , List<double> minutesFromEnd)
        {
            //double lengthRec = minutesToLength(minutes);
            Point startingPoint = new Point(80, 10);
            Brush txtBrush = new SolidBrush(Color.Black);
            Brush colordBrush = new SolidBrush(Color.BlueViolet);
            StringFormat sf = new StringFormat();
            for (int i = 0; i < allMinutes.Count; i++)
            {
                //Trace.WriteLine("length for end" + minutesFromEnd[i]);
                createColorsCubes(g, allStatus[i], startingPoint, i);
                if (sameDays[i])
                {
                    createLine(g, allMinutes[i], minutesFromStart[i], allStatus[i], i, startingPoint);
                    createTxtForLine(g, allMinutes[i], minutesFromStart[i], i, startingPoint);
                }
                else {
                    createLinesForDiffDay(g, allStatus[i], minutesFromStart[i], startingPoint, i , minutesFromEnd[i], allMinutes[i]);
                }

            }
        }
        private void createLine(Graphics g, double minutes ,double minutesFromStart ,  string status, int i , Point startingPoint  ) {
            Brush txtBrush = new SolidBrush(Color.Black);
            Brush colordBrush = getColorForStatus(status);
            float length = (float)minutesToLength(minutes);
            float lengthFromStart = (float)minutesToLength(minutesFromStart);
            
            //g.FillRectangle(colordBrush, (startingPoint.X - 20), 20 + (i+1) * 20, 10, 10);

            if(length != 0 && !status.Equals("Absent") && !status.Equals("Data error"))
                g.FillRectangle(colordBrush, lengthFromStart + startingPoint.X, +20 + (i+1) * 20, length, 10);
        }
        private void createLinesForDiffDay(Graphics g, string status,double minutesFromStart, Point startingPoint , int i , double minutesFromEnd , double minutes) {
            Brush colordBrush = getColorForStatus(status);
            float lengthFromStart = (float)minutesToLength(minutesFromStart);
            float lengthForEnd = (float)minutesToLength(minutesFromEnd);
            StringFormat sf = new StringFormat();
            Brush txtBrush = new SolidBrush(Color.Black);
            //Trace.WriteLine("length for end" + lengthForEnd);
            if (!status.Equals("Absent") && !status.Equals("Data error")) {
                g.FillRectangle(colordBrush, lengthFromStart + startingPoint.X, +20 + (i + 1) * 20, 500 - lengthFromStart, 10);
                g.FillRectangle(colordBrush, startingPoint.X, +20 + (i + 2) * 20, lengthForEnd, 10);
                g.DrawString(minutesToHours(minutes) + "", DrawButton.Font, txtBrush, lengthForEnd + startingPoint.X, 20 + 20 * (i + 2), sf);
            }
        }
        private void createColorsCubes(Graphics g, string status, Point startingPoint , int i) {
            Brush colordBrush = getColorForStatus(status);
            g.FillRectangle(colordBrush, (startingPoint.X - 20), 20 + (i + 1) * 20, 10, 10);
        }

        private void createTxtForLine(Graphics g, double minutes, double minutesFromStart, int i, Point startingPoint)
        {
            StringFormat sf = new StringFormat();
            Brush txtBrush = new SolidBrush(Color.Black);
            
            float length = (float)minutesToLength(minutes);
            float lengthFromStart = (float)minutesToLength(minutesFromStart);
            float wholeLength = lengthFromStart + length;
            //g.FillRectangle(colordBrush, (startingPoint.X - 20), 20 + (i + 1) * 20, 10, 10);
            if (length != 0)
                g.DrawString(minutesToHours(minutes) + "", DrawButton.Font, txtBrush, wholeLength + startingPoint.X, 20 + 20 * (i+1), sf);
        }

        private double minutesToLength(double minutes) {
            return ((minutes / 60)) * 20;
        }
        private Brush getColorForStatus(string status) {
            Brush colordBrush = new SolidBrush(Color.BlueViolet);
            if (status.Equals("Absent"))
            {
                colordBrush = new SolidBrush(Color.DarkRed);
            }
            else if (status.Equals("Data error"))
            {
                colordBrush = new SolidBrush(Color.BlueViolet);

            }
            else if (status.Equals("present"))
            {
                colordBrush = new SolidBrush(Color.LightGreen);

            }
            else if (status.Equals("insuffecient"))
            {
                colordBrush = new SolidBrush(Color.Orange);
            }
            else {
                colordBrush = new SolidBrush(Color.Black);
            }
            return colordBrush;
        }
        private void addIds(Graphics g, List<int> ids)
        {
            for (int i = 0; i < ids.Count; i++)
            {
                SheetContents_ListBox.Items.Add(ids[i]);
            }
        }
        private string minutesToHours(double minutes)
        {
            int hours = (int)minutes / 60;
            int minutesRemaining = (int)minutes % 60;
            string strMinRem = minutesRemaining.ToString();
            if (strMinRem.Length == 1) {
                strMinRem = "0" + strMinRem;
            }
            else if(strMinRem.Length == 0) {
                strMinRem = "00";
            }

            return hours + ":" + strMinRem;
        }
        private void drawGrayLines(Graphics g) {
            Brush colordBrush = new SolidBrush(Color.LightGray);
            for (int i = 1; i <= 18; i++) {
                g.DrawLine(new Pen(colordBrush), new Point(0, 100 * i + 35), new Point(700, 100 * i + 35));
            }
        }

        //private void Scroller_scroll(object sender, ScrollEventArgs e)
        //{
        //    TimeLineDrawingPanel.VerticalScroll = -Scroller.Value;
        //}
    }
}

