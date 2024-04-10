using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HeThongSach
{
    public partial class PublishingHouseInfo : Form
    {
        Menu Admin;
        public SqlConnection cn = new SqlConnection();
        DataTable dt = new DataTable();
        String str = @"Data Source=DESKTOP-RQNCF8U;Initial Catalog=BookStore;Integrated Security=True";
        public void Connect()
        {
            try
            {
                if (cn.State == 0)
                {
                    cn.ConnectionString = "Data Source=DESKTOP-RQNCF8U;Initial Catalog=BookStore;Integrated Security=True";
                    cn.Open();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Disconnect()
        {
            if (cn.State != 0)
            {
                cn.Close();
            }
        }

        public DataTable Showdata(String sql)
        {
            Connect();
            SqlDataAdapter adap = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            return dt;
            Disconnect();
        }

        public SqlCommand Execute(string sql)
        {
            Connect();
            SqlCommand cm = new SqlCommand(sql, cn);
            cm.ExecuteNonQuery();
            return cm;
            Disconnect();
        }

        void Display()
        {
            cn.Close();
            cn.Open();
            SqlCommand cm = cn.CreateCommand();
            cm.CommandText = "select * from PHs";
            SqlDataAdapter adap = new SqlDataAdapter();
            adap.SelectCommand = cm;
            dt.Clear();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public PublishingHouseInfo()
        {
            InitializeComponent();
        }

        private void returnToMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin = new Menu();
            Admin.Show();
            this.Close();
        }

        private void PublishingHouseInfo_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(str);
            cn.Open();
            Display();
        }
        //id name address phone card pay
        private void button1_Click(object sender, EventArgs e)//add
        {
            SqlCommand cm = new SqlCommand();
            cm = cn.CreateCommand();
            cm.CommandText = "insert into PHs values('" + id.Text + "',N'"
                + name.Text + "', N'" + add.Text + "','" + phone.Text + "','" + cac.Text + "','" + pay.Text + "')";
            cm.ExecuteNonQuery();
            Display();
        }

        private void button2_Click(object sender, EventArgs e)//delete
        {
            SqlCommand cm = new SqlCommand();
            cm = cn.CreateCommand();
            cm.CommandText = "delete from PHs where PHid = '" + id.Text + "'";
            cm.ExecuteNonQuery();
            Display();
        }

        private void button3_Click(object sender, EventArgs e)//update
        {
            SqlCommand cm = new SqlCommand();
            cm = cn.CreateCommand();
            cm.CommandText = "update PHs set unpaid_amount= unpaid_amount- " + int.Parse(pay.Text) + " where PHid= '" + id.Text + "'";
            cm.ExecuteNonQuery();
            Display();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    id.Text = row.Cells[0].Value.ToString();
                    name.Text = row.Cells[1].Value.ToString();
                    add.Text = row.Cells[2].Value.ToString();
                    phone.Text = row.Cells[3].Value.ToString();
                    cac.Text = row.Cells[4].Value.ToString();
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
