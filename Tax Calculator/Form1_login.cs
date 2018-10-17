using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tax_Calculator
{
    public partial class Form1_login : MetroFramework.Forms.MetroForm
    {
        static Form1_login _instance;
        public static Form1_login GetInstance
        {
            get
            {
                if (_instance == null)
                    _instance = new Form1_login();
                return _instance;
            }

        }

        public Form1_login()
        {
            InitializeComponent();
        }

        private void creditsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form_Credits f = Form_Credits.GetInstance;  //creating Form_Credits object
            f.Show();  //show Form_Credits window
        }

        private void btSign_in_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1_Personal_info f = Form1_Personal_info.GetInstance;
            f.Show();
        }
    }
}
