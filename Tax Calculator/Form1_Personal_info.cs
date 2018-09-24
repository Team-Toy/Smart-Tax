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
    
    public partial class Form1_Personal_info : Form
    {
        public Form1_Personal_info()
        {
            InitializeComponent();
        }
        
        private void Form1_Personal_info_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2_Salaries f = new Form2_Salaries();
            f.Show();
            
        }
    }
}
