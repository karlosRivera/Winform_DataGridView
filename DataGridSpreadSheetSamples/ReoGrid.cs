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
    public partial class ReoGrid : Form
    {
        public ReoGrid()
        {
            InitializeComponent();
        }

        private void ReoGrid_Load(object sender, EventArgs e)
        {
            int NumColumns = 0;
            int NumRows = 0;

            string[,] rows = new string[,]{ 
                                             {"1","2","5","10"},
                                             {"9","6","20","11"},
                                             {"7","4","9","30"},
                                             {"4","13","80","40"},
                                             {"9","12","55","50"},
                                             {"6","19","21","60"},
                                             {"=SUM(A1:A2)","=SUM(B1:B6)","=SUM(C1:C3)","=SUM(D2:D5)"}
                                          };

            NumRows = rows.GetLength(0);
            NumColumns = rows.GetLength(1);

            var sheet = reoGrd.CurrentWorksheet;
            for (int row = 0; row < NumRows; row++)
            {
                for (int col = 0; col < NumColumns; col++)
                {
                    sheet[row, col] = rows[row, col];
                    if(rows[row, col].StartsWith("=SUM"))
                    {
                        string cellname = GenerateColumnText(col) + (row+1).ToString();
                        var cell = sheet.Cells[cellname];
                        cell.Style.BackColor = Color.SkyBlue;

                    }

                }
            }
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
    }
}
