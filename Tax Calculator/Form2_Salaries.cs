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
                                 "true","0","0",      //Leave_allowance
                                 "true","0","0",     //Honorarium/Reward/Fee	
                                 "true","0","0",    //Overtime_allowance
                                 "true","0","0",    //Bonus/Ex-gratia
                                 "true","0","0",    //Other_allowance
                                 "true","0","0",    //Employer's_contribution_to_recognized_provident_fund 
                                 "true","0.145","0.0",   //interest_accrued_on_Recognized_provident_fund 
                                 "true","0.05","60000",    //Deemed_income_for_transport_facility 
                                 "true","0.25","0",        //Deemed_income_for_free_furnished/unfurnish accommodation
                                 "true","0","0",        //Other,if_any
                                 "true","0.7","0"       //randomly created for fixing list index out of bound
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
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            madeAllTextBoxZero();

            // default value set for medical allowance
            comboBox1.SelectedIndex = 0;
            // default value set for accomodation
            comboBox2.SelectedIndex = 0;

            List<double> maxNonTaxable;
            for (int i = 0; i < data.Length; i++)
            {
                bool taxable = Boolean.Parse(data[i]);
                double maxPercentOfNonTaxable = Math.Round(double.Parse(data[++i]));
                
                maxNonTaxable = new List<double>();
                maxNonTaxable.Add(double.Parse(data[++i]));
                if ( i == data.Length-1)
                    break;
                else
                {
                    if (data[i + 1] == ";")
                    {
                        maxNonTaxable.Add(double.Parse(data[i + 2]));
                        i += 2;
                    }
                }
    

                SalaryConditionals salaryType = new SalaryConditionals(taxable, maxPercentOfNonTaxable, maxNonTaxable);
                list.Add(salaryType);
            }
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
            textBox11.Text = "0";
            textBox12.Text = "0";
            textBox13.Text = "0";
            textBox14.Text = "0";
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

        private void button1_Click(object sender, EventArgs e)
        {
            //go to investment Tax Credit form
            Form3_InvestmentTaxCredit f = new Form3_InvestmentTaxCredit();
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
                                    double.Parse(textBox8.Text.ToString()) +
                                    double.Parse(textBox9.Text.ToString()) +
                                    double.Parse(textBox10.Text.ToString()) +
                                    double.Parse(textBox11.Text.ToString()) +
                                    double.Parse(textBox12.Text.ToString()) +
                                    double.Parse(textBox13.Text.ToString()) +
                                    double.Parse(textBox14.Text.ToString()) +
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
            netTaxableIncome = double.Parse(label40.Text.ToString()) +
                                    double.Parse(label41.Text.ToString()) +
                                    double.Parse(label42.Text.ToString()) +
                                    double.Parse(label43.Text.ToString()) +
                                    double.Parse(label44.Text.ToString()) +
                                    double.Parse(label45.Text.ToString()) +
                                    double.Parse(label46.Text.ToString()) +
                                    double.Parse(label47.Text.ToString()) +
                                    double.Parse(label48.Text.ToString()) +
                                    double.Parse(label49.Text.ToString()) +
                                    double.Parse(label50.Text.ToString()) +
                                    double.Parse(label51.Text.ToString()) +
                                    double.Parse(label52.Text.ToString()) +
                                    double.Parse(label53.Text.ToString()) +
                                    double.Parse(label54.Text.ToString()) +
                                    double.Parse(label55.Text.ToString());


            return netTaxableIncome;
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
                    taxableIncome = list[5].TaxableIncome(basicPay,medicalAllowance, 0);

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

                textBox8.Focus();
            }
            else
            {
                label46.ForeColor = Color.Red;
                label63.ForeColor = Color.Red;
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
                double taxableIncome = list[7].TaxableIncome(basicPay,rewardSalary, 0);
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
                double taxableIncome = list[8].TaxableIncome(basicPay,overtimeAllowance, 0);
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
                double taxableIncome = list[9].TaxableIncome(basicPay,bonusOrGratia, 0);
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
                double taxableIncome = list[10].TaxableIncome(basicPay,otherAllowance, 0);
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
                double taxableIncome = list[11].TaxableIncome(basicPay,providentFund, 0);
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
                double taxableIncome = list[12].TaxableIncome(sum, InterestOnprovidentFund, 0);
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

                textBox14.Focus();
            }
            else
            {
                label52.ForeColor = Color.Red;
                label69.ForeColor = Color.Red;
            }
        }

        private void textBox14_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox14.Text.Length == 0)
                {
                    textBox14.Text = "0";

                }
                double transportFacility = double.Parse(textBox14.Text.ToString());
                double taxableIncome = list[13].TaxableIncome(basicPay,transportFacility, 0);
                double taxExtempted = TaxExemptCal(transportFacility, taxableIncome);

                label53.ForeColor = Color.Black;
                label70.ForeColor = Color.Black;

                label53.Text = "" + taxExtempted;
                label70.Text = "" + taxableIncome;

                netTaxableIncome += taxableIncome;
                totalTaxExtempted += taxExtempted;

                // net taxable income from salary
                label39.Text = TotalAmountOfIncome().ToString();
                label56.Text = CalTotalTaxExempted().ToString();
                //showing total taxable income
                label73.Text = CalNetTaxableIncome().ToString();

                textBox15.Focus();
            }
            else
            {
                label53.ForeColor = Color.Red;
                label70.ForeColor = Color.Red;
            }
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
                    taxableIncome = list[14].TaxableIncome(basicPay,accomodation, 0);
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
                double taxableIncome = list[15].TaxableIncome(basicPay,other, 0);
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

        private void label90_Click(object sender, EventArgs e)
        {

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
                repair = Double.Parse(textBox18.Text.ToString());

                totalClaimedExpense += repair;
                netRentalIncome = annualRentalIncome - totalClaimedExpense;

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
                municipalTax = Double.Parse(textBox19.Text.ToString());

                totalClaimedExpense += municipalTax;
                netRentalIncome = annualRentalIncome - totalClaimedExpense;

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
                landRevenue = Double.Parse(textBox20.Text.ToString());

                totalClaimedExpense += landRevenue;
                netRentalIncome = annualRentalIncome - totalClaimedExpense;

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
                interestOnLoan = Double.Parse(textBox21.Text.ToString());

                totalClaimedExpense += interestOnLoan;
                netRentalIncome = annualRentalIncome - totalClaimedExpense;

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
                insurancePremium = Double.Parse(textBox22.Text.ToString());

                totalClaimedExpense += insurancePremium;
                netRentalIncome = annualRentalIncome - totalClaimedExpense;

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
                vacancyAllowance = Double.Parse(textBox23.Text.ToString());

                totalClaimedExpense += vacancyAllowance;
                netRentalIncome = annualRentalIncome - totalClaimedExpense;

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
                other = Double.Parse(textBox24.Text.ToString());

                totalClaimedExpense += other;
                netRentalIncome = annualRentalIncome - totalClaimedExpense;

                label90.Text = totalClaimedExpense.ToString();
                label91.Text = netRentalIncome.ToString();

            }
        }

        
        
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox17_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox18_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox19_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox20_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox21_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox22_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox23_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox24_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
