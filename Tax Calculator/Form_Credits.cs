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
    public partial class Form_Credits : Form
    {
        static Form_Credits _instance;
        public static Form_Credits GetInstance  //making singleton instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Form_Credits();
                return _instance;
            }

        }

        public Form_Credits()
        {
            InitializeComponent();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {    // hide setting form window
                //Close();
                this.Hide();
            }
        }

        private void Form3_Activated(object sender, EventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Enabled = false;
            }
        }

        private void Form3_Deactivate(object sender, EventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Enabled = true;
            }
        }
    }
}
