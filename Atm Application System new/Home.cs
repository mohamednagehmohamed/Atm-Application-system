using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Speech.Synthesis;
namespace Atm_Application_System_new
{
    public partial class Home : Form
    {
        SpeechSynthesizer ssinthize = new SpeechSynthesizer();
        public Home()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // this.Close();
            WITHDRAW withdaw = new WITHDRAW();
            withdaw.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //this.Close();
            Mini_Statement mini = new Mini_Statement();
            mini.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           // this.Close();
            BALANCE balance = new BALANCE();
            balance.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Close();
            DEPOSIT deposit = new DEPOSIT();
            deposit.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //this.Close();
            FAST_CASH first = new FAST_CASH();
            first.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //this.Close();
            CHANGE_PIN change = new CHANGE_PIN();
            change.Show();
            this.Hide();
        }
        public static string Accnumber;
        private void Home_Load(object sender, EventArgs e)
        {
            accn.Text =  "Accout Number  :"+Login.Accnumber;
            Accnumber = Login.Accnumber;
            //ssinthize.SpeakAsync("Welcome To Home Page Select Transaction");
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //this.Close();
            /*Login log = new Login();
            log.ShowDialog();
            this.Hide();*/
            Application.Exit();
        }
    }
}
