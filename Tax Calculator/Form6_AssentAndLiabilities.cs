using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Tax_Calculator
{
    public partial class Form6_AssentAndLiabilities : Form
    {
        /** The original PDF file. */
        public static string oldFile = Application.StartupPath + @"\File\income tax form.pdf";  //making 
        private string myFont = "Arial";    //Font name to print
        private int fontSize = 8;       //font size to print
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
        private double CalTotalAssets()
        {
            return totalAssets = Double.Parse(textBox1.Text.ToString()) +
                                 Double.Parse(textBox2.Text.ToString()) +
                                 Double.Parse(textBox3.Text.ToString()) +
                                 Double.Parse(textBox4.Text.ToString()) +
                                 Double.Parse(textBox5.Text.ToString()) +
                                 Double.Parse(textBox6.Text.ToString()) +
                                 Double.Parse(textBox7.Text.ToString()) +
                                 Double.Parse(textBox8.Text.ToString()) +
                                 Double.Parse(textBox9.Text.ToString()) +
                                 Double.Parse(textBox10.Text.ToString()) +
                                 Double.Parse(textBox11.Text.ToString()) +
                                 Double.Parse(textBox12.Text.ToString()) +
                                 Double.Parse(textBox13.Text.ToString()) +
                                 Double.Parse(textBox14.Text.ToString()) +
                                 Double.Parse(textBox15.Text.ToString()) +
                                 Double.Parse(textBox16.Text.ToString()) +
                                 Double.Parse(textBox17.Text.ToString());

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
            return totalInvestments = Double.Parse(textBox5.Text.ToString()) +
                                        Double.Parse(textBox6.Text.ToString()) +
                                        Double.Parse(textBox7.Text.ToString()) +
                                        Double.Parse(textBox8.Text.ToString()) +
                                        Double.Parse(textBox9.Text.ToString());


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
            return totalCashAssets = Double.Parse(textBox14.Text.ToString())+
                                     Double.Parse(textBox15.Text.ToString())+
                                     Double.Parse(textBox16.Text.ToString());
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
            return totalLiabilities = Double.Parse(textBox18.Text.ToString()) +
                                      Double.Parse(textBox19.Text.ToString()) +
                                      Double.Parse(textBox20.Text.ToString()) +
                                      Double.Parse(textBox21.Text.ToString());
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
                netWealthPrevYear = Double.Parse(textBox22.Text.ToString());
                accretionInWealth = netWealthThisYear - netWealthPrevYear;

                label82.Text = accretionInWealth.ToString();

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
                familyExpenditure = Double.Parse(textBox23.Text.ToString());
                totalAccretionInWealth = accretionInWealth + familyExpenditure;

                label85.Text = totalAccretionInWealth.ToString();

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
                adult = int.Parse(textBox24.Text.ToString());
                

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
                child = int.Parse(textBox25.Text.ToString());


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
            SaveFileDialog svg = new SaveFileDialog();  //show dialgue box to take a location with file name
            svg.ShowDialog();   //getting new pdf file location and file name given by user
            // size = reader.GetPageSizeWithRotation(1); 

            using (var outputPdfStream = new FileStream(svg.FileName + ".pdf", FileMode.Create, FileAccess.Write))
            {
                //open the reader
                PdfReader reader = new PdfReader(oldFile);

                PdfStamper stamper = new PdfStamper(reader, outputPdfStream);
                var pageSize = reader.GetPageSize(1);   //getting page size by giving page number=1
                
                pdfWrite_Form2(ref stamper, ref reader);    //salaries form print
                pdfWrite_Form3(ref stamper, ref reader);    //Investment-tax-credit form print
                pdfWrite_Form5(ref stamper, ref reader);    //statement-of-salary form print
                pdfWrite_Form4(ref stamper, ref reader);    //Expenses form print
                pdfWrite_Form6(ref stamper, ref reader);    //Asset and Liabilities form print
                stamper.Close();

            }

            
        }
        private void pdfWrite_Form2(ref PdfStamper stamper, ref PdfReader reader)
        {
            int pageNo = 3;     //page = 3 is Salaries form
            PdfContentByte canvas = stamper.GetOverContent(pageNo);
            Form2_HelperFunction(ref canvas,ref reader);        

        }

        private void pdfWrite_Form3(ref PdfStamper stamper, ref PdfReader reader)
        {
            int pageNo = 4;     //page = 4 is investment form
            PdfContentByte canvas = stamper.GetOverContent(pageNo);
            //print "investment tax  credit"
            Form3_HelperFunction1(ref canvas, ref reader);
            //print "list of documents furnished"
            Form3_HelperFunction2(ref canvas, ref reader);

        }

        private void pdfWrite_Form5(ref PdfStamper stamper, ref PdfReader reader)
        {
            int pageNo = 7;     //page = 7 is Expense form
            PdfContentByte canvas = stamper.GetOverContent(pageNo);
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form1_Personal_info.pdfInputs[0], 185, 140); //print "Name of Assessee"

            float tempX = 342;  //set "TIN" number positon x=342 , y =142
            string s = Form1_Personal_info.pdfInputs[3];    //get "TIN" as a string 
            //print "TIN" above the "Expense form"
            for (int i=0; i<s.Length; i++)
            {
                if(i==3 || i==6)    //checking to jump additionally
                {
                    tempX += 18;     // jump with difference of x=18 to right hand side box
                }
               
                WriteStringOnPdf(ref canvas, ref reader, pageNo, s[i]+"", tempX, 142);
                tempX += 18;    // jump with difference of x=18 to right hand side box
            }
            //print "Expense" form
            Form5_HelperFunction(ref canvas, ref reader);

            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form1_Personal_info.pdfInputs[0], 184, 642); //print "name of assessee" in Receipt of income tax return
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form1_Personal_info.pdfInputs[3], 467, 642); //print "Assessment year" in Receipt of income tax return
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form1_Personal_info.pdfInputs[4], 390, 678); //print "Circle" in Receipt of income tax return
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form1_Personal_info.pdfInputs[5], 491, 680); //print "Taxes Zone" in Receipt of income tax return

            float tempX1 = 139;  //set "TIN" number positon x=140 , y =680
           //print "TIN" under the "Expense form"
            for (int i = 0; i < s.Length; i++)
            {
                if (i == 3 || i == 6)    //checking to jump R.H.S. additionally
                {
                    tempX1 += 16;    // jump with difference of x=16 to right hand side box
                }
                WriteStringOnPdf(ref canvas, ref reader, pageNo, s[i]+"" , tempX1, 680);
                tempX1 += 16;    // jump with difference of x=16 to right hand side box
            }

        }
        private void pdfWrite_Form4(ref PdfStamper stamper, ref PdfReader reader)
        {
            int pageNo = 2;     //page = 2 is "statement of income" form
            PdfContentByte canvas = stamper.GetOverContent(pageNo);
            //print "Expense" form
            Form4_HelperFunction(ref canvas, ref reader);

        }

        private void pdfWrite_Form6(ref PdfStamper stamper, ref PdfReader reader)
        {
            int pageNo = 5;     //page = 5 is   //Asset and Liabilities form
            PdfContentByte canvas = stamper.GetOverContent(pageNo);
           // Form6_HelperFunction(ref canvas, ref reader);

        }

        private void Form2_HelperFunction(ref PdfContentByte canvas, ref PdfReader reader)
        {
            //setting-up the X and Y coordinates of the document
            float x = 273;  //by default x increment left-right
            float y = 170;
            int starIndex = 0;
            int endIndex = 18;
            Form2_HelperFunction1(ref canvas,ref reader, x,y, starIndex, endIndex);

            x += 103;   //x coordinate right shift(column)
            starIndex =endIndex;
            endIndex += endIndex;
            Form2_HelperFunction1(ref canvas, ref reader, x, y, starIndex,  endIndex);

            x += 103;   //x coordinate right shift(column)
            starIndex = 36;
            endIndex = 54;
            Form2_HelperFunction1(ref canvas, ref reader, x, y, starIndex, endIndex); //print "salaried"
            Form2_HelperFunction2(ref canvas, ref reader);  //print "House property income"

        }

        private void Form2_HelperFunction2(ref PdfContentByte canvas, ref PdfReader reader)
        {
            int pageNo = 3;
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form2_Salaries.pdfInputs2[0], 71, 593);    //location and description of property
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form2_Salaries.pdfInputs2[1], 469, 593);   //print annual rental income
            var pageSize3 = reader.GetPageSize(pageNo);   //getting page size by giving page number=3   
            float x = 374;
            float tempY = 627;
            //printing House property income under "salaries" form 
            for (int i=2 ; i < 9; i++)
            {
                string s = Form2_Salaries.pdfInputs1[i];
                if (i == 6)  //checking to jump down additionally
                {
                    tempY += 8;   // jump half line down with difference of x=8 
                }
                WriteStringOnPdf(ref canvas, ref reader, pageNo, s, x, tempY);   //printing "House property income" from "annual rental income" to "others, if any"
                tempY += 17;    // jump one line down with difference of x=17 .          
            }
            WriteStringOnPdf(ref canvas, ref reader, pageNo,Form2_Salaries.pdfInputs2[9], 469, tempY);  //printing total "House property income"
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form2_Salaries.pdfInputs2[10], 469, tempY+17); //printing "Net income" from house
        }
 
        private void Form2_HelperFunction1(ref PdfContentByte canvas, ref PdfReader reader,float x,float y, int startIndex, int endIndex)
        {           
            int pageNo = 3;
            var pageSize3 = reader.GetPageSize(pageNo);   //getting page size by giving page number=3 

            float tempY = y;    //set y positon
            //printing "salaries" form
            for ( ; startIndex < endIndex- 5; startIndex++)
            {
                string s = Form2_Salaries.pdfInputs1[startIndex];   //get each of the salary amount
                WriteStringOnPdf(ref canvas, ref reader, pageNo,s, x, tempY);   //print from basicPay to "employer's contribution to recongnized provident fund"
                tempY += 17;    // jump one line down with difference of x=17
            }
            tempY += 17;    //jump one line shift down using difference of y =17
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form2_Salaries.pdfInputs1[startIndex], x, tempY);  //print interest accrued on recoginzed provient fund
            tempY += 17*2;  //jump two line shift down using difference of y =17
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form2_Salaries.pdfInputs1[++startIndex], x, tempY);     //print deemed income for transport facility
            tempY += 17;    //jump one line shift down using difference of y =17
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form2_Salaries.pdfInputs1[++startIndex], x, tempY); //print deemed income for free furnished/unfurnished accommodation
            tempY += 17 * 2;    //jump two line shift down using difference of y =17
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form2_Salaries.pdfInputs1[++startIndex], x, tempY);  //print other, if any
            tempY += 17;    //jump one line shift down using difference of y =17
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form2_Salaries.pdfInputs1[++startIndex], x, tempY);  //print net taxable income from salary

        }

        private void Form3_HelperFunction1(ref PdfContentByte canvas, ref PdfReader reader)
        {
            //setting-up the X and Y coordinates of the document
            float x = 424;  //by default x increment left-right for investment form
            float y = 99;      //define vertically staring =99

            int length = Form3_InvestmentTaxCredit.pdfInputs.Length;
            //printing "investment tax credit"
            for (int i = 0; i < 11; i++)
            {
                string s = Form3_InvestmentTaxCredit.pdfInputs[i];
                if (i == 3) //checking to jump down additionally
                {
                    y += 13;   // jump almost one line down with difference of x=13

                }
                if (i == 4 || i == 6)   //checking to jump down additionally
                {
                    y += 15;    // jump almost one line down with difference of x=15
                }
                WriteStringOnPdf(ref canvas, ref reader, 4, s, x, y);   //print all "investment tax"
                y += 17;    // jump one line down with difference of x=17 . 
            }
                      
        }
        private void Form3_HelperFunction2(ref PdfContentByte canvas, ref PdfReader reader)
        {
            //setting-up the X and Y coordinates of the document
            float x = 78;   //by default x coordinate for "investment form"
            float y = 437;  //by default y increment top-down for "investment form"

            // printing "list of document furnished" from 1-5
            for (int i = 11; i < 16; i++)
            {
                string s = Form3_InvestmentTaxCredit.pdfInputs[i];
                
                WriteStringOnPdf(ref canvas, ref reader, 4, s, x, y);   //print from "document 1-5"
                y += 66;    // jump three lines down with difference of x=66
            }

            //setting x and y positions
            x = 321;
            y = 435;
            int length = Form3_InvestmentTaxCredit.pdfInputs.Length;
            //print from "document 6-10" in "investment tax credit" form
            for (int i = 16; i < length; i++)
            {
                string s = Form3_InvestmentTaxCredit.pdfInputs[i];
                WriteStringOnPdf(ref canvas, ref reader, 4, s, x, y);   //print from "document 6-7"
                y += 66;  // jump three lines down with difference of x=66
            }
        }

        private void Form5_HelperFunction(ref PdfContentByte canvas, ref PdfReader reader)
        {
            //setting-up the X and Y coordinates of the document
            float x = 343;   //by default x coordinate for "Expenses form"
            float y = 197;  //by default y increment top-down for "Expenses form"

            int length = Form5_Expenses.pdfInputs.Length;
            // printing "list of Expenses" entry
            for (int i = 0; i < length; i++)
            {
                string s = Form5_Expenses.pdfInputs[i]; //getting all Expenses one by one

                WriteStringOnPdf(ref canvas, ref reader, 7, s, x, y);   //print all entry "Expenses"
                y += 20;   // jump almost one line down with difference of x=20
            }
        }

        private void Form4_HelperFunction(ref PdfContentByte canvas, ref PdfReader reader)
        {
            //setting-up the X and Y coordinates of the document
            float x = 453;   //by default x coordinate for "statement of income form"
            float y = 116;  //by default y increment top-down for "statement of income form"

            int length = Form4_SatementOfSalary.pdfInputs.Length;
            // printing "statement of income" entry
            for (int i = 0; i < 18; i++)
            {
                string s = Form4_SatementOfSalary.pdfInputs[i]; //getting each statement of salary info one by by
                if(i==15 ||i==16 || i==17) //checking to jump down additionally
                {
                    y += 11;    // jump half line down with difference of x=11
                }
         
                WriteStringOnPdf(ref canvas, ref reader, 2, s, x, y);   //print all entry "statement of income"
                y += 17;    // jump one line down with difference of x=17
            }

            y += 8; // jump half line down with difference of x=8
            WriteStringOnPdf(ref canvas, ref reader, 2, Form4_SatementOfSalary.pdfInputs[18], x, y);     //printing "Tax paid on the basis of this return (u/s 74)"
            y += 25;    // jump some lines down with difference of x=25
            WriteStringOnPdf(ref canvas, ref reader, 2, Form4_SatementOfSalary.pdfInputs[19], x, y);     //printing "Advance o Tax Refund (if any)"
            y += 22;    // jump almost one line down with difference of x=22
            WriteStringOnPdf(ref canvas, ref reader, 2, Form4_SatementOfSalary.pdfInputs[20], x, y);     //printing "Difference between serial no.15 and 16 (if any)"
            y += 17;    // jump one line down with difference of x=17
            WriteStringOnPdf(ref canvas, ref reader, 2, Form4_SatementOfSalary.pdfInputs[21], x, y);     //printing "Tax exempted and Tax free income"
            y += 17;    // jump one line down with difference of x=17
            WriteStringOnPdf(ref canvas, ref reader, 2, Form4_SatementOfSalary.pdfInputs[21], x, y);    //printing "Income tax paid in the last assessment year"

        }

        //testing /..............
        private void Form6_HelperFunction(ref PdfContentByte canvas, ref PdfReader reader)
        {
            //setting-up the X and Y coordinates of the document
            float x = 0;   //by default x coordinate for "statement of income form"
            float y = 0;  //by default y increment top-down for "statement of income form"

            int length = pdfInputs.Length;
            //printing "Asset and Liabilities" form entry
            for (int i = 0; i < 18; i++)
            {
                string s = Form4_SatementOfSalary.pdfInputs[i];
                if (i == 15 || i == 16 || i == 17)  //checking to jump down additionally
                {
                    y += 11;    // jump half line down with difference of x=11
                }

                WriteStringOnPdf(ref canvas, ref reader, 2, s, x, y);   //print all entry "Asset and Liabilities"
                y += 17;   // jump one line down with difference of x=17
            }
        }

        //write a single string on existing pdf file 
        private void WriteStringOnPdf(ref PdfContentByte canvas, ref PdfReader reader,int pageNo , string s, float posX,float posY)
        {             
            var pageSize = reader.GetPageSize(pageNo);  //"pageSize" = giving "pageNo"

            //making the y to increment top-Down
            posY = pageSize.Height - posY - 3;  //posY = position token from gimp
            //defining Arial font with font_size=8 
            iTextSharp.text.Font font = FontFactory.GetFont(myFont, fontSize);
            Phrase p = new Phrase(s,font);          
            
            ColumnText.ShowTextAligned(canvas, Element.ALIGN_LEFT, p, posX, posY, 0);       //Here zero means "Rotation = 0" or  "no Rotation "
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
            // only allow integers
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox25_KeyPress(object sender, KeyPressEventArgs e)
        {
            // only allow integers
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox26_KeyPress(object sender, KeyPressEventArgs e)
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
