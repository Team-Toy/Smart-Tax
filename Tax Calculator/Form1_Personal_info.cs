using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tax_Calculator
{
    
    public partial class Form1_Personal_info : Form
    {
        static Form1_Personal_info _instance;
        public static Form1_Personal_info GetInstance
        {
            get
            {
                if (_instance == null)
                    _instance = new Form1_Personal_info();
                return _instance;
            }
            
        }
        public static string[] pdfInputs;
        public Form1_Personal_info()
        {
           
            InitializeComponent();
            pdfInputs = new string[17];
        }

        private void Form1_Personal_info_Load(object sender, EventArgs e)
        {
            //label8.Text = dateTimePicker1.Text.ToString();
        }
        private void UserInputs_PersonInformation()
        {
            pdfInputs[0] = textBox1.Text.ToString();   // Name of Assessese
            pdfInputs[1] = textBox2.Text.ToString();   // National ID
            pdfInputs[2] = textBox3.Text.ToString();   // UTIN
            pdfInputs[3] = textBox4.Text.ToString();   // TIN
            pdfInputs[4] = textBox5.Text.ToString();   // Circle
            pdfInputs[5] = textBox6.Text.ToString();   // taxes zone
            pdfInputs[6] = textBox7.Text.ToString();   // Assessment year
            pdfInputs[7] = textBox8.Text.ToString();   // Name of employer
            pdfInputs[8] = textBox9.Text.ToString();   // Wife/husband name
            pdfInputs[9] = textBox10.Text.ToString();   // Father name
            pdfInputs[10] = textBox11.Text.ToString();   // Mother name
            pdfInputs[11] = dateTimePicker1.Text.ToString();  // Date of birth
            pdfInputs[12] = textBox12.Text.ToString();  // Present address
            pdfInputs[13] = textBox13.Text.ToString();  // Permanent address
            pdfInputs[14] = textBox14.Text.ToString();  // Office telephone
            pdfInputs[15] = textBox15.Text.ToString();  // Resident telephone
            pdfInputs[16] = textBox16.Text.ToString();  // VAT registration number
        }
        private void button1_Click(object sender, EventArgs e)
        {
            UserInputs_PersonInformation();

            Form2_Salaries f =  Form2_Salaries.GetInstance;
            this.Hide(); // form1 hide
            f.Show();
            
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox3.Focus();
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox4.Focus();
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox5.Focus();
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox6.Focus();
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox7.Focus();
            }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox8.Focus();
            }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox9.Focus();
            }
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox10.Focus();
            }
        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox11.Focus();
            }
        }

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dateTimePicker1.Focus();
            }
        }

        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {

            textBox12.Focus();

        }

        private void textBox12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox13.Focus();
            }
        }

        private void textBox13_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox14.Focus();
            }
        }

        private void textBox14_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox15.Focus();
            }
        }

        private void textBox15_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox16.Focus();
            }
        }

        private void Form1_Personal_info_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (e.CloseReason == CloseReason.UserClosing)
            {
                 //application Closing by cross cursor;
                Application.Exit();
            }
           
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {   
            // national ID
            // only accept digit upto 13 character
            if ((!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) || (e.KeyChar == '.') || (sender as TextBox).Text.Length >= 13)
            {
                e.Handled = true;
            }
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            // UTIN
            // only accept digit upto 12 character
            if ((!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) || (e.KeyChar == '.') || (sender as TextBox).Text.Length >= 12)
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            // TIN
            // only accept digit upto 12 character
            if ((!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) || (e.KeyChar == '.') || (sender as TextBox).Text.Length >= 12)
            {
                e.Handled = true;
            }
        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            // telephone
            if ((!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) || (e.KeyChar == '.') || (sender as TextBox).Text.Length >= 15)
            {
                e.Handled = true;
            }
        }

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            // telephone
            if ((!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) || (e.KeyChar == '.') || (sender as TextBox).Text.Length >= 15)
            {
                e.Handled = true;
            }
        }

        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {
            // VAT no
            if ((!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) || (e.KeyChar == '.') )
            { 
                e.Handled = true;
            }
        }
    }
}
