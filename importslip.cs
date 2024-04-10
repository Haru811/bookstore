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
    public partial class ImportSlip : Form
    {

        string Message = "Print Complete!";
        string title = "Notification!";
        DialogResult dr;

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
        /*  void Display()
          {
              cn.Close();
              cn.Open();
              SqlCommand cm = cn.CreateCommand();
              cm.CommandText = "select * from import";
              SqlDataAdapter adap = new SqlDataAdapter();
              adap.SelectCommand = cm;
              dt.Clear();
              adap.Fill(dt);
              dataGridView1.DataSource = dt;
          }
         */

        public SqlCommand Execute(string sql)
        {
            Connect();
            SqlCommand cm = new SqlCommand(sql, cn);
            cm.ExecuteNonQuery();
            return cm;
            Disconnect();
        }


        public ImportSlip()
        {
            InitializeComponent();
            // Attach event handlers
            quantity.TextChanged += RecalculateTotal;
            price.TextChanged += RecalculateTotal;
        }
        private void RecalculateTotal(object sender, EventArgs e)
        {
            // Parse quantity and price, then calculate total
            if (int.TryParse(quantity.Text, out int quantityValue) && int.TryParse(price.Text, out int priceValue))
            {
                int totalValue = quantityValue * priceValue;
                total.Text = totalValue.ToString();
            }
            else
            {
                total.Text = ""; // Or any other handling for invalid input
            }
        }
        private void ReturnIm_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//Print
        {
            MessageBox.Show(Message, title);
            SqlCommand cm = new SqlCommand();
            cm = cn.CreateCommand();
            cm.CommandText = "insert into import values('" + id.Text + "','"
                + phid.Text + "','" + phone.Text + "',N'" + add.Text + "',N'" + dname.Text + "','" + bookid.Text + "','" + quantity.Text + "','" + price.Text + "','"
                + DOD.Text + "','" + SED.Text + "','" + total.Text + "')";
            cm.ExecuteNonQuery();

        }

        private void button2_Click(object sender, EventArgs e)//Delete
        {
            dr = MessageBox.Show("Are you sure about deleting?", "Notification", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                    phid.Text = "";
                    phone.Text = "";
                    add.Text = "";
                    dname.Text = "";
                    DOD.Text = "";
                    bookid.Text = "";
                    quantity.Text = "";
                    price.Text = "";
                    total.Text = "";
                    SED.Text = "";
                    id.Text = "";
                    break;
            }
        }
        /*
        importid VARCHAR (15) PRIMARY KEY,
        PHid VARCHAR (15),
        PHphone VARCHAR (12),
        PHaddress NVARCHAR (50),
        Deliver NVARCHAR (50),
        bookid VARCHAR (15),
        quantity int,
        price int,
        DOD date,
        SED date
        FOREIGN KEY (bookid) REFERENCES book (bookid),
        FOREIGN KEY (PHid) REFERENCES PHs (PHid)

        phid phone add dname DOD bookid quantity SED id*/

        private void ImportSlip_Load(object sender, EventArgs e)
        {

            cn = new SqlConnection(str);
            cn.Open();
            /* Display();*/
        }

        private void total_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
