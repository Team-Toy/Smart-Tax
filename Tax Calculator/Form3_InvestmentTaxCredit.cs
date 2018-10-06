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
    
    public partial class Form3_InvestmentTaxCredit : Form
    {
        static Form3_InvestmentTaxCredit _instance;
        public static Form3_InvestmentTaxCredit GetInstance
        {
            get
            {
                if (_instance == null)
                    _instance = new Form3_InvestmentTaxCredit();
                return _instance;
            }

        }
        public static string[] pdfInputs;
        public static double totalInvestment = 0.0;
        // investment documents
        public static string document1 = "";
        public static string document2 = "";
        public static string document3 = "";
        public static string document4 = "";
        public static string document5 = "";
        public static string document6 = "";
        public static string document7 = "";
        public static string document8 = "";
        public static string document9 = "";
        public static string document10 = "";
        public Form3_InvestmentTaxCredit()
        {
            InitializeComponent();
            pdfInputs = new string[21];
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            madeAllTextBoxZero();
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
        }
      
        private double InvestmentTaxCalculate()
        {
            totalInvestment = (double)Convert.ToDecimal(textBox1.Text.ToString()) +
                                (double)Convert.ToDecimal(textBox2.Text.ToString()) +
                                (double)Convert.ToDecimal(textBox3.Text.ToString()) +
                                (double)Convert.ToDecimal(textBox4.Text.ToString()) +
                                (double)Convert.ToDecimal(textBox5.Text.ToString()) +
                                (double)Convert.ToDecimal(textBox6.Text.ToString()) +
                                (double)Convert.ToDecimal(textBox7.Text.ToString()) +
                                (double)Convert.ToDecimal(textBox8.Text.ToString()) +
                                (double)Convert.ToDecimal(textBox9.Text.ToString()) +
                                (double)Convert.ToDecimal(textBox10.Text.ToString());
           
            return totalInvestment;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    double value = (double)Convert.ToDecimal(textBox1.Text.ToString());
                    textBox1.Text = value.ToString("N");
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
                    double value = (double)Convert.ToDecimal(textBox2.Text.ToString());
                    textBox2.Text = value.ToString("N");
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
                    double value = (double)Convert.ToDecimal(textBox3.Text.ToString());
                    textBox3.Text = value.ToString("N");
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
                    double value = (double)Convert.ToDecimal(textBox4.Text.ToString());
                    textBox4.Text = value.ToString("N");
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
                    double value = (double)Convert.ToDecimal(textBox5.Text.ToString());
                    textBox5.Text = value.ToString("N");
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
                    double value = (double)Convert.ToDecimal(textBox6.Text.ToString());
                    textBox6.Text = value.ToString("N");
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
                    double value = (double)Convert.ToDecimal(textBox7.Text.ToString());
                    textBox7.Text = value.ToString("N");
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
                    double value = (double)Convert.ToDecimal(textBox8.Text.ToString());
                    textBox8.Text = value.ToString("N");
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
                    double value = (double)Convert.ToDecimal(textBox9.Text.ToString());
                    textBox9.Text = value.ToString("N");
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
                    double value = (double)Convert.ToDecimal(textBox10.Text.ToString());
                    textBox10.Text = value.ToString("N");
                }
            }
            catch
            {
                textBox10.Text = "0.0";  //clear user input because of invaild inputs
            }
        }

        //textBox1 to textBox10
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //show total "Investment tax credit"
                label12.Text = InvestmentTaxCalculate().ToString("N");    //string formatting as a number;which has comma
            }
            catch
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {   //save data for pdf file
            UserInput_InvestmentTaxCredit();
            
            
            Form4_SatementOfSalary f = Form4_SatementOfSalary.GetInstance;
            //hiding investment tex credit form
            this.Hide();
            //showing "Satement Of Salary" form
            f.Show();        
        }

        /*..............List of documents furnished.............*/

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                document1 = textBox11.Text.ToString();
                textBox12.Focus();
            }
        }

        private void textBox12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                document2 = textBox12.Text.ToString();
                textBox13.Focus();
            }
        }

        private void textBox13_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                document3 = textBox13.Text.ToString();
                textBox14.Focus();
            }
        }

        private void textBox14_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                document4 = textBox14.Text.ToString();
                textBox15.Focus();
            }
        }

        private void textBox15_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                document5 = textBox15.Text.ToString();
                textBox16.Focus();
            }
        }
        private void textBox16_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                document6 = textBox16.Text.ToString();
                textBox17.Focus();
            }
        }
        private void textBox17_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                document7 = textBox17.Text.ToString();
                textBox18.Focus();
            }
        }
        private void textBox18_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                document8 = textBox18.Text.ToString();
                textBox19.Focus();
            }
        }
        private void textBox19_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                document9 = textBox19.Text.ToString();
                textBox20.Focus();
            }
        }
        private void textBox20_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                document10 = textBox20.Text.ToString();
            }
        }

        //saving all user inputs to print in pdf file
        public void UserInput_InvestmentTaxCredit()
        {
            pdfInputs[0] = textBox1.Text.ToString();   //Life insurance premium
            pdfInputs[1] = textBox2.Text.ToString();   //Contribution to deffered annuity
            pdfInputs[2] = textBox3.Text.ToString();   //Contribution to provident fund
            pdfInputs[3] = textBox4.Text.ToString();   //Self contribution and employers contributon to recognized provdent fund
            pdfInputs[4] = textBox5.Text.ToString();   //Contribution to super annuaton fund / DPS
            pdfInputs[5] = textBox6.Text.ToString();   //investment in approved debebnture stock, stock, or shares
            pdfInputs[6] = textBox7.Text.ToString();   //Contributon to depost pension scheem
            pdfInputs[7] = textBox8.Text.ToString();   //Group insurance premium
            pdfInputs[8] = textBox9.Text.ToString();   //Contribution to zaat fund
            pdfInputs[9] = textBox10.Text.ToString();   //Other (if any)
            pdfInputs[10] = label12.Text.ToString();  //total

            pdfInputs[11] = textBox11.Text.ToString();  //Document 1
            pdfInputs[12] = textBox12.Text.ToString();  //Document 2
            pdfInputs[13] = textBox13.Text.ToString();  //Document 3
            pdfInputs[14] = textBox14.Text.ToString();  //Document 4
            pdfInputs[15] = textBox15.Text.ToString();  //Document 5
            pdfInputs[16] = textBox16.Text.ToString();  //Document 6
            pdfInputs[17] = textBox17.Text.ToString();  //Document 7
            pdfInputs[18] = textBox18.Text.ToString();  //Document 8
            pdfInputs[19] = textBox19.Text.ToString();  //Document 9
            pdfInputs[20] = textBox20.Text.ToString();  //Document 10           

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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2_Salaries.GetInstance.Show();
        }

        private void Form3_InvestmentTaxCredit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                //application Closing by cross cursor;
                Application.Exit();
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text.ToString() == "") textBox1.Text = "0.0";  //copy "0.0" if user clears input field
            try
            {
                Convert.ToDecimal(textBox1.Text.ToString());    //checking user inputs valid or not
            }
            catch
            {
                textBox1.Text = "0.0";  //clean user inputs because of invalid inputs
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text.ToString() == "") textBox2.Text = "0.0";  //copy "0.0" if user clears input field
            try
            {
                Convert.ToDecimal(textBox2.Text.ToString());    //checking user inputs valid or not
            }
            catch
            {
                textBox2.Text = "0.0";  //clean user inputs because of invalid inputs
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text.ToString() == "") textBox3.Text = "0.0";  //copy "0.0" if user clears input field
            try
            {
                Convert.ToDecimal(textBox3.Text.ToString());    //checking user inputs valid or not
            }
            catch
            {
                textBox3.Text = "0.0";  //clean user inputs because of invalid inputs
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text.ToString() == "") textBox4.Text = "0.0";  //copy "0.0" if user clears input field
            try
            {
                Convert.ToDecimal(textBox4.Text.ToString());    //checking user inputs valid or not
            }
            catch
            {
                textBox4.Text = "0.0";  //clean user inputs because of invalid inputs
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text.ToString() == "") textBox5.Text = "0.0";  //copy "0.0" if user clears input field
            try
            {
                Convert.ToDecimal(textBox5.Text.ToString());    //checking user inputs valid or not
            }
            catch
            {
                textBox5.Text = "0.0";  //clean user inputs because of invalid inputs
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox6.Text.ToString() == "") textBox6.Text = "0.0";  //copy "0.0" if user clears input field
            try
            {
                Convert.ToDecimal(textBox6.Text.ToString());    //checking user inputs valid or not
            }
            catch
            {
                textBox6.Text = "0.0";  //clean user inputs because of invalid inputs
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (textBox7.Text.ToString() == "") textBox7.Text = "0.0";  //copy "0.0" if user clears input field
            try
            {
                Convert.ToDecimal(textBox7.Text.ToString());    //checking user inputs valid or not
            }
            catch
            {
                textBox7.Text = "0.0";  //clean user inputs because of invalid inputs
            }
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            if (textBox8.Text.ToString() == "") textBox8.Text = "0.0";  //copy "0.0" if user clears input field
            try
            {
                Convert.ToDecimal(textBox8.Text.ToString());    //checking user inputs valid or not
            }
            catch
            {
                textBox8.Text = "0.0";  //clean user inputs because of invalid inputs
            }
        }

        private void textBox9_Leave(object sender, EventArgs e)
        {
            if (textBox9.Text.ToString() == "") textBox9.Text = "0.0";  //copy "0.0" if user clears input field
            try
            {
                Convert.ToDecimal(textBox9.Text.ToString());    //checking user inputs valid or not
            }
            catch
            {
                textBox9.Text = "0.0";  //clean user inputs because of invalid inputs
            }
        }

        private void textBox10_Leave(object sender, EventArgs e)
        {
            if (textBox10.Text.ToString() == "") textBox10.Text = "0.0";  //copy "0.0" if user clears input field
            try
            {
                Convert.ToDecimal(textBox10.Text.ToString());    //checking user inputs valid or not
            }
            catch
            {
                textBox10.Text = "0.0";  //clean user inputs because of invalid inputs
            }
        }

        private void textBox_Leave(object sender, EventArgs e)
        {

        }
    }
}
