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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int NumColumns = 150;
            int NumRows = 7000;
            Random rnd = new Random();

            // Lets add columns, we can't add rows without columns
            for (int i = 0; i < NumColumns; i++)
            {
                //string column = string.Format("Column{0}", i + 1);
                string column = GenerateColumnText(i);
                dgList.Columns.Add(column, column);
            }

            // Your data ...
            for (int row = 0; row < NumRows; row++)
            {
                // We need to save each row as an array
                string[] currentColumn = new string[NumColumns];
                // We we add each column to the currentColumn

                for (int col = 0; col < NumColumns; col++)
                {
                    currentColumn[col] = rnd.Next(0, 100).ToString();
                }
                // We add that to the gridView

                dgList.Rows.Add(currentColumn);

            }

            stopwatch.Stop();
            TimeSpan timeSpan = stopwatch.Elapsed;
            // Write result.
            //Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
            //Console.WriteLine("Time: {0}h {1}m {2}s {3}ms", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);
            label1.Text = string.Format("Time elapsed: {0}h {1}m {2}s {3}ms", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);
        }

        private void dgList_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.FillWeight = 10;
        }

        //generate excel like column text for grid header
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

        /*
            float sumNumbers = 0;
            private void datagridview1_SelectionChanged(object sender, EventArgs e)
            {
              for (int i = 0; i < datagridview1.SelectedCells.Count; i++)
              {
                if (!datagridview1.SelectedCells.Contains(datagridview1.Rows[i].Cells[i]))
                {
                  float nextNumber = 0;

                  if (float.TryParse(datagridview1.SelectedCells[i].FormattedValue.ToString(), out nextNumber))
                    sumNumbers += nextNumber;

                  label13.Text = "selected value: " + sumNumbers;
                  label16.Text = "Nr.selected cell: " + datagridview1.SelectedCells.Count.ToString();
                }
                else
                {
                  MessageBox.Show("Can't sum");
                }
              }
        */

    }
}
