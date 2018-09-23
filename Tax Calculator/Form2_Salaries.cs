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
        public static string[] pdfInputs1,pdfInputs2;
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
                                };  //dataset for all type of salary incomes

        //values for form 4, totalTaxableIncome, totalTaxExtempted
        public static double totalAmountOfIncome = 0.0;
        public static double netTaxableIncome = 0.0;
        public static double totalTaxExtempted = 0.0;
        public double basicPay = 0.0;
        public static List<SalaryConditionals> list = new List<SalaryConditionals>();
        

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

            pdfInputs1 = new string[51];  
            pdfInputs2 = new string[11];
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
            textBox11.Text = "0.0";
            textBox12.Text = "0.0";
            textBox13.Text = "0.0";
            textBox14.Text = "0.0";
            textBox15.Text = "0.0";
            textBox16.Text = "0.0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserInputs_Salaries();
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
            totalAmountOfIncome =   double.Parse(textBox1.Text.ToString()) +    //Basic Pay
                                    double.Parse(textBox2.Text.ToString()) +    //Special pay
                                    double.Parse(textBox3.Text.ToString()) +    //Dearness Allowances
                                    double.Parse(textBox4.Text.ToString()) +    //Conveyance allowances
                                    double.Parse(textBox5.Text.ToString()) +    //House rent allounces
                                    double.Parse(textBox6.Text.ToString()) +    //Medical Allowances
                                    double.Parse(textBox7.Text.ToString()) +    //Servant allowances
                                    double.Parse(textBox8.Text.ToString()) +    //Honorarum/reward/Arear salary
                                    double.Parse(textBox9.Text.ToString()) +    //Overtime allowance
                                    double.Parse(textBox10.Text.ToString()) +   //Bonus / Extra Gratia
                                    double.Parse(textBox11.Text.ToString()) +   //Other Allowances
                                    double.Parse(textBox12.Text.ToString()) +   //Employees contributions to recognized Provdent Fund
                                    double.Parse(textBox13.Text.ToString()) +   //Interest accrued on Recognized provident fund
                                    double.Parse(textBox14.Text.ToString()) +   //Deemed income for transport facility
                                    double.Parse(textBox15.Text.ToString()) +   //Deemed income for furnished /unfurnished accomodation
                                    double.Parse(textBox16.Text.ToString());    //Other ( if any)


            return totalAmountOfIncome;
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                basicPay = double.Parse(textBox1.Text.ToString());
                double taxableIncome = list[0].TaxableIncome(basicPay,basicPay,0);
                double taxExtempted = TaxExemptCal(basicPay, taxableIncome);

                label40.Text = "" + taxExtempted;
                label57.Text = "" + taxableIncome;

                netTaxableIncome += taxableIncome;
                totalTaxExtempted += taxExtempted;

                textBox2.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double specialPay = double.Parse(textBox2.Text.ToString());
                double taxableIncome = list[1].TaxableIncome(basicPay,specialPay, 0);
                double taxExtempted = TaxExemptCal(specialPay, taxableIncome);

                label41.Text = "" + taxExtempted;
                label58.Text = "" + taxableIncome;

                netTaxableIncome += taxableIncome;
                totalTaxExtempted += taxExtempted;

                textBox3.Focus();
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double dearnessAllowance = double.Parse(textBox3.Text.ToString());
                double taxableIncome = list[2].TaxableIncome(basicPay,dearnessAllowance, 0);
                double taxExtempted = TaxExemptCal(dearnessAllowance, taxableIncome);

                label42.Text = "" + taxExtempted;
                label59.Text = "" + taxableIncome;

                netTaxableIncome += taxableIncome;
                totalTaxExtempted += taxExtempted;

                textBox4.Focus();
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double conveyanceAllowance = double.Parse(textBox4.Text.ToString());
                double taxableIncome = list[3].TaxableIncome(basicPay,conveyanceAllowance, 0);
                double taxExtempted = TaxExemptCal(conveyanceAllowance, taxableIncome);

                label43.Text = "" + taxExtempted;
                label60.Text = "" + taxableIncome;

                netTaxableIncome += taxableIncome;
                totalTaxExtempted += taxExtempted;

                textBox5.Focus();
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double houseRentAllowance = double.Parse(textBox5.Text.ToString());
                double taxableIncome = list[4].TaxableIncome(basicPay,houseRentAllowance, 0);
                double taxExtempted = TaxExemptCal(houseRentAllowance, taxableIncome);

                label44.Text = "" + taxExtempted;
                label61.Text = "" + taxableIncome;

                netTaxableIncome += taxableIncome;
                totalTaxExtempted += taxExtempted;

                textBox6.Focus();
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double medicalAllowance = double.Parse(textBox6.Text.ToString());
                double taxableIncome;
                //double taxableIncome;
                if (comboBox1.SelectedIndex == 0)
                    taxableIncome = list[5].TaxableIncome(basicPay,medicalAllowance, 0);

                else  
                    taxableIncome = list[5].TaxableIncome(basicPay,medicalAllowance, 1);

                double taxExtempted = TaxExemptCal(medicalAllowance, taxableIncome);

                label45.Text = "" + taxExtempted;
                label62.Text = "" + taxableIncome;

                netTaxableIncome += taxableIncome;
                totalTaxExtempted += taxExtempted;

                textBox7.Focus();
            }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double serventAllowance = double.Parse(textBox7.Text.ToString());
                double taxableIncome = list[6].TaxableIncome(basicPay,serventAllowance, 0);
                double taxExtempted = TaxExemptCal(serventAllowance, taxableIncome);

                label46.Text = "" + taxExtempted;
                label63.Text = "" + taxableIncome;

                netTaxableIncome += taxableIncome;
                totalTaxExtempted += taxExtempted;

                textBox8.Focus();
            }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double rewardSalary = double.Parse(textBox8.Text.ToString());
                double taxableIncome = list[7].TaxableIncome(basicPay,rewardSalary, 0);
                double taxExtempted = TaxExemptCal(rewardSalary, taxableIncome);

                label47.Text = "" + taxExtempted;
                label64.Text = "" + taxableIncome;

                netTaxableIncome += taxableIncome;
                totalTaxExtempted += taxExtempted;

                textBox9.Focus();
            }
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double overtimeAllowance = double.Parse(textBox9.Text.ToString());
                double taxableIncome = list[8].TaxableIncome(basicPay,overtimeAllowance, 0);
                double taxExtempted = TaxExemptCal(overtimeAllowance, taxableIncome);

                label48.Text = "" + taxExtempted;
                label65.Text = "" + taxableIncome;

                netTaxableIncome += taxableIncome;
                totalTaxExtempted += taxExtempted;

                textBox10.Focus();
            }
        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double bonusOrGratia = double.Parse(textBox10.Text.ToString());
                double taxableIncome = list[9].TaxableIncome(basicPay,bonusOrGratia, 0);
                double taxExtempted = TaxExemptCal(bonusOrGratia, taxableIncome);

                label49.Text = "" + taxExtempted;
                label66.Text = "" + taxableIncome;

                netTaxableIncome += taxableIncome;
                totalTaxExtempted += taxExtempted;

                textBox11.Focus();
            }
        }

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double otherAllowance = double.Parse(textBox11.Text.ToString());
                double taxableIncome = list[10].TaxableIncome(basicPay,otherAllowance, 0);
                double taxExtempted = TaxExemptCal(otherAllowance, taxableIncome);

                label50.Text = "" + taxExtempted;
                label67.Text = "" + taxableIncome;

                netTaxableIncome += taxableIncome;
                totalTaxExtempted += taxExtempted;

                textBox12.Focus();
            }
        }

        private void textBox12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double providentFund = double.Parse(textBox12.Text.ToString());
                double taxableIncome = list[11].TaxableIncome(basicPay,providentFund, 0);
                double taxExtempted = TaxExemptCal(providentFund, taxableIncome);

                label51.Text = "" + taxExtempted;
                label68.Text = "" + taxableIncome;

                netTaxableIncome += taxableIncome;
                totalTaxExtempted += taxExtempted;

                textBox13.Focus();
            }
        }

        private void textBox13_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //sum = basic pay + Dearness Allowances
                double sum = basicPay + double.Parse(textBox3.Text.ToString());

                //set the maxNonTaxable value for "Interest accrued on Recognized provident fund"
                list[12].setmaxNonTaxable(sum / 3.0);   
                //saving "Interest accrued On provident Fund" user input
                double InterestOnprovidentFund = double.Parse(textBox13.Text.ToString());
                double taxableIncome = list[12].TaxableIncome(sum, InterestOnprovidentFund, 0);
                double taxExtempted = TaxExemptCal(InterestOnprovidentFund, taxableIncome);

                label52.Text = "" + taxExtempted;
                label69.Text = "" + taxableIncome;

                netTaxableIncome += taxableIncome;
                totalTaxExtempted += taxExtempted;
                
                textBox14.Focus();
            }
        }

        private void textBox14_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double transportFacility = double.Parse(textBox14.Text.ToString());
                double taxableIncome = list[13].TaxableIncome(basicPay,transportFacility, 0);
                double taxExtempted = TaxExemptCal(transportFacility, taxableIncome);

                label53.Text = "" + taxExtempted;
                label70.Text = "" + taxableIncome;

                netTaxableIncome += taxableIncome;
                totalTaxExtempted += taxExtempted;

                textBox15.Focus();
            }
        }

        private void textBox15_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
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

                label54.Text = "" + taxExtempted;
                label71.Text = "" + taxableIncome;

                netTaxableIncome += taxableIncome;
                totalTaxExtempted += taxExtempted;

                textBox16.Focus();
            }
        }

        private void textBox16_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double other = double.Parse(textBox16.Text.ToString());
                double taxableIncome = list[15].TaxableIncome(basicPay,other, 0);
                double taxExtempted = TaxExemptCal(other, taxableIncome);

                label55.Text = "" + taxExtempted;
                label72.Text = "" + taxableIncome;

                netTaxableIncome += taxableIncome;
                totalTaxExtempted += taxExtempted;


                // net taxable income from salary
                label39.Text = TotalAmountOfIncome().ToString();
                label56.Text = totalTaxExtempted.ToString();
                //showing total taxable income
                label73.Text = netTaxableIncome.ToString();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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
                annualRentalIncome = Double.Parse(textBox17.Text.ToString());

                textBox18.Focus();
            }
        }

        private void textBox18_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
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
                other = Double.Parse(textBox24.Text.ToString());

                totalClaimedExpense += other;
                netRentalIncome = annualRentalIncome - totalClaimedExpense;

                label90.Text = totalClaimedExpense.ToString();
                label91.Text = netRentalIncome.ToString();

            }
        }

        private void label62_Click(object sender, EventArgs e)
        {

        }

        private void label57_Click(object sender, EventArgs e)
        {

        }

        private void label58_Click(object sender, EventArgs e)
        {

        }

        private void label59_Click(object sender, EventArgs e)
        {

        }

        private void label60_Click(object sender, EventArgs e)
        {

        }

        private void label63_Click(object sender, EventArgs e)
        {

        }

        private void label64_Click(object sender, EventArgs e)
        {

        }

        private void label65_Click(object sender, EventArgs e)
        {

        }

        private void label66_Click(object sender, EventArgs e)
        {

        }

        private void label67_Click(object sender, EventArgs e)
        {

        }

        private void label68_Click(object sender, EventArgs e)
        {

        }

        private void label69_Click(object sender, EventArgs e)
        {

        }

        private void label70_Click(object sender, EventArgs e)
        {

        }

        private void label71_Click(object sender, EventArgs e)
        {

        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label61_Click(object sender, EventArgs e)
        {

        }

        private void label56_Click(object sender, EventArgs e)
        {

        }

        private void label55_Click(object sender, EventArgs e)
        {

        }

        private void label54_Click(object sender, EventArgs e)
        {

        }

        private void label53_Click(object sender, EventArgs e)
        {

        }

        private void label52_Click(object sender, EventArgs e)
        {

        }

        private void label51_Click(object sender, EventArgs e)
        {

        }

        private void label50_Click(object sender, EventArgs e)
        {

        }

        private void label49_Click(object sender, EventArgs e)
        {

        }

        private void label48_Click(object sender, EventArgs e)
        {

        }

        private void label47_Click(object sender, EventArgs e)
        {

        }

        private void label46_Click(object sender, EventArgs e)
        {

        }

        private void label45_Click(object sender, EventArgs e)
        {

        }

        private void label44_Click(object sender, EventArgs e)
        {

        }

        private void label43_Click(object sender, EventArgs e)
        {

        }

        private void label42_Click(object sender, EventArgs e)
        {

        }

        private void label41_Click(object sender, EventArgs e)
        {

        }

        private void label40_Click(object sender, EventArgs e)
        {

        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label91_Click(object sender, EventArgs e)
        {

        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void label89_Click(object sender, EventArgs e)
        {

        }

        private void label88_Click(object sender, EventArgs e)
        {

        }

        private void label87_Click(object sender, EventArgs e)
        {

        }

        private void label86_Click(object sender, EventArgs e)
        {

        }

        private void label85_Click(object sender, EventArgs e)
        {

        }

        private void label84_Click(object sender, EventArgs e)
        {

        }

        private void label83_Click(object sender, EventArgs e)
        {

        }

        private void label82_Click(object sender, EventArgs e)
        {

        }

        private void label81_Click(object sender, EventArgs e)
        {

        }

        private void label80_Click(object sender, EventArgs e)
        {

        }

        private void label79_Click(object sender, EventArgs e)
        {

        }

        private void label78_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label77_Click(object sender, EventArgs e)
        {

        }

        private void label76_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label73_Click(object sender, EventArgs e)
        {

        }

        private void label72_Click(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label75_Click(object sender, EventArgs e)
        {

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
            pdfInputs1[7] = textBox8.Text.ToString();   //Honorarum/reward/Arear salary
            pdfInputs1[8] = textBox9.Text.ToString();   //Overtime allowance
            pdfInputs1[9] = textBox10.Text.ToString();   //Bonus / Extra Gratia
            pdfInputs1[10] = textBox11.Text.ToString();  //Other Allowances
            pdfInputs1[11] = textBox12.Text.ToString();  //Employees contributions to recognized Provdent Fund
            pdfInputs1[12] = textBox13.Text.ToString();  //Interest accrued on Recognized provident fund
            pdfInputs1[13] = textBox14.Text.ToString();  //Deemed income for transport facility
            pdfInputs1[14] = textBox15.Text.ToString();  //Deemed income for furnished /unfurnished accomodation
            pdfInputs1[15] = textBox16.Text.ToString();  //Other ( if any)
            pdfInputs1[16] = textBox17.Text.ToString();  //Net taxable income from salary

            //non-taxable incomes
            pdfInputs1[17] = label39.Text.ToString();  
            pdfInputs1[18] = label40.Text.ToString(); 
            pdfInputs1[19] = label41.Text.ToString();  
            pdfInputs1[20] = label42.Text.ToString();  
            pdfInputs1[21] = label43.Text.ToString();  
            pdfInputs1[22] = label44.Text.ToString();  
            pdfInputs1[23] = label45.Text.ToString();  
            pdfInputs1[24] = label46.Text.ToString();  
            pdfInputs1[25] = label47.Text.ToString();  
            pdfInputs1[26] = label48.Text.ToString();  
            pdfInputs1[27] = label49.Text.ToString();  
            pdfInputs1[28] = label50.Text.ToString();  
            pdfInputs1[29] = label51.Text.ToString();  
            pdfInputs1[30] = label52.Text.ToString();  
            pdfInputs1[31] = label53.Text.ToString();  
            pdfInputs1[32] = label54.Text.ToString();  
            pdfInputs1[33] = label55.Text.ToString();  
            pdfInputs1[34] = label56.Text.ToString();  

            //taxable incomes
            pdfInputs1[35] = label57.Text.ToString();  
            pdfInputs1[36] = label58.Text.ToString();  
            pdfInputs1[37] = label59.Text.ToString();  
            pdfInputs1[38] = label60.Text.ToString();  
            pdfInputs1[39] = label61.Text.ToString();  
            pdfInputs1[40] = label62.Text.ToString();  
            pdfInputs1[41] = label63.Text.ToString();  
            pdfInputs1[42] = label64.Text.ToString();  
            pdfInputs1[43] = label65.Text.ToString();  
            pdfInputs1[44] = label66.Text.ToString();  
            pdfInputs1[45] = label67.Text.ToString();  
            pdfInputs1[46] = label68.Text.ToString();  
            pdfInputs1[47] = label69.Text.ToString();  
            pdfInputs1[48] = label70.Text.ToString();  
            pdfInputs1[49] = label71.Text.ToString();  
            pdfInputs1[50] = label72.Text.ToString();  
            pdfInputs1[51] = label73.Text.ToString();  

        }
    }
}
