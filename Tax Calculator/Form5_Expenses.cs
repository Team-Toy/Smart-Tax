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
    public partial class Form5_Expenses : Form
    {
        static Form5_Expenses _instance;
        public static Form5_Expenses GetInstance
        {
            get
            {
                if (_instance == null)
                    _instance = new Form5_Expenses();
                return _instance;
            }

        }
        public static string[] pdfInputs;
        public static double totalExpense = 0;
        public Form5_Expenses()
        {
            InitializeComponent();
            pdfInputs = new string[12];
        }

        private void Form5_Expenses_Load(object sender, EventArgs e)
        {
            // made all textbox zero by default
            makeAllTextBoxZero();
        }
        public void makeAllTextBoxZero()
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
        }
        private double CalTotalExpense()
        {
            totalExpense = (double)Convert.ToDecimal(textBox1.Text.ToString()) +
                            (double)Convert.ToDecimal(textBox2.Text.ToString()) +
                           (double)Convert.ToDecimal(textBox3.Text.ToString()) +
                            (double)Convert.ToDecimal(textBox4.Text.ToString()) +
                            (double)Convert.ToDecimal(textBox5.Text.ToString()) +
                            (double)Convert.ToDecimal(textBox6.Text.ToString()) +
                            (double)Convert.ToDecimal(textBox7.Text.ToString()) +
                            (double)Convert.ToDecimal(textBox8.Text.ToString()) +
                            (double)Convert.ToDecimal(textBox9.Text.ToString()) +
                            (double)Convert.ToDecimal(textBox10.Text.ToString()) +
                            (double)Convert.ToDecimal(textBox11.Text.ToString());                           

            return totalExpense;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                   // any string number(with comma or without comma) coverted to double
                    double tempValue = (double)Convert.ToDecimal(textBox1.Text.ToString());    //checking user input vaild or not
                    textBox1.Text = tempValue.ToString("N");  //making user input as a currency style number
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
                    // any string number(with comma or without comma) coverted to double
                    double tempValue = (double)Convert.ToDecimal(textBox2.Text.ToString());    //checking user input vaild or not
                    textBox2.Text = tempValue.ToString("N");  //making user input as a currency style number
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
                    // any string number(with comma or without comma) coverted to double
                    double tempValue = (double)Convert.ToDecimal(textBox3.Text.ToString());    //checking user input vaild or not
                    textBox3.Text = tempValue.ToString("N");  //making user input as a currency style number
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
                    // any string number(with comma or without comma) coverted to double
                    double tempValue = (double)Convert.ToDecimal(textBox4.Text.ToString());    //checking user input vaild or not
                    textBox4.Text = tempValue.ToString("N");  //making user input as a currency style number
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
                    // any string number(with comma or without comma) coverted to double
                    double tempValue = (double)Convert.ToDecimal(textBox5.Text.ToString());    //checking user input vaild or not
                    textBox5.Text = tempValue.ToString("N");  //making user input as a currency style number
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
                    // any string number(with comma or without comma) coverted to double
                    double tempValue = (double)Convert.ToDecimal(textBox6.Text.ToString());    //checking user input vaild or not
                    textBox6.Text = tempValue.ToString("N");  //making user input as a currency style number
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
                    // any string number(with comma or without comma) coverted to double
                    double tempValue = (double)Convert.ToDecimal(textBox7.Text.ToString());    //checking user input vaild or not
                    textBox7.Text = tempValue.ToString("N");  //making user input as a currency style number
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
                    // any string number(with comma or without comma) coverted to double
                    double tempValue = (double)Convert.ToDecimal(textBox8.Text.ToString());    //checking user input vaild or not
                    textBox8.Text = tempValue.ToString("N");  //making user input as a currency style number
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
                    // any string number(with comma or without comma) coverted to double
                    double tempValue = (double)Convert.ToDecimal(textBox9.Text.ToString());    //checking user input vaild or not
                    textBox9.Text = tempValue.ToString("N");  //making user input as a currency style number
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
                    // any string number(with comma or without comma) coverted to double
                    double tempValue = (double)Convert.ToDecimal(textBox10.Text.ToString());    //checking user input vaild or not
                    textBox10.Text = tempValue.ToString("N");  //making user input as a currency style number
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
                    // any string number(with comma or without comma) coverted to double
                    double tempValue = (double)Convert.ToDecimal(textBox11.Text.ToString());    //checking user input vaild or not
                    textBox11.Text = tempValue.ToString("N");  //making user input as a currency style number
                    button1.Focus();    //focus on "Next" button
                }
            }
            catch
            {
                textBox11.Text = "0.0";  //clear user input because of invaild inputs
            }
        }

        private void UserInputs_Expenses()
        {
            pdfInputs[0] = textBox1.Text.ToString();   //Personal and fooding expenses
            pdfInputs[1] = textBox2.Text.ToString();   //Tax paid including deduction at source of the last financial year
            pdfInputs[2] = textBox3.Text.ToString();   //Accommodation expenses
            pdfInputs[3] = textBox4.Text.ToString();   //Transport expenses
            pdfInputs[4] = textBox5.Text.ToString();   //Electricity Bill for residence
            pdfInputs[5] = textBox6.Text.ToString();   //Wasa Bill for residence
            pdfInputs[6] = textBox7.Text.ToString();   //Gas Bill for residence
            pdfInputs[7] = textBox8.Text.ToString();   //Telephone Bill for residence
            pdfInputs[8] = textBox9.Text.ToString();   //Education expenses for foreign travel
            pdfInputs[9] = textBox10.Text.ToString();   //Personal expenses for Foreign travel
            pdfInputs[10] = textBox11.Text.ToString();   //Festival and other special expenses, if any
            pdfInputs[11] = label13.Text.ToString();    //Total Expenditure
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //save data for pdf file
            UserInputs_Expenses();
            Form6_AssentAndLiabilities f = Form6_AssentAndLiabilities.GetInstance;
            this.Hide();
            f.Show();
        }

        //
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

        private void Form5_Expenses_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                //application Closing by cross cursor;
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4_SatementOfSalary f = Form4_SatementOfSalary.GetInstance;
            this.Hide();
            f.Show();
        }

        //
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                totalExpense = CalTotalExpense();
                label13.Text = totalExpense.ToString("N");  //string formatting as currency number style
            }
            catch
            {

            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text.ToString() == "") textBox1.Text = "0.0";  //if user try to input field empty then auto field it by "0.0"

            try
            {
                //any string number(with comma or without comma) coverted to double
                Convert.ToDecimal(textBox1.Text.ToString());    //checking user input valid or not
            }
            catch
            {
                textBox1.Text = "0.0";  //clear user input because of invaild inputs
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {

            if (textBox2.Text.ToString() == "") textBox2.Text = "0.0";  //if user try to input field empty then auto field it by "0.0"

            try
            {
                //any string number(with comma or without comma) coverted to double
                Convert.ToDecimal(textBox2.Text.ToString());    //checking user input valid or not
            }
            catch
            {
                textBox2.Text = "0.0";  //clear user input because of invaild inputs
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {

            if (textBox3.Text.ToString() == "") textBox3.Text = "0.0";  //if user try to input field empty then auto field it by "0.0"

            try
            {
                //any string number(with comma or without comma) coverted to double
                Convert.ToDecimal(textBox3.Text.ToString());    //checking user input valid or not
            }
            catch
            {
                textBox3.Text = "0.0";  //clear user input because of invaild inputs
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {

            if (textBox4.Text.ToString() == "") textBox4.Text = "0.0";  //if user try to input field empty then auto field it by "0.0"

            try
            {
                //any string number(with comma or without comma) coverted to double
                Convert.ToDecimal(textBox4.Text.ToString());    //checking user input valid or not
            }
            catch
            {
                textBox4.Text = "0.0";  //clear user input because of invaild inputs
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {

            if (textBox5.Text.ToString() == "") textBox5.Text = "0.0";  //if user try to input field empty then auto field it by "0.0"

            try
            {
                //any string number(with comma or without comma) coverted to double
                Convert.ToDecimal(textBox5.Text.ToString());    //checking user input valid or not
            }
            catch
            {
                textBox5.Text = "0.0";  //clear user input because of invaild inputs
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {

            if (textBox6.Text.ToString() == "") textBox6.Text = "0.0";  //if user try to input field empty then auto field it by "0.0"

            try
            {
                //any string number(with comma or without comma) coverted to double
                Convert.ToDecimal(textBox6.Text.ToString());    //checking user input valid or not
            }
            catch
            {
                textBox6.Text = "0.0";  //clear user input because of invaild inputs
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {

            if (textBox7.Text.ToString() == "") textBox7.Text = "0.0";  //if user try to input field empty then auto field it by "0.0"

            try
            {
                //any string number(with comma or without comma) coverted to double
                Convert.ToDecimal(textBox7.Text.ToString());    //checking user input valid or not
            }
            catch
            {
                textBox7.Text = "0.0";  //clear user input because of invaild inputs
            }
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {

            if (textBox8.Text.ToString() == "") textBox8.Text = "0.0";  //if user try to input field empty then auto field it by "0.0"

            try
            {
                //any string number(with comma or without comma) coverted to double
                Convert.ToDecimal(textBox8.Text.ToString());    //checking user input valid or not
            }
            catch
            {
                textBox8.Text = "0.0";  //clear user input because of invaild inputs
            }
        }

        private void textBox9_Leave(object sender, EventArgs e)
        {

            if (textBox9.Text.ToString() == "") textBox9.Text = "0.0";  //if user try to input field empty then auto field it by "0.0"

            try
            {
                //any string number(with comma or without comma) coverted to double
                Convert.ToDecimal(textBox9.Text.ToString());    //checking user input valid or not
            }
            catch
            {
                textBox9.Text = "0.0";  //clear user input because of invaild inputs
            }
        }

        private void textBox10_Leave(object sender, EventArgs e)
        {

            if (textBox10.Text.ToString() == "") textBox10.Text = "0.0";  //if user try to input field empty then auto field it by "0.0"

            try
            {
                //any string number(with comma or without comma) coverted to double
                Convert.ToDecimal(textBox10.Text.ToString());    //checking user input valid or not
            }
            catch
            {
                textBox10.Text = "0.0";  //clear user input because of invaild inputs
            }
        }

        private void textBox11_Leave(object sender, EventArgs e)
        {

            if (textBox11.Text.ToString() == "") textBox11.Text = "0.0";  //if user try to input field empty then auto field it by "0.0"

            try
            {
                //any string number(with comma or without comma) coverted to double
                Convert.ToDecimal(textBox11.Text.ToString());    //checking user input valid or not
            }
            catch
            {
                textBox11.Text = "0.0";  //clear user input because of invaild inputs
            }
        }

       
    }
}
