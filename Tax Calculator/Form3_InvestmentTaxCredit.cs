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
        public static string[] pdfInputs;
        public static double totalInvestment = 0.0;
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
            pdfInputs = new string[21];
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            madeAllTextBoxZero();
        }
        public void madeAllTextBoxZero()
        {
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox5.Text = "0";
            textBox6.Text = "0";
            textBox7.Text = "0";
            textBox8.Text = "0";
            textBox9.Text = "0";
            textBox10.Text = "0";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //calling calculation method to show total investment result by label
            label12.Text = InvestmentTaxCalculate().ToString();
        }

        private double InvestmentTaxCalculate()
        {
            totalInvestment =   double.Parse(textBox1.Text.ToString()) +
                                double.Parse(textBox2.Text.ToString()) +
                                double.Parse(textBox3.Text.ToString()) +
                                double.Parse(textBox4.Text.ToString()) +
                                double.Parse(textBox5.Text.ToString()) +
                                double.Parse(textBox6.Text.ToString()) +
                                double.Parse(textBox7.Text.ToString()) +
                                double.Parse(textBox8.Text.ToString()) +
                                double.Parse(textBox9.Text.ToString()) +
                                double.Parse(textBox10.Text.ToString());
           
            return totalInvestment;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text.Length == 0)
                {
                    textBox1.Text = "0";

                }
                label12.Text = (InvestmentTaxCalculate()).ToString();
                textBox2.Focus();
            }
            
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox2.Text.Length == 0)
                {
                    textBox2.Text = "0";

                }
                label12.Text = (InvestmentTaxCalculate()).ToString();
                textBox3.Focus();
            }
        }
        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (textBox3.Text.Length == 0)
                {
                    textBox3.Text = "0";

                }
                label12.Text = (InvestmentTaxCalculate()).ToString();
                textBox4.Focus();
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox4.Text.Length == 0)
                {
                    textBox4.Text = "0";

                }
                label12.Text = (InvestmentTaxCalculate()).ToString();
                textBox5.Focus();
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox5.Text.Length == 0)
                {
                    textBox5.Text = "0";

                }
                label12.Text = (InvestmentTaxCalculate()).ToString();
                textBox6.Focus();
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox6.Text.Length == 0)
                {
                    textBox6.Text = "0";

                }
                label12.Text = (InvestmentTaxCalculate()).ToString();
                textBox7.Focus();
            }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox7.Text.Length == 0)
                {
                    textBox7.Text = "0";
                }
                label12.Text = (InvestmentTaxCalculate()).ToString();
                textBox8.Focus();
            }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox8.Text.Length == 0)
                {
                    textBox8.Text = "0";
                }
                label12.Text = (InvestmentTaxCalculate()).ToString();
                textBox9.Focus();
            }
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox9.Text.Length == 0)
                {
                    textBox9.Text = "0";
                }
                label12.Text = (InvestmentTaxCalculate()).ToString();
                textBox10.Focus();
            }
        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox10.Text.Length == 0)
                {
                    textBox10.Text = "0";

                }
                label12.Text = (InvestmentTaxCalculate()).ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {   //save data for pdf file
            UserInput_InvestmentTaxCredit();
            //hiding investment tex credit form
            this.Hide();
            Form4_SatementOfSalary f = new Form4_SatementOfSalary();
            //showing "Satement Of Salary" form
            f.Show();        
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

        public void UserInput_InvestmentTaxCredit()
        {
            pdfInputs[0] = textBox1.Text.ToString();   //Life insurance premium
            pdfInputs[1] = textBox2.Text.ToString();   //Contribution to deffered annuity
            pdfInputs[2] = textBox3.Text.ToString();   //Contribution to provident fund
            pdfInputs[3] = textBox4.Text.ToString();   //Self contribution and employers contributon to recognized provdent fund
            pdfInputs[4] = textBox5.Text.ToString();   //Contribution to super annuaton fund / DPS
            pdfInputs[5] = textBox6.Text.ToString();   //investment in approved debebnture stock, stock, or shares
            pdfInputs[6] = textBox7.Text.ToString();   //Contributon to depost pension scheem
            pdfInputs[7] = textBox8.Text.ToString();   //Group insurance premium
            pdfInputs[8] = textBox9.Text.ToString();   //Contribution to zaat fund
            pdfInputs[9] = textBox10.Text.ToString();   //Other (if any)
            pdfInputs[10] = label12.Text.ToString();  //total

            pdfInputs[11] = textBox11.Text.ToString();  //Document 1
            pdfInputs[12] = textBox12.Text.ToString();  //Document 2
            pdfInputs[13] = textBox13.Text.ToString();  //Document 3
            pdfInputs[14] = textBox14.Text.ToString();  //Document 4
            pdfInputs[15] = textBox15.Text.ToString();  //Document 5
            pdfInputs[16] = textBox16.Text.ToString();  //Document 6
            pdfInputs[17] = textBox17.Text.ToString();  //Document 7
            pdfInputs[18] = textBox18.Text.ToString();  //Document 8
            pdfInputs[19] = textBox19.Text.ToString();  //Document 9
            pdfInputs[20] = textBox20.Text.ToString();  //Document 10           

        }
    }
}
