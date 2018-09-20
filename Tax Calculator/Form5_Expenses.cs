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
    public partial class Form5_Expenses : Form
    {
        public static double totalExpense = 0.0;
        public Form5_Expenses()
        {
            InitializeComponent();
        }

        private void Form5_Expenses_Load(object sender, EventArgs e)
        {
            // made all textbox zero by default
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

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                totalExpense += Double.Parse(textBox1.ToString());
                label13.Text = totalExpense.ToString();

                textBox2.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                totalExpense += Double.Parse(textBox2.ToString());
                label13.Text = totalExpense.ToString();

                textBox3.Focus();
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                totalExpense += Double.Parse(textBox3.ToString());
                label13.Text = totalExpense.ToString();

                textBox4.Focus();
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                totalExpense += Double.Parse(textBox4.ToString());
                label13.Text = totalExpense.ToString();

                textBox5.Focus();
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                totalExpense += Double.Parse(textBox5.ToString());
                label13.Text = totalExpense.ToString();

                textBox6.Focus();
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                totalExpense += Double.Parse(textBox6.ToString());
                label13.Text = totalExpense.ToString();

                textBox7.Focus();
            }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                totalExpense += Double.Parse(textBox7.ToString());
                label13.Text = totalExpense.ToString();

                textBox8.Focus();
            }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                totalExpense += Double.Parse(textBox8.ToString());
                label13.Text = totalExpense.ToString();

                textBox9.Focus();
            }
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                totalExpense += Double.Parse(textBox9.ToString());
                label13.Text = totalExpense.ToString();

                textBox10.Focus();
            }
        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                totalExpense += Double.Parse(textBox10.ToString());
                label13.Text = totalExpense.ToString();

                textBox11.Focus();
            }
        }

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                totalExpense += Double.Parse(textBox11.ToString());
                label13.Text = totalExpense.ToString();
            }
        }
    }
}
