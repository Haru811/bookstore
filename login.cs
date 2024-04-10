namespace HeThongSach
{
    public partial class Login : Form
    {
        Menu Admin;
        ExportSlip Exp;
        ImportSlip Imp;
        Statistic Sta;

        string Message = "Incorrect Information! Try again.";
        string title = "Error";

        public Login()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


        private void Enter_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin" && textBox2.Text == "1")
            {
                Admin = new Menu();
                Admin.Show();
            }
            else if (textBox1.Text == "export" && textBox2.Text == "1")
            {
                Exp = new ExportSlip();
                Exp.Show();
            }
            else if (textBox1.Text == "import" && textBox2.Text == "1")
            {
                Imp = new ImportSlip();
                Imp.Show();
            }
            else if (textBox1.Text == "statistic" && textBox2.Text == "1")
            {
                Sta = new Statistic();
                Sta.Show();
            }
            else
                MessageBox.Show(Message, title);
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
