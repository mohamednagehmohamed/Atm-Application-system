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
    public partial class accountcs : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\el mahdi pc\Documents\atm database.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        public accountcs()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int bal=0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (Accnumtb.Text == "" || nametb.Text == "" || fnametb.Text == "" || addresstb.Text == "" || phonetb.Text == "" || pintb.Text == "" || occupationtb.Text == "" )
            {
                MessageBox.Show("Please fill all data", "Atm Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else {
                try {
                    con.Open();
                    string query = "insert into Accounttbl values('" + Accnumtb.Text + "','" + nametb.Text + "','" + fnametb.Text + "','" + dop.Value.Date + "','" + phonetb.Text + "','" + addresstb.Text + "','" + educationtb.SelectedItem.ToString() + "','" + occupationtb.Text + "'," + pintb.Text + "," + bal + ")";
                    SqlCommand cmd = new SqlCommand(query,con);
                    cmd.ExecuteNonQuery();
                    //con.Close();
                    MessageBox.Show("Successfully Addition");
                    
                    con.Close();
                   // this.Hide();
                    Login LOG = new Login();
                    LOG.Show();
                    this.Hide();
                }
                catch(Exception ex){
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.Hide();
            Login LOG = new Login();
            LOG.Show();
            this.Hide();
        }
    }
}
