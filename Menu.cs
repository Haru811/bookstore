using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongSach
{
    public partial class Menu : Form
    {
        ImportSlip ImSlip;
        ExportSlip ExSlip;
        Statistic Sta;
        PublishingHouseInfo Pub;
        BookInfo BookI;
        BookAgentInfo BookA;
        Staff Staff;
        ThongCute Thong;
        Menu Admin;
        
        public Menu()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)//Book Agent Info
        {
            BookA = new BookAgentInfo();
            BookA.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)//Publishing House Info
        {
            Pub = new PublishingHouseInfo();
            Pub.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)//Import Slip
        {
            ImSlip = new ImportSlip();
            ImSlip.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)//Export Slip
        {
            ExSlip = new ExportSlip();
            ExSlip.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)//Statistic
        {
            Sta = new Statistic();
            Sta.Show();
            
        }

        private void button4_Click(object sender, EventArgs e)//Book Info
        {
            BookI = new BookInfo();
            BookI.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)//Staff
        {
            Staff = new Staff();
            Staff.Show();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)//Thong cute
        {
            Thong = new ThongCute();
            Thong.Show();
            
        }
    }
}
