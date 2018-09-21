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
    public partial class Form4_SatementOfSalary : Form
    {
        //declared total for summation from serial no 1 to serial no 9
        private static double totalTaxableIncome = 0.0;
        public Form4_SatementOfSalary()
        {
            InitializeComponent();
        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form4_SatementOfSalary_Load(object sender, EventArgs e)
        {
            // make all text boxt zero
            madeAllTextBoxZero();
            //taking total taxable income and showing in label51
            label51.Text = Form2_Salaries.netTaxableIncome.ToString();
            //taking total taxable exempted income and showing in label52
            label52.Text = Form2_Salaries.totalTaxExtempted.ToString();

            totalTaxableIncome += Form2_Salaries.netTaxableIncome;


            label39.Text = "0.0";
            label40.Text= "0.0";
        }
        public void madeAllTextBoxZero()
        {
            
            textBox2.Text = "0.0";
            textBox3.Text = "0.0";
            textBox4.Text = "0.0";
            textBox5.Text = "0.0";
            textBox6.Text = "0.0";
            textBox7.Text = "0.0";
            textBox8.Text = "0.0";
            textBox9.Text = "0.0";
            textBox10.Text = "0.0";
            textBox11.Text = "0.0";
            textBox12.Text = "0.0";
            textBox13.Text = "0.0";
            textBox14.Text = "0.0";
            textBox17.Text = "0.0";

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                totalTaxableIncome += double.Parse(textBox2.Text.ToString());
                //
                label39.Text = totalTaxableIncome.ToString();
                label40.Text = totalTaxableIncome.ToString();
                //focusing "income from house property" text field
                textBox3.Focus();
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                totalTaxableIncome += double.Parse(textBox3.Text.ToString());
                //
                label39.Text = totalTaxableIncome.ToString();
                label40.Text = totalTaxableIncome.ToString();
                //focusing "agricultural income" text field
                textBox4.Focus();
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                totalTaxableIncome += double.Parse(textBox4.Text.ToString());
                //
                label39.Text = totalTaxableIncome.ToString();
                label40.Text = totalTaxableIncome.ToString();
                //focusing "Income from Business or profession" text field
                textBox5.Focus();
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                totalTaxableIncome += double.Parse(textBox5.Text.ToString());
                //
                label39.Text = totalTaxableIncome.ToString();
                label40.Text = totalTaxableIncome.ToString();
                //focusing "Share of proft in a firm" text field
                textBox6.Focus();
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                totalTaxableIncome += double.Parse(textBox6.Text.ToString());
                //
                label39.Text = totalTaxableIncome.ToString();
                label40.Text = totalTaxableIncome.ToString();
                //focusing "Income of spouse or minor child as applicable" text field
                textBox7.Focus();
            }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                totalTaxableIncome += double.Parse(textBox7.Text.ToString());
                //
                label39.Text = totalTaxableIncome.ToString();
                label40.Text = totalTaxableIncome.ToString();
                //focusing "Capital Gains" text field
                textBox8.Focus();
            }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                totalTaxableIncome += double.Parse(textBox8.Text.ToString());
                //
                label39.Text = totalTaxableIncome.ToString();
                label40.Text = totalTaxableIncome.ToString();
                //focusing "Income from other source" text field
                textBox9.Focus();
            }
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                totalTaxableIncome += double.Parse(textBox9.Text.ToString());
                //
                label39.Text = totalTaxableIncome.ToString();
                label40.Text = totalTaxableIncome.ToString();
                //focusing "foreign income" text field
                textBox9.Focus();
            }
        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //totalTaxableIncome = total + foreignIncome
                totalTaxableIncome += double.Parse(textBox10.Text.ToString());
                //showing total income by label
                label40.Text = totalTaxableIncome.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_PayableTaxCalculator f = new Form_PayableTaxCalculator();
            f.Show();
        }
        private double CalTaxRevate(double taxableIncome)
        {
            //base case
            if (taxableIncome == 0) return 0.0; //if no taxable income return 0
            double y = (taxableIncome * 0.25);  //y = taxableIncome*25%
            double z = 15000000;    //absolute maximum amount

            if (y < z)
            {
                if (totalInvestment < y) return totalInvestment;
                else if (y < totalInvestment) return y;
            }
            else if (z < y)
            {
                if (totalInvestment < z) return totalInvestment;
                else if (z < totalInvestment) return z;
            }
            return 0.0;
        }
    }
}
