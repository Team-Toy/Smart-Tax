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
    public partial class Form6_AssentAndLiabilities : Form
    {
        static Form6_AssentAndLiabilities _instance;
        public static Form6_AssentAndLiabilities GetInstance
        {
            get
            {
                if (_instance == null)
                    _instance = new Form6_AssentAndLiabilities();
                return _instance;
            }

        }
      
        public static string[] pdfInputs;

        public static double totalAssets = 0;
        public static double totalInvestments = 0;
        public static double totalCashAssets = 0;
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
            pdfInputs = new string[38];
        }

        private void Form6_AssentAndLiabilities_Load(object sender, EventArgs e)
        {
            makeAlltextBoxZero();
            shownReturnIncome = Form4_SatementOfSalary.totalTaxableIncome;
            taxExempted = Form2_Salaries.totalTaxExtempted;

            label35.Text = shownReturnIncome.ToString();
            label84.Text = taxExempted.ToString();
            label_totalExpense.Text = Form5_Expenses.totalExpense.ToString();

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
            label_totalExpense.Text = "0";
            textBox24.Text = "0";
            textBox25.Text = "0";
            textBox26.Text = "0";
        }
        private double CalTotalAssets()
        {
            //addind "0" to prevent program crash because of null character of textBox
            return totalAssets = Double.Parse("0"+ textBox1.Text.ToString()) +
                                 Double.Parse("0" + textBox2.Text.ToString()) +
                                 Double.Parse("0" + textBox3.Text.ToString()) +
                                 Double.Parse("0" + textBox4.Text.ToString()) +
                                 Double.Parse("0" + textBox5.Text.ToString()) +
                                 Double.Parse("0" + textBox6.Text.ToString()) +
                                 Double.Parse("0" + textBox7.Text.ToString()) +
                                 Double.Parse("0" + textBox8.Text.ToString()) +
                                 Double.Parse("0" + textBox9.Text.ToString()) +
                                 Double.Parse("0" + textBox10.Text.ToString()) +
                                 Double.Parse("0" + textBox11.Text.ToString()) +
                                 Double.Parse("0" + textBox12.Text.ToString()) +
                                 Double.Parse("0" + textBox13.Text.ToString()) +
                                 Double.Parse("0" + textBox14.Text.ToString()) +
                                 Double.Parse("0" + textBox15.Text.ToString()) +
                                 Double.Parse("0" + textBox16.Text.ToString()) +
                                 Double.Parse("0" + textBox17.Text.ToString());

        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text.Length == 0)
                {
                    textBox1.Text = "0";
                }

                label10.Text = CalTotalAssets().ToString();

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

                label10.Text = CalTotalAssets().ToString();

                textBox3.Focus();
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

                label10.Text = CalTotalAssets().ToString();

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

                label10.Text = CalTotalAssets().ToString();

                textBox5.Focus();
            }
        }
        private double CalTotalInvestments()
        {
            //addind "0" to prevent program crash because of null character of textBox
            return totalInvestments = Double.Parse("0" + textBox5.Text.ToString()) +
                                        Double.Parse("0" + textBox6.Text.ToString()) +
                                        Double.Parse("0" + textBox7.Text.ToString()) +
                                        Double.Parse("0" + textBox8.Text.ToString()) +
                                        Double.Parse("0" + textBox9.Text.ToString());


        }
        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox5.Text.Length == 0)
                {
                    textBox5.Text = "0";
                }


                label10.Text = CalTotalAssets().ToString();
                label11.Text = CalTotalInvestments().ToString();

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


                label10.Text = CalTotalAssets().ToString();
                label11.Text = CalTotalInvestments().ToString();

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


                label10.Text = CalTotalAssets().ToString();
                label11.Text = CalTotalInvestments().ToString();

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


                label10.Text = CalTotalAssets().ToString();
                label11.Text = CalTotalInvestments().ToString();

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


                label10.Text = CalTotalAssets().ToString();
                label11.Text = CalTotalInvestments().ToString();

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


                label10.Text = CalTotalAssets().ToString();

                textBox11.Focus();
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
                label10.Text = CalTotalAssets().ToString();

                textBox12.Focus();
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
                label10.Text = CalTotalAssets().ToString();

                textBox13.Focus();
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
                label10.Text = CalTotalAssets().ToString();

                textBox14.Focus();
            }
        }
        private double CalTotalCashAssets()
        {
            //addind "0" to prevent program crash because of null character of textBox
            return totalCashAssets = Double.Parse("0" + textBox14.Text.ToString()) +
                                     Double.Parse("0" + textBox15.Text.ToString()) +
                                     Double.Parse("0" + textBox16.Text.ToString());
        }

        private void textBox14_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox14.Text.Length == 0)
                {
                    textBox14.Text = "0";
                }
                label10.Text = CalTotalAssets().ToString();

                label51.Text = CalTotalCashAssets().ToString();

                textBox15.Focus();
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

                label10.Text = CalTotalAssets().ToString();

                label51.Text = CalTotalCashAssets().ToString();

                textBox16.Focus();
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
                label10.Text = CalTotalAssets().ToString();

                label51.Text = CalTotalCashAssets().ToString();

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
                label10.Text = CalTotalAssets().ToString();


                textBox18.Focus();
            }
        }
        private double CalTotalLiabilities()
        {
            //addind "0" to prevent program crash because of null character of textBox
            return totalLiabilities = Double.Parse("0" + textBox18.Text.ToString()) +
                                      Double.Parse("0" + textBox19.Text.ToString()) +
                                      Double.Parse("0" + textBox20.Text.ToString()) +
                                      Double.Parse("0" + textBox21.Text.ToString());
        }
        private void textBox18_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox18.Text.Length == 0)
                {
                    textBox18.Text = "0";
                }


                label56.Text = CalTotalLiabilities().ToString();


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
                label56.Text = CalTotalLiabilities().ToString();


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
                label56.Text = CalTotalLiabilities().ToString();


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
                label56.Text = CalTotalLiabilities().ToString();

                netWealthThisYear = totalAssets - totalLiabilities;
                label86.Text = netWealthThisYear.ToString();

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
                //addind "0" to prevent program crash because of null character of textBox
                netWealthPrevYear = Double.Parse("0" + textBox22.Text.ToString());
                accretionInWealth = netWealthThisYear - netWealthPrevYear;

                label82.Text = accretionInWealth.ToString();

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
                //addind "0" to prevent program crash because of null character of textBox
                adult = int.Parse("0" + textBox24.Text.ToString());


                textBox25.Focus();
            }
        }

        private void textBox25_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox25.Text.Length == 0)
                {
                    textBox25.Text = "0";
                }
                //addind "0" to prevent program crash because of null character of textBox
                child = int.Parse("0" + textBox25.Text.ToString());


                textBox26.Focus();
            }
        }

        private void textBox26_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox26.Text.Length == 0)
                {
                    textBox26.Text = "0";
                }
                totalSourcesOfFund = Double.Parse(textBox25.Text.ToString()) + shownReturnIncome + taxExempted;

                label83.Text = totalSourcesOfFund.ToString();

                label81.Text = (totalAccretionInWealth - totalSourcesOfFund).ToString();

            }
        }


        //pdf creating button. print button
        private void button1_Click(object sender, EventArgs e)
        {
            //taking all assets and liabilities info in a string
            UserInputs_AssetAndLiabilities();

            MyPdfWriter myPdfWriter = new MyPdfWriter();

            MessageBox.Show("Print succeessfully");


        }



        /* Function name: textBox_KeyPress()
         * ..................................
         * It works for textBox1 to textBox26; except textBox24 and textBox25
         * It makes a restriction so that user can only type positive numerical number.
         * Numerial number can be decimal or interger but not character type
          */
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

        /* Function name: textBox24_KeyPress()
        * ..................................
        * It works for only textBox24 field as a user's "number of having Adult" person
        * It makes a restriction so that user can only type positive numerical integer number.
        * Numerial number can't be decimal or character type
        * 
         */
        private void textBox24_KeyPress(object sender, KeyPressEventArgs e)
        {
            // only allow integers
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
        }

        /* Function name: textBox25_KeyPress()
        * ..................................
        * It works for only textBox24 field as a user's "number of having child"
        * It makes a restriction so that user can only type positive numerical integer number.
        * Numerial number can't be decimal or character type
        * 
         */
        private void textBox25_KeyPress(object sender, KeyPressEventArgs e)
        {
            // only allow integers
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
        }


        private void UserInputs_AssetAndLiabilities()
        {
            pdfInputs[0] = textBox1.Text.ToString();   //Business Capital ( Closing Balance)
            pdfInputs[1] = textBox2.Text.ToString();   //Directors Shareholdings in Limited Companies (at cost) 
            pdfInputs[2] = textBox3.Text.ToString();   //Non-Agricultural Property (at cost with legal expenses)
            pdfInputs[3] = textBox4.Text.ToString();   //Agricultural Property (at cost with legal expenses)
            pdfInputs[4] = textBox5.Text.ToString();   //Shares/Debentures 
            pdfInputs[5] = textBox6.Text.ToString();   //Saving Certificate/Unit Certificate/Bond 
            pdfInputs[6] = textBox7.Text.ToString();   // Prize bond/Savings Scheme 
            pdfInputs[7] = textBox8.Text.ToString();   //Loans Given
            pdfInputs[8] = textBox9.Text.ToString();   //Other investment
            pdfInputs[9] = label11.Text.ToString();   //total

            pdfInputs[10] = textBox10.Text.ToString();   //Motor Vehicles (at cost)
            pdfInputs[11] = textBox11.Text.ToString();   //Jewellery (quantity and cost)
            pdfInputs[12] = textBox12.Text.ToString();   //Furniture (at cost)
            pdfInputs[13] = textBox13.Text.ToString();   //Electronic Equipment (at cost)

            //Cash Asset Outside Business:
            pdfInputs[14] = textBox14.Text.ToString();   //(a) Cash in hand Tk
            pdfInputs[15] = textBox15.Text.ToString();   //(b) Cash at bank Tk
            pdfInputs[16] = textBox16.Text.ToString();   // (c) Other deposits Tk
            pdfInputs[17] = label51.Text.ToString();    //total

            pdfInputs[18] = ""+BalanceForward();    //return and save B/F result

            pdfInputs[19] = textBox17.Text.ToString();   //Any Other Assets
            pdfInputs[20] = label10.Text.ToString();    //total assets

            //Less Liabilities:
            pdfInputs[21] = textBox18.Text.ToString();   //(a) Mortgages secured on property or land Tk.
            pdfInputs[22] = textBox19.Text.ToString();   //(b) Unsecured loans Tk. ...........
            pdfInputs[23] = textBox20.Text.ToString();   //(c) Bank loan Tk
            pdfInputs[24] = textBox21.Text.ToString();    //(d) Others
            pdfInputs[25] = label56.Text.ToString();     //Total Liabilities
            pdfInputs[26] = label86.Text.ToString();    //Net wealth as on last date of this income year
            pdfInputs[27] = textBox22.Text.ToString();   // Net wealth as on last date of previous income year
            pdfInputs[28] = label82.Text.ToString();   //Accretion in wealth (Difference between serial no. 12 and 13)
            pdfInputs[29] = label_totalExpense.Text.ToString();   //(a) Family Expenditure: (Total expenditure as per Form IT 10 BB)  
           
            // (b)Number of dependant children of the family:
            pdfInputs[30] = textBox24.Text.ToString();  //adult
            pdfInputs[31] = textBox25.Text.ToString();  //child
            pdfInputs[32] = label85.Text.ToString();  //Total Accretion of wealth (Total of serial 14 and 15)

            //Sources of Fund :
            pdfInputs[33] = label35.Text.ToString();     //(i) Shown Return Income 
            pdfInputs[34] = label84.Text.ToString();    //(ii) Tax exempted/Tax free Income
            pdfInputs[35] = textBox26.Text.ToString();   // (iii) Other receipts
            pdfInputs[36] = label83.Text.ToString();   //Total source of Fund =
            pdfInputs[37] = label81.Text.ToString();  //Difference (Between serial 16 and 17)
        }

        private double BalanceForward()
        {
            double b_f = 0.0;
            b_f +=double.Parse("0" + textBox1.Text.ToString() );   //Business Capital ( Closing Balance)
            b_f += double.Parse("0" + textBox2.Text.ToString());   //Directors Shareholdings in Limited Companies (at cost) 
            b_f += double.Parse("0" + textBox3.Text.ToString() );   //Non-Agricultural Property (at cost with legal expenses)
            b_f += double.Parse("0" + textBox4.Text.ToString() );   //Agricultural Property (at cost with legal expenses)
            b_f += double.Parse("0" + label11.Text.ToString() );   //total
            b_f += double.Parse("0" + textBox10.Text.ToString() );   //Motor Vehicles (at cost)
            b_f += double.Parse("0" + textBox11.Text.ToString() );   //Jewellery (quantity and cost)
            b_f += double.Parse("0" + textBox12.Text.ToString() );   //Furniture (at cost)
            b_f += double.Parse("0" + textBox13.Text.ToString() );   //Electronic Equipment (at cost)
            b_f += double.Parse("0" + label51.Text.ToString() );    //total

            return b_f;
        }

        private void Form6_AssentAndLiabilities_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                //application Closing by cross cursor;
                Application.Exit();
            }
        }

        //Back button click event
        private void button2_Click(object sender, EventArgs e)
        {
            Form5_Expenses f = Form5_Expenses.GetInstance;
            this.Hide();
            f.Show();
        }


        //Home button click event
        private void button3_Click(object sender, EventArgs e)
        {
            this.Show();    //Hide curent window form
            Form1_Personal_info f = Form1_Personal_info.GetInstance;
            f.Show();   //go to Home page
        }
    }
}
