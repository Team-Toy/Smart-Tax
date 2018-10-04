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
        static Form4_SatementOfSalary _instance;
        public static Form4_SatementOfSalary GetInstance
        {
            get
            {
                if (_instance == null)
                    _instance = new Form4_SatementOfSalary();
                return _instance;
            }

        }
        public static string[] pdfInputs;

        //declared total for summation from serial no 1 to serial no 9
        public static double totalTaxableIncome = 0.0;
        public static double taxLeviable = 0.0;
        public static double taxRebate = 0.0;
        public static double taxPayable = 0.0;
        public static double totalTaxPayment = 0.0;
        public static double taxPaidLastYear = 0.0;
     
        public Form4_SatementOfSalary()
        {
           
            InitializeComponent();
            pdfInputs = new string[23];
        }

        private void Form4_SatementOfSalary_Load(object sender, EventArgs e)
        {
            // make all text boxt zero
            madeAllTextBoxZero();
        }
        private void Form4_SatementOfSalary_Activated(object sender, EventArgs e)
        {
            //taking total taxable income from "salaries" form and showing in label51
            label51.Text = Form2_Salaries.pdfInputs1[53];
            //taking total taxable exempted income and showing in label52
            label52.Text = Form2_Salaries.pdfInputs1[35];
            //taking value from NetHousePropertyIncome of Form2_Salaries
            label_NetHousePropertyIncome.Text = Form2_Salaries.pdfInputs2[10]; 

            // showing total and total income
            label39.Text = CalTotalTaxableIncome().ToString();
            label40.Text = CalTotalTaxableIncome().ToString();
            //............................

            taxLeviable = Form_PayableTaxCalculator.taxLeviable;
            label41.Text = taxLeviable.ToString();

            taxPayable = Math.Abs(taxLeviable - taxRebate);
            label43.Text = taxPayable.ToString();

        }
        public void madeAllTextBoxZero()
        {
            
            textBox2.Text = "0";
            textBox4.Text = "0";
            textBox5.Text = "0";
            textBox6.Text = "0";
            textBox7.Text = "0";
            textBox8.Text = "0";
            textBox9.Text = "0";
            textBox10.Text = "0";
            textBox11.Text = "0";
            textBox12.Text = "0";
            textBox13.Text = "0";
            textBox14.Text = "0";
            textBox15.Text = "0";

        }
        
        private double CalTotalTaxableIncome()
        {
            //addind "0" to prevent program crash because of null character of textBox
            return totalTaxableIncome = double.Parse(Form2_Salaries.pdfInputs1[53]) +   //net taxable income from salaries form
                                        double.Parse("0"+ textBox2.Text.ToString()) +
                                        double.Parse("0" + label_NetHousePropertyIncome.Text.ToString()) +
                                        double.Parse("0" + textBox4.Text.ToString()) +
                                        double.Parse("0" + textBox5.Text.ToString()) +
                                        double.Parse("0" + textBox6.Text.ToString()) +
                                        double.Parse("0" + textBox7.Text.ToString()) +
                                        double.Parse("0" + textBox8.Text.ToString()) +
                                        double.Parse("0" + textBox9.Text.ToString()) +
                                        double.Parse("0" + textBox10.Text.ToString());


            
        }
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox2.Text.Length == 0)
                {
                    textBox2.Text = "0";
                }
                double total = CalTotalTaxableIncome();
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
                if (textBox4.Text.Length == 0)
                {
                    textBox4.Text = "0";
                }
                double total = CalTotalTaxableIncome();
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
                if (textBox5.Text.Length == 0)
                {
                    textBox5.Text = "0";
                }
                double total = CalTotalTaxableIncome();
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
                if (textBox6.Text.Length == 0)
                {
                    textBox6.Text = "0";
                }
                double total = CalTotalTaxableIncome();
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
                if (textBox7.Text.Length == 0)
                {
                    textBox7.Text = "0";
                }
                double total = CalTotalTaxableIncome();
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
                if (textBox8.Text.Length == 0)
                {
                    textBox8.Text = "0";
                }
                double total = CalTotalTaxableIncome();

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
                if (textBox9.Text.Length == 0)
                {
                    textBox9.Text = "0";
                }
                double totalIncome = CalTotalTaxableIncome();
                //showing total income on label39 and labe40
                label39.Text = totalIncome.ToString();
                label40.Text = totalIncome.ToString();

                // calculate tax rebate and show on label42
                taxRebate = CalTaxRebate();
                label42.Text = taxRebate.ToString();
                //focusing "foreign income" text field
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

                double totalIncome = CalTotalTaxableIncome();
             
                //showing total income in labe40
                label40.Text = totalIncome.ToString();

                // showing tax rebate
                taxRebate = CalTaxRebate();
                label42.Text = taxRebate.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double totalIncome = CalTotalTaxableIncome();

            //showing total income in labe40
            label40.Text = totalIncome.ToString();

            // showing tax rebate
            taxRebate = CalTaxRebate();
            label42.Text = taxRebate.ToString();

            Form_PayableTaxCalculator f = new Form_PayableTaxCalculator();
            f.ShowDialog();
        }

        public double CalTaxRebate()
        {
            
            double allowableInvestmentTaxCredit = CalAllowableInvestmentTaxCredit();
            double taxRebate = 0;

            // see tax book page-29, assessment year(2018-2019)
            if(totalTaxableIncome <= 1000000.00)
            {
                taxRebate = allowableInvestmentTaxCredit * 0.15;
            }
            else if(totalTaxableIncome > 1000000.00 && totalTaxableIncome <= 3000000.00)
            {
                if ((allowableInvestmentTaxCredit - 250000) >= 0)
                    taxRebate = (250000 * 0.15) + ((allowableInvestmentTaxCredit - 250000) * 0.12);
                else
                    taxRebate = allowableInvestmentTaxCredit * 0.15;

            }
            else
            {
                if ((allowableInvestmentTaxCredit - 750000) >= 0)
                    taxRebate = (250000 * 0.15) + (500000 * 0.12) + ((allowableInvestmentTaxCredit - 750000) * 0.1);
                else if ((allowableInvestmentTaxCredit - 250000) >= 0)
                    taxRebate = (250000 * 0.15) + ((allowableInvestmentTaxCredit - 250000) * 0.12);
                else
                    taxRebate = allowableInvestmentTaxCredit * 0.15;                
            }
            return taxRebate;
        }

        private double CalAllowableInvestmentTaxCredit()
        {
            List<double> tempList = new List<double>();

            tempList.Add(Form3_InvestmentTaxCredit.totalInvestment);
            tempList.Add(15000000.00);
            tempList.Add(totalTaxableIncome*0.25);

            return tempList.Min();
        }

     
        private double totalTaxPayments()
        {
            //addind "0" to prevent program crash because of null character of textBox
            return totalTaxPayment = Double.Parse("0"+ textBox11.Text.ToString()) +
                                     Double.Parse("0" + textBox12.Text.ToString()) +
                                     Double.Parse("0" + textBox13.Text.ToString()) +
                                     Double.Parse("0" + textBox14.Text.ToString());
        }

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox10.Text.Length == 0)
                {
                    textBox10.Text = "0";
                }
                label55.Text = totalTaxPayments().ToString();

                textBox12.Focus();
            }
        }

        private void textBox12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox10.Text.Length == 0)
                {
                    textBox10.Text = "0";
                }
                label55.Text = totalTaxPayments().ToString();

                textBox13.Focus();
            }
        }

        private void textBox13_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox10.Text.Length == 0)
                {
                    textBox10.Text = "0";
                }
                label55.Text = totalTaxPayments().ToString();

                textBox14.Focus();
            }
        }

        private void textBox14_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox10.Text.Length == 0)
                {
                    textBox10.Text = "0";
                }

                double totalTaxPay = totalTaxPayments();

                label55.Text = totalTaxPay.ToString();

                double difference = taxPayable - totalTaxPay;
                label50.Text = difference.ToString();

                textBox15.Focus();
            }
        }

        private void textBox15_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                taxPaidLastYear = Double.Parse(textBox15.Text.ToString());
            }
        }
        private void UserInputs_StatementOfSalary()
        {
            pdfInputs[0] = label51.Text.ToString();   //salaries
            pdfInputs[1] = textBox2.Text.ToString();   //Interest on securities
            pdfInputs[2] = label_NetHousePropertyIncome.Text.ToString();   //Income from house property
            pdfInputs[3] = textBox4.Text.ToString();   //Agricultural Income
            pdfInputs[4] = textBox5.Text.ToString();   //Income from Business or profession
            pdfInputs[5] = textBox6.Text.ToString();   //Share of proft in a firm
            pdfInputs[6] = textBox7.Text.ToString();   //Income of spouse or minor child as applicable
            pdfInputs[7] = textBox8.Text.ToString();   //Capital Gains
            pdfInputs[8] = textBox9.Text.ToString();   //Income from other source
            pdfInputs[9] = label39.Text.ToString();   //total

            pdfInputs[10] = textBox10.Text.ToString();  //Foreign Income 

            pdfInputs[11] = label40.Text.ToString();  //Total income ( serial 10 and 11)
            pdfInputs[12] = label41.Text.ToString();  //TAX Leviable on Total Income
            pdfInputs[13] = label42.Text.ToString();  //Tax Rebate

            pdfInputs[14] = label43.Text.ToString();  //Tax Payable( Difference between serial 13 and 14)
            pdfInputs[15] = textBox11.Text.ToString();  //a) Tax deducted at source
            pdfInputs[16] = textBox12.Text.ToString();  //b) advance tax as per challan
            pdfInputs[17] = textBox13.Text.ToString();  //c) Tax paid on the basis of this return
            pdfInputs[18] = textBox14.Text.ToString();  //d) Adjustment of tax refund (If any)
       
            pdfInputs[19] = label55.Text.ToString();  //Total ( a + b + c + d )  
            pdfInputs[20] = label50.Text.ToString();  //Difference between 15 and 16 (if any)
            pdfInputs[21] = label52.Text.ToString();  //Tax exempted and tax free income
            pdfInputs[22] = textBox15.Text.ToString();  //Income tax paid in the last assesment year  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //save data for pdf file
            UserInputs_StatementOfSalary();
            Form5_Expenses f = Form5_Expenses.GetInstance;
            this.Hide();
            f.Show();

        }



        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
       
        private void Form4_SatementOfSalary_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                //application Closing by cross cursor;
                Application.Exit();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {           
            Form3_InvestmentTaxCredit f = Form3_InvestmentTaxCredit.GetInstance;
            this.Hide();
            f.Show();
        }

    }
}