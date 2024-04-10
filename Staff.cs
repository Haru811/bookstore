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
    public partial class Staff : Form
    {
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
            cm.CommandText = "select * from Staff";
            SqlDataAdapter adap = new SqlDataAdapter();
            adap.SelectCommand = cm;
            dt.Clear();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        Menu Admin;
        public Staff()
        {
            InitializeComponent();
        }

        private void returnToMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin = new Menu();
            Admin.Show();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //id  name role phone salary
        private void add_Click(object sender, EventArgs e)
        {
            SqlCommand cm = new SqlCommand();
            cm = cn.CreateCommand();
            cm.CommandText = "insert into Staff values('" + id.Text + "',N'"
                + name.Text + "','" + role.Text + "','" + phone.Text + "','" + salary.Text + "')";
            cm.ExecuteNonQuery();
            Display();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            SqlCommand cm = new SqlCommand();
            cm = cn.CreateCommand();
            cm.CommandText = "delete from Staff where ID = '" + id.Text + "'";
            cm.ExecuteNonQuery();
            Display();
        }

        private void update_Click(object sender, EventArgs e)
        {
            SqlCommand cm = new SqlCommand();
            cm = cn.CreateCommand();
            cm.CommandText = "update STAFF set Phone=" + phone.Text + ", Salary="
                + salary.Text + " where ID='" + id.Text + "'";
            cm.ExecuteNonQuery();
            Display();
        }

        private void search_Click(object sender, EventArgs e)
        {

        }

        private void Staff_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(str);
            cn.Open();
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
                    role.Text = row.Cells[2].Value.ToString();
                    phone.Text = row.Cells[3].Value.ToString();
                    salary.Text = row.Cells[4].Value.ToString();
                }
            }
        }
    }
}
