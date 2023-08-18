using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Atm_Application_System_new
{
    public partial class BALANCE : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\el mahdi pc\Documents\atm database.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        public BALANCE()
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
            Home home = new Home();
            home.Show();
            this.Hide();
        }
        //public string acc = Login.Accnumber;
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void getbalance() {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select balance from Accounttbl where AccNum='" + accountnumberlbl.Text+ "'",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            balancelbl.Text = dt.Rows[0][0].ToString();
            con.Close();
            //return dt;
        }
        private void BALANCE_Load(object sender, EventArgs e)
        {
            accountnumberlbl.Text = Home.Accnumber;
            getbalance();
        }
    }
}
