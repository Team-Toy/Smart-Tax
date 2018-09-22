using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tax_Calculator
{
    public partial class Form_PayableTaxCalculator : Form
    {
        List<double> areaWiseMinimumPayableTax; //minimum tax for remainning_income_without_tax
        private bool dataExist = false;
        private string inputErrorMessage = "Input required value !";
        private string ComboBoxErrorMessage = "Select Category !";

        private static double soFar = 0.0;
        private double[] personWiseFirstSlab = new double[5];   //slabs for 1st slab all type of people
        private double[] slabs = new double[5];   //slaps for 2nd to remaining
        private double[] taxPercents = new double[6];

        // tax configuration file path variable
        private string filepath = Application.StartupPath + "temp.txt";

        public Form_PayableTaxCalculator()
        {
            InitializeComponent();
            areaWiseMinimumPayableTax = new List<double>();
            areaWiseMinimumPayableTax.Add(5000);    //for Dhaka and Chittagong city corporation
            areaWiseMinimumPayableTax.Add(4000);    //for other city corporation
            areaWiseMinimumPayableTax.Add(3000);    //for outside of city corporation
        }

        private void Form_PayableTaxCalculator_Load(object sender, EventArgs e)
        {
            // default combobox value selected
            comboBox1.SelectedIndex = 0;

            label4.Text = ""+ Form4_SatementOfSalary.totalTaxableIncome;


            // make result of tax calculation transparent over background image
            label3.Parent = this.panel1;
            label3.BackColor = Color.Transparent;
            label3.BringToFront();


            //this.textBox1.KeyPress += new KeyPressEventHandler(CheckEnterPress);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VerifyAndTaxCal();
        }

        private void VerifyAndTaxCal()
        {
            double tax = 0.0;

            if (label4.Text.ToString().Equals(string.Empty))
            {

                label3.Text = inputErrorMessage;
                label3.ForeColor = Color.Red;

            }
            else
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    label3.Text = ComboBoxErrorMessage;
                    label3.ForeColor = Color.Red;
                }
                else
                {
                    // showing output result
                    tax = TaxCal(double.Parse(label4.Text.ToString()));

                    // added auto comma in currency style
                    label3.Text = (String.Format("{0:n}", tax) + "  ৳");
                    label3.ForeColor = Color.Black;
                }
            }
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            dataExist = defaultSlabAndPercentageRead();
            if (dataExist)
            {
                label3.Text = "0.0  ৳";
                comboBox1.SelectedIndex = 0;
            }
                
        }
 
        private bool defaultSlabAndPercentageRead()
        {
            bool flag = false;
            if (File.Exists(filepath))
            {
                flag = true;
                //reading all server connection info from file
                //List<string> lines = File.ReadAllLines(filepath).ToList();

                using (StreamReader sr = new StreamReader(filepath, true)) // checking tax records info not empty
                {

                    for (int i = 0; i < 4; i++)
                    {
                        personWiseFirstSlab[i] = double.Parse(sr.ReadLine());
                    }
                    for (int i = 0; i < 4; i++)
                    {
                        slabs[i] = double.Parse(sr.ReadLine());
                    }
                    for (int i = 0; i < 5; i++)
                    {
                        taxPercents[i] = double.Parse(sr.ReadLine());
                    }

                    // file reader closed
                    sr.Close();
                    label3.Text = "0.0  ৳";
                }


            }
            //if tax configuration file not found
            else
            {
                // make red warning if file not exits
                label3.ForeColor = Color.Red;
                label3.Text = "Update settings !";
                button1.Enabled = false;
            }
            //file exist check 
            return flag;

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                VerifyAndTaxCal();
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Settings f2 = new Form_Settings();
            //sending parent form to hide parent form by form2
            f2.ShowDialog(this);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //check selected person type as Male, Female,Diability,Fredom Fighter
            if (comboBox1.SelectedIndex != 0 && dataExist)
            {
                button1.Enabled = true;

                // calculate "button" color LimeGreen when button disabled
                button1.BackColor = Color.LimeGreen;
                button1.ForeColor = Color.White;
            }
            else
            {
                button1.Enabled = false;
                // calculate "button" color red when button disabled
                button1.BackColor = Color.Red;
                button1.ForeColor = Color.White;
            }
        }


        private double TaxCal(double total)
        {
            double firstSlab = 0.0, tax = 0.0;
            firstSlab = personWiseFirstSlab[comboBox1.SelectedIndex-1]; //choose person by selecting combox1
           
            if (total > firstSlab)
            {
                soFar = total - firstSlab;  // first slab deduction
            }

            if (soFar > 0)
            {   // calculate tax from 2nd to upto Remaining slap
                tax = Cal2ndTo5thSlab() + RemainingSlab();
                //choose area by selecting combox2 to check minimum payable tax after 1st slab
                if (tax < areaWiseMinimumPayableTax[comboBox2.SelectedIndex-1]) 
                {
                    // selecting tax rate Area wise by combox2
                    tax = areaWiseMinimumPayableTax[comboBox2.SelectedIndex-1]; 
                }
            }

            return tax;
        }

        private double Cal2ndTo5thSlab()
        {
            double tax = 0.0;
            for (int i = 0; i < 4; i++)
            {
                tax += CalTaxSlabHelper(slabs[i], tax, taxPercents[i]);
            }

            return tax;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Credits f3 = new Form_Credits();
            //sending parent form to hide parent form by form2
            f3.ShowDialog(this);
        }

        private double CalTaxSlabHelper(double slab, double tax, double taxPercent)
        {
            // checking to stop tax calculation
            if (soFar == 0.0) return soFar;

            if (soFar >= slab)  //if taxable income is above the slab range
            {
                //calculating amount of income excess from current slab range
                soFar = soFar - slab;
                tax = (slab * taxPercent) / 100.0;  //calculating payable tax on this max slab amount
            }
            else if (soFar > 0.0)   //if taxable income is under the slab range and non-zero
            {
                tax = (soFar * taxPercent) / 100.0;  //calculating payable tax 
                //making condition not to go next slab
                soFar = 0.0;
            }

            return tax;
        }

        private double RemainingSlab()
        {
            return (soFar * taxPercents[4]) / 100.00;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                VerifyAndTaxCal();
            }
        }
// need to use inside the code 
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                VerifyAndTaxCal();
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                VerifyAndTaxCal();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1_Personal_info f = new Form1_Personal_info();
            f.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}