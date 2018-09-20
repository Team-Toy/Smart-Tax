﻿using System;
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
    
    public partial class Form3_InvestmentTaxCredit : Form
    {
        public static double sum = 0.0;
        // investment documents
        public static string document1 = "";
        public static string document2 = "";
        public static string document3 = "";
        public static string document4 = "";
        public static string document5 = "";
        public static string document6 = "";
        public static string document7 = "";
        public static string document8 = "";
        public static string document9 = "";
        public static string document10 = "";
        public Form3_InvestmentTaxCredit()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            madeAllTextBoxZero();
        }
        public void madeAllTextBoxZero()
        {
            textBox1.Text = "0.0";
            textBox2.Text = "0.0";
            textBox3.Text = "0.0";
            textBox4.Text = "0.0";
            textBox5.Text = "0.0";
            textBox6.Text = "0.0";
            textBox7.Text = "0.0";
            textBox8.Text = "0.0";
            textBox9.Text = "0.0";
            textBox10.Text = "0.0";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //calling calculation method to show total investment result by label
            label12.Text=(InvestmentTaxCalculate()).ToString();
        }

        private double InvestmentTaxCalculate()
        {
            sum =   double.Parse(textBox1.Text.ToString()) +
                    double.Parse(textBox2.Text.ToString()) +
                    double.Parse(textBox3.Text.ToString()) +
                    double.Parse(textBox4.Text.ToString()) +
                    double.Parse(textBox5.Text.ToString()) +
                    double.Parse(textBox6.Text.ToString()) +
                    double.Parse(textBox7.Text.ToString()) +
                    double.Parse(textBox8.Text.ToString()) +
                    double.Parse(textBox9.Text.ToString()) +
                    double.Parse(textBox10.Text.ToString());
           
            return sum;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                label12.Text = (InvestmentTaxCalculate()).ToString();
                textBox2.Focus();
            }
            
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                label12.Text = (InvestmentTaxCalculate()).ToString();
                textBox3.Focus();
            }
        }
        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                label12.Text = (InvestmentTaxCalculate()).ToString();
                textBox4.Focus();
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                label12.Text = (InvestmentTaxCalculate()).ToString();
                textBox5.Focus();
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                label12.Text = (InvestmentTaxCalculate()).ToString();
                textBox6.Focus();
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                label12.Text = (InvestmentTaxCalculate()).ToString();
                textBox7.Focus();
            }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                label12.Text = (InvestmentTaxCalculate()).ToString();
                textBox8.Focus();
            }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                label12.Text = (InvestmentTaxCalculate()).ToString();
                textBox9.Focus();
            }
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                label12.Text = (InvestmentTaxCalculate()).ToString();
                textBox10.Focus();
            }
        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                label12.Text = (InvestmentTaxCalculate()).ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //hiding investment tex credit form
            this.Hide();
            Form4_SatementOfSalary f = new Form4_SatementOfSalary();
            //showing "Satement Of Salary" form
            f.Show();        
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                document1 = textBox11.Text.ToString();
                textBox12.Focus();
            }
        }

        private void textBox12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                document2 = textBox12.Text.ToString();
                textBox13.Focus();
            }
        }

        private void textBox13_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                document3 = textBox13.Text.ToString();
                textBox14.Focus();
            }
        }

        private void textBox14_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                document4 = textBox14.Text.ToString();
                textBox15.Focus();
            }
        }

        private void textBox15_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                document5 = textBox15.Text.ToString();
                textBox16.Focus();
            }
        }
        private void textBox16_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                document6 = textBox16.Text.ToString();
                textBox17.Focus();
            }
        }
        private void textBox17_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                document7 = textBox17.Text.ToString();
                textBox18.Focus();
            }
        }
        private void textBox18_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                document8 = textBox18.Text.ToString();
                textBox19.Focus();
            }
        }
        private void textBox19_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                document9 = textBox19.Text.ToString();
                textBox20.Focus();
            }
        }
        private void textBox20_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                document10 = textBox20.Text.ToString();
            }
        }

        

        

        

        
    }
}
