using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Speech.Synthesis;
namespace Atm_Application_System_new
{
    public partial class Login : Form
    {
        SpeechSynthesizer ssinthize = new SpeechSynthesizer();
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\el mahdi pc\Documents\atm database.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        public Login()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.Close();
            accountcs ACCOUNT = new accountcs();
            ACCOUNT.Show();
            this.Hide();
        }
        public static string Accnumber;
        private void button1_Click(object sender, EventArgs e)
        {
            if (Accnum.Text.Trim() != "" && pin.Text.Trim() != "")
            {
                con.Open();
                //string query = "select count(*) from Accounttbl where AccNum='" + Accnum.Text + "'and pin='"+pin.Text+"";
                SqlDataAdapter sda = new SqlDataAdapter("select count(*) from Accounttbl where AccNum='"+Accnum.Text+"'and pin='"+pin.Text+"'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    this.Hide();
                    Accnumber = Accnum.Text;
                    Home home = new Home();
                    home.Show();
                    //Accnum.Text = Accnumber;
                    ssinthize.SpeakAsync("Welcome To Home Page Select Transaction");
                }
                else {
                    MessageBox.Show("In Correct Pin");
                }
                con.Close();
            }
            else {
                MessageBox.Show("Please Fill All Data","Atm System",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
