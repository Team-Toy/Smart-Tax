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
    public partial class Form4_SatementOfSalary : MetroFramework.Forms.MetroForm
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
            label51.Text = ((double)Convert.ToDecimal(Form2_Salaries.pdfInputs1[53])).ToString("N");    //making total taxable income as currency style
            //taking total taxable exempted income and showing in label52
            label52.Text = ((double)Convert.ToDecimal(Form2_Salaries.pdfInputs1[35])).ToString("N");     //making total taxable exempted income as currency style
            //taking value from NetHousePropertyIncome of Form2_Salaries
            label_NetHousePropertyIncome.Text = ((double)Convert.ToDecimal(Form2_Salaries.pdfInputs2[10])).ToString("N");   //making total NetHousePropertyIncome as currency style

            // showing total and total income
            label39.Text = CalTotalTaxableIncome().ToString("N");
            label40.Text = (CalTotalTaxableIncome() + (double)Convert.ToDecimal(textBox10.Text.ToString())).ToString("N");
            //............................

            taxLeviable = Form_PayableTaxCalculator.taxLeviable;
            label41.Text = taxLeviable.ToString("N");

            // calculate tax rebate and show on label42
            taxRebate = CalTaxRebate();
            label42.Text = taxRebate.ToString("N"); //string formatting as a number;which has comma

            taxPayable = taxLeviable - taxRebate;
            if (taxPayable < 0)
                taxPayable = 0.0;
            label43.Text = taxPayable.ToString("N");

        }
        public void madeAllTextBoxZero()
        {
            
            textBox2.Text = "0.0";
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
            textBox15.Text = "0.0";

        }
        
        private double CalTotalTaxableIncome()
        {
            totalTaxableIncome = (double)Convert.ToDecimal(Form2_Salaries.pdfInputs1[53]) +   //net taxable income from salaries form
                                  (double)Convert.ToDecimal(textBox2.Text.ToString()) +
                                  (double)Convert.ToDecimal(label_NetHousePropertyIncome.Text.ToString()) +
                                  (double)Convert.ToDecimal(textBox4.Text.ToString()) +
                                  (double)Convert.ToDecimal(textBox5.Text.ToString()) +
                                  (double)Convert.ToDecimal(textBox6.Text.ToString()) +
                                  (double)Convert.ToDecimal(textBox7.Text.ToString()) +
                                  (double)Convert.ToDecimal(textBox8.Text.ToString()) +
                                  (double)Convert.ToDecimal(textBox9.Text.ToString());                          
            return totalTaxableIncome;
        }
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {           
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //any string number(with comma or without comma) coverted to double
                    double value = (double)Convert.ToDecimal(textBox2.Text.ToString());
                    textBox2.Text = value.ToString("N");    //string formatting as a number;which has comma
                    //focusing "agricultural income" text field
                    textBox4.Focus();
                    // calculate tax rebate
                    taxRebate = CalTaxRebate();
                    // showing tax rebate
                    label42.Text = taxRebate.ToString("N"); //string formatting as a currency number   
                }
            }
            catch
            {
                textBox2.Text = "0.0";  //clear user input because of invaild inputs
            }

        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //any string number(with comma or without comma) coverted to double
                    double value = (double)Convert.ToDecimal(textBox4.Text.ToString());
                    textBox4.Text = value.ToString("N");    //string formatting as a number;which has comma
                    //focusing "agricultural income" text field
                    textBox5.Focus();
                    // calculate tax rebate
                    taxRebate = CalTaxRebate();
                    // showing tax rebate
                    label42.Text = taxRebate.ToString("N"); //string formatting as a currency number   
                }
            }
            catch
            {
                textBox4.Text = "0.0";  //clear user input because of invaild inputs
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        //any string number(with comma or without comma) coverted to double
                        double value = (double)Convert.ToDecimal(textBox5.Text.ToString());
                        textBox5.Text = value.ToString("N");    //string formatting as a number;which has comma                                                               
                        //focusing "Share of proft in a firm" text field
                        textBox6.Focus();
                        // calculate tax rebate
                        taxRebate = CalTaxRebate();
                        // showing tax rebate
                        label42.Text = taxRebate.ToString("N"); //string formatting as a currency number   
                    }
                }
                catch
                {
                    textBox5.Text = "0.0";  //clear user input because of invaild inputs
                }
               
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //any string number(with comma or without comma) coverted to double
                    double value = (double)Convert.ToDecimal(textBox6.Text.ToString());
                    textBox6.Text = value.ToString("N");    //string formatting as a number;which has comma
                     //focusing "Income of spouse or minor child as applicable" text field
                    textBox7.Focus();
                    // calculate tax rebate
                    taxRebate = CalTaxRebate();
                    // showing tax rebate
                    label42.Text = taxRebate.ToString("N"); //string formatting as a currency number   
                }
            }
            catch
            {
                textBox6.Text = "0.0";  //clear user input because of invaild inputs
            }
                     
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //any string number(with comma or without comma) coverted to double
                    double value = (double)Convert.ToDecimal(textBox7.Text.ToString());
                    textBox7.Text = value.ToString("N");    //string formatting as a number;which has comma                                                          
                    //focusing "Capital Gains" text field
                    textBox8.Focus();
                    // calculate tax rebate
                    taxRebate = CalTaxRebate();
                    // showing tax rebate
                    label42.Text = taxRebate.ToString("N"); //string formatting as a currency number   
                }
            }
            catch
            {
                textBox7.Text = "0.0";  //clear user input because of invaild inputs
            }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //any string number(with comma or without comma) coverted to double
                    double value = (double)Convert.ToDecimal(textBox8.Text.ToString());
                    textBox8.Text = value.ToString("N");    //string formatting as a number;which has comma                                                          
                    //focusing "Income from other source" text field
                    textBox9.Focus();
                    // calculate tax rebate
                    taxRebate = CalTaxRebate();
                    // showing tax rebate
                    label42.Text = taxRebate.ToString("N");  //string formatting as a currency number  
                }
            }
            catch
            {
                textBox8.Text = "0.0";  //clear user input because of invaild inputs
            }

        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //any string number(with comma or without comma) coverted to double
                    double value = (double)Convert.ToDecimal(textBox9.Text.ToString());
                    textBox9.Text = value.ToString("N");    //string formatting as a number;which has comma                                                          
                    //focusing "foreign income" text field
                    textBox10.Focus();
                    // calculate tax rebate
                    taxRebate = CalTaxRebate();
                    // showing tax rebate
                    label42.Text = taxRebate.ToString("N");  //string formatting as a currency number  
                }
            }
            catch
            {
                textBox9.Text = "0.0";  //clear user input because of invaild inputs
            }
        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //any string number(with comma or without comma) coverted to double
                    double value = (double)Convert.ToDecimal(textBox10.Text.ToString());
                    textBox10.Text = value.ToString("N");    //string formatting as a number;which has comma                                                          
                    //focusing "tax deducted at source" text field
                    textBox11.Focus();
                    // calculate tax rebate
                    taxRebate = CalTaxRebate();
                    // showing tax rebate
                    label42.Text = taxRebate.ToString("N");  //string formatting as a currency number  
                }
            }
            catch
            {
                textBox10.Text = "0.0";  //clear user input because of invaild inputs
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {                                                   //foregin income
            totalTaxableIncome = CalTotalTaxableIncome() + (double)Convert.ToDecimal(textBox10.Text.ToString()); 

            taxRebate = CalTaxRebate(); // calculating tax rebate
            // showing tax rebate
            label42.Text = taxRebate.ToString("N");  //string formatting as a currency number  

            Form_PayableTaxCalculator f = new Form_PayableTaxCalculator();
            f.ShowDialog();
        }

        public double CalTaxRebate()
        {
            //calculating total taxable income + foregin income
            totalTaxableIncome = CalTotalTaxableIncome() + (double)Convert.ToDecimal(textBox10.Text.ToString());    
            double allowableInvestmentTaxCredit = CalAllowableInvestmentTaxCredit();
            double taxRebate = 0;
            
            // see tax book page-29, assessment year(2018-2019)
            if (totalTaxableIncome <= 1000000.00)
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
            return totalTaxPayment = (double)Convert.ToDecimal(textBox11.Text.ToString()) +
                                     (double)Convert.ToDecimal(textBox12.Text.ToString()) +
                                     (double)Convert.ToDecimal(textBox13.Text.ToString()) +
                                     (double)Convert.ToDecimal(textBox14.Text.ToString());
        }

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //any string number(with comma or without comma) coverted to double
                    double value = (double)Convert.ToDecimal(textBox11.Text.ToString());
                    textBox11.Text = value.ToString("N");   //string format as currency number style
                    textBox12.Focus();
                }
            }
            catch
            {
                textBox11.Text = "0.0"; //clear user input because of invaild inputs
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
            try
            {              
                if (e.KeyCode == Keys.Enter)
                {
                    taxPaidLastYear = (double)Convert.ToDecimal(textBox15.Text.ToString());
                    btNext.Focus();   //Next button
                }
                
            }
            catch
            {
                textBox15.Text = "0.0"; //clear user input because of invaild inputs
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
       
            pdfInputs[19] = label55.Text.ToString();  //Total ( a + b + c + d )  :Total payments of tax
            pdfInputs[20] = label50.Text.ToString();  //Difference between 15 and 16 (if any)
            pdfInputs[21] = label52.Text.ToString();  //Tax exempted and tax free income
            pdfInputs[22] = textBox15.Text.ToString();  //Income tax paid in the last assesment year  
        }

        // for all texbox keypress method: works for invaild inputs restriction
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

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double total = CalTotalTaxableIncome();
                //
                label39.Text = total.ToString("N"); //string formatting as a number;which has comma
                label40.Text = total.ToString("N"); //string formatting as a number;which has comma
                // calculate tax rebate and show on label42
                taxRebate = CalTaxRebate();
                label42.Text = taxRebate.ToString("N"); //string formatting as a number;which has comma
            }
            catch
            {

            }
        }

        //total income
        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            try
            {         //total = total taxable income + foregin income
                double total = CalTotalTaxableIncome() + (double)Convert.ToDecimal(textBox10.Text.ToString());
                //
                label40.Text = total.ToString("N"); //string formatting as a number;which has comma
                // calculate tax rebate and show on label42
                taxRebate = CalTaxRebate();
                label42.Text = taxRebate.ToString("N"); //string formatting as a number;which has comma
            }
            catch
            {

            }
        }
        //
        private void TaxPayments_TextChanged(object sender, EventArgs e)
        {
            try
            {             
                label55.Text = totalTaxPayments().ToString("N");
                double difference = taxPayable - totalTaxPayments();
                label50.Text = difference.ToString("N");
            }
            catch
            {

            }
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            try
            {
                taxPaidLastYear = (double)Convert.ToDecimal(textBox15.Text.ToString());
            }
            catch
            {

            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text.ToString() == "") textBox2.Text = "0.0";  //if user clear input then auto copy "0.0"
            try    //By clicking any other toolbox after copy-paste by user following code run
            {
                double tempValue = (double)Convert.ToDecimal(textBox2.Text.ToString());
                textBox2.Text = tempValue.ToString("N"); //input auto convert as currency number style
            }
            catch  //if user copy-paste invaild(or number with characters)
            {
                textBox2.Text = "0.0";   //clear user input because of invaild inputs
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text.ToString() == "") textBox4.Text = "0.0";  //if user clear input then auto copy "0.0"
            try    //By clicking any other toolbox after copy-paste by user following code run
            {
                double tempValue = (double)Convert.ToDecimal(textBox4.Text.ToString());
                textBox4.Text = tempValue.ToString("N"); //input auto convert as currency number style
            }
            catch  //if user copy-paste invaild(or number with characters)
            {
                textBox4.Text = "0.0";   //clear user input because of invaild inputs
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text.ToString() == "") textBox5.Text = "0.0";  //if user clear input then auto copy "0.0"
            try    //By clicking any other toolbox after copy-paste by user following code run
            {
                double tempValue = (double)Convert.ToDecimal(textBox5.Text.ToString());
                textBox5.Text = tempValue.ToString("N"); //input auto convert as currency number style
            }
            catch  //if user copy-paste invaild(or number with characters)
            {
                textBox5.Text = "0.0";   //clear user input because of invaild inputs
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox6.Text.ToString() == "") textBox6.Text = "0.0";  //if user clear input then auto copy "0.0"
            try    //By clicking any other toolbox after copy-paste by user following code run
            {
                double tempValue = (double)Convert.ToDecimal(textBox6.Text.ToString());
                textBox6.Text = tempValue.ToString("N"); //input auto convert as currency number style
            }
            catch  //if user copy-paste invaild(or number with characters)
            {
                textBox6.Text = "0.0";   //clear user input because of invaild inputs
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (textBox7.Text.ToString() == "") textBox7.Text = "0.0";  //if user clear input then auto copy "0.0"
            try    //By clicking any other toolbox after copy-paste by user following code run
            {
                double tempValue = (double)Convert.ToDecimal(textBox7.Text.ToString());
                textBox7.Text = tempValue.ToString("N"); //input auto convert as currency number style
            }
            catch  //if user copy-paste invaild(or number with characters)
            {
                textBox7.Text = "0.0";   //clear user input because of invaild inputs
            }
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            if (textBox8.Text.ToString() == "") textBox8.Text = "0.0";  //if user clear input then auto copy "0.0"
            try    //By clicking any other toolbox after copy-paste by user following code run
            {
                double tempValue = (double)Convert.ToDecimal(textBox8.Text.ToString());
                textBox8.Text = tempValue.ToString("N"); //input auto convert as currency number style
            }
            catch  //if user copy-paste invaild(or number with characters)
            {
                textBox8.Text = "0.0";   //clear user input because of invaild inputs
            }
        }

        private void textBox9_Leave(object sender, EventArgs e)
        {
            if (textBox9.Text.ToString() == "") textBox9.Text = "0.0";  //if user clear input then auto copy "0.0"
            try    //By clicking any other toolbox after copy-paste by user following code run
            {
                double tempValue = (double)Convert.ToDecimal(textBox9.Text.ToString());
                textBox9.Text = tempValue.ToString("N"); //input auto convert as currency number style
            }
            catch  //if user copy-paste invaild(or number with characters)
            {
                textBox9.Text = "0.0";   //clear user input because of invaild inputs
            }
        }

        private void textBox10_Leave(object sender, EventArgs e)
        {
            if (textBox10.Text.ToString() == "") textBox10.Text = "0.0";  //if user clear input then auto copy "0.0"
            try    //By clicking any other toolbox after copy-paste by user following code run
            {
                double tempValue = (double)Convert.ToDecimal(textBox10.Text.ToString());
                textBox10.Text = tempValue.ToString("N"); //input auto convert as currency number style
            }
            catch  //if user copy-paste invaild(or number with characters)
            {
                textBox10.Text = "0.0";   //clear user input because of invaild inputs
            }
        }

        private void textBox11_Leave(object sender, EventArgs e)
        {
            if (textBox11.Text.ToString() == "") textBox11.Text = "0.0";  //if user clear input then auto copy "0.0"
            try    //By clicking any other toolbox after copy-paste by user following code run
            {
                double tempValue = (double)Convert.ToDecimal(textBox11.Text.ToString());
                textBox11.Text = tempValue.ToString("N"); //input auto convert as currency number style
            }
            catch  //if user copy-paste invaild(or number with characters)
            {
                textBox11.Text = "0.0";   //clear user input because of invaild inputs
            }
        }

        private void textBox12_Leave(object sender, EventArgs e)
        {
            if (textBox12.Text.ToString() == "") textBox12.Text = "0.0";  //if user clear input then auto copy "0.0"
            try    //By clicking any other toolbox after copy-paste by user following code run
            {
                double tempValue = (double)Convert.ToDecimal(textBox12.Text.ToString());
                textBox12.Text = tempValue.ToString("N"); //input auto convert as currency number style
            }
            catch  //if user copy-paste invaild(or number with characters)
            {
                textBox12.Text = "0.0";   //clear user input because of invaild inputs
            }
        }

        private void textBox13_Leave(object sender, EventArgs e)
        {
            if (textBox13.Text.ToString() == "") textBox13.Text = "0.0";  //if user clear input then auto copy "0.0"
            try    //By clicking any other toolbox after copy-paste by user following code run
            {
                double tempValue = (double)Convert.ToDecimal(textBox13.Text.ToString());
                textBox13.Text = tempValue.ToString("N"); //input auto convert as currency number style
            }
            catch  //if user copy-paste invaild(or number with characters)
            {
                textBox13.Text = "0.0";   //clear user input because of invaild inputs
            }
        }

        private void textBox14_Leave(object sender, EventArgs e)
        {
            if (textBox14.Text.ToString() == "") textBox14.Text = "0.0";  //if user clear input then auto copy "0.0"
            try    //By clicking any other toolbox after copy-paste by user following code run
            {
                double tempValue = (double)Convert.ToDecimal(textBox14.Text.ToString());
                textBox14.Text = tempValue.ToString("N"); //input auto convert as currency number style
            }
            catch  //if user copy-paste invaild(or number with characters)
            {
                textBox14.Text = "0.0";   //clear user input because of invaild inputs
            }
        }

        private void textBox15_Leave(object sender, EventArgs e)
        {
            if (textBox15.Text.ToString() == "") textBox15.Text = "0.0";  //if user clear input then auto copy "0.0"
            try    //By clicking any other toolbox after copy-paste by user following code run
            {
                double tempValue = (double)Convert.ToDecimal(textBox15.Text.ToString());
                textBox15.Text = tempValue.ToString("N"); //input auto convert as currency number style
            }
            catch  //if user copy-paste invaild(or number with characters)
            {
                textBox15.Text = "0.0";   //clear user input because of invaild inputs
            }
        }

        private void btHome_Click(object sender, EventArgs e)
        {
            Form1_Personal_info f = Form1_Personal_info.GetInstance;
            f.Show();   //go to Home page
            this.Hide();    //Hide curent window form
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            //save data for pdf file
            UserInputs_StatementOfSalary();
            Form5_Expenses f = Form5_Expenses.GetInstance;
            f.Show();
            this.Hide();     //Hide curent window form
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            Form3_InvestmentTaxCredit f = Form3_InvestmentTaxCredit.GetInstance;
            f.Show();
            this.Hide();     //Hide curent window form
        }
    }
}