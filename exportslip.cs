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
using System.Net;
using System.Security.Cryptography.Xml;

namespace HeThongSach
{
    public partial class ExportSlip : Form
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

        public SqlCommand Execute(string sql)
        {
            Connect();
            SqlCommand cm = new SqlCommand(sql, cn);
            cm.ExecuteNonQuery();
            return cm;
            Disconnect();
        }



        public ExportSlip()
        {
            InitializeComponent();
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
        private void button2_Click(object sender, EventArgs e)//Print
        {

            MessageBox.Show(Message, title);
            SqlCommand cm = new SqlCommand();
            cm = cn.CreateCommand();
            cm.CommandText = "insert into export values('" + id.Text + "','"
                + agentid.Text + "','" + phone.Text + "',N'" + add.Text + "',N'" + dname.Text + "','" + bookid.Text + "','" + quantity.Text + "','"
                + price.Text +"','" + DOD.Text + "','" + SED.Text + "','" + total.Text + "')";
            cm.ExecuteNonQuery();

        }
        /*
         exportid VARCHAR(15) PRIMARY KEY,
        agentid VARCHAR(15),
	    agentphone VARCHAR(12),
	    agentaddr NVARCHAR(50),
	    Deliver NVARCHAR(50),
	    bookid VARCHAR(15),
	    quantity int,
	    price int,
	    DOD date,
            SID date
        FOREIGN KEY(bookid) REFERENCES book(bookid),
	    FOREIGN KEY(agentid) REFERENCES AGENT(agentid)*/
        private void button1_Click(object sender, EventArgs e)//Delete
        {
            dr = MessageBox.Show("Are you sure deleting?", "Notification", MessageBoxButtons.YesNo);
            switch (dr)
            {
                case DialogResult.Yes:
                    agentid.Text = "";
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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void ExportSlip_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(str);
            cn.Open();
        }
    }
}
