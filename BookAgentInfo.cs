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
    public partial class BookAgentInfo : Form
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
            cm.CommandText = "select * from AGENT";
            SqlDataAdapter adap = new SqlDataAdapter();
            adap.SelectCommand = cm;
            dt.Clear();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public BookAgentInfo()
        {
            InitializeComponent();
        }

        private void returnToMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin = new Menu();
            Admin.Show();
            this.Close();
        }
        //agent add id phone unpaid
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cm = new SqlCommand();
            cm = cn.CreateCommand();
            cm.CommandText = "insert into AGENT values('" + id.Text + "',N'"
                + agent.Text + "','" + phone.Text + "',N'" + add.Text + "','" + paid.Text + "')";
            cm.ExecuteNonQuery();
            Display();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cm = new SqlCommand();
            cm = cn.CreateCommand();
            cm.CommandText = "delete from AGENT where agentid = '" + id.Text + "'";
            cm.ExecuteNonQuery();
            Display();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cm = new SqlCommand();
            cm = cn.CreateCommand();
            cm.CommandText = "update AGENT set amount_owed= amount_owed - " + int.Parse(paid.Text) + " where agentid= '" + id.Text + "'";
            cm.ExecuteNonQuery();
            Display();
        }

        private void BookAgentInfo_Load(object sender, EventArgs e)
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
                    agent.Text = row.Cells[1].Value.ToString();
                    phone.Text = row.Cells[2].Value.ToString();
                    add.Text = row.Cells[3].Value.ToString();
                    paid.Text = row.Cells[4].Value.ToString();

                }
            }
        }

        private void agent_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
