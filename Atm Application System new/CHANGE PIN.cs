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
    public partial class CHANGE_PIN : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\el mahdi pc\Documents\atm database.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        public CHANGE_PIN()
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
        public string acc = Login.Accnumber;
        private void button1_Click(object sender, EventArgs e)
        {
            if(newpintxt.Text.Trim()==""||confirmpintxt.Text.Trim()==""){
                MessageBox.Show("Please Fil All Data, Missing Data");
            }
            else if (newpintxt.Text != confirmpintxt.Text)
            {
                MessageBox.Show("The Tow Pin Arnt Identical");
            }
            else {
                try {
                    con.Open();
                    string query = "update Accounttbl set pin=" + newpintxt.Text + "where AccNum="+acc+"";
                    SqlCommand sqlcmd = new SqlCommand(query,con);
                    sqlcmd.ExecuteNonQuery();
                    MessageBox.Show("Pin Updated.......");
                    con.Close();
                }
                catch(Exception ex){
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
