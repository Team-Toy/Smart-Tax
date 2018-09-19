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
    public partial class Form2_Salaries : Form
    {
        public Form2_Salaries()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            List<SalaryObject> l = Form1_Personal_info.list;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label57.Text = ""+Form1_Personal_info.list[0].TaxableIncome(double.Parse(textBox1.Text.ToString()),0);
        }
    }
}
