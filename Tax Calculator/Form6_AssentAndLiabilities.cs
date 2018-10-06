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
        public double B_F =0.0;
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

        //need to shift code
        private void Form6_AssentAndLiabilities_Load(object sender, EventArgs e)
        {
            makeAlltextBoxZero();           
        }

        private void Form6_AssentAndLiabilities_Activated(object sender, EventArgs e)
        {
            //data collection from previous forms
            shownReturnIncome = Form4_SatementOfSalary.totalTaxableIncome;
            taxExempted = (double)Convert.ToDecimal(Form2_Salaries.pdfInputs1[35]); //taking tax exempted from Salaries form

            label35.Text = shownReturnIncome.ToString("N"); //string formatting as a currency number
            label84.Text = taxExempted.ToString("N");       //string formatting as a currency number
            label_totalExpense.Text = Form5_Expenses.totalExpense.ToString("N");    //string formatting as a currency number
        }
        private void makeAlltextBoxZero()
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
            textBox17.Text = "0.0";
            textBox18.Text = "0.0";
            textBox19.Text = "0.0";
            textBox20.Text = "0.0";
            textBox21.Text = "0.0";
            textBox22.Text = "0.0";
            label_totalExpense.Text = "0.0";
            textBox24.Text = "0";   //number of adult family member
            textBox25.Text = "0";  //number of child family member
            textBox26.Text = "0.0";
        }

        private double CalTotalAssets()
        {
            B_F = (double)Convert.ToDecimal(textBox1.Text.ToString()) + //Business Capital ( Closing Balance)
                 (double)Convert.ToDecimal(textBox2.Text.ToString()) +  //Directors Shareholdings in Limited Companies (at cost) 
                 (double)Convert.ToDecimal(textBox3.Text.ToString()) +  //Non-Agricultural Property (at cost with legal expenses)
                 (double)Convert.ToDecimal(textBox4.Text.ToString()) +  //Agricultural Property (at cost with legal expenses)
                  CalTotalInvestments() +
                 (double)Convert.ToDecimal(textBox10.Text.ToString()) +  //Motor Vehicles (at cost)
                 (double)Convert.ToDecimal(textBox11.Text.ToString()) +  //Jewellery (quantity and cost)
                 (double)Convert.ToDecimal(textBox12.Text.ToString()) +   //Furniture (at cost)
                 (double)Convert.ToDecimal(textBox13.Text.ToString()) +   //Electronic Equipment (at cost)
                 CalTotalCashAsset_OutsideBusiness();
           //total Asset = B/F + any other assets
           totalAssets = B_F + (double)Convert.ToDecimal(textBox17.Text.ToString());
           return totalAssets;
        }
        private double CalTotalInvestments()
        {
            totalInvestments = (double)Convert.ToDecimal(textBox5.Text.ToString()) +
                                (double)Convert.ToDecimal(textBox6.Text.ToString()) +
                                (double)Convert.ToDecimal(textBox7.Text.ToString()) +
                                (double)Convert.ToDecimal(textBox8.Text.ToString()) +
                                (double)Convert.ToDecimal(textBox9.Text.ToString());
            return totalInvestments;

        }

        private double CalTotalCashAsset_OutsideBusiness()
        {
            totalCashAssets = (double)Convert.ToDecimal(textBox14.Text.ToString()) +
                                             (double)Convert.ToDecimal(textBox15.Text.ToString()) +
                                             (double)Convert.ToDecimal(textBox16.Text.ToString());
            return totalCashAssets;
        }

        private double CalTotalLiabilities()
        {
            return totalLiabilities = (double)Convert.ToDecimal(textBox18.Text.ToString()) +
                                     (double)Convert.ToDecimal(textBox19.Text.ToString()) +
                                     (double)Convert.ToDecimal(textBox20.Text.ToString()) +
                                     (double)Convert.ToDecimal(textBox21.Text.ToString());
        }

   
        private double CalTotalSourceOfFund()
        {
            totalSourcesOfFund = (double)Convert.ToDecimal(textBox25.Text.ToString()) + 
                                  shownReturnIncome + taxExempted;

            return totalSourcesOfFund;
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Convert.ToDecimal(textBox1.Text.ToString());    //checking user inputs valid or not
                    textBox2.Focus();
                }
            }
            catch
            {
                textBox1.Text = "0.0";  //clear user input because of invaild inputs
            }
        
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Convert.ToDecimal(textBox2.Text.ToString());    //checking user inputs valid or not
                    textBox3.Focus();
                }
            }
            catch
            {
                textBox2.Text = "0.0";  //clear user input because of invaild inputs
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Convert.ToDecimal(textBox3.Text.ToString());    //checking user inputs valid or not
                    textBox4.Focus();
                }
            }
            catch
            {
                textBox3.Text = "0.0";  //clear user input because of invaild inputs
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Convert.ToDecimal(textBox4.Text.ToString());    //checking user inputs valid or not
                    textBox5.Focus();
                }
            }
            catch
            {
                textBox4.Text = "0.0";  //clear user input because of invaild inputs
            }
        }
        
        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Convert.ToDecimal(textBox5.Text.ToString());    //checking user inputs valid or not
                    textBox6.Focus();
                }
            }
            catch
            {
                textBox5.Text = "0.0";  //clear user input because of invaild inputs
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Convert.ToDecimal(textBox6.Text.ToString());    //checking user inputs valid or not
                    textBox7.Focus();
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
                    Convert.ToDecimal(textBox7.Text.ToString());    //checking user inputs valid or not
                    textBox8.Focus();
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
                    Convert.ToDecimal(textBox8.Text.ToString());    //checking user inputs valid or not
                    textBox9.Focus();
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
                    Convert.ToDecimal(textBox9.Text.ToString());    //checking user inputs valid or not
                    textBox10.Focus();
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
                    Convert.ToDecimal(textBox10.Text.ToString());    //checking user inputs valid or not
                    textBox11.Focus();
                }
            }
            catch
            {
                textBox10.Text = "0.0";  //clear user input because of invaild inputs
            }
        }

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Convert.ToDecimal(textBox11.Text.ToString());    //checking user inputs valid or not
                    textBox12.Focus();
                }
            }
            catch
            {
                textBox11.Text = "0.0";  //clear user input because of invaild inputs
            }
        }

        private void textBox12_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Convert.ToDecimal(textBox12.Text.ToString());    //checking user inputs valid or not
                    textBox13.Focus();
                }
            }
            catch
            {
                textBox12.Text = "0.0";  //clear user input because of invaild inputs
            }
        }

        private void textBox13_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Convert.ToDecimal(textBox13.Text.ToString());    //checking user inputs valid or not
                    textBox14.Focus();
                }
            }
            catch
            {
                textBox13.Text = "0.0";  //clear user input because of invaild inputs
            }
        }     

        private void textBox14_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Convert.ToDecimal(textBox14.Text.ToString());    //checking user inputs valid or not
                    textBox15.Focus();
                }
            }
            catch
            {
                textBox14.Text = "0.0";  //clear user input because of invaild inputs
            }

        }

        private void textBox15_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Convert.ToDecimal(textBox15.Text.ToString());    //checking user inputs valid or not
                    textBox16.Focus();
                }
            }
            catch
            {
                textBox15.Text = "0.0";  //clear user input because of invaild inputs
            }
        }

        private void textBox16_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Convert.ToDecimal(textBox16.Text.ToString());    //checking user inputs valid or not
                    textBox17.Focus();
                }
            }
            catch
            {
                textBox16.Text = "0.0";  //clear user input because of invaild inputs
            }
        }

        private void textBox17_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Convert.ToDecimal(textBox17.Text.ToString());    //checking user inputs valid or not
                    textBox18.Focus();
                }
            }
            catch
            {
                textBox17.Text = "0.0";  //clear user input because of invaild inputs
            }
        }
       
        private void textBox18_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Convert.ToDecimal(textBox18.Text.ToString());    //checking user inputs valid or not
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
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Convert.ToDecimal(textBox19.Text.ToString());    //checking user inputs valid or not
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
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Convert.ToDecimal(textBox20.Text.ToString());    //checking user inputs valid or not
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
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Convert.ToDecimal(textBox21.Text.ToString());    //checking user inputs valid or not
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
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Convert.ToDecimal(textBox22.Text.ToString());    //checking user inputs valid or not
                    textBox24.Focus();
                }
            }
            catch
            {
                textBox22.Text = "0.0"; //clear user input because of invaild inputs
            }
        }


        private void textBox24_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    adult = (int)Convert.ToDecimal(textBox24.Text.ToString()); //save and check user inputs valid or not 
                    textBox25.Focus();
                }
            }
            catch
            {
                textBox24.Text = "0"; //clear user input because of invaild inputs
            }

        }

        private void textBox25_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    child = (int)Convert.ToDecimal(textBox25.Text.ToString()); //save and check user inputs valid or not 
                    textBox26.Focus();
                }
            }
            catch
            {
                textBox25.Text = "0"; //clear user input because of invaild inputs
            }
        }

        private void textBox26_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //textBox26 = other receipts
                    Convert.ToDecimal(textBox26.Text.ToString()); //save and check user inputs valid or not 
                }
            }
            catch
            {
                textBox26.Text = "0.0"; //clear user input because of invaild inputs
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

            pdfInputs[18] = B_F.ToString("N");    // save B/F result

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
            pdfInputs[36] = label83.Text.ToString();   //Total source of Fund 

            pdfInputs[37] = label81.Text.ToString();  //Difference (Between serial 16 and 17)
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
            this.Hide();
            Form5_Expenses f = Form5_Expenses.GetInstance;
            f.Show();
        }


        //Home button click event
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();    //Hide curent window form
            Form1_Personal_info f = Form1_Personal_info.GetInstance;
            f.Show();   //go to Home page
        }

        //for any assets textbox works for method: textBox1 to textBox17 
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            try
            {               
                label11.Text =  CalTotalInvestments().ToString("N");
                label51.Text = CalTotalCashAsset_OutsideBusiness().ToString("N");
                label10.Text = CalTotalAssets().ToString("N");

                label56.Text = CalTotalLiabilities().ToString("N");

                //net wealth as on last date of this income year
                double diff1 = CalTotalAssets() - CalTotalLiabilities();
                label86.Text = diff1.ToString("N");
                
                //accretion in wealth
                double diff2 = diff1 - (double)Convert.ToDecimal(textBox22.Text.ToString());
                label82.Text = diff2.ToString("N");
                
                //total accretion fo wealth
                double diff3 = diff2- (double)Convert.ToDecimal(label_totalExpense.Text.ToString());
                label85.Text = diff3.ToString("N");

                label83.Text = CalTotalSourceOfFund().ToString("N");    //return and save "total source of fund"

                //Difference(Between serial 16-17)
                double diff4 = diff3 - CalTotalSourceOfFund();
                label81.Text = diff4.ToString("N");

            }
            catch
            {

            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text.ToString() == "") textBox1.Text = "0.0";
            try
            {
                Convert.ToDecimal(textBox1.Text.ToString());    //checking using inputs vaild or not
            }
            catch
            {
                textBox1.Text = "0.0";   //clear user input because of invaild inputs
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text.ToString() == "") textBox2.Text = "0.0";
            try
            {
                Convert.ToDecimal(textBox2.Text.ToString());    //checking using inputs vaild or not
            }
            catch
            {
                textBox2.Text = "0.0";   //clear user input because of invaild inputs
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text.ToString() == "") textBox3.Text = "0.0";
            try
            {
                Convert.ToDecimal(textBox3.Text.ToString());    //checking using inputs vaild or not
            }
            catch
            {
                textBox3.Text = "0.0";   //clear user input because of invaild inputs
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text.ToString() == "") textBox4.Text = "0.0";
            try
            {
                Convert.ToDecimal(textBox4.Text.ToString());    //checking using inputs vaild or not
            }
            catch
            {
                textBox4.Text = "0.0";   //clear user input because of invaild inputs
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text.ToString() == "") textBox5.Text = "0.0";
            try
            {
                Convert.ToDecimal(textBox5.Text.ToString());    //checking using inputs vaild or not
            }
            catch
            {
                textBox5.Text = "0.0";   //clear user input because of invaild inputs
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox6.Text.ToString() == "") textBox6.Text = "0.0";
            try
            {
                Convert.ToDecimal(textBox6.Text.ToString());    //checking using inputs vaild or not
            }
            catch
            {
                textBox6.Text = "0.0";   //clear user input because of invaild inputs
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (textBox7.Text.ToString() == "") textBox7.Text = "0.0";
            try
            {
                Convert.ToDecimal(textBox7.Text.ToString());    //checking using inputs vaild or not
            }
            catch
            {
                textBox7.Text = "0.0";   //clear user input because of invaild inputs
            }
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            if (textBox8.Text.ToString() == "") textBox8.Text = "0.0";
            try
            {
                Convert.ToDecimal(textBox8.Text.ToString());    //checking using inputs vaild or not
            }
            catch
            {
                textBox8.Text = "0.0";   //clear user input because of invaild inputs
            }
        }

        private void textBox9_Leave(object sender, EventArgs e)
        {
            if (textBox9.Text.ToString() == "") textBox9.Text = "0.0";
            try
            {
                Convert.ToDecimal(textBox9.Text.ToString());    //checking using inputs vaild or not
            }
            catch
            {
                textBox9.Text = "0.0";   //clear user input because of invaild inputs
            }
        }

        private void textBox10_Leave(object sender, EventArgs e)
        {
            if (textBox10.Text.ToString() == "") textBox10.Text = "0.0";
            try
            {
                Convert.ToDecimal(textBox10.Text.ToString());    //checking using inputs vaild or not
            }
            catch
            {
                textBox10.Text = "0.0";   //clear user input because of invaild inputs
            }
        }

        private void textBox11_Leave(object sender, EventArgs e)
        {
            if (textBox11.Text.ToString() == "") textBox11.Text = "0.0";
            try
            {
                Convert.ToDecimal(textBox11.Text.ToString());    //checking using inputs vaild or not
            }
            catch
            {
                textBox11.Text = "0.0";   //clear user input because of invaild inputs
            }
        }

        private void textBox12_Leave(object sender, EventArgs e)
        {
            if (textBox12.Text.ToString() == "") textBox12.Text = "0.0";
            try
            {
                Convert.ToDecimal(textBox12.Text.ToString());    //checking using inputs vaild or not
            }
            catch
            {
                textBox12.Text = "0.0";   //clear user input because of invaild inputs
            }
        }

        private void textBox13_Leave(object sender, EventArgs e)
        {
            if (textBox13.Text.ToString() == "") textBox13.Text = "0.0";
            try
            {
                Convert.ToDecimal(textBox13.Text.ToString());    //checking using inputs vaild or not
            }
            catch
            {
                textBox13.Text = "0.0";   //clear user input because of invaild inputs
            }
        }

        private void textBox14_Leave(object sender, EventArgs e)
        {
            if (textBox14.Text.ToString() == "") textBox14.Text = "0.0";
            try
            {
                Convert.ToDecimal(textBox14.Text.ToString());    //checking using inputs vaild or not
            }
            catch
            {
                textBox14.Text = "0.0";   //clear user input because of invaild inputs
            }
        }

        private void textBox15_Leave(object sender, EventArgs e)
        {
            if (textBox15.Text.ToString() == "") textBox15.Text = "0.0";
            try
            {
                Convert.ToDecimal(textBox15.Text.ToString());    //checking using inputs vaild or not
            }
            catch
            {
                textBox15.Text = "0.0";   //clear user input because of invaild inputs
            }
        }

        private void textBox16_Leave(object sender, EventArgs e)
        {
            if (textBox16.Text.ToString() == "") textBox16.Text = "0.0";
            try
            {
                Convert.ToDecimal(textBox16.Text.ToString());    //checking using inputs vaild or not
            }
            catch
            {
                textBox16.Text = "0.0";   //clear user input because of invaild inputs
            }
        }

        private void textBox17_Leave(object sender, EventArgs e)
        {
            if (textBox17.Text.ToString() == "") textBox17.Text = "0.0";
            try
            {
                Convert.ToDecimal(textBox17.Text.ToString());    //checking using inputs vaild or not
            }
            catch
            {
                textBox17.Text = "0.0";   //clear user input because of invaild inputs
            }
        }

        private void textBox18_Leave(object sender, EventArgs e)
        {
            if (textBox18.Text.ToString() == "") textBox18.Text = "0.0";
            try
            {
                Convert.ToDecimal(textBox18.Text.ToString());    //checking using inputs vaild or not
            }
            catch
            {
                textBox18.Text = "0.0";   //clear user input because of invaild inputs
            }
        }

        private void textBox19_Leave(object sender, EventArgs e)
        {
            if (textBox19.Text.ToString() == "") textBox19.Text = "0.0";
            try
            {
                Convert.ToDecimal(textBox19.Text.ToString());    //checking using inputs vaild or not
            }
            catch
            {
                textBox19.Text = "0.0";   //clear user input because of invaild inputs
            }
        }

        private void textBox20_Leave(object sender, EventArgs e)
        {
            if (textBox20.Text.ToString() == "") textBox20.Text = "0.0";
            try
            {
                Convert.ToDecimal(textBox20.Text.ToString());    //checking using inputs vaild or not
            }
            catch
            {
                textBox20.Text = "0.0";   //clear user input because of invaild inputs
            }
        }

        private void textBox21_Leave(object sender, EventArgs e)
        {
            if (textBox21.Text.ToString() == "") textBox21.Text = "0.0";
            try
            {
                Convert.ToDecimal(textBox21.Text.ToString());    //checking using inputs vaild or not
            }
            catch
            {
                textBox21.Text = "0.0";   //clear user input because of invaild inputs
            }
        }

        private void textBox22_Leave(object sender, EventArgs e)
        {
            if (textBox22.Text.ToString() == "") textBox22.Text = "0.0";
            try
            {
                Convert.ToDecimal(textBox22.Text.ToString());    //checking using inputs vaild or not
            }
            catch
            {
                textBox22.Text = "0.0";   //clear user input because of invaild inputs
            }
        }

        private void textBox24_Leave(object sender, EventArgs e)
        {
            if (textBox24.Text.ToString() == "") textBox24.Text = "0";
            try
            {
                Convert.ToDecimal(textBox24.Text.ToString());    //checking using inputs vaild or not
            }
            catch
            {
                textBox24.Text = "0";   //clear user input because of invaild inputs
            }
        }

        private void textBox25_Leave(object sender, EventArgs e)
        {
            if (textBox25.Text.ToString() == "") textBox25.Text = "0";
            try
            {
                Convert.ToDecimal(textBox25.Text.ToString());    //checking using inputs vaild or not
            }
            catch
            {
                textBox25.Text = "0";   //clear user input because of invaild inputs
            }
        }

        private void textBox26_Leave(object sender, EventArgs e)
        {
            if (textBox26.Text.ToString() == "") textBox26.Text = "0.0";
            try
            {
                Convert.ToDecimal(textBox26.Text.ToString());    //checking using inputs vaild or not
            }
            catch
            {
                textBox26.Text = "0.0";   //clear user input because of invaild inputs
            }
        }

        
    }
}
