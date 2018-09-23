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
    public partial class Form6_AssentAndLiabilities : Form
    {
        public static string[] pdfInputs;

        public static double totalAssets = 0;
        public static double totalInvestments = 0;
        public static double cashAssets = 0;
        public static double totalLiabilities = 0;
        public static double netWealthThisYear = 0;
        public static double netWealthPrevYear = 0;
        public static double accretionInWealth = 0;
        public static double totalAccretionInWealth = 0;
        public static double familyExpenditure = 0;
        private int adult = 0;
        private int child = 0;
        public static double totalSourcesOfFund = 0;
        private double shownReturnIncome = 0;
        private double taxExempted = 0;

        public Form6_AssentAndLiabilities()
        {
            InitializeComponent();
            pdfInputs = new string[35];
        }

        private void Form6_AssentAndLiabilities_Load(object sender, EventArgs e)
        {
            makeAlltextBoxZero();
            shownReturnIncome = Form4_SatementOfSalary.totalTaxableIncome;
            taxExempted = Form2_Salaries.totalTaxExtempted;

            label35.Text = shownReturnIncome.ToString();
            label84.Text = taxExempted.ToString();

        }
        private void makeAlltextBoxZero()
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
            textBox24.Text = "0";
            textBox25.Text = "0";
            textBox26.Text = "0";
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                totalAssets += Double.Parse(textBox1.Text.ToString());
                label10.Text = totalAssets.ToString();

                textBox2.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                totalAssets += Double.Parse(textBox2.Text.ToString());
                label10.Text = totalAssets.ToString();

                textBox3.Focus();
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                totalAssets += Double.Parse(textBox3.Text.ToString());
                label10.Text = totalAssets.ToString();

                textBox4.Focus();
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                totalAssets += Double.Parse(textBox4.Text.ToString());
                label10.Text = totalAssets.ToString();

                textBox5.Focus();
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                totalInvestments += Double.Parse(textBox5.Text.ToString());
                totalAssets += totalInvestments;

                label10.Text = totalAssets.ToString();
                label11.Text = totalInvestments.ToString();

                textBox6.Focus();
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                totalInvestments += Double.Parse(textBox6.Text.ToString());
                totalAssets += totalInvestments;

                label10.Text = totalAssets.ToString();
                label11.Text = totalInvestments.ToString();

                textBox7.Focus();
            }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                totalInvestments += Double.Parse(textBox7.Text.ToString());
                totalAssets += totalInvestments;

                label10.Text = totalAssets.ToString();
                label11.Text = totalInvestments.ToString();

                textBox8.Focus();
            }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                totalInvestments += Double.Parse(textBox8.Text.ToString());
                totalAssets += totalInvestments;

                label10.Text = totalAssets.ToString();
                label11.Text = totalInvestments.ToString();

                textBox9.Focus();
            }
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                totalInvestments += Double.Parse(textBox9.Text.ToString());
                totalAssets += totalInvestments;

                label10.Text = totalAssets.ToString();
                label11.Text = totalInvestments.ToString();

                textBox10.Focus();
            }
        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {       
                totalAssets += Double.Parse(textBox10.Text.ToString());

                label10.Text = totalAssets.ToString();

                textBox11.Focus();
            }
        }

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                totalAssets += Double.Parse(textBox11.Text.ToString());

                label10.Text = totalAssets.ToString();

                textBox12.Focus();
            }
        }

        private void textBox12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                totalAssets += Double.Parse(textBox12.Text.ToString());

                label10.Text = totalAssets.ToString();

                textBox13.Focus();
            }
        }

        private void textBox13_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                totalAssets += Double.Parse(textBox13.Text.ToString());

                label10.Text = totalAssets.ToString();

                textBox14.Focus();
            }
        }

        private void textBox14_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cashAssets += Double.Parse(textBox14.Text.ToString());
                totalAssets += cashAssets;

                label10.Text = totalAssets.ToString();
                label51.Text = cashAssets.ToString();

                textBox15.Focus();
            }

        }

        private void textBox15_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cashAssets += Double.Parse(textBox15.Text.ToString());
                totalAssets += cashAssets;

                label10.Text = totalAssets.ToString();
                label51.Text = cashAssets.ToString();

                textBox16.Focus();
            }
        }

        private void textBox16_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cashAssets += Double.Parse(textBox16.Text.ToString());
                totalAssets += cashAssets;

                label10.Text = totalAssets.ToString();
                label51.Text = cashAssets.ToString();

                textBox17.Focus();
            }
        }

        private void textBox17_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                totalAssets += Double.Parse(textBox17.Text.ToString());

                label10.Text = totalAssets.ToString();
                

                textBox18.Focus();
            }
        }

        private void textBox18_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                totalLiabilities += Double.Parse(textBox18.Text.ToString());

                label56.Text = totalLiabilities.ToString();


                textBox19.Focus();
            }
        }

        private void textBox19_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                totalLiabilities += Double.Parse(textBox19.Text.ToString());

                label56.Text = totalLiabilities.ToString();


                textBox20.Focus();
            }
        }

        private void textBox20_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                totalLiabilities += Double.Parse(textBox20.Text.ToString());

                label56.Text = totalLiabilities.ToString();


                textBox21.Focus();
            }
        }

        private void textBox21_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                totalLiabilities += Double.Parse(textBox21.Text.ToString());

                label56.Text = totalLiabilities.ToString();

                netWealthThisYear = totalAssets - totalLiabilities;
                label86.Text = netWealthThisYear.ToString();

                textBox22.Focus();
            }
        }

        private void textBox22_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                netWealthPrevYear += Double.Parse(textBox22.Text.ToString());
                accretionInWealth = netWealthThisYear - netWealthPrevYear;

                label82.Text = accretionInWealth.ToString();

                textBox23.Focus();
            }
        }

        private void textBox23_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                familyExpenditure += Double.Parse(textBox23.Text.ToString());
                totalAccretionInWealth = accretionInWealth + familyExpenditure;

                label85.Text = totalAccretionInWealth.ToString();

                textBox24.Focus();
            }
        }

        private void textBox24_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                adult = int.Parse(textBox24.Text.ToString());
                

                textBox25.Focus();
            }
        }

        private void textBox25_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                child = int.Parse(textBox25.Text.ToString());


                textBox26.Focus();
            }
        }

        private void textBox26_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                totalSourcesOfFund = Double.Parse(textBox25.Text.ToString()) + shownReturnIncome + taxExempted;

                label83.Text = totalSourcesOfFund.ToString();

                label81.Text = (totalAccretionInWealth - totalSourcesOfFund).ToString();
                
            }
        }

        private void UserIput_AssetsAndLiabilities()
        {
            pdfInputs[0] = textBox1.Text.ToString();   //a)Business Capital ( Closing Balance)
            pdfInputs[1] = textBox2.Text.ToString();   //b)Directors Shareholdings in Limited Companies (at cost) 
            pdfInputs[2] = textBox3.Text.ToString();   //Non-Agricultural Property (at cost with legal expenses ) :
            pdfInputs[3] = textBox4.Text.ToString();   //Agricultural Property (at cost with legal expenses ) :
            pdfInputs[4] = textBox5.Text.ToString();   //(a) Shares/Debentures 
            pdfInputs[5] = textBox6.Text.ToString();   //(b) Saving Certificate/Unit Certificate/Bond 
            pdfInputs[6] = textBox7.Text.ToString();   //(c) Prize bond/Savings Scheme 
            pdfInputs[7] = textBox8.Text.ToString();   //(d) Loans given 
            pdfInputs[8] = textBox9.Text.ToString();   //(e) Other Investment 
            pdfInputs[9] = label11.Text.ToString();     //Total 

            pdfInputs[10] = textBox10.Text.ToString();  //Motor Vehicles (at cost) : 
            pdfInputs[11] = textBox11.Text.ToString();   //Jewellery (quantity and cost) :
            pdfInputs[12] = textBox12.Text.ToString();   //Furniture (at cost) :
            pdfInputs[13] = textBox13.Text.ToString();   //Electronic Equipment (at cost) :

            //Cash Asset Outside Business:
            pdfInputs[14] = textBox14.Text.ToString();   //(a) Cash in hand Tk.
            pdfInputs[15] = textBox15.Text.ToString();   //(b) Cash at bank Tk.
            pdfInputs[16] = textBox16.Text.ToString();   //(c) Other deposits Tk. 
            pdfInputs[17] = label51.Text.ToString();    //Total

            pdfInputs[18] = textBox17.Text.ToString();   //Any Other Assets
            pdfInputs[19] = label10.Text.ToString();   //Total Assets

            //Less Liabilities
            pdfInputs[20] = textBox18.Text.ToString();   //(a) Mortgages secured on property or land (Tk)
            pdfInputs[21] = label19.Text.ToString();  //(b) Unsecured loans (Tk)
            pdfInputs[22] = textBox20.Text.ToString();   //(c) Bank loan Tk.
            pdfInputs[23] = textBox21.Text.ToString();   //(d) Others

            pdfInputs[24] = label56.Text.ToString();   //Total Liabilities

            pdfInputs[25] = label86.Text.ToString();   //Net wealth as on last date of this income year

            pdfInputs[26] = textBox22.Text.ToString();   //Net wealth as on last date of previous income year

            pdfInputs[27] = label22.Text.ToString();   //Accretion in wealth (Difference between serial no. 12 and 13)

            pdfInputs[28] = label82.Text.ToString();   //(a) Family Expenditure: (Total expenditure as per Form IT 10 BB)  
            //(b) Number of dependant children of the family:
            pdfInputs[29] = textBox8.Text.ToString();   //Adult
            pdfInputs[30] = textBox9.Text.ToString();   //Child

            pdfInputs[31)= label85.Text.ToString();   //Total Accretion of wealth (Total of serial 14 and 15)
            //Sources of Fund :
            pdfInputs[32] = label35.Text.ToString();  //(i) Shown Return Income 
            pdfInputs[33] = label84.Text.ToString();    //(ii) Tax exempted/Tax free Income

            pdfInputs[34] = textBox26.Text.ToString(); //(iii)Other receipts

            pdfInputs[35] = label83.Text.ToString(); //Total source of Fund 
            pdfInputs[36] = label81.Text.ToString();//Difference (Between serial 16 and 17)
        }
    }
}
