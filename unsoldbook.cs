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
    public partial class UnsoldBooks : Form
    {
        Statistic Sta;
        ThongCute Thong;
        string Message = "Print Complete!";
        string title = "Notification!";

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
            cm.CommandText = "select * from statistic";
            SqlDataAdapter adap = new SqlDataAdapter();
            adap.SelectCommand = cm;
            dt.Clear();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        public UnsoldBooks()
        {
            InitializeComponent();
        }

        private void statisticToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sta = new Statistic();
            Sta.Show();
            this.Close();
        }

        private void thongCuteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thong = new ThongCute();
            Thong.Show();
            this.Close();
        }
        /*statistic(
	statisticid VARCHAR (15), 
	PHid VARCHAR (15),
	bookid VARCHAR (15),
	unsold_quantity int, */
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cm = new SqlCommand();
            cm = cn.CreateCommand();
            cm.CommandText = "insert into statistic values('" + textBox4.Text + "',N'"
                + textBox1.Text + "', N'" + textBox2.Text + "','" + textBox3.Text + "')";
            cm.ExecuteNonQuery();
            Display();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Message, title);
        }

        private void UnsoldBooks_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(str);
            cn.Open();
            Display();
        }
    }
}
