using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridSpreadSheetSamples
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[,] rows = new string[,]{ 
                                             {"1","2","5","10"},
                                             {"9","6","20","11"},
                                             {"7","4","9","30"},
                                             {"4","13","80","40"},
                                             {"9","12","55","50"},
                                             {"6","19","21","60"},
                                             //{"=SUM(A1:A2)","=SUM(B1:B6)","=SUM(C1:C3)","=SUM(D2:D5)"}
                                          };


            string[] rows2 = rows.Cast<string>().Select((x, i) => new { value = x, column = i % 4 })
                .GroupBy(x => x.column)
                .Select(x => x.Sum(y => int.Parse(y.value))
                    .ToString()).ToArray();



        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[,] baserows = new string[,]{
                                             {"1","2","5","10"},
                                             {"9","6","20","11"},
                                             {"7","4","9","30"},
                                             {"4","13","80","40"},
                                             {"9","12","55","50"},
                                             {"6","19","21","60"} };
            var rowCount = 10;
            string[,] rows = new string[rowCount, 4];
            Array.Copy(baserows, rows, baserows.Length);
            for (int i = 0; i < rowCount - 6; i++)
            {
                rows[i + 6, 0] = (Int32.Parse(rows[i, 0]) + Int32.Parse(rows[i + 1, 0])).ToString();
                rows[i + 6, 1] = (Int32.Parse(rows[i, 1]) + Int32.Parse(rows[i + 5, 1])).ToString();
                rows[i + 6, 2] = (Int32.Parse(rows[i, 2]) + Int32.Parse(rows[i + 2, 2])).ToString();
                rows[i + 6, 3] = (Int32.Parse(rows[i + 1, 3]) + Int32.Parse(rows[i + 4, 3])).ToString();
            }

            int height = rows.GetLength(0);
            int width = rows.GetLength(1);

            this.dgList.ColumnCount = width;

            for (int r = 0; r < height; r++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(this.dgList);

                for (int c = 0; c < width; c++)
                {
                    row.Cells[c].Value = rows[r,c];
                }

                this.dgList.Rows.Add(row);
            }
        }
    }
}
