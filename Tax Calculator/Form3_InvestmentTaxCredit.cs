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
    
    public partial class Form3_InvestmentTaxCredit : Form
    {
        public static double sum = 0.0;
        public Form3_InvestmentTaxCredit()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            textBox1.Text = "0.0";
            textBox2.Text = "0.0";
            textBox3.Text = "0.0";
            textBox4.Text = "0.0";
            textBox5.Text = "0.0";
            textBox6.Text = "0.0";
            textBox7.Text = "0.0";
            textBox8.Text = "0.0";
            textBox9.Text="0.0";
            textBox10.Text = "0.0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //calling calculation method to show total investment result by label
            label12.Text=(InvestmentTaxCalculate()).ToString();
        }

        private double InvestmentTaxCalculate()
        {
            double tempTotal = 0.0;
            tempTotal = double.Parse(textBox1.Text.ToString()) +
                        double.Parse(textBox2.Text.ToString()) +
                        double.Parse(textBox3.Text.ToString()) +
                        double.Parse(textBox4.Text.ToString()) +
                        double.Parse(textBox5.Text.ToString()) +
                        double.Parse(textBox6.Text.ToString()) +
                        double.Parse(textBox7.Text.ToString()) +
                        double.Parse(textBox8.Text.ToString()) +
                        double.Parse(textBox9.Text.ToString()) +
                        double.Parse(textBox10.Text.ToString());
            sum = tempTotal;
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

        
    }
}
