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
    public partial class Statistic : Form
    {
        UnsoldBooks Uns;
        ThongCute Thong;

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
            cm.CommandText = "select * from Sales";
            SqlDataAdapter adap = new SqlDataAdapter();
            adap.SelectCommand = cm;
            dt.Clear();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
        }


        public Statistic()
        {
            InitializeComponent();
        }

        private void stocksToolStripMenuItem_Click(object sender, EventArgs e)//unsold
        {
            Uns = new UnsoldBooks();
            Uns.Show();
            this.Close();
        }

        private void thongCuteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thong = new ThongCute();
            Thong.Show();
            this.Close();
        }

        private void Statistic_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(str);
            cn.Open();
            Display();
        }

        private void button1_Click(object sender, EventArgs e)//weekly
        {
            dataGridView1.DataSource = Showdata("SELECT YEAR(SaleDate) AS SaleYear,DATEPART(WEEK, SaleDate) AS WeekNumber,SUM(Amount) AS WeeklyRevenue FROM Sales GROUP BY YEAR(SaleDate), DATEPART(WEEK, SaleDate) ORDER BY SaleYear, WeekNumber;");
        }

        private void button2_Click(object sender, EventArgs e)//monthly
        {
            dataGridView1.DataSource = Showdata("SELECT YEAR(SaleDate) AS SaleYear,DATEPART(MONTH, SaleDate) AS MonthNumber,SUM(Amount) AS MonthlyRevenue FROM Sales GROUP BY YEAR(SaleDate), DATEPART(MONTH, SaleDate)ORDER BY SaleYear, MonthNumber;");
        }

        private void button3_Click(object sender, EventArgs e)//yearly
        {
            dataGridView1.DataSource = Showdata("SELECT YEAR(SaleDate) AS SaleYear,SUM(Amount) AS YearlyRevenue FROM Sales GROUP BY YEAR(SaleDate) ORDER BY SaleYear;");
        }
    }
}
