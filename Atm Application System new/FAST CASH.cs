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
    public partial class FAST_CASH : Form
    {
        public FAST_CASH()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            //this.Close();
            Home home = new Home();
            home.Show();
            this.Hide();
        }
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\el mahdi pc\Documents\atm database.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        int oldbal, newbal;
        string accnumber = Login.Accnumber;
        string firstcash = "First Cash";
        private void getbalance()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select balance from Accounttbl where AccNum='" + accnumber + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            oldbal = Convert.ToInt32(dt.Rows[0][0].ToString());
            con.Close();
        }
        private void addtransaction1()
        {
            try
            {
                con.Open();
                string query = "insert into Transactiontbl values('" + accnumber + "','" + firstcash + "','" + 100 + "','" + DateTime.Today.Date.ToString() + "')";
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
        private void addtransaction2()
        {
            try
            {
                con.Open();
                string query = "insert into Transactiontbl values('" + accnumber + "','" + firstcash + "','" + 200 + "','" + DateTime.Today.Date.ToString() + "')";
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
        private void addtransaction3()
        {
            try
            {
                con.Open();
                string query = "insert into Transactiontbl values('" + accnumber + "','" + firstcash + "','" + 500 + "','" + DateTime.Today.Date.ToString() + "')";
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
        private void addtransaction4()
        {
            try
            {
                con.Open();
                string query = "insert into Transactiontbl values('" + accnumber + "','" + firstcash + "','" + 1000 + "','" + DateTime.Today.Date.ToString() + "')";
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
        private void addtransaction5()
        {
            try
            {
                con.Open();
                string query = "insert into Transactiontbl values('" + accnumber + "','" + firstcash + "','" + 2000 + "','" + DateTime.Today.Date.ToString() + "')";
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
        private void addtransaction6()
        {
            try
            {
                con.Open();
                string query = "insert into Transactiontbl values('" + accnumber + "','" + firstcash + "','" + 10000 + "','" + DateTime.Today.Date.ToString() + "')";
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
            newbal = oldbal - 100;
            if (newbal <= 0)
            {
                MessageBox.Show("Please Enter Valid Value");
            }
            else {
                try
                {
                    con.Open();
                    string query = "update Accounttbl set balance='" + newbal + "'where AccNum='" + accnumber + "'";
                    SqlCommand sqlcmd = new SqlCommand(query, con);
                    sqlcmd.ExecuteNonQuery();
                    MessageBox.Show(" Successfully First Cash");
                    con.Close();
                    addtransaction1();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
           
        }

        private void FAST_CASH_Load(object sender, EventArgs e)
        {
            getbalance();
            lblbalance.Text = "Available Balance :"+oldbal.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            newbal = oldbal - 500;
            if (newbal <= 0)
            {
                MessageBox.Show("Please Enter Valid Value");
            }
            else {
                try
                {
                    con.Open();
                    string query = "update Accounttbl set balance='" + newbal + "'where AccNum='" + accnumber + "'";
                    SqlCommand sqlcmd = new SqlCommand(query, con);
                    sqlcmd.ExecuteNonQuery();
                    MessageBox.Show(" Successfully First Cash");
                    con.Close();
                    addtransaction3();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            newbal = oldbal - 2000;
            if (newbal <= 0)
            {
                MessageBox.Show("Please Enter Valid Value");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "update Accounttbl set balance='" + newbal + "'where AccNum='" + accnumber + "'";
                    SqlCommand sqlcmd = new SqlCommand(query, con);
                    sqlcmd.ExecuteNonQuery();
                    MessageBox.Show(" Successfully First Cash");
                    con.Close();
                    addtransaction5();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            newbal = oldbal - 200;
            if (newbal <= 0)
            {
                MessageBox.Show("Please Enter Valid Value");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "update Accounttbl set balance='" + newbal + "'where AccNum='" + accnumber + "'";
                    SqlCommand sqlcmd = new SqlCommand(query, con);
                    sqlcmd.ExecuteNonQuery();
                    MessageBox.Show(" Successfully First Cash");
                    con.Close();
                    addtransaction2();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            newbal = oldbal - 1000;
            if (newbal <= 0)
            {
                MessageBox.Show("Please Enter Valid Value");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "update Accounttbl set balance='" + newbal + "'where AccNum='" + accnumber + "'";
                    SqlCommand sqlcmd = new SqlCommand(query, con);
                    sqlcmd.ExecuteNonQuery();
                    MessageBox.Show(" Successfully First Cash");
                    con.Close();
                    addtransaction4();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            newbal = oldbal - 10000;
            if (newbal <= 0)
            {
                MessageBox.Show("Please Enter Valid Value");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "update Accounttbl set balance='" + newbal + "'where AccNum='" + accnumber + "'";
                    SqlCommand sqlcmd = new SqlCommand(query, con);
                    sqlcmd.ExecuteNonQuery();
                    MessageBox.Show(" Successfully First Cash");
                    con.Close();
                    addtransaction6();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
