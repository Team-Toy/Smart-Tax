using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Tax_Calculator
{
    
    public partial class Form1_Personal_info : Form
    {
        public static string[] userInputs;

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

        public void UserInputs_Personal_info()
        {
            userInputs = new string[17];
            userInputs[0] = textBox1.Text.ToString();
            userInputs[0] = textBox1.Text.ToString();
            userInputs[0] = textBox1.Text.ToString();
            userInputs[0] = textBox1.Text.ToString();
            userInputs[0] = textBox1.Text.ToString();
            userInputs[0] = textBox1.Text.ToString();
            userInputs[0] = textBox1.Text.ToString();
            userInputs[0] = textBox1.Text.ToString();
            userInputs[0] = textBox1.Text.ToString();
        }
    }
}
