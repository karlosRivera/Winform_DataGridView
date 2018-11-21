using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel;

namespace DataGridSpreadSheetSamples
{
    public partial class WriteToExcel : Form
    {
        public WriteToExcel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet = null;

            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);

            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            //xlWorkBook.Windows.Application.ActiveWindow.DisplayGridlines = false;

            xlWorkSheet.Cells[1, 1] = "Hello1";
            xlWorkSheet.Cells[2, 1] = "Hello2";
            xlWorkSheet.Cells[3, 1] = "Hello3";

            xlWorkBook.SaveAs(@"d:\pop.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, 
                misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
            xlApp = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch
            {
                obj = null;
                //MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
        }
    }
}
