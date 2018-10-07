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
        static Form2_Salaries _instance;
        public static Form2_Salaries GetInstance
        {
            get
            {
                if (_instance == null)
                    _instance = new Form2_Salaries();
                return _instance;
            }

        }
        public static string[] pdfInputs1, pdfInputs2;
        //values for form 4, totalTaxableIncome, totalTaxExtempted
        public double totalAmountOfIncome = 0.0;
       // public static double netTaxableIncome = 0.0;
        public double totalTaxExtempted = 0.0;
        public double basicPay = 0.0;
        public static List<SalaryConditionals> list = new List<SalaryConditionals>();
        private string[] data = {"true","0","0",        //BasicPay 
                                 "true","0","0",          //SpecialPay
                                 "true","0","0",          //Dearness_allowance
                                 "true","0","30000",    //Conveyance_allowance 
                                 "true","0.5","300000", //HouseRent_allowance  
                                 "true","0.1","120000",";","1000000",  //Medical_allowance
                                 "true","0","0",      //Servant_allownace
                                 "true","0","0",      //Leave_allowance
                                 "true","0","0",     //Honorarium/Reward/Fee	
                                 "true","0","0",    //Overtime_allowance
                                 "true","0","0",    //Bonus/Ex-gratia
                                 "true","0","0",    //Other_allowance
                                 "true","0","0",    //Employer's_contribution_to_recognized_provident_fund 
                                 "true","0.145","0",   //interest_accrued_on_Recognized_provident_fund 
                                 "true","0.05","60000",    // Deemed_income_for_transport_facility 
                                 "true","0.25","0",        //Deemed_income_for_free_furnished/unfurnish accommodation
                                 "true","0","0",        //Other,if_any
                                 //"true","0.7","0"       //randomly created for fixing list index out of bound
                                };
        public static double reducedHomeRent = 0.0;



        public Form2_Salaries()
        {
            InitializeComponent();
            pdfInputs1 = new string[54];
            pdfInputs2 = new string[11];

            //testing

            List<double> maxNonTaxable;
            for (int i = 0; i < data.Length; i++)
            {
                bool taxable = Boolean.Parse(data[i]);
                double maxPercentOfNonTaxable = (double.Parse(data[++i]));

                maxNonTaxable = new List<double>();
                maxNonTaxable.Add(double.Parse(data[++i]));

                if (i == 17)
                {
                    maxNonTaxable.Add(double.Parse(data[i + 2]));
                    i += 2; //jump to next row 
                }

                SalaryConditionals salaryType = new SalaryConditionals(taxable, maxPercentOfNonTaxable, maxNonTaxable);
                list.Add(salaryType);
            }

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            makeAllTextBoxZero();
            makeAllLabelZero();

            textBox15.Enabled = false; // 

            // default value set for medical allowance
            comboBox1.SelectedIndex = 0;
            // default value set for accomodation
            comboBox2.SelectedIndex = 0;
            //default value set for Deemed_income_for_transport_facility 
            comboBox3.SelectedIndex = 0;

            List<double> maxNonTaxable;
            for (int i = 0; i < data.Length; i++)
            {
                bool taxable = Boolean.Parse(data[i]);
                double maxPercentOfNonTaxable = (double.Parse(data[++i]));
                
                maxNonTaxable = new List<double>();
                maxNonTaxable.Add(double.Parse(data[++i]));

                if (i == 17)
                {
                    maxNonTaxable.Add(double.Parse(data[i + 2]));
                    i += 2; //jump to next row 
                }
    
                SalaryConditionals salaryType = new SalaryConditionals(taxable, maxPercentOfNonTaxable, maxNonTaxable);
                list.Add(salaryType);
            }
        }
        private void makeAllTextBoxZero()
        {
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox5.Text = "0";
            textBox6.Text = "0";
            textBox7.Text = "0";
            textBox25.Text ="0"; //Leave_allowance
            textBox8.Text = "0";
            textBox9.Text = "0";
            textBox10.Text = "0";
            textBox11.Text = "0";
            textBox12.Text = "0";
            textBox13.Text = "0";
            
            textBox15.Text = "0";
            textBox16.Text = "0";
            textBox17.Text = "0";
            textBox18.Text = "0";
            textBox19.Text = "0";
            textBox20.Text = "0";
            textBox21.Text = "0";
            textBox22.Text = "0";
            textBox23.Text = "0";
            textBox24.Text = "0";
        }
        public void makeAllLabelZero()
        {
            label40.Text = "0";
            label41.Text = "0";
            label42.Text = "0";
            label43.Text = "0";
            label44.Text = "0";
            label45.Text = "0";
            label46.Text = "0";
            label92.Text = "0"; //Leave allowance (non-Taxable)
            label47.Text = "0";
            label48.Text = "0";
            label49.Text = "0";
            label50.Text = "0";
            label51.Text = "0";
            label52.Text = "0";
            label52.Text = "0";
            label53.Text = "0";
            label54.Text = "0";
            label55.Text = "0";

            label57.Text = "0";
            label58.Text = "0";
            label59.Text = "0";
            label60.Text = "0";
            label61.Text = "0";
            label62.Text = "0";
            label63.Text = "0";
            label93.Text = "0"; //Leave allowance (Taxable)
            label64.Text = "0";
            label65.Text = "0";
            label66.Text = "0";
            label67.Text = "0";
            label68.Text = "0";
            label69.Text = "0";
            label70.Text = "0";
            label71.Text = "0";
            label72.Text = "0";

            label39.Text = "0";
            label56.Text = "0";
            label73.Text = "0";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //save data for pdf file
            UserInputs_Salaries();
            //go to investment Tax Credit form
            Form3_InvestmentTaxCredit f = Form3_InvestmentTaxCredit.GetInstance;
            this.Hide(); // form1 hide
            f.Show();
        }

        private double TaxExemptCal(double income, double taxableIncome)
        {
            return (income - taxableIncome);
        }
        private double TotalAmountOfIncome()
        {
                                //cleanning space,additional commas during copy-paste by user inputs
            totalAmountOfIncome = (double)Convert.ToDecimal(textBox1.Text.ToString()) +
                                  (double)Convert.ToDecimal(textBox2.Text.ToString()) +
                                  (double)Convert.ToDecimal(textBox3.Text.ToString()) +
                                  (double)Convert.ToDecimal(textBox4.Text.ToString()) +
                                  (double)Convert.ToDecimal(textBox5.Text.ToString()) +
                                  (double)Convert.ToDecimal(textBox6.Text.ToString()) +
                                  (double)Convert.ToDecimal(textBox7.Text.ToString()) +
                                  (double)Convert.ToDecimal(textBox25.Text.ToString()) +  //Leave allowance
                                  (double)Convert.ToDecimal(textBox8.Text.ToString()) +
                                  (double)Convert.ToDecimal(textBox9.Text.ToString()) +
                                  (double)Convert.ToDecimal(textBox10.Text.ToString()) +
                                  (double)Convert.ToDecimal(textBox11.Text.ToString()) +
                                  (double)Convert.ToDecimal(textBox12.Text.ToString()) +
                                  (double)Convert.ToDecimal(textBox13.Text.ToString()) +
                                  (double)Convert.ToDecimal(textBox16.Text.ToString());

             
            return totalAmountOfIncome;
        }
        private double CalTotalTaxExempted()
        {
                             //cleanning space,additional commas during copy-paste by user inputs
           totalTaxExtempted = (double)Convert.ToDecimal(label40.Text.ToString()) +
                               (double)Convert.ToDecimal(label41.Text.ToString()) +
                                (double)Convert.ToDecimal(label42.Text.ToString()) +
                                (double)Convert.ToDecimal(label43.Text.ToString()) +
                                (double)Convert.ToDecimal(label44.Text.ToString()) +
                                (double)Convert.ToDecimal(label45.Text.ToString()) +
                                (double)Convert.ToDecimal(label46.Text.ToString()) +
                                (double)Convert.ToDecimal(label92.Text.ToString()) +     //Leave allowance
                                (double)Convert.ToDecimal(label47.Text.ToString()) +
                                (double)Convert.ToDecimal(label48.Text.ToString()) +
                                (double)Convert.ToDecimal(label49.Text.ToString()) +
                                (double)Convert.ToDecimal(label50.Text.ToString()) +
                                (double)Convert.ToDecimal(label51.Text.ToString()) +
                                (double)Convert.ToDecimal(label52.Text.ToString()) +
                                (double)Convert.ToDecimal(label53.Text.ToString()) +
                                (double)Convert.ToDecimal(label54.Text.ToString()) +
                                (double)Convert.ToDecimal(label55.Text.ToString());


            return totalTaxExtempted;
        }
        private double CalNetTaxableIncome()
        {
            double netTaxableIncome = 0.0;
                                //cleanning space,additional commas during copy-paste by user inputs
            netTaxableIncome = (double)Convert.ToDecimal(label57.Text.ToString()) +
                               (double)Convert.ToDecimal(label58.Text.ToString()) +
                                (double)Convert.ToDecimal(label59.Text.ToString()) +
                               (double)Convert.ToDecimal(label60.Text.ToString()) +
                                (double)Convert.ToDecimal(label61.Text.ToString()) +
                                (double)Convert.ToDecimal(label62.Text.ToString()) +
                                (double)Convert.ToDecimal(label63.Text.ToString()) +
                                (double)Convert.ToDecimal(label93.Text.ToString()) +  //Leave allowance
                                (double)Convert.ToDecimal(label64.Text.ToString()) +
                                (double)Convert.ToDecimal(label65.Text.ToString()) +
                                (double)Convert.ToDecimal(label66.Text.ToString()) +
                                (double)Convert.ToDecimal(label67.Text.ToString()) +
                                (double)Convert.ToDecimal(label68.Text.ToString()) +
                                (double)Convert.ToDecimal(label69.Text.ToString()) +
                                (double)Convert.ToDecimal(label70.Text.ToString()) +
                                (double)Convert.ToDecimal(label71.Text.ToString()) +
                                (double)Convert.ToDecimal(label72.Text.ToString());

            return netTaxableIncome;
        }
        private double CalTotalClaimedExpense()
        {
           double totalClaimedExpense = 0.0;
                                //cleanning space,additional commas during copy-paste by user inputs
           totalClaimedExpense = (double)Convert.ToDecimal(textBox18.Text.ToString()) +
                                (double)Convert.ToDecimal(textBox19.Text.ToString()) +
                                (double)Convert.ToDecimal(textBox20.Text.ToString()) +
                                (double)Convert.ToDecimal(textBox21.Text.ToString()) +
                                (double)Convert.ToDecimal(textBox22.Text.ToString()) +
                                (double)Convert.ToDecimal(textBox23.Text.ToString()) +
                                (double)Convert.ToDecimal(textBox24.Text.ToString());

            return totalClaimedExpense;
        }
        
        //basic pay enter key event function
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {                
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //cleanning space,additional commas during copy-paste by user inputs
                    basicPay = (double)Convert.ToDecimal(textBox1.Text.ToString());
                    //textBox1.Text = basicPay.ToString("N"); //making user inputs with comma after three digits
                    textBox2.Focus();
                }
            }
            catch (Exception ex)
            {
               //clear user input because of invaild input
               textBox1.Text = "0.0";    
               label40.Text = "0.0";  
               label57.Text = "0.0";  
            }

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //any string number(with comma or without comma) coverted to double
                    double specialPay = (double)Convert.ToDecimal(textBox2.Text.ToString());
                    textBox2.Text = specialPay.ToString("N"); //making user inputs with comma after three digits
                    textBox3.Focus();
                }
            }
            catch
            {
                //clear user input because of invaild inputs
                textBox2.Text = "0.0";
                label41.Text = "0.0";
                label58.Text = "0.0";
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //any string number(with comma or without comma) coverted to double
                    double dearnessAllowance = (double)Convert.ToDecimal(textBox3.Text.ToString());
                    textBox3.Text = dearnessAllowance.ToString("N"); //making user inputs with comma after three digits
                    textBox4.Focus();
                }
            }
            catch
            {
                //clear user input because of invaild inputs
                textBox3.Text = "0.0";    
                label42.Text = "0.0";
                label59.Text = "0.0";
            }
            
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //any string number(with comma or without comma) coverted to double
                    double conveyanceAllowance = (double)Convert.ToDecimal(textBox4.Text.ToString());
                    textBox4.Text = conveyanceAllowance.ToString("N"); //making user inputs with comma after three digits
                    textBox5.Focus();
                }
            }
            catch
            {
                textBox4.Text = "0.0";    //clear user input because of invaild inputs
                label43.Text = "0.0";
                label60.Text = "0.0";
            }
           
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //any string number(with comma or without comma) coverted to double
                    double houseRentAllowance = (double)Convert.ToDecimal(textBox5.Text.ToString());
                    textBox5.Text = houseRentAllowance.ToString("N"); //making user inputs with comma after three digits
                    textBox6.Focus();
                }
            }
            catch
            {
                //show crash issue to user
                //clear user input because of invaild inputs
                textBox5.Text = "0.0";   
                label44.Text = "0.0";
                label61.Text = "0.0";
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //any string number(with comma or without comma) coverted to double
                    double medicalAllowance = (double)Convert.ToDecimal(textBox6.Text.ToString());
                    textBox6.Text = medicalAllowance.ToString("N"); //making user inputs with comma after three digits
                    textBox7.Focus();
                }
            }
            catch
            {
                //show crash issue to user
                //clear user input because of invaild inputs
                textBox6.Text = "0.0";    
                label45.Text = "0.0";
                label62.Text = "0.0";
            }
            
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //any string number(with comma or without comma) coverted to double
                    double serventAllowance = (double)Convert.ToDecimal(textBox7.Text.ToString());
                    textBox7.Text = serventAllowance.ToString("N"); //making user inputs with comma after three digits
                    textBox25.Focus();
                }
            }
            catch
            {
                //clear user input because of invaild inputs
                textBox7.Text = "0.0";    
                label46.Text = "0.0";
                label63.Text = "0.0";
            }
        }

        // Leave allownace calculation result
        private void textBox25_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //any string number(with comma or without comma) coverted to double
                    double serventAllowance = (double)Convert.ToDecimal(textBox25.Text.ToString());
                    textBox25.Text = serventAllowance.ToString("N"); //making user inputs with comma after three digits
                    textBox8.Focus();
                }
            }
            catch
            {
                //clear user input because of invaild inputs
                textBox25.Text = "0.0";    
                label92.Text = "0.0";
                label93.Text = "0.0";
            }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //any string number(with comma or without comma) coverted to double
                    double rewardSalary = (double)Convert.ToDecimal(textBox8.Text.ToString());
                    textBox8.Text = rewardSalary.ToString("N"); //making user inputs with comma after three digits
                    textBox9.Focus();
                }
            }
            catch
            {
                //clear user input because of invaild inputs
                textBox8.Text = "0.0";    
                label47.Text = "0.0";
                label64.Text = "0.0";
            }
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //any string number(with comma or without comma) coverted to double
                    double overtimeAllowance = (double)Convert.ToDecimal(textBox9.Text.ToString());
                    textBox9.Text = overtimeAllowance.ToString("N"); //making user inputs with comma after three digits
                    textBox10.Focus();
                }
            }
            catch
            {
                //clear user input because of invaild inputs
                textBox9.Text = "0.0";    
                label48.Text = "0.0";
                label65.Text = "0.0";
            }
            
        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //any string number(with comma or without comma) coverted to double
                    double bonusOrGratia = (double)Convert.ToDecimal(textBox10.Text.ToString());
                    textBox10.Text = bonusOrGratia.ToString("N"); //making user inputs with comma after three digits
                    textBox11.Focus();
                }
            }
            catch
            {
                //clear user input because of invaild inputs
                textBox10.Text = "0.0";    
                label49.Text = "0.0";
                label66.Text = "0.0";
            }
            
        }

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //any string number(with comma or without comma) coverted to double
                    double otherAllowance = (double)Convert.ToDecimal(textBox11.Text.ToString());
                    textBox11.Text = otherAllowance.ToString("N"); //making user inputs with comma after three digits
                    textBox12.Focus();
                }
            }
            catch
            {
                //clear user input because of invaild inputs
                textBox11.Text = "0.0";    
                label50.Text = "0.0";
                label67.Text = "0.0";
            }
        }

        private void textBox12_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //any string number(with comma or without comma) coverted to double
                    double providentFund = (double)Convert.ToDecimal(textBox12.Text.ToString());
                    textBox12.Text = providentFund.ToString("N"); //making user inputs with comma after three digits
                    textBox13.Focus();
                }
            }
            catch
            {
                //clear user input because of invaild inputs
                textBox12.Text = "0.0";    
                label51.Text = "0.0";
                label68.Text = "0.0";
            }
        }

        private void textBox13_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //any string number(with comma or without comma) coverted to double
                    double InterestOnprovidentFund = (double)Convert.ToDecimal(textBox13.Text.ToString());//saving "Interest accrued On provident Fund" user input
                    textBox13.Text = InterestOnprovidentFund.ToString("N"); //making user inputs with comma after three digits
                    comboBox3.Focus();
                }
            }
            catch
            {
                //clear user input because of invaild inputs
                textBox13.Text = "0.0";    
                label52.Text = "0.0";
                label69.Text = "0.0";
            }
           
        }


        private void comboBox3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(comboBox3.SelectedIndex == 1)
            {
                double taxableIncome = list[14].TaxableIncome(basicPay, 0);
                double taxExtempted = 0;

                label53.ForeColor = Color.Black;    //valid nontaxable income show as black color
                label70.ForeColor = Color.Black;    //valid taxable income show as black color

                //show valid nontaxable income
                label53.Text = taxExtempted.ToString("N");  //string formatting as a number;which has comma   
                //show valid taxable income 
                label70.Text = taxableIncome.ToString("N");  //string formatting as a number;which has comma   

                //making sum of upto the Net-nontaxable income and showing net TaxExempted income
                label56.Text = CalTotalTaxExempted().ToString("N");    //string formatting as currency number
                ////making sum of upto the Net-taxable income and showing total taxable income
                label73.Text = CalNetTaxableIncome().ToString("N");    //string formatting as currency number
            }
            else
            {
                label53.Text = "0.0";   //select "No", nontaxable show as zero
                label70.Text = "0.0";  //select "No", taxable show as zero

                // net TaxExempted income from salary
                label56.Text = CalTotalTaxExempted().ToString("N");
                //showing total taxable income
                label73.Text = CalNetTaxableIncome().ToString("N");
            }
            comboBox2.Focus();
        }

        private void textBox15_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //any string number(with comma or without comma) coverted to double
                    reducedHomeRent = (double)Convert.ToDecimal(textBox15.Text.ToString());
                    textBox15.Text = reducedHomeRent.ToString("N"); //making user inputs with comma after three digits
                    textBox16.Focus();
                }
            }
            catch
            {
                //clear user input because of invaild inputs
                textBox15.Text = "0.0";    
                label54.Text = "0.0";
                label71.Text = "0.0";
            }
        }

        private void textBox16_KeyDown(object sender, KeyEventArgs e)
        {
            double other = 0.0;

            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //any string number(with comma or without comma) coverted to double
                    other = (double)Convert.ToDecimal(textBox16.Text.ToString());
                    textBox16.Text = other.ToString("N"); //making user inputs with comma after three digits
                }
            }
            catch
            {
                //clear user input because of invaild inputs
                textBox16.Text = "0.0";    
                label55.Text = "0.0";
                label72.Text = "0.0";
            }
           
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox17.Focus();             
            }
        }

        private void textBox17_KeyDown(object sender, KeyEventArgs e)
        {
            double annualRentalIncome = 0.0;
            try
            {
               if (e.KeyCode == Keys.Enter)
                {
                    //any string number(with comma or without comma) coverted to double
                    annualRentalIncome = (double)Convert.ToDecimal(textBox17.Text.ToString());
                    textBox17.Text = annualRentalIncome.ToString("N");  //string formatting as a currency number
                    textBox18.Focus();
                }
            }
            catch
            {
                //show crash issue to user
                //clear user input because of invaild inputs
                textBox17.Text = "0.0";
            }
        }

        private void textBox18_KeyDown(object sender, KeyEventArgs e)
        {
            double repair = 0.0;
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    repair = (double)Convert.ToDecimal(textBox18.Text.ToString());
                    textBox18.Text = repair.ToString("N");
                    textBox19.Focus();
                }
            }
            catch
            {
                textBox18.Text = "0.0"; //clear user input because of invaild inputs
            }
        }

        private void textBox19_KeyDown(object sender, KeyEventArgs e)
        {
            double localTax = 0.0;
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                    localTax = (double)Convert.ToDecimal(textBox19.Text.ToString());
                    textBox19.Text = localTax.ToString("N");    //string formatting as a currency number
                    textBox20.Focus();
                }
            }
            catch
            {
                textBox19.Text = "0.0"; //clear user input because of invaild inputs
            }
        }

        private void textBox20_KeyDown(object sender, KeyEventArgs e)
        {
            double landRevenue = 0.0; 
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    landRevenue = (double)Convert.ToDecimal(textBox20.Text.ToString());
                    textBox20.Text = landRevenue.ToString("N");    //string formatting as a currency number
                    textBox21.Focus();
                }
            }
            catch
            {
                textBox20.Text = "0.0"; //clear user input because of invaild inputs
            }
        }

        private void textBox21_KeyDown(object sender, KeyEventArgs e)
        {          
            double interestOnLoan = 0.0;
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    interestOnLoan = (double)Convert.ToDecimal(textBox21.Text.ToString());
                    textBox21.Text = interestOnLoan.ToString("N");    //string formatting as a currency number

                    textBox22.Focus();
                }
            }
            catch
            {
                textBox21.Text = "0.0"; //clear user input because of invaild inputs
            }
        }

        private void textBox22_KeyDown(object sender, KeyEventArgs e)
        {
            double insurancePremium = 0.0;
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    insurancePremium = (double)Convert.ToDecimal(textBox22.Text.ToString());
                    textBox22.Text = insurancePremium.ToString("N");    //string formatting as a currency number
                    textBox23.Focus();
                }
            }
            catch
            {
                textBox22.Text = "0.0";
            }
        }

        private void textBox23_KeyDown(object sender, KeyEventArgs e)
        {
            double vancancyAllowance = 0.0;
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    vancancyAllowance = (double)Convert.ToDecimal(textBox23.Text.ToString());
                    textBox23.Text = vancancyAllowance.ToString("N");    //string formatting as a currency number
                    textBox24.Focus();
                }
            }
            catch
            {
                textBox23.Text = "0.0"; //clear user input because of invaild inputs
            }
        }

        private void textBox24_KeyDown(object sender, KeyEventArgs e)
        {
            double others = 0.0;
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    others = (double)Convert.ToDecimal(textBox24.Text.ToString());
                    textBox24.Text = others.ToString("N");    //string formatting as a currency number
                }
            }
            catch
            {
                textBox24.Text = "0.0";  //clear user input because of invaild inputs
            }
        }

        //basic pay
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            //
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;   //cancel the event 

            }


            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;

            }

           
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;   //cancel the event 

            }


            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;

            }

        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;   //cancel the event 

            }


            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;

            }

        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            //
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;   //cancel the event 

            }


            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;

            }

        }
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            //
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;   //cancel the event 

            }


            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;

            }

        }
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            //
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;   //cancel the event 

            }


            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;

            }
            else
            {
                if (textBox6.Text.ToString().Length > 0 && textBox6.Text.ToString()[0] != '0')
                {

                    double medicalAllowance = double.Parse(textBox6.Text.ToString());
                    
                }
            }

        }
        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            //
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;   //cancel the event 

            }


            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;

            }

        }
        private void textBox25_KeyPress(object sender, KeyPressEventArgs e)
        {
            //
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;   //cancel the event 

            }


            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;

            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            //
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;   //cancel the event 

            }


            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;

            }

        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            //
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;   //cancel the event 

            }


            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;

            }

        }
        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            //
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;   //cancel the event 

            }


            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;

            }

        }
        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            //
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;   //cancel the event 

            }


            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;

            }

        }
        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            //
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;   //cancel the event 

            }


            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;

            }

        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            //
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;   //cancel the event 

            }


            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;

            }

        }
        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            //
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;   //cancel the event 

            }


            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;

            }

        }

        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {
            //
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;   //cancel the event 

            }


            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;

            }

        }
        private void textBox17_KeyPress(object sender, KeyPressEventArgs e)
        {
            //
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;   //cancel the event 

            }


            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;

            }

        }
        private void textBox18_KeyPress(object sender, KeyPressEventArgs e)
        {
            //
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;   //cancel the event 

            }


            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;

            }

        }
        private void textBox19_KeyPress(object sender, KeyPressEventArgs e)
        {
            //
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;   //cancel the event 

            }


            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;

            }

        }
        private void textBox20_KeyPress(object sender, KeyPressEventArgs e)
        {
            //
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;   //cancel the event 

            }


            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;

            }

        }
        private void textBox21_KeyPress(object sender, KeyPressEventArgs e)
        {
            //
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;   //cancel the event 

            }


            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;

            }

        }
        private void textBox22_KeyPress(object sender, KeyPressEventArgs e)
        {
            //
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;   //cancel the event 

            }


            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;

            }

        }
        private void textBox23_KeyPress(object sender, KeyPressEventArgs e)
        {
            //
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;   //cancel the event 

            }


            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;

            }

        }
        private void textBox24_KeyPress(object sender, KeyPressEventArgs e)
        {
            //
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;   //cancel the event 

            }


            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;

            }

        }
  
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1_Personal_info.GetInstance.Show();
        }

        private void Form2_Salaries_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                //application Closing by cross cursor;
                Application.Exit();
            }
        }


        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(comboBox2.SelectedIndex == 0) // if none is selected
            {
                textBox15.Enabled = false;
                label54.ForeColor = Color.Black;
                label71.ForeColor = Color.Black;

                textBox15.Text = "0";
                label54.Text = "0";
                label71.Text = "0";

                //showing total taxable income
                label73.Text = CalNetTaxableIncome().ToString();
            }
            else if(comboBox2.SelectedIndex == 1) // if it is free home
            {
                textBox15.Enabled = false;
                label54.ForeColor = Color.Black;
                label71.ForeColor = Color.Black;

                textBox15.Text = "0";
                label54.Text = "0";
                label71.Text = (basicPay * 0.25).ToString();

                //showing total taxable income
                label73.Text = CalNetTaxableIncome().ToString();
            }
            else if(comboBox2.SelectedIndex == 2) // if there is reduced rent
            {
                textBox15.Enabled = true;
                textBox15.Focus();

                label54.ForeColor = Color.Black;
                label71.ForeColor = Color.Black;

                label54.Text = "0";
                label71.Text = "0";
                textBox15.Text = "0";

                //showing total taxable income
                label73.Text = CalNetTaxableIncome().ToString();
            }
        }


        //basic pay calculation
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //cleanning space,additional commas during copy-paste by user inputs
                basicPay = (double)Convert.ToDecimal(textBox1.Text.ToString());
                textBox1.Text = basicPay.ToString("N"); //making user inputs with comma after three digits
                //any string number(with comma or without comma) coverted to double
                //basicPay = (double)Convert.ToDecimal(textBox1.Text.ToString());
                double taxableIncome = list[0].TaxableIncome(basicPay, basicPay, 0);
                double taxExtempted = TaxExemptCal(basicPay, taxableIncome);

                label40.ForeColor = Color.Black;
                label57.ForeColor = Color.Black;

                label40.Text = taxExtempted.ToString("N");  //string formatting as a number;which has comma
                label57.Text = taxableIncome.ToString("N");  //string formatting as a number;which has comma

                // net taxable income from salary
                label39.Text = TotalAmountOfIncome().ToString("N");  //string formatting as a number;which has comma
                label56.Text = CalTotalTaxExempted().ToString("N");  //string formatting as a number;which has comma
                                                                     //showing total taxable income
                label73.Text = CalNetTaxableIncome().ToString("N");  //string formatting as a number;which has comma
            }
            catch
            {
                //show crash issue to user
                //textBox1.Text = "";    //clear user input because of invaild inputs
            }

        }

        //special pay calculation
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //any string number(with comma or without comma) coverted to double
                double specialPay = (double)Convert.ToDecimal(textBox2.Text.ToString());
                double taxableIncome = list[1].TaxableIncome(basicPay, specialPay, 0);
                double taxExtempted = TaxExemptCal(specialPay, taxableIncome);

                label41.ForeColor = Color.Black;
                label58.ForeColor = Color.Black;

                label41.Text = taxExtempted.ToString("N");  //string formatting as a number;which has comma;
                label58.Text = taxableIncome.ToString("N");  //string formatting as a number;which has comma

                // net taxable income from salary
                label39.Text = TotalAmountOfIncome().ToString("N");  //string formatting as a number;which has comma
                label56.Text = CalTotalTaxExempted().ToString("N");  //string formatting as a number;which has comma
                                                                     //showing total taxable income                                                   
                label73.Text = CalNetTaxableIncome().ToString("N");  //string formatting as a number;which has comma
            }
            catch
            {
                //show crash issue to user
               // textBox2.Text = "";    //clear user input because of invaild inputs
            }

        }

        //Dearness allownace calculation
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //any string number(with comma or without comma) coverted to double
                double dearnessAllowance = (double)Convert.ToDecimal(textBox3.Text.ToString());
                double taxableIncome = list[2].TaxableIncome(basicPay, dearnessAllowance, 0);
                double taxExtempted = TaxExemptCal(dearnessAllowance, taxableIncome);

                label42.ForeColor = Color.Black;
                label59.ForeColor = Color.Black;

                label42.Text = taxExtempted.ToString("N");  //string formatting as a number;which has comma
                label59.Text = taxableIncome.ToString("N");  //string formatting as a number;which has comma

                // net taxable income from salary
                label39.Text = TotalAmountOfIncome().ToString("N");  //string formatting as a number;which has comma
                label56.Text = CalTotalTaxExempted().ToString("N");  //string formatting as a number;which has comma
                //showing total taxable income
                label73.Text = CalNetTaxableIncome().ToString("N");  //string formatting as a number;which has comma
            }
            catch 
            {
                //show crash issue to user
                //textBox3.Text = "";    //clear user input because of invaild inputs
            }

        }

        //Conveyance allownace calculation
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //any string number(with comma or without comma) coverted to double
                double conveyanceAllowance = (double)Convert.ToDecimal(textBox4.Text.ToString());
                double taxableIncome = list[3].TaxableIncome(basicPay, conveyanceAllowance, 0);
                double taxExtempted = TaxExemptCal(conveyanceAllowance, taxableIncome);

                label43.ForeColor = Color.Black;
                label60.ForeColor = Color.Black;

                label43.Text = taxExtempted.ToString("N");  //string formatting as a number;which has comma
                label60.Text = taxableIncome.ToString("N");  //string formatting as a number;which has comma

                // net taxable income from salary
                label39.Text = TotalAmountOfIncome().ToString("N");  //string formatting as a number;which has comma
                label56.Text = CalTotalTaxExempted().ToString("N");  //string formatting as a number;which has comma
                 //showing total taxable income
                label73.Text = CalNetTaxableIncome().ToString("N");  //string formatting as a number;which has comma
            }
            catch
            {
                //show crash issue to user
               // textBox4.Text = "";    //clear user input because of invaild inputs
            }
        }

        //House rent calculation
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //any string number(with comma or without comma) coverted to double
                double houseRentAllowance = (double)Convert.ToDecimal(textBox5.Text.ToString());
                double taxableIncome = list[4].TaxableIncome(basicPay, houseRentAllowance, 0);
                double taxExtempted = TaxExemptCal(houseRentAllowance, taxableIncome);

                label44.ForeColor = Color.Black;
                label61.ForeColor = Color.Black;

                label44.Text = taxExtempted.ToString("N");  //string formatting as a number;which has comma
                label61.Text = taxableIncome.ToString("N");  //string formatting as a number;which has comma

                // net taxable income from salary
                label39.Text = TotalAmountOfIncome().ToString("N");  //string formatting as a number;which has comma
                label56.Text = CalTotalTaxExempted().ToString("N");  //string formatting as a number;which has comma
                //showing total taxable income
                label73.Text = CalNetTaxableIncome().ToString("N");  //string formatting as a number;which has comma
            }
            catch
            {
                //textBox5.Text = "";    //clear user input because of invaild inputs
            }
        }

        //Medical allowance calculation
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            double taxableIncome =0.0;
            try
            {
                //any string number(with comma or without comma) coverted to double
                double medicalAllowance = (double)Convert.ToDecimal(textBox6.Text.ToString());
                
                if (comboBox1.SelectedIndex == 0)
                {
                    taxableIncome = list[5].TaxableIncome(basicPay, medicalAllowance, 0);

                }
                else
                    taxableIncome = list[5].TaxableIncome(basicPay, medicalAllowance, 1);

                double taxExtempted = TaxExemptCal(medicalAllowance, taxableIncome);

                label45.ForeColor = Color.Black;
                label62.ForeColor = Color.Black;

                label45.Text = taxExtempted.ToString("N");  //string formatting as a number;which has comma
                label62.Text = taxableIncome.ToString("N");  //string formatting as a number;which has comma

                // net taxable income from salary
                label39.Text = TotalAmountOfIncome().ToString("N");  //string formatting as a number;which has comma
                label56.Text = CalTotalTaxExempted().ToString("N");  //string formatting as a number;which has comma
                //showing total taxable income
                label73.Text = CalNetTaxableIncome().ToString("N");  //string formatting as a number;which has comma
            }
            catch
            {
                //show crash issue to user
                //textBox6.Text = "";    //clear user input because of invaild inputs
            }
        }

        //Servant allowance calculation
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //any string number(with comma or without comma) coverted to double
                double serventAllowance = (double)Convert.ToDecimal(textBox7.Text.ToString());
                double taxableIncome = list[6].TaxableIncome(basicPay, serventAllowance, 0);
                double taxExtempted = TaxExemptCal(serventAllowance, taxableIncome);

                label46.ForeColor = Color.Black;
                label63.ForeColor = Color.Black;

                label46.Text = taxExtempted.ToString("N");  //string formatting as a number;which has comma
                label63.Text = taxableIncome.ToString("N");  //string formatting as a number;which has comma

                // net taxable income from salary
                label39.Text = TotalAmountOfIncome().ToString("N");  //string formatting as a number;which has comma
                label56.Text = CalTotalTaxExempted().ToString("N");  //string formatting as a number;which has comma
                //showing total taxable income
                label73.Text = CalNetTaxableIncome().ToString("N");  //string formatting as a number;which has comma
            }
            catch
            {
                //show crash issue to user
                //textBox7.Text = "";    //clear user input because of invaild inputs
            }
        }

        //Leave allowance calculation
        private void textBox25_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //any string number(with comma or without comma) coverted to double
                double serventAllowance = (double)Convert.ToDecimal(textBox25.Text.ToString());
                double taxableIncome = list[7].TaxableIncome(basicPay, serventAllowance, 0);
                double taxExtempted = TaxExemptCal(serventAllowance, taxableIncome);

                label92.ForeColor = Color.Black;
                label93.ForeColor = Color.Black;

                label92.Text = taxExtempted.ToString("N");  //string formatting as a number;which has comma
                label93.Text = taxableIncome.ToString("N");  //string formatting as a number;which has comma

                // net taxable income from salary
                label39.Text = TotalAmountOfIncome().ToString("N");  //string formatting as a number;which has comma
                label56.Text = CalTotalTaxExempted().ToString("N");  //string formatting as a number;which has comma
                //showing total taxable income
                label73.Text = CalNetTaxableIncome().ToString("N");  //string formatting as a number;which has comma
            }
            catch
            {
                //show crash issue to user
                //textBox25.Text = "";    //clear user input because of invaild inputs
            }
        }

        //Honorarium/Reward /Fee calculation
        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //any string number(with comma or without comma) coverted to double
                double rewardSalary = (double)Convert.ToDecimal(textBox8.Text.ToString());
                double taxableIncome = list[8].TaxableIncome(basicPay, rewardSalary, 0);
                double taxExtempted = TaxExemptCal(rewardSalary, taxableIncome);

                label47.ForeColor = Color.Black;
                label64.ForeColor = Color.Black;

                label47.Text = taxExtempted.ToString("N");  //string formatting as a number;which has comma
                label64.Text = taxableIncome.ToString("N");  //string formatting as a number;which has comma

                // net taxable income from salary
                label39.Text = TotalAmountOfIncome().ToString("N");  //string formatting as a number;which has comma
                label56.Text = CalTotalTaxExempted().ToString("N");  //string formatting as a number;which has comma
                 //showing total taxable income
                label73.Text = CalNetTaxableIncome().ToString("N");  //string formatting as a number;which has comma

            }
            catch
            {
                //show crash issue to user
               // textBox8.Text = "";    //clear user input because of invaild inputs
            }

        }

        //Overtime allowance calculation
        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //any string number(with comma or without comma) coverted to double
                double overtimeAllowance = (double)Convert.ToDecimal(textBox9.Text.ToString());
                double taxableIncome = list[9].TaxableIncome(basicPay, overtimeAllowance, 0);
                double taxExtempted = TaxExemptCal(overtimeAllowance, taxableIncome);

                label48.ForeColor = Color.Black;
                label65.ForeColor = Color.Black;

                label48.Text = taxExtempted.ToString("N");  //string formatting as a number;which has comma
                label65.Text = taxableIncome.ToString("N");  //string formatting as a number;which has comma

                // net taxable income from salary
                label39.Text = TotalAmountOfIncome().ToString("N");  //string formatting as a number;which has comma
                label56.Text = CalTotalTaxExempted().ToString("N");  //string formatting as a number;which has comma
                //showing total taxable income
                label73.Text = CalNetTaxableIncome().ToString("N");  //string formatting as a number;which has comma
            }
            catch
            {
                //show crash issue to user
                //textBox9.Text = "";    //clear user input because of invaild inputs
            }
        }

        //Bonus /Ex-graria calculation
        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //any string number(with comma or without comma) coverted to double
                double bonusOrGratia = (double)Convert.ToDecimal(textBox10.Text.ToString());
                double taxableIncome = list[10].TaxableIncome(basicPay, bonusOrGratia, 0);
                double taxExtempted = TaxExemptCal(bonusOrGratia, taxableIncome);

                label49.ForeColor = Color.Black;
                label66.ForeColor = Color.Black;

                label49.Text = taxExtempted.ToString("N");  //string formatting as a number;which has comma
                label66.Text = taxableIncome.ToString("N");  //string formatting as a number;which has comma

                // net taxable income from salary
                label39.Text = TotalAmountOfIncome().ToString("N");  //string formatting as a number;which has comma
                label56.Text = CalTotalTaxExempted().ToString("N");  //string formatting as a number;which has comma
                 //showing total taxable income
                label73.Text = CalNetTaxableIncome().ToString("N");  //string formatting as a number;which has comma

            }
            catch
            {
                //show crash issue to user
                //textBox10.Text = "";    //clear user input because of invaild inputs
            }
        }

        //Other allowance calculation
        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //any string number(with comma or without comma) coverted to double
                double otherAllowance = (double)Convert.ToDecimal(textBox11.Text.ToString());
                double taxableIncome = list[11].TaxableIncome(basicPay, otherAllowance, 0);
                double taxExtempted = TaxExemptCal(otherAllowance, taxableIncome);

                label50.ForeColor = Color.Black;
                label67.ForeColor = Color.Black;

                label50.Text = taxExtempted.ToString("N");  //string formatting as a number;which has comma
                label67.Text = taxableIncome.ToString("N");  //string formatting as a number;which has comma

                // net taxable income from salary
                label39.Text = TotalAmountOfIncome().ToString("N");  //string formatting as a number;which has comma
                label56.Text = CalTotalTaxExempted().ToString("N");  //string formatting as a number;which has comma
                //showing total taxable income
                label73.Text = CalNetTaxableIncome().ToString("N");  //string formatting as a number;which has comma

            }
            catch
            {
                //show crash issue to user
               // textBox11.Text = "";    //clear user input because of invaild inputs
            }
        }

        //Employer's contribution to Recognized provident fund calculation
        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //any string number(with comma or without comma) coverted to double
                double providentFund = (double)Convert.ToDecimal(textBox12.Text.ToString());
                double taxableIncome = list[12].TaxableIncome(basicPay, providentFund, 0);
                double taxExtempted = TaxExemptCal(providentFund, taxableIncome);

                label51.ForeColor = Color.Black;
                label68.ForeColor = Color.Black;

                label51.Text = taxExtempted.ToString("N");  //string formatting as a number;which has comma
                label68.Text = taxableIncome.ToString("N");  //string formatting as a number;which has comma

                // net taxable income from salary
                label39.Text = TotalAmountOfIncome().ToString("N");  //string formatting as a number;which has comma
                label56.Text = CalTotalTaxExempted().ToString("N");  //string formatting as a number;which has comma
                //showing total taxable income
                label73.Text = CalNetTaxableIncome().ToString("N");  //string formatting as a number;which has comma
            }
            catch
            {
                // show crash issue to user
                //textBox12.Text = "";    //clear user input because of invaild inputs
            }
        }

        //Interest accrued on Recognized Provident fund calculation
        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //sum = basic pay + Dearness Allowances
                double sum = basicPay + (double)Convert.ToDecimal(textBox3.Text.ToString()); //any string number(with comma or without comma) coverted to double
                //set the maxNonTaxable value for "Interest accrued on Recognized provident fund"
                list[12].setmaxNonTaxable(sum / 3.0);

                //any string number(with comma or without comma) coverted to double
                double InterestOnprovidentFund = (double)Convert.ToDecimal(textBox13.Text.ToString());//saving "Interest accrued On provident Fund" user input

                double taxableIncome = list[13].TaxableIncome(sum, InterestOnprovidentFund, 0);
                double taxExtempted = TaxExemptCal(InterestOnprovidentFund, taxableIncome);

                label52.ForeColor = Color.Black;
                label69.ForeColor = Color.Black;

                label52.Text = taxExtempted.ToString("N");  //string formatting as a number;which has comma
                label69.Text = taxableIncome.ToString("N");  //string formatting as a number;which has comma

                // net taxable income from salary
                label39.Text = TotalAmountOfIncome().ToString("N");  //string formatting as a number;which has comma
                label56.Text = CalTotalTaxExempted().ToString("N");  //string formatting as a number;which has comma
                //summing total "Net Taxable income" and show in label73
                label73.Text = CalNetTaxableIncome().ToString("N");  //string formatting as a number;which has comma    
            }
            catch
            {
                //show crash issue to user
                //textBox13.Text = "";    //clear user input because of invaild inputs
            }
        }

        //Deemed incoem for transport facility calculation
        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            double houseRentTax = 0.0;
            try
            {
                //any string number(with comma or without comma) coverted to double
                reducedHomeRent = (double)Convert.ToDecimal(textBox15.Text.ToString());
                houseRentTax = (basicPay * 0.25) - reducedHomeRent;
                if (houseRentTax > 0.0)
                    label71.Text = houseRentTax.ToString("N");  //string formatting as a number;which has comma
                else
                    label71.Text = "0.0"; // if basic pay is zero , tax is zero

                //showing total taxable income
                label73.Text = CalNetTaxableIncome().ToString("N");  //string formatting as a number;which has comma
            }
            catch
            {
                //show crash issue to user
                //textBox15.Text = "";    //clear user input because of invaild inputs
            }
        }

        //Other, if any :calculation
        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            double other = 0.0, taxableIncome = 0.0, taxExtempted = 0.0;
            try
            {
                //any string number(with comma or without comma) coverted to double
                other = (double)Convert.ToDecimal(textBox16.Text.ToString());
                taxableIncome = list[16].TaxableIncome(basicPay, other, 0);
                taxExtempted = TaxExemptCal(other, taxableIncome);

                label55.ForeColor = Color.Black;
                label72.ForeColor = Color.Black;

                label55.Text = taxExtempted.ToString("N");  //string formatting as a number;which has comma
                label72.Text = taxableIncome.ToString("N");  //string formatting as a number;which has comma

                // net taxable income from salary
                label39.Text = TotalAmountOfIncome().ToString("N");  //string formatting as a number;which has comma
                label56.Text = CalTotalTaxExempted().ToString("N");  //string formatting as a number;which has comma
                //showing total taxable income
                label73.Text = CalNetTaxableIncome().ToString("N");  //string formatting as a number;which has comma
            }
            catch
            {
                //show crash issue to user
                //textBox16.Text = "";    //clear user input because of invaild inputs
            }
        }
       
        /*............House property income calculation ...............*/
        
            //Annul Rental Income
        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            double annualRentalIncome = 0.0, netRentalIncome = 0.0;
            try
            {
                //any string number(with comma or without comma) coverted to double
                annualRentalIncome = (double)Convert.ToDecimal(textBox17.Text.ToString());
                netRentalIncome = annualRentalIncome - CalTotalClaimedExpense();
                label91.Text = netRentalIncome.ToString("N");   //string formatting as a currrency number "N";which makes comma
            }
            catch
            {
               
            }
        }

        //textbox18 to textBox24 ; all house rent "Claim Expenses"
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            double annualRentalIncome = 0.0, netRentalIncome = 0.0, totalClaimedExpense = 0.0;
            try
            {
                //any string number(with comma or without comma) coverted to double
                annualRentalIncome = (double)Convert.ToDecimal(textBox17.Text.ToString());
                totalClaimedExpense = CalTotalClaimedExpense();
                netRentalIncome = annualRentalIncome - totalClaimedExpense;

                //show total "Clain Expenses"
                label90.Text = totalClaimedExpense.ToString("N");   //string formatting as a currrency number "N";which makes comma
                //show "Net income" from house property
                label91.Text = netRentalIncome.ToString("N");   //string formatting as a currrency number "N";which makes comma
            }
            catch
            {

            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "") textBox1.Text = "0.0";
            try
            {
                Convert.ToDecimal(textBox1.Text.ToString());    //if user copy-paste invaild(or number with characters)
            }
            catch
            {
                textBox1.Text = "0.0";      //Then make user inputs cleaned by "0.0"
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "") textBox2.Text = "0.0"; //if user clean input field then replaced input by "0.0"
            try
            {
                Convert.ToDecimal(textBox2.Text.ToString());    //if user copy-paste invaild(or number with characters)
            }
            catch
            {
                textBox2.Text = "0.0";      //Then make user inputs cleaned by "0.0"
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "") textBox3.Text = "0.0"; //if user clean input field then replaced input by "0.0"
            try
            {
                Convert.ToDecimal(textBox3.Text.ToString());    //if user copy-paste invaild(or number with characters)
            }
            catch
            {
                textBox3.Text = "0.0";      //Then make user inputs cleaned by "0.0"
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "") textBox4.Text = "0.0"; //if user clean input field then replaced input by "0.0"
            try
            {
                Convert.ToDecimal(textBox4.Text.ToString());    //if user copy-paste invaild(or number with characters)
            }
            catch
            {
                textBox4.Text = "0.0";      //Then make user inputs cleaned by "0.0"
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text == "") textBox5.Text = "0.0"; //if user clean input field then replaced input by "0.0"
            try
            {
                Convert.ToDecimal(textBox5.Text.ToString());    //if user copy-paste invaild(or number with characters)
            }
            catch
            {
                textBox5.Text = "0.0";      //Then make user inputs cleaned by "0.0"
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox6.Text == "") textBox6.Text = "0.0"; //if user clean input field then replaced input by "0.0"
            try
            {
                Convert.ToDecimal(textBox6.Text.ToString());    //if user copy-paste invaild(or number with characters)
            }
            catch
            {
                textBox6.Text = "0.0";      //Then make user inputs cleaned by "0.0"
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (textBox7.Text == "") textBox7.Text = "0.0"; //if user clean input field then replaced input by "0.0"
            try
            {
                Convert.ToDecimal(textBox7.Text.ToString());    //if user copy-paste invaild(or number with characters)
            }
            catch
            {
                textBox7.Text = "0.0";      //Then make user inputs cleaned by "0.0"
            }
        }

        private void textBox25_Leave(object sender, EventArgs e)
        {
            if (textBox25.Text == "") textBox25.Text = "0.0";   //if user clean input field then replaced input by "0.0"
            try
            {
                Convert.ToDecimal(textBox25.Text.ToString());    //if user copy-paste invaild(or number with characters)
            }
            catch
            {
                textBox25.Text = "0.0";      //Then make user inputs cleaned by "0.0"
            }
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            if (textBox8.Text == "") textBox8.Text = "0.0"; //if user clean input field then replaced input by "0.0"
            try
            {
                Convert.ToDecimal(textBox8.Text.ToString());    //if user copy-paste invaild(or number with characters)
            }
            catch
            {
                textBox8.Text = "0.0";      //Then make user inputs cleaned by "0.0"
            }
        }

        private void textBox9_Leave(object sender, EventArgs e)
        {
            if (textBox9.Text == "") textBox9.Text = "0.0"; //if user clean input field then replaced input by "0.0"
            try
            {
                Convert.ToDecimal(textBox9.Text.ToString());    //if user copy-paste invaild(or number with characters)
            }
            catch
            {
                textBox9.Text = "0.0";      //Then make user inputs cleaned by "0.0"
            }
        }

        private void textBox10_Leave(object sender, EventArgs e)
        {
            if (textBox10.Text == "") textBox10.Text = "0.0";   //if user clean input field then replaced input by "0.0"
            try
            {
                Convert.ToDecimal(textBox10.Text.ToString());    //if user copy-paste invaild(or number with characters)
            }
            catch
            {
                textBox10.Text = "0.0";      //Then make user inputs cleaned by "0.0"
            }
        }

        private void textBox11_Leave(object sender, EventArgs e)
        {
            if (textBox11.Text == "") textBox11.Text = "0.0";   //if user clean input field then replaced input by "0.0"
            try
            {
                Convert.ToDecimal(textBox11.Text.ToString());    //if user copy-paste invaild(or number with characters)
            }
            catch
            {
                textBox11.Text = "0.0";      //Then make user inputs cleaned by "0.0"
            }
        }

        private void textBox12_Leave(object sender, EventArgs e)
        {
            if (textBox12.Text == "") textBox12.Text = "0.0";   //if user clean input field then replaced input by "0.0"
            try
            {
                Convert.ToDecimal(textBox12.Text.ToString());    //if user copy-paste invaild(or number with characters)
            }
            catch
            {
                textBox12.Text = "0.0";      //Then make user inputs cleaned by "0.0"
            }
        }

        private void textBox13_Leave(object sender, EventArgs e)
        {
            if (textBox13.Text == "") textBox13.Text = "0.0";   //if user clean input field then replaced input by "0.0"
            try
            {
                Convert.ToDecimal(textBox13.Text.ToString());    //if user copy-paste invaild(or number with characters)
            }
            catch
            {
                textBox13.Text = "0.0";      //Then make user inputs cleaned by "0.0"
            }
        }

        private void textBox15_Leave(object sender, EventArgs e)
        {
            if (textBox15.Text == "") textBox15.Text = "0.0";   //if user clean input field then replaced input by "0.0"
            try
            {
                Convert.ToDecimal(textBox15.Text.ToString());    //if user copy-paste invaild(or number with characters)
            }
            catch
            {
                textBox15.Text = "0.0";      //Then make user inputs cleaned by "0.0"
            }
        }

        private void textBox16_Leave(object sender, EventArgs e)
        {
            if (textBox16.Text == "") textBox16.Text = "0.0";   //if user clean input field then replaced input by "0.0"
            try
            {
                Convert.ToDecimal(textBox16.Text.ToString());    //if user copy-paste invaild(or number with characters)
            }
            catch
            {
                textBox16.Text = "0.0";      //Then make user inputs cleaned by "0.0"
            }
        }


        private void textBox17_Leave(object sender, EventArgs e)
        {
            if (textBox17.Text == "") textBox17.Text = "0.0";   //if user clean input field then replaced input by "0.0"
            try
            {
                Convert.ToDecimal(textBox17.Text.ToString());    //if user copy-paste invaild(or number with characters)
            }
            catch
            {
                textBox17.Text = "0.0";      //Then make user inputs cleaned by "0.0"
            }
        }

        private void textBox18_Leave(object sender, EventArgs e)
        {
            if (textBox18.Text == "") textBox18.Text = "0.0";   //if user clean input field then replaced input by "0.0"
            try
            {
                Convert.ToDecimal(textBox18.Text.ToString());    //if user copy-paste invaild(or number with characters)
            }
            catch
            {
                textBox18.Text = "0.0";      //Then make user inputs cleaned by "0.0"
            }
        }

        private void textBox19_Leave(object sender, EventArgs e)
        {
            if (textBox19.Text == "") textBox19.Text = "0.0";   //if user clean input field then replaced input by "0.0"
            try
            {
                Convert.ToDecimal(textBox19.Text.ToString());    //if user copy-paste invaild(or number with characters)
            }
            catch
            {
                textBox19.Text = "0.0";      //Then make user inputs cleaned by "0.0"
            }
        }

        private void textBox20_Leave(object sender, EventArgs e)
        {
            if (textBox20.Text == "") textBox20.Text = "0.0";   //if user clean input field then replaced input by "0.0"
            try
            {
                Convert.ToDecimal(textBox20.Text.ToString());    //if user copy-paste invaild(or number with characters)
            }
            catch
            {
                textBox20.Text = "0.0";      //Then make user inputs cleaned by "0.0"
            }
        }

        private void textBox21_Leave(object sender, EventArgs e)
        {
            if (textBox21.Text == "") textBox21.Text = "0.0";   //if user clean input field then replaced input by "0.0"
            try
            {
                Convert.ToDecimal(textBox21.Text.ToString());    //if user copy-paste invaild(or number with characters)
            }
            catch
            {
                textBox21.Text = "0.0";      //Then make user inputs cleaned by "0.0"
            }
        }

        private void textBox22_Leave(object sender, EventArgs e)
        {
            if (textBox22.Text == "") textBox22.Text = "0.0";   //if user clean input field then replaced input by "0.0"
            try
            {
                Convert.ToDecimal(textBox22.Text.ToString());    //if user copy-paste invaild(or number with characters)
            }
            catch
            {
                textBox22.Text = "0.0";      //Then make user inputs cleaned by "0.0"
            }
        }

        private void textBox23_Leave(object sender, EventArgs e)
        {
            if (textBox23.Text == "") textBox23.Text = "0.0";   //if user clean input field then replaced input by "0.0"
            try
            {
                Convert.ToDecimal(textBox23.Text.ToString());    //if user copy-paste invaild(or number with characters)
            }
            catch
            {
                textBox23.Text = "0.0";      //Then make user inputs cleaned by "0.0"
            }
        }

        private void textBox24_Leave(object sender, EventArgs e)
        {
            if (textBox24.Text == "") textBox24.Text = "0.0";   //if user clean input field then replaced input by "0.0"
            try
            {
                Convert.ToDecimal(textBox24.Text.ToString());    //if user copy-paste invaild(or number with characters)
            }
            catch
            {
                textBox24.Text = "0.0";      //Then make user inputs cleaned by "0.0"
            }
        }


        private void UserInputs_Salaries()
        {
            pdfInputs1[0] = textBox1.Text.ToString();    //salaries
            pdfInputs1[1] = textBox2.Text.ToString();    //Special pay
            pdfInputs1[2] = textBox3.Text.ToString();    //Dearness Allowances
            pdfInputs1[3] = textBox4.Text.ToString();    //Conveyance allowances
            pdfInputs1[4] = textBox5.Text.ToString();    //House rent allounces
            pdfInputs1[5] = textBox6.Text.ToString();    //Medical Allowances
            pdfInputs1[6] = textBox7.Text.ToString();    //Servant allowances
            pdfInputs1[7] = textBox25.Text.ToString();   //Leave allowances
            pdfInputs1[8] = textBox8.Text.ToString();    //Honorarum/reward/Arear salary
            pdfInputs1[9] = textBox9.Text.ToString();    //Overtime allowance
            pdfInputs1[10] = textBox10.Text.ToString();  //Bonus / Extra Gratia
            pdfInputs1[11] = textBox11.Text.ToString();  //Other Allowances
            pdfInputs1[12] = textBox12.Text.ToString();  //Employees contributions to recognized Provdent Fund
            pdfInputs1[13] = textBox13.Text.ToString();  //Interest accrued on Recognized provident fund
            pdfInputs1[14] = comboBox3.Text;             //Deemed income for transport facility "yes" or "No"
            pdfInputs1[15] = comboBox2.Text;             //Deemed income for furnished /unfurnished accomodation: None, Free Home, Reduced Rent
            
            pdfInputs1[16] = textBox16.Text.ToString();  //Other ( if any)
            pdfInputs1[17] = label39.Text.ToString();    //Net taxable income from salary


            //non-taxable incomes
            pdfInputs1[18] = label40.Text.ToString();
            pdfInputs1[19] = label41.Text.ToString();
            pdfInputs1[20] = label42.Text.ToString();
            pdfInputs1[21] = label43.Text.ToString();
            pdfInputs1[22] = label44.Text.ToString();
            pdfInputs1[23] = label45.Text.ToString();
            pdfInputs1[24] = label46.Text.ToString();
            pdfInputs1[25] = label92.Text.ToString();       //Leave allowance for nontaxable
            pdfInputs1[26] = label47.Text.ToString();
            pdfInputs1[27] = label48.Text.ToString();
            pdfInputs1[28] = label49.Text.ToString();
            pdfInputs1[29] = label50.Text.ToString();
            pdfInputs1[30] = label51.Text.ToString();
            pdfInputs1[31] = label52.Text.ToString();
            pdfInputs1[32] = label53.Text.ToString();
            pdfInputs1[33] = label54.Text.ToString();
            pdfInputs1[34] = label55.Text.ToString();
            pdfInputs1[35] = label56.Text.ToString();   //Amount of tax exempted income

            //taxable incomes
            pdfInputs1[36] = label57.Text.ToString();
            pdfInputs1[37] = label58.Text.ToString();
            pdfInputs1[38] = label59.Text.ToString();
            pdfInputs1[39] = label60.Text.ToString();
            pdfInputs1[40] = label61.Text.ToString();
            pdfInputs1[41] = label62.Text.ToString();
            pdfInputs1[42] = label63.Text.ToString();
            pdfInputs1[43] = label93.Text.ToString();
            pdfInputs1[44] = label64.Text.ToString();
            pdfInputs1[45] = label65.Text.ToString();
            pdfInputs1[46] = label66.Text.ToString();
            pdfInputs1[47] = label67.Text.ToString();
            pdfInputs1[48] = label68.Text.ToString();
            pdfInputs1[49] = label69.Text.ToString();
            pdfInputs1[50] = label70.Text.ToString();
            pdfInputs1[51] = label71.Text.ToString();
            pdfInputs1[52] = label72.Text.ToString();
            pdfInputs1[53] = label73.Text.ToString();   //Net taxable income form salary

            //House rent property
            pdfInputs2[0] = richTextBox1.Text.ToString();      
            pdfInputs2[1] = textBox17.Text.ToString();  //1.Annual Rental Income
            
            //2.Claimed Expenses:
            pdfInputs2[2] = textBox18.Text.ToString();    //Repair
            pdfInputs2[3] = textBox19.Text.ToString();    //Municipal or Local Tax
            pdfInputs2[4] = textBox20.Text.ToString();    //Land Revenue
            pdfInputs2[5] = textBox21.Text.ToString();    //Interest on Loan/ Mortgage/Capital Charge
            pdfInputs2[6] = textBox22.Text.ToString();     //Insurance Premium
            pdfInputs2[7] = textBox23.Text.ToString();    //Vacancy Allowance
            pdfInputs2[8] = textBox24.Text.ToString();    //Other ( If any )
            pdfInputs2[9] = label90.Text.ToString();    //total

            pdfInputs2[10] = label91.Text.ToString();    // 3.Net Income(difference between item 1 and 2)
        }
    }
}