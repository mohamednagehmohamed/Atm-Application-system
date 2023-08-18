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
    public partial class WITHDRAW : Form
    {
        SpeechSynthesizer ssynthize = new SpeechSynthesizer();
        public WITHDRAW()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.Close();
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\el mahdi pc\Documents\atm database.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        string accnumber = Login.Accnumber;
        string withdrawtype = "WithDraw";
        int oldbal,newbal;
        private void getbalance() {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select balance from Accounttbl where AccNum='" + accnumber + "'",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            oldbal = Convert.ToInt32(dt.Rows[0][0].ToString());
            con.Close();
        }
        private void addtransaction()
        {
            try
            {
                con.Open();
                string query = "insert into Transactiontbl values('" + accnumber + "','" + withdrawtype + "','" + txtwithdraw.Text + "','" + DateTime.Today.Date.ToString() + "')";
                SqlCommand sqlcmd = new SqlCommand(query, con);
                sqlcmd.ExecuteNonQuery();
                MessageBox.Show("Transaction Added");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtwithdraw.Text.Trim() == "" || Convert.ToInt32(txtwithdraw.Text) < 0)
            {
                MessageBox.Show("Not Value Added, please Enter Correct value");
            }
                else if(Convert.ToInt32(txtwithdraw.Text)>oldbal){
                    MessageBox.Show("Balance Cant Be Negative");
                }
            else {
                newbal = oldbal - Convert.ToInt32(txtwithdraw.Text);
                try {
                    con.Open();
                    string query = "update Accounttbl set balance='" + newbal + "'where AccNum='"+accnumber+"'";
                    SqlCommand sqlcmd = new SqlCommand(query,con);
                    sqlcmd.ExecuteNonQuery();
                    MessageBox.Show("Withdraw Successfully");
                    ssynthize.SpeakAsync("Successfully Withdarw, Your Balance Is" + newbal.ToString());
                    con.Close();
                    addtransaction();
                }
                catch(Exception ex){
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void WITHDRAW_Load(object sender, EventArgs e)
        {
            getbalance();
            lblwithdraw.Text = "RS "+oldbal.ToString();
        }
    }
}
