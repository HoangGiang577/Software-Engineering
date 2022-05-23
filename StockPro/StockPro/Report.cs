using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockPro
{
    public partial class Report : Form
    {

        SqlConnection sqlConnection;
        SqlCommand command;

        string str = @"Data Source=JAGPC;Initial Catalog=Stock;Integrated Security=True";

        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        public Report()
        {
            InitializeComponent();
        }

        void loadData()
        {
            command = sqlConnection.CreateCommand();
            command.CommandText = "Select ex.ID_Product, p.Name, p.Price , ex.ID_Product, sum(ex.Quantity) as TotalQuantity "
            + " from Export ex join Product p on ex.ID_Product = p.ID where datepart(month, doe) = MONTH(GETDATE()) "
            + " group by ex.ID_Product, p.Name, p.Price; ";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgv1.DataSource = table;
        }

        private void Report_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            loadData();
        }


        private void analysis_Click(object sender, EventArgs e)
        {
            command = sqlConnection.CreateCommand();
            command.CommandText = "Select ex.ID_Product, p.Name, p.Price , ex.ID_Product, sum(ex.Quantity) as TotalQuantity "
            +" from Export ex join Product p on ex.ID_Product = p.ID where datepart(month, doe) = MONTH(GETDATE()) "
            +" group by ex.ID_Product, p.Name, p.Price; ";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgv1.DataSource = table;

            barchart.Series[0].XValueMember = "Name";
            barchart.Series[0].YValueMembers = "TotalQuantity";
            string sMonth = DateTime.Now.ToString("MM");
            var sYear = DateTime.Now.Year;
            barchart.Titles.Add("Export in month: "+ sMonth+"/"+ sYear);
            barchart.DataSource = table;
            barchart.DataBind();
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
