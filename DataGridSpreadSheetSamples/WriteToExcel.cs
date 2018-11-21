using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
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
            string strSum = "", strColName, strImmediateOneUp = "", strImmediateTwoUp = "";

            int NumRows = 1000;
            int NumColumns = 150;

            int startsum = 0;
            int currow = 0;
            bool firstTimeSum = true;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet = null;

            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);

            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);


            for (int row = 0; row < NumRows; row++)
            {
                for (int col = 0; col < NumColumns; col++)
                {
                    if (row < 2)
                    {
                        xlWorkSheet.Cells[row+1, col+1] = new Random().Next(1, NumRows).ToString();
                    }
                    else
                    {
                        if (firstTimeSum)
                        {
                            if (row - currow == 2)
                            {
                                currow = row;
                                startsum = 0;
                                firstTimeSum = false;
                            }
                            else
                            {
                                startsum = 1;
                            }
                        }
                        else
                        {
                            if (row - currow == 3)
                            {
                                currow = row;
                                startsum = 0;
                            }
                        }


                        if (startsum == 0)
                        {
                            strColName = GenerateColumnText(col);
                            strImmediateOneUp = strColName + ((row + 1) - 1).ToString();
                            strImmediateTwoUp = strColName + ((row + 1) - 2).ToString();
                            strSum = string.Format("=SUM({0}:{1})", strImmediateTwoUp, strImmediateOneUp);
                            xlWorkSheet.Cells[row+1, col+1] = strSum;
                        }
                        else
                        {
                            xlWorkSheet.Cells[row + 1, col + 1] = new Random().Next(1, NumRows).ToString();
                        }
                    }

                }

                startsum = 1;
            }

            if (System.IO.File.Exists(@"d:\pop.xls"))
            {
                System.IO.File.Delete(@"d:\pop.xls");
            }

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

            stopwatch.Stop();
            TimeSpan timeSpan = stopwatch.Elapsed;

            MessageBox.Show(string.Format("Time elapsed: {0}h {1}m {2}s {3}ms", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds));

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

        private string GenerateColumnText(int num)
        {
            string str = "";
            char achar;
            int mod;
            while (true)
            {
                mod = (num % 26) + 65;
                num = (int)(num / 26);
                achar = (char)mod;
                str = achar + str;
                if (num > 0) num--;
                else if (num == 0) break;
            }
            return str;
        }
    }
}
