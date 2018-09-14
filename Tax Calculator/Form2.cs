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
    public partial class Form2 : Form
    {
        // tax configuration file path variable
        private string filepath = Application.StartupPath + "temp.txt";
        private string emptyString = "";
        

        public Form2()
        {
            InitializeComponent();           
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            InitializeConfiguration();
        }

        
        private void InitializeConfiguration()
        {


            if (File.Exists(filepath))
            {
                
                
                //List<string> lines = myFileReadIntoList();

                // checking tax slabs values and it's percentage records info not empty
                StreamReader sr = new StreamReader(filepath, true);
                

                textBox1.Text = sr.ReadLine();   //auto fill 1st slab in textbox1 for male
                textBox2.Text = sr.ReadLine();     //auto fill 1st slab in textbox2 for female
                textBox3.Text = sr.ReadLine();    //auto fill 1st slab in textbox2 for others
                textBox4.Text = sr.ReadLine();
                textBox5.Text = sr.ReadLine();  //auto fill 2nd slab in textbox2
                textBox6.Text = sr.ReadLine();    //auto fill 3rd slab in textbox3
                textBox7.Text = sr.ReadLine();     //auto fill 4th slab in textbox4
                textBox8.Text = sr.ReadLine();    //auto fill 5th slab in textbox5

                // tax percentage reading from file
                textBox9.Text = sr.ReadLine();    //auto fill 2nd slab percentage in textbox2
                textBox10.Text = sr.ReadLine();  //auto fill 3rd slab percentage in textbox3
                textBox11.Text = sr.ReadLine();  //auto fill 4th slab percentage in textbox4
                textBox12.Text = sr.ReadLine(); //auto fill 5th slab percentage in textbox5
                textBox13.Text = sr.ReadLine();  //auto fill remainning slab percentage in textbox5
                sr.Close();
                //checking if no connection info found
               

            }
            //if tax configuration file not found
            //else
            //
            //    //find current file directory
            //    FileInfo fi = new FileInfo(filepath);
            //    //create file in current directory
            //    fi.Create();

            //}
        }

        /// <summary>
        /// here all the tax infos are written in file
        /// </summary>
        private void FileInfoWriter()
        {
            //List<string> lines = new List<string>();
            
            //saving all slaps values  by lines variable into a file
            if (textBox1.Text.ToString().Equals(emptyString) || textBox2.Text.ToString().Equals(emptyString) || textBox3.Text.ToString().Equals(emptyString) || textBox4.Text.ToString().Equals(emptyString) || textBox6.Text.ToString().Equals(emptyString) || textBox7.Text.ToString().Equals(emptyString) || textBox8.Text.ToString().Equals(emptyString) || textBox9.Text.ToString().Equals(emptyString) || textBox10.Text.ToString().Equals(emptyString) || textBox11.Text.ToString().Equals(emptyString) || textBox12.Text.ToString().Equals(emptyString) || textBox13.Text.ToString().Equals(emptyString))
            {
                label13.Text = "Not Saved. Check values !";

            }
            else
            {
                StreamWriter sw = new StreamWriter(filepath, false);
                sw.WriteLine(textBox1.Text.ToString());
                sw.WriteLine(textBox2.Text.ToString());
                sw.WriteLine(textBox3.Text.ToString());
                sw.WriteLine(textBox4.Text.ToString());
                sw.WriteLine(textBox5.Text.ToString());
                sw.WriteLine(textBox6.Text.ToString());
                sw.WriteLine(textBox7.Text.ToString());
                sw.WriteLine(textBox8.Text.ToString());
                sw.WriteLine(textBox9.Text.ToString());
                sw.WriteLine(textBox10.Text.ToString());
                sw.WriteLine(textBox11.Text.ToString());
                sw.WriteLine(textBox12.Text.ToString());
                sw.WriteLine(textBox13.Text.ToString());

                sw.Close();
                //writing tax slabs and tax percentages info in file
                //File.WriteAllLines(filepath, lines);

                label13.Text = "Saved successfully.";

                
                             
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // saving all income tax slaps information into a file
            
                FileInfoWriter();
                       
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        /* Form2_FormClosing():
         * .......................
         * it close form2 by click cross bar.
        */
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {    // hide setting form window
                //Close();
                this.Hide();   
            }
        }
        /* Form2_Activated():
         * 
         * 
         */
        private void Form2_Activated(object sender, EventArgs e)
        {
            if(this.Owner != null)
            {
                this.Owner.Enabled = false;
            }
        }
        /* Form2_Deactivated():
         * 
         * 
         */
        private void Form2_Deactivate(object sender, EventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Enabled = true;                
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
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
    }
}
