using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;
namespace AttendanceVisualizer
{
    public class Reader
    {
        public Reader()
        {
        }
        public static List<string> readLine(int row)
        {
            Excel.Workbook xWorkBook = Globals.ThisAddIn.Application.ActiveWorkbook;

            Excel.Worksheet xWorksheet = xWorkBook.Worksheets.Item[1];
            Excel.Range usedRng;
            usedRng = xWorksheet.UsedRange;
            int numberOfRows = usedRng.Rows.Count;
            //int row = 1;
            Excel.Range idRead = xWorksheet.Cells[row, 1];
            Excel.Range dateRead = xWorksheet.Cells[row, 2];
            Excel.Range inRead = xWorksheet.Cells[row, 3];
            Excel.Range outRead = xWorksheet.Cells[row, 4];

            List<string> rowReaded = new List<string>();
            rowReaded.Add(idRead.Text);
            rowReaded.Add(dateRead.Text);

            rowReaded.Add(inRead.Text);
            rowReaded.Add(outRead.Text);

            return rowReaded;
        }
        public static int getNumberOfRows() {
            Excel.Workbook xWorkBook = Globals.ThisAddIn.Application.ActiveWorkbook;
            Excel.Worksheet xWorksheet = xWorkBook.Worksheets.Item[1];
            Excel.Range usedRng;
            usedRng = xWorksheet.UsedRange;
            int numberOfRows = usedRng.Rows.Count;
            return numberOfRows;
        }
    }
}