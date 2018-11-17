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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            DataTable dtSample = new DataTable();
            dtSample.Columns.Add(new DataColumn("Item", typeof(string)));
            dtSample.Columns.Add(new DataColumn("Quantity", typeof(int)));
            dtSample.Columns.Add(new DataColumn("Price", typeof(decimal)));
            dtSample.Columns.Add(new DataColumn("Sale", typeof(decimal)));

            // assign expression using the col names
            dtSample.Columns[3].Expression = "(Quantity * Price)";

            DataRow _dr = dtSample.NewRow();
            _dr["Item"] = "Soap";
            _dr["Quantity"] = 2;
            _dr["Price"] = 200;
            dtSample.Rows.Add(_dr);

            _dr = dtSample.NewRow();
            _dr["Item"] = "TV";
            _dr["Quantity"] = 3;
            _dr["Price"] = 150;
            dtSample.Rows.Add(_dr);

            _dr = dtSample.NewRow();
            _dr["Item"] = "Camera";
            _dr["Quantity"] = 5;
            _dr["Price"] = 50;
            dtSample.Rows.Add(_dr);

            dgList.DataSource = dtSample;
        }
    }
}
