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

        }

        private double InvestmentTaxCalculate()
        {
            double tempTotal = 0.0;
                tempTotal = double.Parse(textBox1.Text.ToString())+
                            double.Parse(textBox2.Text.ToString())+
                            double.Parse(textBox3.Text.ToString())+
                            double.Parse(textBox4.Text.ToString())+
                            double.Parse(textBox5.Text.ToString())+
                            double.Parse(textBox6.Text.ToString())+
                            double.Parse(textBox7.Text.ToString())+
                            double.Parse(textBox8.Text.ToString())+
                            double.Parse(textBox9.Text.ToString())+
                            double.Parse(textBox10.Text.ToString());
            sum = tempTotal;
            return sum;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //calling calculation method to show total investment result by label
            label12.Text=(InvestmentTaxCalculate()).ToString();
        }
    }
}
