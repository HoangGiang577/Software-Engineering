using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockPro
{
    public partial class Export : Form
    {

        SqlConnection sqlConnection;
        SqlCommand command;

        string str = @"Data Source=JAGPC;Initial Catalog=Stock;Integrated Security=True";

        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        public Export()
        {
            InitializeComponent();

        }

        public Export(string id)
        {
            InitializeComponent();
            this.Value = id;
        }

        void loadData()
        {
            command = sqlConnection.CreateCommand();
            command.CommandText = "Select * from Product where id = @id";
            command.Parameters.Add("@id", this.Value);
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgv1.DataSource = table;
        }

        public string Value { get; set; }

        private void deliver_Click(object sender, EventArgs e)
        {
            string quantityX = dgv1.CurrentRow.Cells[3].Value.ToString();
            string quanEx = quantity.Text;
            int x = Convert.ToInt32(quantityX) - Convert.ToInt32(quanEx);
            if (x>=0)
            {
                string idX = id.Text;
                int quanPost = Convert.ToInt32(quantityX) - Convert.ToInt32(quanEx);
                command.CommandText = "update Product set quantity = @quantity where id = @idX";
                command.Parameters.Add("@quantity", quanPost);
                command.Parameters.Add("@idX", idX);
                command.ExecuteNonQuery();
                command.CommandText = "insert into Export(ID_Product, Quantity, DOE) values(@idPro, @quantityX, @doe)";
                command.Parameters.Add("@idPro", this.Value);
                command.Parameters.Add("@quantityX", quanPost);
                command.Parameters.Add("@doe", DateTime.Now);
                command.ExecuteNonQuery();
                MessageBox.Show("Xuất kho thành công!");
                loadData();
            }
            else
            {
                MessageBox.Show("Số lượng hàng xuất kho phải ít hơn hoặc bằng số lượng hàng trong kho");
            }
        }
            

        private void Export_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            loadData();
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgv1.CurrentRow.Index;
            id.Text = dgv1.CurrentRow.Cells[0].Value.ToString();
            id.Enabled = false;
            name.Text = dgv1.CurrentRow.Cells[1].Value.ToString();
            quantity.Text = dgv1.CurrentRow.Cells[3].Value.ToString();
            price.Text = dgv1.CurrentRow.Cells[4].Value.ToString();
            desc.Text = dgv1.CurrentRow.Cells[5].Value.ToString();
            cb1.Text = dgv1.CurrentRow.Cells[6].Value.ToString();
            string quantityX = quantity.Text;
            string priceX = price.Text;
            string descriptionX = desc.Text;
            if (dgv1.CurrentRow.Cells[2].Value.ToString() != "")
            {
                MemoryStream memoryStream = new MemoryStream((byte[])dgv1.CurrentRow.Cells[2].Value);
                pb1.Image = Image.FromStream(memoryStream);
            }
            else
            {
                pb1.Image = null;
            }
        }
    }
}
