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
    public partial class Form4_SatementOfSalary : Form
    {
        //declared total for summation from serial no 1 to serial no 9
        private double total = 0.0;
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
            
            //taking total taxable income and showing in label51
            label51.Text = Form2_Salaries.totalTaxableIncome.ToString();
            //taking total taxable exempted income and showing in label51
            label52.Text = Form2_Salaries.totalTaxableIncome.ToString();
            total += Form2_Salaries.totalTaxableIncome;
            label39.Text = total.ToString();
            label40.Text= total.ToString();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                total += double.Parse(textBox2.Text.ToString());
                //
                label39.Text = total.ToString();
                label40.Text = total.ToString();
                //focusing "income from house property" text field
                textBox3.Focus();
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                total += double.Parse(textBox3.Text.ToString());
                //
                label39.Text = total.ToString();
                label40.Text = total.ToString();
                //focusing "agricultural income" text field
                textBox4.Focus();
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                total += double.Parse(textBox4.Text.ToString());
                //
                label39.Text = total.ToString();
                label40.Text = total.ToString();
                //focusing "Income from Business or profession" text field
                textBox5.Focus();
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                total += double.Parse(textBox5.Text.ToString());
                //
                label39.Text = total.ToString();
                label40.Text = total.ToString();
                //focusing "Share of proft in a firm" text field
                textBox6.Focus();
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                total += double.Parse(textBox6.Text.ToString());
                //
                label39.Text = total.ToString();
                label40.Text = total.ToString();
                //focusing "Income of spouse or minor child as applicable" text field
                textBox7.Focus();
            }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                total += double.Parse(textBox7.Text.ToString());
                //
                label39.Text = total.ToString();
                label40.Text = total.ToString();
                //focusing "Capital Gains" text field
                textBox8.Focus();
            }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                total += double.Parse(textBox8.Text.ToString());
                //
                label39.Text = total.ToString();
                label40.Text = total.ToString();
                //focusing "Income from other source" text field
                textBox9.Focus();
            }
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                total += double.Parse(textBox9.Text.ToString());
                label39.Text = total.ToString();
                label40.Text = total.ToString();
            }
        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double totalIncome= total + double.Parse(textBox10.Text.ToString());
                
                label40.Text = totalIncome.ToString();
            }
        }
    }
}
