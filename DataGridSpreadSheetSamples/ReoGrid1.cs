using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

namespace DataGridSpreadSheetSamples
{
    public partial class ReoGrid1 : Form
    {
        public ReoGrid1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strSum = "", strColName, strImmediateOneUp = "", strImmediateTwoUp = "";
            //int NumRows = 10;
            //int NumColumns = 5;

            int NumRows = 10;
            int NumColumns = 5;

            int startsum = 0;
            int currow = 0;
            bool firstTimeSum = true;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var sheet = reoGrd.CurrentWorksheet;
            sheet.Resize(NumRows, NumColumns);  // resize 


            for (int row = 0; row < NumRows; row++)
            {
                for (int col = 0; col < NumColumns; col++)
                {
                    if (row < 2)
                    {
                        sheet[row, col] = new Random().Next(1, NumRows).ToString();
                        //var xval = GenerateUniqueNumber(1, NumRows);

                        //sheet[row, col] = new Random().Next(1, 100).ToString("D2");
                        //sheet[row, col] = GenerateUniqueNumber(1, NumRows);
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
                            sheet[row, col] = strSum;

                            string cellname = GenerateColumnText(col) + (row + 1).ToString();
                            var cell = sheet.Cells[cellname];
                            cell.Style.BackColor = Color.LightGoldenrodYellow;
                        }
                        else
                        {
                            //var xval = GenerateUniqueNumber(1, NumRows);
                            sheet[row, col] = new Random().Next(1, NumRows).ToString("D2");
                            //string  uniqueVal= GenerateUniqueNumber(1, NumRows);
                            //sheet[row, col] = uniqueVal;

                        }
                    }

                }

                startsum = 1;
            }

            stopwatch.Stop();
            TimeSpan timeSpan = stopwatch.Elapsed;

            MessageBox.Show(string.Format("Time elapsed: {0}h {1}m {2}s {3}ms", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds));
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

        private void button2_Click(object sender, System.EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            string strSum = "", strColName, strImmediateOneUp = "", strImmediateTwoUp = "";

            int startsum = 0;
            int currow = 0;
            bool firstTimeSum = true;

            int NumRows = 10;
            int NumColumns = 5;

            var sheet = reoGrd.CurrentWorksheet;
            sheet.Resize(NumRows, NumColumns);  // resize 

            DataTable dt = new DataTable();

            for (int col = 0; col < NumColumns; col++)
            {
                strColName = GenerateColumnText(col);
                DataColumn datacol = new DataColumn(strColName, typeof(string));
                dt.Columns.Add(datacol);
            }


            for (int row = 0; row < NumRows; row++)
            {
                dt.Rows.Add();

                for (int col = 0; col < NumColumns; col++)
                {
                    if (row < 2)
                    {
                        dt.Rows[row][col] = new Random().Next(1, NumRows).ToString("D2");
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
                            dt.Rows[row][col] = strSum;

                            string cellname = GenerateColumnText(col) + (row + 1).ToString();
                            var cell = sheet.Cells[cellname];
                            cell.Style.BackColor = Color.LightGoldenrodYellow;
                        }
                        else
                        {
                            dt.Rows[row][col] = new Random().Next(1, NumRows).ToString("D2");
                        }
                    }

                }

                startsum = 1;
            }

            sheet["A1"] = dt;

            stopwatch.Stop();
            TimeSpan timeSpan = stopwatch.Elapsed;

            MessageBox.Show(string.Format("Time elapsed: {0}h {1}m {2}s {3}ms", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds));

        }
    }
}
