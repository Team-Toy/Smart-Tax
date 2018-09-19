﻿using System;
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
        public static double totalTaxableIncome = 0.0;
        public static double totalTaxExtempted = 0.0;

        public static List<SalaryConditionals> list = new List<SalaryConditionals>();
        private string[] data = {"false","true","0","0",
                               "false","true","0","0",
                               "false","true","0","0",
                                "false","false","0.05","30000",
                                "false","false","0.5","25000",
                                 "false","false","0.01","120000",";","1000000",
                                "false","true","0","0",
                                "false","true","0","0",
                                 "false","true","0","0",
                                 "false","true","0","0",
                                 "false","true","0","0",
                                 "false","true","0","0",
                                 "false","false","0.145","0",
                                 "false","false","0.05","60000",
                                 "false","false","0.25","0",
                                 "false","true","0","0"
                                };
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
            for (int i = 0; i < data.Length - 4; i++)
            {
                bool fullIncomeNonTaxable = Boolean.Parse(data[i]);
                bool fullIncomeTaxable = Boolean.Parse(data[++i]);
                float maxPercentOfNonTaxable = float.Parse(data[++i]);
                maxNonTaxable = new List<double>();
                maxNonTaxable.Add(double.Parse(data[++i]));

                if (data[i + 1] == ";")
                {
                    maxNonTaxable.Add(double.Parse(data[i + 2]));
                    i += 2;
                }

                SalaryConditionals salaryType = new SalaryConditionals(fullIncomeNonTaxable, fullIncomeTaxable, maxPercentOfNonTaxable, maxNonTaxable);
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
            //go to investment Tax Credit form
            Form3_InvestmentTaxCredit f = new Form3_InvestmentTaxCredit();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this will go into enter key even function
           //double basicPay= double.Parse(textBox1.Text.ToString());
           //double taxableIncome=list[0].TaxableIncome(basicPay, 0);
           //double taxExtempted = TaxExemptCal(basicPay, taxableIncome);

            //label40.Text = "" + taxExtempted;
            //label57.Text = "" + taxableIncome;
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
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double basicPay = double.Parse(textBox1.Text.ToString());
                double taxableIncome = list[0].TaxableIncome(basicPay, 0);
                double taxExtempted = TaxExemptCal(basicPay, taxableIncome);

                label40.Text = "" + taxExtempted;
                label57.Text = "" + taxableIncome;

                totalTaxableIncome += taxableIncome;
                totalTaxExtempted += taxExtempted;

                textBox2.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double specialPay = double.Parse(textBox2.Text.ToString());
                double taxableIncome = list[1].TaxableIncome(specialPay, 0);
                double taxExtempted = TaxExemptCal(specialPay, taxableIncome);

                label41.Text = "" + taxExtempted;
                label58.Text = "" + taxableIncome;

                totalTaxableIncome += taxableIncome;
                totalTaxExtempted += taxExtempted;

                textBox3.Focus();
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double dearnessAllowance = double.Parse(textBox3.Text.ToString());
                double taxableIncome = list[2].TaxableIncome(dearnessAllowance, 0);
                double taxExtempted = TaxExemptCal(dearnessAllowance, taxableIncome);

                label42.Text = "" + taxExtempted;
                label59.Text = "" + taxableIncome;

                totalTaxableIncome += taxableIncome;
                totalTaxExtempted += taxExtempted;

                textBox4.Focus();
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double conveyanceAllowance = double.Parse(textBox4.Text.ToString());
                double taxableIncome = list[3].TaxableIncome(conveyanceAllowance, 0);
                double taxExtempted = TaxExemptCal(conveyanceAllowance, taxableIncome);

                label43.Text = "" + taxExtempted;
                label60.Text = "" + taxableIncome;

                totalTaxableIncome += taxableIncome;
                totalTaxExtempted += taxExtempted;

                textBox5.Focus();
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double houseRentAllowance = double.Parse(textBox5.Text.ToString());
                double taxableIncome = list[4].TaxableIncome(houseRentAllowance, 0);
                double taxExtempted = TaxExemptCal(houseRentAllowance, taxableIncome);

                label44.Text = "" + taxExtempted;
                label61.Text = "" + taxableIncome;

                totalTaxableIncome += taxableIncome;
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

                if (comboBox1.SelectedIndex == 0)
                {
                    label74.Text = list[5].getMaxNonTaxable(0).ToString();
                    taxableIncome = list[5].TaxableIncome(medicalAllowance, 0);
                }
                else
                {
                    label74.Text = (list[5].getMaxNonTaxable(1)).ToString();
                    taxableIncome = list[5].TaxableIncome(medicalAllowance, 1);
                }

                double taxExtempted = TaxExemptCal(medicalAllowance, taxableIncome);

                label45.Text = "" + taxExtempted;
                label62.Text = "" + taxableIncome;

                totalTaxableIncome += taxableIncome;
                totalTaxExtempted += taxExtempted;

                textBox7.Focus();
            }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double serventAllowance = double.Parse(textBox7.Text.ToString());
                double taxableIncome = list[6].TaxableIncome(serventAllowance, 0);
                double taxExtempted = TaxExemptCal(serventAllowance, taxableIncome);

                label46.Text = "" + taxExtempted;
                label63.Text = "" + taxableIncome;

                totalTaxableIncome += taxableIncome;
                totalTaxExtempted += taxExtempted;

                textBox8.Focus();
            }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double rewardSalary = double.Parse(textBox8.Text.ToString());
                double taxableIncome = list[7].TaxableIncome(rewardSalary, 0);
                double taxExtempted = TaxExemptCal(rewardSalary, taxableIncome);

                label47.Text = "" + taxExtempted;
                label64.Text = "" + taxableIncome;

                totalTaxableIncome += taxableIncome;
                totalTaxExtempted += taxExtempted;

                textBox9.Focus();
            }
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double overtimeAllowance = double.Parse(textBox9.Text.ToString());
                double taxableIncome = list[8].TaxableIncome(overtimeAllowance, 0);
                double taxExtempted = TaxExemptCal(overtimeAllowance, taxableIncome);

                label48.Text = "" + taxExtempted;
                label65.Text = "" + taxableIncome;

                totalTaxableIncome += taxableIncome;
                totalTaxExtempted += taxExtempted;

                textBox10.Focus();
            }
        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double bonusOrGratia = double.Parse(textBox10.Text.ToString());
                double taxableIncome = list[9].TaxableIncome(bonusOrGratia, 0);
                double taxExtempted = TaxExemptCal(bonusOrGratia, taxableIncome);

                label49.Text = "" + taxExtempted;
                label66.Text = "" + taxableIncome;

                totalTaxableIncome += taxableIncome;
                totalTaxExtempted += taxExtempted;

                textBox11.Focus();
            }
        }

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double otherAllowance = double.Parse(textBox11.Text.ToString());
                double taxableIncome = list[10].TaxableIncome(otherAllowance, 0);
                double taxExtempted = TaxExemptCal(otherAllowance, taxableIncome);

                label50.Text = "" + taxExtempted;
                label67.Text = "" + taxableIncome;

                totalTaxableIncome += taxableIncome;
                totalTaxExtempted += taxExtempted;

                textBox12.Focus();
            }
        }

        private void textBox12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double providentFund = double.Parse(textBox12.Text.ToString());
                double taxableIncome = list[11].TaxableIncome(providentFund, 0);
                double taxExtempted = TaxExemptCal(providentFund, taxableIncome);

                label51.Text = "" + taxExtempted;
                label68.Text = "" + taxableIncome;

                totalTaxableIncome += taxableIncome;
                totalTaxExtempted += taxExtempted;

                textBox13.Focus();
            }
        }

        private void textBox13_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double InterestOnprovidentFund = double.Parse(textBox13.Text.ToString());
                double taxableIncome = list[12].TaxableIncome(InterestOnprovidentFund, 0);
                double taxExtempted = TaxExemptCal(InterestOnprovidentFund, taxableIncome);

                label52.Text = "" + taxExtempted;
                label69.Text = "" + taxableIncome;

                totalTaxableIncome += taxableIncome;
                totalTaxExtempted += taxExtempted;

                textBox14.Focus();
            }
        }

        private void textBox14_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double transportFacility = double.Parse(textBox14.Text.ToString());
                double taxableIncome = list[13].TaxableIncome(transportFacility, 0);
                double taxExtempted = TaxExemptCal(transportFacility, taxableIncome);

                label53.Text = "" + taxExtempted;
                label70.Text = "" + taxableIncome;

                totalTaxableIncome += taxableIncome;
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
                    taxableIncome = list[14].TaxableIncome(accomodation, 0);
                }
                else
                {
                    // made it zero by force, but it is wrong, need to fix
                    taxableIncome = 0.0;
                }
                
                double taxExtempted = TaxExemptCal(accomodation, taxableIncome);

                label54.Text = "" + taxExtempted;
                label71.Text = "" + taxableIncome;

                totalTaxableIncome += taxableIncome;
                totalTaxExtempted += taxExtempted;

                textBox16.Focus();
            }
        }

        private void textBox16_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double other = double.Parse(textBox16.Text.ToString());
                double taxableIncome = list[15].TaxableIncome(other, 0);
                double taxExtempted = TaxExemptCal(other, taxableIncome);

                label55.Text = "" + taxExtempted;
                label72.Text = "" + taxableIncome;

                totalTaxableIncome += taxableIncome;
                totalTaxExtempted += taxExtempted;


                // net taxable income from salary
                label39.Text = TotalAmountOfIncome().ToString();
                label56.Text = totalTaxExtempted.ToString();
                label73.Text = totalTaxableIncome.ToString();
            }
        }
    }
}
