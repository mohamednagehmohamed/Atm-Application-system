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
    public partial class load : Form
    {
        SpeechSynthesizer ssinthize = new SpeechSynthesizer();
        int x;
        int socend = 0;
        public load()
        {
            InitializeComponent();
            x = progressBar1.Value;
            ssinthize.SelectVoiceByHints(VoiceGender.Female);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void load_Load(object sender, EventArgs e)
        {
            timer1.Interval = 500;
            timer1.Start();
            ssinthize.SpeakAsync("Welcome To ATM Application");

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            socend++;
            x += 10;
            progressBar1.Value = x;
            if (socend >= 10)
            {
                timer1.Stop();
                Login log = new Login();
                log.Show();
                this.Hide();
                ssinthize.SpeakAsync("Login Form");
               // this.Close();
            }
        }
    }
}
