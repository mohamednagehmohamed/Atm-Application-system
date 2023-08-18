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
    public partial class DEPOSIT : Form
    {
        SpeechSynthesizer ssynthize = new SpeechSynthesizer();
        public DEPOSIT()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.Hide();
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int oldbalance, newbalance;
        private void getbalance()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select balance from Accounttbl where AccNum='" + accnum + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            oldbalance = Convert.ToInt32( dt.Rows[0][0].ToString());
            con.Close();
            //return dt;
        }
        private void addtransaction() {
            try {
                con.Open();
                string query = "insert into Transactiontbl values('"+accnum+"','"+deptype+"','"+txtdeposit.Text+"','"+DateTime.Today.Date.ToString()+"')";
                SqlCommand sqlcmd = new SqlCommand(query,con);
                sqlcmd.ExecuteNonQuery();
                MessageBox.Show("Transaction Added");
                con.Close();
            }
            catch(Exception ex){
                MessageBox.Show(ex.Message);
            }
        }
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\el mahdi pc\Documents\atm database.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        string accnum = Login.Accnumber;
        string deptype = "Deposit";
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtdeposit.Text.Trim() == "" || Convert.ToInt32(txtdeposit.Text) <= 0)
            {
                MessageBox.Show("Not Value Added, please Enter Correct value");
            }
            else {
                
                newbalance = oldbalance + Convert.ToInt32(txtdeposit.Text);
                try {
                    con.Open();
                    string query = "update Accounttbl set balance='" + newbalance + "'where AccNum='"+accnum+"'";
                    SqlCommand sqlcmd = new SqlCommand(query,con);
                    sqlcmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully Deposit");
                    ssynthize.SpeakAsync("Successfully Deposit, Your Balance Is"+newbalance.ToString());
                    con.Close();
                    addtransaction();
                    Home home = new Home();
                    home.ShowDialog();
                    this.Hide();
                }
                catch(Exception ex){
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DEPOSIT_Load(object sender, EventArgs e)
        {
            getbalance();
            lbldeposit.Text = "RS " + oldbalance.ToString();
        }
    }
}
