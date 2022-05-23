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
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection;
        SqlCommand command;

        string str = @"Data Source=JAGPC;Initial Catalog=Stock;Integrated Security=True";

        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        void loadData()
        {
            command = sqlConnection.CreateCommand();
            command.CommandText = "Select * from Product";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgv1.DataSource = table;
        }

        void loadCb()
        {
            adapter = new SqlDataAdapter("select id, status from StatusProduct", sqlConnection);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "status");
            cb1.DataSource = ds.Tables["status"];
            cb1.DisplayMember = "status";
            cb1.ValueMember = "id";
            cb1.Text = "Status";
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(str);
            sqlConnection.Open();
            loadData();
            loadCb();
        }

        private void add_Click(object sender, EventArgs e)
        {
            string nameX = name.Text;
            byte[] image = imageToByte(pb1);
            string quantityX = quantity.Text;
            string priceX = price.Text;
            string descriptionX = desc.Text;
            int status = Convert.ToInt32(cb1.SelectedValue);
            command.CommandText = "insert into Product(name, quantity, price, description, status, DOI, image)"
                + " values(@name, @quantity, @price, @description, @status, @MyDate, @image)";
            command.Parameters.Add("@name", nameX);
            command.Parameters.Add("@quantity", quantityX);
            command.Parameters.Add("@price", priceX);
            command.Parameters.Add("@description", descriptionX);
            command.Parameters.Add("@status", status); 
            command.Parameters.Add("@MyDate", DateTime.Now);
            command.Parameters.Add("@image", image);
            command.ExecuteNonQuery();
            MessageBox.Show("Thêm sản phẩm thành công!");
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

        private void delete_Click(object sender, EventArgs e)
        {
            string idX = id.Text;
            command.CommandText = "delete from Product where id = @id";
            command.Parameters.Add("@id", idX);
            command.ExecuteNonQuery();
            MessageBox.Show("Xóa sản phẩm thành công!");
            loadData();
        }

        private void update_Click(object sender, EventArgs e)
        {
            string idX = id.Text;
            string nameX = name.Text;
            byte[] image = imageToByte(pb1);
            string quantityX = quantity.Text;
            string priceX = price.Text;
            string descriptionX = desc.Text;
            int status = Convert.ToInt32(cb1.SelectedValue);
            command.CommandText = "update Product set name = @name, quantity = @quantity, price = @price, description = @description, status = status, image = @image where id = @id";
            command.Parameters.Add("@name", nameX);
            command.Parameters.Add("@quantity", quantityX);
            command.Parameters.Add("@price", priceX);
            command.Parameters.Add("@description", descriptionX);
            command.Parameters.Add("@status", status);
            command.Parameters.Add("@image", image);
            command.Parameters.Add("@id", idX);
            command.ExecuteNonQuery();
            MessageBox.Show("Cập nhật thành công!");
            loadData();
        }

        byte[] imageToByte(PictureBox pictureBox)
        {
            MemoryStream memoryStream = new MemoryStream();
            pb1.Image.Save(memoryStream, pictureBox.Image.RawFormat);
            return memoryStream.ToArray();
        }

        private void pb1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select Image";
            openFileDialog.Filter = "Image Filter(*.png; *jpg)|*.png; *jpg";
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pb1.ImageLocation = openFileDialog.FileName;
            }
        }

        private void export_Click(object sender, EventArgs e)
        {
            Export export = new Export(id.Text);
            export.Show();
        }

        private void report_Click(object sender, EventArgs e)
        {
            Report report = new Report();
            report.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
