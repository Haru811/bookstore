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
using System.Diagnostics.Eventing.Reader;

namespace HeThongSach
{
    public partial class BookInfo : Form
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
            cm.CommandText = "select * from book";
            SqlDataAdapter adap = new SqlDataAdapter();
            adap.SelectCommand = cm;
            dt.Clear();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        public BookInfo()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void reutrnToMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin = new Menu();
            Admin.Show();
            this.Close();
        }

        private void BookInfo_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(str);
            cn.Open();
            Display();
        }

        private void button1_Click(object sender, EventArgs e)//add
        {
            SqlCommand cm = new SqlCommand();
            cm = cn.CreateCommand();
            cm.CommandText = "insert into book values('" + textBox4.Text + "',N'"
                + textBox1.Text + "','" + textBox2.Text + "',N'" + textBox5.Text + "','" + textBox3.Text + "',N'" + comboBox1.Text + "')";
            cm.ExecuteNonQuery();
            Display();
        }

        private void button2_Click(object sender, EventArgs e)//delete
        {
            SqlCommand cm = new SqlCommand();
            cm = cn.CreateCommand();
            cm.CommandText = "delete from book where bookid = '" + textBox4.Text + "'";
            cm.ExecuteNonQuery();
            Display();
        }

        private void button3_Click(object sender, EventArgs e)//update
        {
            SqlCommand cm = new SqlCommand();
            cm = cn.CreateCommand();
            cm.CommandText = "update book set price= '" + textBox3.Text + "' where bookid='" + textBox4.Text + "'";
            cm.ExecuteNonQuery();
            Display();
        }
        /*textBox1 bookname, textBox5 author, textBox4 bookid, textBox3 price, comboBox1 type
          text N4 N1 2 5 3 Ncombo
      */
        #region[Search]
        private void button4_Click(object sender, EventArgs e)//search, author, bookname,book id,type
        {
            //PH01 and Type
            if (comboBox1.Text == "Sách thiếu nhi" && textBox2.Text == "PUB01")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách thiếu nhi' AND PHid = 'PUB01'");
            }
            else if (comboBox1.Text == "Sách văn học viễn tưởng" && textBox2.Text == "PUB01")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách văn học viễn tưởng' AND PHid = 'PUB01'");
            }
            else if (comboBox1.Text == "Sách tiểu sử, tự truyện" && textBox2.Text == "PUB01")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách tiểu sử, tự truyện' AND PHid = 'PUB01'");
            }
            else if (comboBox1.Text == "Sách kinh dị, bí ẩn" && textBox2.Text == "PUB01")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách kinh dị, bí ẩn' AND PHid = 'PUB01'");
            }
            else if (comboBox1.Text == "Sách dạy nấu ăn" && textBox2.Text == "PUB01")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách dạy nấu ăn' AND PHid = 'PUB01'");
            }
            else if (comboBox1.Text == "Sách khoa học công nghệ" && textBox2.Text == "PUB01")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách khoa học công nghệ' AND PHid = 'PUB01'");
            }
            else if (comboBox1.Text == "Sách truyền cảm hứng" && textBox2.Text == "PUB01")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách truyền cảm hứng' AND PHid = 'PUB01'");
            }
            else if (comboBox1.Text == "Sách tôn giáo" && textBox2.Text == "PUB01")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách tôn giáo' AND PHid = 'PUB01'");
            }
            else if (comboBox1.Text == "Sách văn hoá xã hội" && textBox2.Text == "PUB01")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách văn hóa xã hội'AND PHid = 'PUB01'");
            }
            else if (comboBox1.Text == "Sách lịch sử" && textBox2.Text == "PUB01")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách lịch sử'AND PHid = 'PUB01'");
            }


            //PH02 and Type
            else if (comboBox1.Text == "Sách thiếu nhi" && textBox2.Text == "PUB02")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách thiếu nhi' AND PHid = 'PUB02'");
            }
            else if (comboBox1.Text == "Sách văn học viễn tưởng" && textBox2.Text == "PUB02")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách văn học viễn tưởng' AND PHid = 'PUB02'");
            }
            else if (comboBox1.Text == "Sách tiểu sử, tự truyện" && textBox2.Text == "PUB02")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách tiểu sử, tự truyện' AND PHid = 'PUB02'");
            }
            else if (comboBox1.Text == "Sách kinh dị, bí ẩn" && textBox2.Text == "PUB02")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách kinh dị, bí ẩn' AND PHid = 'PUB02'");
            }
            else if (comboBox1.Text == "Sách dạy nấu ăn" && textBox2.Text == "PUB02")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách dạy nấu ăn' AND PHid = 'PUB02'");
            }
            else if (comboBox1.Text == "Sách khoa học công nghệ" && textBox2.Text == "PUB02")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách khoa học công nghệ' AND PHid = 'PUB02'");
            }
            else if (comboBox1.Text == "Sách truyền cảm hứng" && textBox2.Text == "PUB02")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách truyền cảm hứng' AND PHid = 'PUB02'");
            }
            else if (comboBox1.Text == "Sách tôn giáo" && textBox2.Text == "PUB02")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách tôn giáo' AND PHid = 'PUB02'");
            }
            else if (comboBox1.Text == "Sách văn hoá xã hội" && textBox2.Text == "PUB02")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách văn hóa xã hội'AND PHid = 'PUB02'");
            }
            else if (comboBox1.Text == "Sách lịch sử" && textBox2.Text == "PUB02")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách lịch sử'AND PHid = 'PUB02'");
            }


            //PH03 and Type
            else if (comboBox1.Text == "Sách thiếu nhi" && textBox2.Text == "PUB03")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách thiếu nhi' AND PHid = 'PUB03'");
            }
            else if (comboBox1.Text == "Sách văn học viễn tưởng" && textBox2.Text == "PUB03")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách văn học viễn tưởng' AND PHid = 'PUB03'");
            }
            else if (comboBox1.Text == "Sách tiểu sử, tự truyện" && textBox2.Text == "PUB03")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách tiểu sử, tự truyện' AND PHid = 'PUB03'");
            }
            else if (comboBox1.Text == "Sách kinh dị, bí ẩn" && textBox2.Text == "PUB03")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách kinh dị, bí ẩn' AND PHid = 'PUB03'");
            }
            else if (comboBox1.Text == "Sách dạy nấu ăn" && textBox2.Text == "PUB03")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách dạy nấu ăn' AND PHid = 'PUB03'");
            }
            else if (comboBox1.Text == "Sách khoa học công nghệ" && textBox2.Text == "PUB03")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách khoa học công nghệ' AND PHid = 'PUB03'");
            }
            else if (comboBox1.Text == "Sách truyền cảm hứng" && textBox2.Text == "PUB03")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách truyền cảm hứng' AND PHid = 'PUB03'");
            }
            else if (comboBox1.Text == "Sách tôn giáo" && textBox2.Text == "PUB03")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách tôn giáo' AND PHid = 'PUB03'");
            }
            else if (comboBox1.Text == "Sách văn hoá xã hội" && textBox2.Text == "PUB03")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách văn hóa xã hội'AND PHid = 'PUB03'");
            }
            else if (comboBox1.Text == "Sách lịch sử" && textBox2.Text == "PUB03")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách lịch sử'AND PHid = 'PUB03'");
            }


            //PH04 and Type
            else if (comboBox1.Text == "Sách thiếu nhi" && textBox2.Text == "PUB04")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách thiếu nhi' AND PHid = 'PUB04'");
            }
            else if (comboBox1.Text == "Sách văn học viễn tưởng" && textBox2.Text == "PUB04")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách văn học viễn tưởng' AND PHid = 'PUB04'");
            }
            else if (comboBox1.Text == "Sách tiểu sử, tự truyện" && textBox2.Text == "PUB04")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách tiểu sử, tự truyện' AND PHid = 'PUB04'");
            }
            else if (comboBox1.Text == "Sách kinh dị, bí ẩn" && textBox2.Text == "PUB04")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách kinh dị, bí ẩn' AND PHid = 'PUB04'");
            }
            else if (comboBox1.Text == "Sách dạy nấu ăn" && textBox2.Text == "PUB04")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách dạy nấu ăn' AND PHid = 'PUB04'");
            }
            else if (comboBox1.Text == "Sách khoa học công nghệ" && textBox2.Text == "PUB04")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách khoa học công nghệ' AND PHid = 'PUB04'");
            }
            else if (comboBox1.Text == "Sách truyền cảm hứng" && textBox2.Text == "PUB04")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách truyền cảm hứng' AND PHid = 'PUB04'");
            }
            else if (comboBox1.Text == "Sách tôn giáo" && textBox2.Text == "PUB04")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách tôn giáo' AND PHid = 'PUB04'");
            }
            else if (comboBox1.Text == "Sách văn hoá xã hội" && textBox2.Text == "PUB04")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách văn hóa xã hội'AND PHid = 'PUB04'");
            }
            else if (comboBox1.Text == "Sách lịch sử" && textBox2.Text == "PUB04")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách lịch sử'AND PHid = 'PUB04'");
            }


            //PH05 and Type
            else if (comboBox1.Text == "Sách thiếu nhi" && textBox2.Text == "PUB05")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách thiếu nhi' AND PHid = 'PUB05'");
            }
            else if (comboBox1.Text == "Sách văn học viễn tưởng" && textBox2.Text == "PUB05")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách văn học viễn tưởng' AND PHid = 'PUB05'");
            }
            else if (comboBox1.Text == "Sách tiểu sử, tự truyện" && textBox2.Text == "PUB05")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách tiểu sử, tự truyện' AND PHid = 'PUB05'");
            }
            else if (comboBox1.Text == "Sách kinh dị, bí ẩn" && textBox2.Text == "PUB05")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách kinh dị, bí ẩn' AND PHid = 'PUB05'");
            }
            else if (comboBox1.Text == "Sách dạy nấu ăn" && textBox2.Text == "PUB05")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách dạy nấu ăn' AND PHid = 'PUB05'");
            }
            else if (comboBox1.Text == "Sách khoa học công nghệ" && textBox2.Text == "PUB05")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách khoa học công nghệ' AND PHid = 'PUB05'");
            }
            else if (comboBox1.Text == "Sách truyền cảm hứng" && textBox2.Text == "PUB05")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách truyền cảm hứng' AND PHid = 'PUB05'");
            }
            else if (comboBox1.Text == "Sách tôn giáo" && textBox2.Text == "PUB05")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách tôn giáo' AND PHid = 'PUB05'");
            }
            else if (comboBox1.Text == "Sách văn hoá xã hội" && textBox2.Text == "PUB05")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách văn hóa xã hội'AND PHid = 'PUB05'");
            }
            else if (comboBox1.Text == "Sách lịch sử" && textBox2.Text == "PUB05")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách lịch sử'AND PHid = 'PUB05'");
            }


            //PH06 and Type
            else if (comboBox1.Text == "Sách thiếu nhi" && textBox2.Text == "PUB06")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách thiếu nhi' AND PHid = 'PUB06'");
            }
            else if (comboBox1.Text == "Sách văn học viễn tưởng" && textBox2.Text == "PUB06")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách văn học viễn tưởng' AND PHid = 'PUB06'");
            }
            else if (comboBox1.Text == "Sách tiểu sử, tự truyện" && textBox2.Text == "PUB06")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách tiểu sử, tự truyện' AND PHid = 'PUB06'");
            }
            else if (comboBox1.Text == "Sách kinh dị, bí ẩn" && textBox2.Text == "PUB06")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách kinh dị, bí ẩn' AND PHid = 'PUB06'");
            }
            else if (comboBox1.Text == "Sách dạy nấu ăn" && textBox2.Text == "PUB06")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách dạy nấu ăn' AND PHid = 'PUB06'");
            }
            else if (comboBox1.Text == "Sách khoa học công nghệ" && textBox2.Text == "PUB06")

            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách khoa học công nghệ' AND PHid = 'PUB06'");
            }
            else if (comboBox1.Text == "Sách truyền cảm hứng" && textBox2.Text == "PUB06")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách truyền cảm hứng' AND PHid = 'PUB06'");
            }
            else if (comboBox1.Text == "Sách tôn giáo" && textBox2.Text == "PUB06")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách tôn giáo' AND PHid = 'PUB06'");
            }
            else if (comboBox1.Text == "Sách văn hoá xã hội" && textBox2.Text == "PUB06")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách văn hóa xã hội'AND PHid = 'PUB06'");
            }
            else if (comboBox1.Text == "Sách lịch sử" && textBox2.Text == "PUB06")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách lịch sử'AND PHid = 'PUB06'");
            }


            //PH07 and Type
            else if (comboBox1.Text == "Sách thiếu nhi" && textBox2.Text == "PUB07")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách thiếu nhi' AND PHid = 'PUB07'");
            }
            else if (comboBox1.Text == "Sách văn học viễn tưởng" && textBox2.Text == "PUB07")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách văn học viễn tưởng' AND PHid = 'PUB07'");
            }
            else if (comboBox1.Text == "Sách tiểu sử, tự truyện" && textBox2.Text == "PUB07")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách tiểu sử, tự truyện' AND PHid = 'PUB07'");
            }
            else if (comboBox1.Text == "Sách kinh dị, bí ẩn" && textBox2.Text == "PUB07")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách kinh dị, bí ẩn' AND PHid = 'PUB07'");
            }
            else if (comboBox1.Text == "Sách dạy nấu ăn" && textBox2.Text == "PUB07")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách dạy nấu ăn' AND PHid = 'PUB07'");
            }
            else if (comboBox1.Text == "Sách khoa học công nghệ" && textBox2.Text == "PUB07")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách khoa học công nghệ' AND PHid = 'PUB07'");
            }
            else if (comboBox1.Text == "Sách truyền cảm hứng" && textBox2.Text == "PUB07")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách truyền cảm hứng' AND PHid = 'PUB07'");
            }
            else if (comboBox1.Text == "Sách tôn giáo" && textBox2.Text == "PUB07")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách tôn giáo' AND PHid = 'PUB07'");
            }
            else if (comboBox1.Text == "Sách văn hoá xã hội" && textBox2.Text == "PUB07")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách văn hóa xã hội'AND PHid = 'PUB07'");
            }
            else if (comboBox1.Text == "Sách lịch sử" && textBox2.Text == "PUB07")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách lịch sử'AND PHid = 'PUB07'");
            }
            else if (comboBox1.Text == "Sách lịch sử" && textBox2.Text == "PUB07")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách lịch sử'AND PHid = 'PUB07'");
            }
            else if (comboBox1.Text == "Sách thiếu nhi")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách thiếu nhi'");
            }
            else if (comboBox1.Text == "Sách văn học viễn tưởng")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách văn học viễn tưởng'");
            }
            else if (comboBox1.Text == "Sách tiểu sử, tự truyện")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách tiểu sử, tự truyện'");
            }
            else if (comboBox1.Text == "Sách kinh dị, bí ẩn")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách kinh dị, bí ẩn'");
            }
            else if (comboBox1.Text == "Sách dạy nấu ăn")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách dạy nấu ăn'");
            }
            else if (comboBox1.Text == "Sách khoa học công nghệ")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách khoa học công nghệ'");
            }
            else if (comboBox1.Text == "Sách truyền cảm hứng")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách truyền cảm hứng'");
            }
            else if (comboBox1.Text == "Sách tôn giáo")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách tôn giáo'");
            }
            else if (comboBox1.Text == "Sách văn hoá xã hội")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách văn hóa xã hội'");
            }
            else if (comboBox1.Text == "Sách lịch sử")
            {
                dataGridView1.DataSource = Showdata("select * from book where type = N'Sách lịch sử'");
            }
            //book name
            else if (textBox1.Text == "Harry Potter và Hòn đá Phù thủy")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'Harry Potter và Hòn đá Phù thủy'");
            }
            else if (textBox1.Text == "Bí kíp làm cha mẹ")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'Bí kíp làm cha mẹ'");
            }
            else if (textBox1.Text == "Bác Gấu Đen và hai chú gấu con")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'Bác Gấu Đen và hai chú gấu con'");
            }
            else if (textBox1.Text == "Cây tre trăm đốt")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'Cây tre trăm đốt'");
            }
            else if (textBox1.Text == "The Bible")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'The Bible'");
            }
            else if (textBox1.Text == "The Quran")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'The Quran'");
            }
            else if (textBox1.Text == "Những nguyên tắc thành công")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'Những nguyên tắc thành công'");
            }
            else if (textBox1.Text == "Đường Mây Qua Xứ Sở Của Những Điều Nguy Hiểm")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'Đường Mây Qua Xứ Sở Của Những Điều Nguy Hiểm'");
            }
            else if (textBox1.Text == "Sapiens: A Brief History of Humankind")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'Sapiens: A Brief History of Humankind'");
            }
            else if (textBox1.Text == "Guns, Germs, and Steel: The Fates of Human Societies")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'Guns, Germs, and Steel: The Fates of Human Societies'");
            }
            else if (textBox1.Text == "The Rise and Fall of the Third Reich")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'The Rise and Fall of the Third Reich'");
            }
            else if (textBox1.Text == "The Diary of a Young Girl")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'The Diary of a Young Girl'");
            }
            else if (textBox1.Text == "A Peoples History of the United States")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'A Peoples History of the United States'");
            }
            else if (textBox1.Text == "Dune")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'Dune'");
            }
            else if (textBox1.Text == "1984")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'1984'");
            }
            else if (textBox1.Text == "Brave New World")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'Brave New World'");
            }
            else if (textBox1.Text == "I Am Zlatan Ibrahimovic")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'I Am Zlatan Ibrahimovic'");
            }
            else if (textBox1.Text == "The Autobiography of Pelé")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'The Autobiography of Pelé'");
            }
            else if (textBox1.Text == "My Story")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'My Story'");
            }
            else if (textBox1.Text == "The Autobiography")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'The Autobiography'");
            }
            else if (textBox1.Text == "Quiet Leadership: Winning Hearts, Minds and Matches")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'Quiet Leadership: Winning Hearts, Minds and Matches'");
            }
            else if (textBox1.Text == "Pep Confidential: The Inside Story of Pep Guardiola’s First Season at Bayern Munich")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'Pep Confidential: The Inside Story of Pep Guardiola’s First Season at Bayern Munich'");
            }
            else if (textBox1.Text == "The Autobiography of Roy Keane")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'The Autobiography of Roy Keane'");
            }
            else if (textBox1.Text == "Leading: Learning from Life and My Years at Manchester United")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'Leading: Learning from Life and My Years at Manchester United'");
            }
            else if (textBox1.Text == "Zidane: A 21st Century Portrait")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'Zidane: A 21st Century Portrait'");
            }
            else if (textBox1.Text == "The Autobiography of Alex Ferguson")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'The Autobiography of Alex Ferguson'");
            }
            else if (textBox1.Text == "The Shining")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'The Shining'");
            }
            else if (textBox1.Text == "The Da Vinci Code")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'The Da Vinci Code'");
            }
            else if (textBox1.Text == "House of Leaves")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'House of Leaves'");
            }
            else if (textBox1.Text == "The Professional Chef")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'The Professional Chef'");
            }
            else if (textBox1.Text == "Essentials of Classic Italian Cooking")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'Essentials of Classic Italian Cooking'");
            }
            else if (textBox1.Text == "How to Cook Everything")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'How to Cook Everything'");
            }
            else if (textBox1.Text == "The Flavor Bible: The Essential Guide to Culinary Creativity")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'The Flavor Bible: The Essential Guide to Culinary Creativity'");
            }
            else if (textBox1.Text == "The Food Lab: Better Home Cooking Through Science")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'The Food Lab: Better Home Cooking Through Science'");
            }
            else if (textBox1.Text == "Introduction to Algorithms")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'Introduction to Algorithms'");
            }
            else if (textBox1.Text == "The Art of Computer Programming")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'The Art of Computer Programming'");
            }
            else if (textBox1.Text == "The Selfish Gene")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'The Selfish Gene'");
            }
            else if (textBox1.Text == "The Innovators: How a Group of Hackers, Geniuses, and Geeks Created the Digital Revolution")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'The Innovators: How a Group of Hackers, Geniuses, and Geeks Created the Digital Revolution'");
            }
            else if (textBox1.Text == "Sapiens: A Brief History of Humankind")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'Sapiens: A Brief History of Humankind'");
            }
            else if (textBox1.Text == "The Structure of Scientific Revolutions")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'The Structure of Scientific Revolutions'");
            }
            else if (textBox1.Text == "The Gene: An Intimate History")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'The Gene: An Intimate History'");
            }
            else if (textBox1.Text == "The Alchemist")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'The Alchemist'");
            }
            else if (textBox1.Text == "The Power of Now")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'The Power of Now'");
            }
            else if (textBox1.Text == "The 7 Habits of Highly Effective People")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'The 7 Habits of Highly Effective People'");
            }
            else if (textBox1.Text == "Atomic Habits: An Easy & Proven Way to Build Good Habits & Break Bad Ones")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'Atomic Habits: An Easy & Proven Way to Build Good Habits & Break Bad Ones'");
            }
            else if (textBox1.Text == "Mans Search for Meaning")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'Mans Search for Meaning'");
            }
            else if (textBox1.Text == "The Magic of Thinking Big")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'The Magic of Thinking Big'");
            }
            else if (textBox1.Text == "The Happiness Advantage: How a Positive Brain Fuels Success in Work and Life")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'The Happiness Advantage: How a Positive Brain Fuels Success in Work and Life'");
            }
            else if (textBox1.Text == "Daring Greatly: How the Courage to Be Vulnerable Transforms the Way We Live, Love, Parent, and Lead")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'Daring Greatly: How the Courage to Be Vulnerable Transforms the Way We Live, Love, Parent, and Lead'");
            }
            else if (textBox1.Text == "Extreme Ownership: How U.S. Navy SEALs Lead and Win")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'Extreme Ownership: How U.S. Navy SEALs Lead and Win'");
            }
            else if (textBox1.Text == "Grit: The Power of Passion and Perseverance")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'Grit: The Power of Passion and Perseverance'");
            }
            else if (textBox1.Text == "The Subtle Art of Not Giving a F*ck: A Counterintuitive Approach to Living a Good Life")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'The Subtle Art of Not Giving a F*ck: A Counterintuitive Approach to Living a Good Life'");
            }
            else if (textBox1.Text == "Mindset: The New Psychology of Success")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'Mindset: The New Psychology of Success'");
            }
            else if (textBox1.Text == "Becoming")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book = N'Becoming'");
            }


            //book name
            else if (textBox1.Text == "A")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book Like N'A%'");
            }
            else if (textBox1.Text == "B")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book Like N'B%'");
            }
            else if (textBox1.Text == "C")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book Like N'C%'");
            }
            else if (textBox1.Text == "D")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book Like N'D%'");
            }
            else if (textBox1.Text == "E")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book Like N'E%'");
            }
            else if (textBox1.Text == "F")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book Like N'F%'");
            }
            else if (textBox1.Text == "G")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book Like N'G%'");
            }
            else if (textBox1.Text == "H")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book Like N'H%'");
            }
            else if (textBox1.Text == "I")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book Like N'I%'");
            }
            else if (textBox1.Text == "J")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book Like N'J%'");
            }
            else if (textBox1.Text == "K")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book Like N'K%'");
            }
            else if (textBox1.Text == "L")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book Like N'L%'");
            }
            else if (textBox1.Text == "M")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book Like N'M%'");
            }
            else if (textBox1.Text == "N")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book Like N'N%'");
            }
            else if (textBox1.Text == "O")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book Like N'O%'");
            }
            else if (textBox1.Text == "P")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book Like N'P%'");
            }
            else if (textBox1.Text == "Q")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book Like N'Q%'");
            }
            else if (textBox1.Text == "R")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book Like N'R%'");
            }
            else if (textBox1.Text == "S")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book Like N'S%'");
            }
            else if (textBox1.Text == "T")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book Like N'T%'");
            }
            else if (textBox1.Text == "U")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book Like N'U%'");
            }
            else if (textBox1.Text == "V")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book Like N'V%'");
            }
            else if (textBox1.Text == "W")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book Like N'W%'");
            }
            else if (textBox1.Text == "X")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book Like N'X%'");
            }
            else if (textBox1.Text == "Y")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book Like N'Y%'");
            }
            else if (textBox1.Text == "Z")
            {
                dataGridView1.DataSource = Showdata("select * from book where Book Like N'Z%'");
            }
            //PH
            else if (textBox2.Text == "PUB01")
            {
                dataGridView1.DataSource = Showdata("select * from book where PHid = 'PUB01'");
            }
            else if (textBox2.Text == "PUB02")
            {
                dataGridView1.DataSource = Showdata("select * from book where PHid = 'PUB02'");
            }
            else if (textBox2.Text == "PUB03")
            {
                dataGridView1.DataSource = Showdata("select * from book where PHid = 'PUB03'");
            }
            else if (textBox2.Text == "PUB04")
            {
                dataGridView1.DataSource = Showdata("select * from book where PHid = 'PUB04'");
            }
            else if (textBox2.Text == "PUB05")
            {
                dataGridView1.DataSource = Showdata("select * from book where PHid = 'PUB05'");
            }
            else if (textBox2.Text == "PUB06")
            {
                dataGridView1.DataSource = Showdata("select * from book where PHid = 'PUB06'");
            }
            else if (textBox2.Text == "PUB07")
            {
                dataGridView1.DataSource = Showdata("select * from book where PHid = 'PUB07'");
            }
        }
        #endregion

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    textBox4.Text = row.Cells[0].Value.ToString();
                    textBox1.Text = row.Cells[1].Value.ToString();
                    textBox2.Text = row.Cells[2].Value.ToString();
                    textBox5.Text = row.Cells[3].Value.ToString();
                    textBox3.Text = row.Cells[4].Value.ToString();
                    comboBox1.Text = row.Cells[5].Value.ToString();
                }
            }
        }
    }
}

