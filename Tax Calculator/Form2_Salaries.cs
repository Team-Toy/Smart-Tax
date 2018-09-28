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
        public static double totalAmountOfIncome = 0.0;
        public static double netTaxableIncome = 0.0;
        public static double totalTaxExtempted = 0.0;
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

        // house property income
        public static string locationAndDescription = "";
        public static double annualRentalIncome = 0.0;
        // claimed expense
        public static double repair = 0.0;
        public static double municipalTax = 0.0;
        public static double landRevenue = 0.0;
        public static double interestOnLoan = 0.0;
        public static double insurancePremium = 0.0;
        public static double vacancyAllowance = 0.0;
        public static double other = 0.0;
        public static double totalClaimedExpense = 0.0;
        // netRentalIncome = annualRentalIncome - totalClaimedExpense
        public static double netRentalIncome = 0.0;

        public Form2_Salaries()
        {
            InitializeComponent();
            pdfInputs1 = new string[54];
            pdfInputs2 = new string[11];

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            makeAllTextBoxZero();
            makeAllLabelZero();

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
            totalAmountOfIncome =   double.Parse(textBox1.Text.ToString()) +
                                    double.Parse(textBox2.Text.ToString()) +
                                    double.Parse(textBox3.Text.ToString()) +
                                    double.Parse(textBox4.Text.ToString()) +
                                    double.Parse(textBox5.Text.ToString()) +
                                    double.Parse(textBox6.Text.ToString()) +
                                    double.Parse(textBox7.Text.ToString()) +
                                    double.Parse(textBox25.Text.ToString()) +  //Leave allowance
                                    double.Parse(textBox8.Text.ToString()) +
                                    double.Parse(textBox9.Text.ToString()) +
                                    double.Parse(textBox10.Text.ToString()) +
                                    double.Parse(textBox11.Text.ToString()) +
                                    double.Parse(textBox12.Text.ToString()) +
                                    double.Parse(textBox13.Text.ToString()) +
                                    
                                    double.Parse(textBox15.Text.ToString()) +
                                    double.Parse(textBox16.Text.ToString());

             
            return totalAmountOfIncome;
        }
        private double CalTotalTaxExempted()
        {
            totalTaxExtempted = double.Parse(label40.Text.ToString()) +
                                    double.Parse(label41.Text.ToString()) +
                                    double.Parse(label42.Text.ToString()) +
                                    double.Parse(label43.Text.ToString()) +
                                    double.Parse(label44.Text.ToString()) +
                                    double.Parse(label45.Text.ToString()) +
                                    double.Parse(label46.Text.ToString()) +
                                    double.Parse(label92.Text.ToString()) +     //Leave allowance
                                    double.Parse(label47.Text.ToString()) +
                                    double.Parse(label48.Text.ToString()) +
                                    double.Parse(label49.Text.ToString()) +
                                    double.Parse(label50.Text.ToString()) +
                                    double.Parse(label51.Text.ToString()) +
                                    double.Parse(label52.Text.ToString()) +
                                    double.Parse(label53.Text.ToString()) +
                                    double.Parse(label54.Text.ToString()) +
                                    double.Parse(label55.Text.ToString());


            return totalTaxExtempted;
        }
        private double CalNetTaxableIncome()
        {
            netTaxableIncome = double.Parse(label57.Text.ToString()) +
                                    double.Parse(label58.Text.ToString()) +
                                    double.Parse(label59.Text.ToString()) +
                                    double.Parse(label60.Text.ToString()) +
                                    double.Parse(label61.Text.ToString()) +
                                    double.Parse(label62.Text.ToString()) +
                                    double.Parse(label63.Text.ToString()) +
                                    double.Parse(label93.Text.ToString()) +  //Leave allowance
                                    double.Parse(label64.Text.ToString()) +
                                    double.Parse(label65.Text.ToString()) +
                                    double.Parse(label66.Text.ToString()) +
                                    double.Parse(label67.Text.ToString()) +
                                    double.Parse(label68.Text.ToString()) +
                                    double.Parse(label69.Text.ToString()) +
                                    double.Parse(label70.Text.ToString()) +
                                    double.Parse(label71.Text.ToString()) +
                                    double.Parse(label72.Text.ToString());


            return netTaxableIncome;
        }
        private double CalTotalClaimedExpense()
        {
            totalClaimedExpense = double.Parse(textBox18.Text.ToString()) +
                                    double.Parse(textBox19.Text.ToString()) +
                                    double.Parse(textBox20.Text.ToString()) +
                                    double.Parse(textBox21.Text.ToString()) +
                                    double.Parse(textBox22.Text.ToString()) +
                                    double.Parse(textBox23.Text.ToString()) +
                                    double.Parse(textBox24.Text.ToString());
                                


            return totalClaimedExpense;
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {           
            if (e.KeyCode == Keys.Enter)
            {
                if(textBox1.Text.Length == 0)
                {
                    textBox1.Text = "0";
                    
                }
                
                basicPay = double.Parse(textBox1.Text.ToString());
                double taxableIncome = list[0].TaxableIncome(basicPay, basicPay, 0);
                double taxExtempted = TaxExemptCal(basicPay, taxableIncome);

                label40.ForeColor = Color.Black;
                label57.ForeColor = Color.Black;

                label40.Text = "" + taxExtempted;
                label57.Text = "" + taxableIncome;

                netTaxableIncome += taxableIncome;
                totalTaxExtempted += taxExtempted;

                // net taxable income from salary
                label39.Text = TotalAmountOfIncome().ToString();
                label56.Text = CalTotalTaxExempted().ToString();
                //showing total taxable income
                label73.Text = CalNetTaxableIncome().ToString();

                textBox2.Focus();
                
               
            }
            else
            {
                label40.ForeColor = Color.Red;
                label57.ForeColor = Color.Red;
            }
           
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(textBox2.Text.Length == 0)
                {
                    textBox2.Text = "0";
                   
                }
                double specialPay = double.Parse(textBox2.Text.ToString());
                double taxableIncome = list[1].TaxableIncome(basicPay,specialPay, 0);
                double taxExtempted = TaxExemptCal(specialPay, taxableIncome);

                label41.ForeColor = Color.Black;
                label58.ForeColor = Color.Black;

                label41.Text = "" + taxExtempted;
                label58.Text = "" + taxableIncome;

                netTaxableIncome += taxableIncome;
                totalTaxExtempted += taxExtempted;

                // net taxable income from salary
                label39.Text = TotalAmountOfIncome().ToString();
                label56.Text = CalTotalTaxExempted().ToString();
                //showing total taxable income
                label73.Text = CalNetTaxableIncome().ToString();

                textBox3.Focus();
            }
            else
            {
                label41.ForeColor = Color.Red;
                label58.ForeColor = Color.Red;
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox3.Text.Length == 0)
                {
                    textBox3.Text = "0";

                }
                double dearnessAllowance = double.Parse(textBox3.Text.ToString());
                double taxableIncome = list[2].TaxableIncome(basicPay,dearnessAllowance, 0);
                double taxExtempted = TaxExemptCal(dearnessAllowance, taxableIncome);

                label42.ForeColor = Color.Black;
                label59.ForeColor = Color.Black;

                label42.Text = "" + taxExtempted;
                label59.Text = "" + taxableIncome;

                netTaxableIncome += taxableIncome;
                totalTaxExtempted += taxExtempted;

                // net taxable income from salary
                label39.Text = TotalAmountOfIncome().ToString();
                label56.Text = CalTotalTaxExempted().ToString();
                //showing total taxable income
                label73.Text = CalNetTaxableIncome().ToString();

                textBox4.Focus();
            }
            else
            {
                label42.ForeColor = Color.Red;
                label59.ForeColor = Color.Red;
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
                double conveyanceAllowance = double.Parse(textBox4.Text.ToString());
                double taxableIncome = list[3].TaxableIncome(basicPay,conveyanceAllowance, 0);
                double taxExtempted = TaxExemptCal(conveyanceAllowance, taxableIncome);

                label43.ForeColor = Color.Black;
                label60.ForeColor = Color.Black;

                label43.Text = "" + taxExtempted;
                label60.Text = "" + taxableIncome;

                netTaxableIncome += taxableIncome;
                totalTaxExtempted += taxExtempted;

                // net taxable income from salary
                label39.Text = TotalAmountOfIncome().ToString();
                label56.Text = CalTotalTaxExempted().ToString();
                //showing total taxable income
                label73.Text = CalNetTaxableIncome().ToString();

                textBox5.Focus();
            }
            else
            {
                label43.ForeColor = Color.Red;
                label60.ForeColor = Color.Red;
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
                double houseRentAllowance = double.Parse(textBox5.Text.ToString());
                double taxableIncome = list[4].TaxableIncome(basicPay,houseRentAllowance, 0);
                double taxExtempted = TaxExemptCal(houseRentAllowance, taxableIncome);

                label44.ForeColor = Color.Black;
                label61.ForeColor = Color.Black;

                label44.Text = "" + taxExtempted;
                label61.Text = "" + taxableIncome;

                netTaxableIncome += taxableIncome;
                totalTaxExtempted += taxExtempted;

                // net taxable income from salary
                label39.Text = TotalAmountOfIncome().ToString();
                label56.Text = CalTotalTaxExempted().ToString();
                //showing total taxable income
                label73.Text = CalNetTaxableIncome().ToString();

                textBox6.Focus();
            }
            else
            {
                label44.ForeColor = Color.Red;
                label61.ForeColor = Color.Red;
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
                double medicalAllowance = double.Parse(textBox6.Text.ToString());
                double taxableIncome;
                //double taxableIncome;
                if (comboBox1.SelectedIndex == 0)
                {
                    taxableIncome = list[5].TaxableIncome(basicPay, medicalAllowance, 0);
                    
                }
                    

                else  
                    taxableIncome = list[5].TaxableIncome(basicPay,medicalAllowance, 1);

                double taxExtempted = TaxExemptCal(medicalAllowance, taxableIncome);

                label45.ForeColor = Color.Black;
                label62.ForeColor = Color.Black;

                label45.Text = "" + taxExtempted;
                label62.Text = "" + taxableIncome;

                netTaxableIncome += taxableIncome;
                totalTaxExtempted += taxExtempted;

                // net taxable income from salary
                label39.Text = TotalAmountOfIncome().ToString();
                label56.Text = CalTotalTaxExempted().ToString();
                //showing total taxable income
                label73.Text = CalNetTaxableIncome().ToString();

                textBox7.Focus();
            }
            else
            {
                label45.ForeColor = Color.Red;
                label62.ForeColor = Color.Red;
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
                double serventAllowance = double.Parse(textBox7.Text.ToString());
                double taxableIncome = list[6].TaxableIncome(basicPay,serventAllowance, 0);
                double taxExtempted = TaxExemptCal(serventAllowance, taxableIncome);

                label46.ForeColor = Color.Black;
                label63.ForeColor = Color.Black;

                label46.Text = "" + taxExtempted;
                label63.Text = "" + taxableIncome;

                netTaxableIncome += taxableIncome;
                totalTaxExtempted += taxExtempted;

                // net taxable income from salary
                label39.Text = TotalAmountOfIncome().ToString();
                label56.Text = CalTotalTaxExempted().ToString();
                //showing total taxable income
                label73.Text = CalNetTaxableIncome().ToString();

                textBox25.Focus();
            }
            else
            {
                label46.ForeColor = Color.Red;
                label63.ForeColor = Color.Red;
            }
        }


        // Leave allownace calculation result
        private void textBox25_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (textBox25.Text.Length == 0)
                {
                    textBox25.Text = "0";

                }
                double serventAllowance = double.Parse(textBox25.Text.ToString());
                double taxableIncome = list[7].TaxableIncome(basicPay, serventAllowance, 0);
                double taxExtempted = TaxExemptCal(serventAllowance, taxableIncome);

                label92.ForeColor = Color.Black;
                label93.ForeColor = Color.Black;

                label92.Text = "" + taxExtempted;
                label93.Text = "" + taxableIncome;

                netTaxableIncome += taxableIncome;
                totalTaxExtempted += taxExtempted;

                // net taxable income from salary
                label39.Text = TotalAmountOfIncome().ToString();
                label56.Text = CalTotalTaxExempted().ToString();
                //showing total taxable income
                label73.Text = CalNetTaxableIncome().ToString();

                textBox8.Focus();
            }
            else
            {
                label92.ForeColor = Color.Red;
                label93.ForeColor = Color.Red;
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
                double rewardSalary = double.Parse(textBox8.Text.ToString());
                double taxableIncome = list[8].TaxableIncome(basicPay,rewardSalary, 0);
                double taxExtempted = TaxExemptCal(rewardSalary, taxableIncome);

                label47.ForeColor = Color.Black;
                label64.ForeColor = Color.Black;

                label47.Text = "" + taxExtempted;
                label64.Text = "" + taxableIncome;

                netTaxableIncome += taxableIncome;
                totalTaxExtempted += taxExtempted;

                // net taxable income from salary
                label39.Text = TotalAmountOfIncome().ToString();
                label56.Text = CalTotalTaxExempted().ToString();
                //showing total taxable income
                label73.Text = CalNetTaxableIncome().ToString();

                textBox9.Focus();
            }
            else
            {
                label47.ForeColor = Color.Red;
                label64.ForeColor = Color.Red;
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
                double overtimeAllowance = double.Parse(textBox9.Text.ToString());
                double taxableIncome = list[9].TaxableIncome(basicPay,overtimeAllowance, 0);
                double taxExtempted = TaxExemptCal(overtimeAllowance, taxableIncome);

                label48.ForeColor = Color.Black;
                label65.ForeColor = Color.Black;

                label48.Text = "" + taxExtempted;
                label65.Text = "" + taxableIncome;

                netTaxableIncome += taxableIncome;
                totalTaxExtempted += taxExtempted;

                // net taxable income from salary
                label39.Text = TotalAmountOfIncome().ToString();
                label56.Text = CalTotalTaxExempted().ToString();
                //showing total taxable income
                label73.Text = CalNetTaxableIncome().ToString();

                textBox10.Focus();
            }
            else
            {
                label48.ForeColor = Color.Red;
                label65.ForeColor = Color.Red;
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
                double bonusOrGratia = double.Parse(textBox10.Text.ToString());
                double taxableIncome = list[10].TaxableIncome(basicPay,bonusOrGratia, 0);
                double taxExtempted = TaxExemptCal(bonusOrGratia, taxableIncome);

                label49.ForeColor = Color.Black;
                label66.ForeColor = Color.Black;

                label49.Text = "" + taxExtempted;
                label66.Text = "" + taxableIncome;

                netTaxableIncome += taxableIncome;
                totalTaxExtempted += taxExtempted;

                // net taxable income from salary
                label39.Text = TotalAmountOfIncome().ToString();
                label56.Text = CalTotalTaxExempted().ToString();
                //showing total taxable income
                label73.Text = CalNetTaxableIncome().ToString();

                textBox11.Focus();
            }
            else
            {
                label49.ForeColor = Color.Red;
                label66.ForeColor = Color.Red;
            }
        }

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox11.Text.Length == 0)
                {
                    textBox11.Text = "0";

                }
                double otherAllowance = double.Parse(textBox11.Text.ToString());
                double taxableIncome = list[11].TaxableIncome(basicPay,otherAllowance, 0);
                double taxExtempted = TaxExemptCal(otherAllowance, taxableIncome);

                label50.ForeColor = Color.Black;
                label67.ForeColor = Color.Black;

                label50.Text = "" + taxExtempted;
                label67.Text = "" + taxableIncome;

                netTaxableIncome += taxableIncome;
                totalTaxExtempted += taxExtempted;

                // net taxable income from salary
                label39.Text = TotalAmountOfIncome().ToString();
                label56.Text = CalTotalTaxExempted().ToString();
                //showing total taxable income
                label73.Text = CalNetTaxableIncome().ToString();

                textBox12.Focus();
            }
            else
            {
                label50.ForeColor = Color.Red;
                label67.ForeColor = Color.Red;
            }
        }

        private void textBox12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox12.Text.Length == 0)
                {
                    textBox12.Text = "0";

                }
                double providentFund = double.Parse(textBox12.Text.ToString());
                double taxableIncome = list[12].TaxableIncome(basicPay,providentFund, 0);
                double taxExtempted = TaxExemptCal(providentFund, taxableIncome);

                label51.ForeColor = Color.Black;
                label68.ForeColor = Color.Black;

                label51.Text = "" + taxExtempted;
                label68.Text = "" + taxableIncome;

                netTaxableIncome += taxableIncome;
                totalTaxExtempted += taxExtempted;

                // net taxable income from salary
                label39.Text = TotalAmountOfIncome().ToString();
                label56.Text = CalTotalTaxExempted().ToString();
                //showing total taxable income
                label73.Text = CalNetTaxableIncome().ToString();

                textBox13.Focus();
            }
            else
            {
                label51.ForeColor = Color.Red;
                label68.ForeColor = Color.Red;
            }
        }

        private void textBox13_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox13.Text.Length == 0)
                {
                    textBox13.Text = "0";

                }
                //sum = basic pay + Dearness Allowances
                double sum = basicPay + double.Parse(textBox3.Text.ToString());

                //set the maxNonTaxable value for "Interest accrued on Recognized provident fund"
                list[12].setmaxNonTaxable(sum / 3.0);   
                //saving "Interest accrued On provident Fund" user input
                double InterestOnprovidentFund = double.Parse(textBox13.Text.ToString());
                double taxableIncome = list[13].TaxableIncome(sum, InterestOnprovidentFund, 0);
                double taxExtempted = TaxExemptCal(InterestOnprovidentFund, taxableIncome);

                label52.ForeColor = Color.Black;
                label69.ForeColor = Color.Black;

                label52.Text = "" + taxExtempted;
                label69.Text = "" + taxableIncome;

                netTaxableIncome += taxableIncome;
                totalTaxExtempted += taxExtempted;

                // net taxable income from salary
                label39.Text = TotalAmountOfIncome().ToString();
                label56.Text = CalTotalTaxExempted().ToString();
                //showing total taxable income
                label73.Text = CalNetTaxableIncome().ToString();

                comboBox3.Focus();
            }
            else
            {
                label52.ForeColor = Color.Red;
                label69.ForeColor = Color.Red;
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

                label53.Text = "" + taxExtempted;   //show valid nontaxable income
                label70.Text = "" + taxableIncome;  //show valid taxable income 

                netTaxableIncome += taxableIncome;  //making sum of upto the net taxable income
                totalTaxExtempted += taxExtempted;  //making sum of upto the net nontaxable income

                // net TaxExempted income from salary
                label56.Text = CalTotalTaxExempted().ToString();
                //showing total taxable income
                label73.Text = CalNetTaxableIncome().ToString();
            }
            else
            {
                label53.Text = "0.0";   //select "No", nontaxable show as zero
                label70.Text = "0.0";  //select "No", taxable show as zero

                // net TaxExempted income from salary
                label56.Text = CalTotalTaxExempted().ToString();
                //showing total taxable income
                label73.Text = CalNetTaxableIncome().ToString();
            }
            textBox15.Focus();

        }

        private void textBox15_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox15.Text.Length == 0)
                {
                    textBox15.Text = "0";

                }
                double accomodation = double.Parse(textBox15.Text.ToString());
                
                double taxableIncome;

                // combobox value 0 handled, need to implement for value 1
                if (comboBox2.SelectedIndex == 0)
                {
                    taxableIncome = list[15].TaxableIncome(basicPay,accomodation, 0);
                }
                else
                {
                    // made it zero by force, but it is wrong, need to fix
                    taxableIncome = 0.0;
                }
                
                double taxExtempted = TaxExemptCal(accomodation, taxableIncome);

                label54.ForeColor = Color.Black;
                label71.ForeColor = Color.Black;

                label54.Text = "" + taxExtempted;
                label71.Text = "" + taxableIncome;

                netTaxableIncome += taxableIncome;
                totalTaxExtempted += taxExtempted;

                // net taxable income from salary
                label39.Text = TotalAmountOfIncome().ToString();
                label56.Text = CalTotalTaxExempted().ToString();
                //showing total taxable income
                label73.Text = CalNetTaxableIncome().ToString();

                textBox16.Focus();
            }
            else
            {
                label54.ForeColor = Color.Red;
                label71.ForeColor = Color.Red;
            }
        }

        private void textBox16_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox16.Text.Length == 0)
                {
                    textBox16.Text = "0";
                }
                double other = double.Parse(textBox16.Text.ToString());
                double taxableIncome = list[16].TaxableIncome(basicPay,other, 0);
                double taxExtempted = TaxExemptCal(other, taxableIncome);

                label55.ForeColor = Color.Black;
                label72.ForeColor = Color.Black;

                label55.Text = "" + taxExtempted;
                label72.Text = "" + taxableIncome;

                netTaxableIncome += taxableIncome;
                totalTaxExtempted += taxExtempted;


                // net taxable income from salary
                label39.Text = TotalAmountOfIncome().ToString();
                label56.Text = CalTotalTaxExempted().ToString();
                //showing total taxable income
                label73.Text = CalNetTaxableIncome().ToString();
            }
            else
            {
                label55.ForeColor = Color.Red;
                label72.ForeColor = Color.Red;
            }
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                locationAndDescription = richTextBox1.Text.ToString();

                textBox17.Focus();
                
            }
        }

        private void textBox17_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox17.Text.Length == 0)
                {
                    textBox17.Text = "0";
                }
                annualRentalIncome = Double.Parse(textBox17.Text.ToString());

                netRentalIncome = annualRentalIncome - CalTotalClaimedExpense();
                label91.Text = netRentalIncome.ToString();

                textBox18.Focus();
            }
        }

        private void textBox18_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox18.Text.Length == 0)
                {
                    textBox18.Text = "0";
                }
                               
                netRentalIncome = annualRentalIncome - CalTotalClaimedExpense();

                label90.Text = totalClaimedExpense.ToString();
                label91.Text = netRentalIncome.ToString();

                textBox19.Focus();
            }
        }

        private void textBox19_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox19.Text.Length == 0)
                {
                    textBox19.Text = "0";
                }
                
                netRentalIncome = annualRentalIncome - CalTotalClaimedExpense();

                label90.Text = totalClaimedExpense.ToString();
                label91.Text = netRentalIncome.ToString();

                textBox20.Focus();
            }
        }

        private void textBox20_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox20.Text.Length == 0)
                {
                    textBox20.Text = "0";
                }
                
                netRentalIncome = annualRentalIncome - CalTotalClaimedExpense();

                label90.Text = totalClaimedExpense.ToString();
                label91.Text = netRentalIncome.ToString();

                textBox21.Focus();
            }
        }

        private void textBox21_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox21.Text.Length == 0)
                {
                    textBox21.Text = "0";
                }
                
                netRentalIncome = annualRentalIncome - CalTotalClaimedExpense();

                label90.Text = totalClaimedExpense.ToString();
                label91.Text = netRentalIncome.ToString();

                textBox22.Focus();
            }
        }

        private void textBox22_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox22.Text.Length == 0)
                {
                    textBox22.Text = "0";
                }
                
                netRentalIncome = annualRentalIncome - CalTotalClaimedExpense();

                label90.Text = totalClaimedExpense.ToString();
                label91.Text = netRentalIncome.ToString();

                textBox23.Focus();
            }
        }

        private void textBox23_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox23.Text.Length == 0)
                {
                    textBox23.Text = "0";
                }
                
                netRentalIncome = annualRentalIncome - CalTotalClaimedExpense();

                label90.Text = totalClaimedExpense.ToString();
                label91.Text = netRentalIncome.ToString();

                textBox24.Focus();
            }
        }

        private void textBox24_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox24.Text.Length == 0)
                {
                    textBox24.Text = "0";
                }
                
                netRentalIncome = annualRentalIncome - CalTotalClaimedExpense();

                label90.Text = totalClaimedExpense.ToString();
                label91.Text = netRentalIncome.ToString();

            }
        }


        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
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
            else if (e.Handled == false)
            {
                if (textBox6.Text.ToString().Length > 0 && textBox6.Text.ToString()[0] != '0')
                {
                   
                    double medicalAllowance = double.Parse(textBox6.Text.ToString());
                    myFunction(medicalAllowance);
                }
            }
        }

        private void myFunction(double medicalAllowance)
        {
               
                double taxableIncome;
                //double taxableIncome;
                if (comboBox1.SelectedIndex == 0)
                {
                    taxableIncome = list[5].TaxableIncome(basicPay, medicalAllowance, 0);

                }


                else
                    taxableIncome = list[5].TaxableIncome(basicPay, medicalAllowance, 1);

                double taxExtempted = TaxExemptCal(medicalAllowance, taxableIncome);

                label45.ForeColor = Color.Black;
                label62.ForeColor = Color.Black;

                label45.Text = "" + taxExtempted;
                label62.Text = "" + taxableIncome;

                netTaxableIncome += taxableIncome;
                totalTaxExtempted += taxExtempted;

                // net taxable income from salary
                label39.Text = TotalAmountOfIncome().ToString();
                label56.Text = CalTotalTaxExempted().ToString();
                //showing total taxable income
                label73.Text = CalNetTaxableIncome().ToString();
         

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

        private void UserInputs_Salaries()
        {
            pdfInputs1[0] = textBox1.Text.ToString();   //salaries
            pdfInputs1[1] = textBox2.Text.ToString();   //Special pay
            pdfInputs1[2] = textBox3.Text.ToString();   //Dearness Allowances
            pdfInputs1[3] = textBox4.Text.ToString();   //Conveyance allowances
            pdfInputs1[4] = textBox5.Text.ToString();   //House rent allounces
            pdfInputs1[5] = textBox6.Text.ToString();   //Medical Allowances
            pdfInputs1[6] = textBox7.Text.ToString();   //Servant allowances
            pdfInputs1[7] = textBox25.Text.ToString();   //Leave allowances
            pdfInputs1[8] = textBox8.Text.ToString();   //Honorarum/reward/Arear salary
            pdfInputs1[9] = textBox9.Text.ToString();   //Overtime allowance
            pdfInputs1[10] = textBox10.Text.ToString();   //Bonus / Extra Gratia
            pdfInputs1[11] = textBox11.Text.ToString();  //Other Allowances
            pdfInputs1[12] = textBox12.Text.ToString();  //Employees contributions to recognized Provdent Fund
            pdfInputs1[13] = textBox13.Text.ToString();  //Interest accrued on Recognized provident fund
            pdfInputs1[14] = comboBox3.Text;             //Deemed income for transport facility "yes" or "No"
            pdfInputs1[15] = textBox15.Text.ToString();  //Deemed income for furnished /unfurnished accomodation
            pdfInputs1[16] = textBox16.Text.ToString();  //Other ( if any)
            pdfInputs1[17] = label39.Text.ToString();   //Net taxable income from salary


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
            pdfInputs1[35] = label56.Text.ToString();

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
            pdfInputs1[53] = label73.Text.ToString();

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

            pdfInputs2[10] = label91.Text.ToString();       // 3.Net Income(difference between item 1 and 2)
        }
    }
}