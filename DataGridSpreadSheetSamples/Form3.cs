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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            int NumColumns =0;
            int NumRows = 0;

            string[,] rows = new string[,]{ // 1   2     3     4 
                                             {"1","2","5","10"},//1
                                             {"9","6","20","11"},//2
                                             {"7","4","9","30"},//3
                                             {"4","13","80","40"},
                                             {"9","12","55","50"},
                                             {"6","19","21","60"},
                                             {"sum(1+2)","41","33","70"}//7
                                          };

            NumRows = rows.GetLength(0);
            NumColumns = rows.GetLength(1);

            // Lets add columns, we can't add rows without columns
            for (int i = 0; i < NumColumns; i++)
            {
                //string column = string.Format("Column{0}", i + 1);
                string column = GenerateColumnText(i);
                dgList.Columns.Add(column, column);
            }

            dgList.Rows.Add(NumRows);

            for (int i = 0; i < NumRows; i++)
            {
                for (int j = 0; j < NumColumns; j++)
                {
                    dgList.Rows[i].Cells[j].Value = rows[i, j];
                }
            }

            //for (int i = 0; i < rows.GetLength(0); i++)// array rows
            //{
            //    string[] row = new string[rows.GetLength(1)];

            //    for (int j = 0; j < rows.GetLength(1); j++)
            //    {
            //        row[j] = rows[i, j];
            //    }

            //    dgList.Rows.Add(row);
            //}
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
