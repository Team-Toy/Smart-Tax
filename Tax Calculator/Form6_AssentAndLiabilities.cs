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
        public static string oldFile = "C:\\Users\\ACM-Bimal\\Desktop Projects\\tax-calculator\\income tax.pdf";

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
            SaveFileDialog svg = new SaveFileDialog();
            svg.ShowDialog();
            // size = reader.GetPageSizeWithRotation(1); 

            using (var outputPdfStream = new FileStream(svg.FileName + ".pdf", FileMode.Create, FileAccess.Write))
            {
                //open the reader
                PdfReader reader = new PdfReader(oldFile);


                

                PdfStamper stamper = new PdfStamper(reader, outputPdfStream);
                //Gets a PdfContentByte to write over the page of the original document. here page=1

                PdfContentByte canvas = stamper.GetOverContent(1);
                ColumnText.ShowTextAligned(canvas, Element.ALIGN_LEFT, new Phrase("Hello people"), 36, 540, 0);

                //...................................
                
                 canvas = stamper.GetOverContent(3);
                //setting-up the X and Y coordinates of the document
               
                var pageSize = reader.GetPageSize(1);   //getting page size by giving page number=1
                                                        // var pageSize2 = reader.GetPageSize(2);   //getting page size by giving page number=2
                //iTextSharp.text.Font font = 4;

                pdfWrite_Form2(ref stamper, ref reader);



                stamper.Close();

            }

           
        }
        private void pdfWrite_Form2(ref PdfStamper stamper, ref PdfReader reader)
        {
            PdfContentByte canvas = stamper.GetOverContent(3);
            //testing
            float x = 273;  //by default x increment left-right
            float y = 173;  //initial y value for salary column

            WriteStringOnPdf(ref canvas, ref reader, 3, "testing on", x, y);
            y += 17;
            WriteStringOnPdf(ref canvas, ref reader, 3, "testing on 2", x, y);
           

            //HelperFunction(ref canvas,ref reader);
        }

        //testing purpose
        private void HelperFunction(ref PdfContentByte canvas, ref PdfReader reader)
        {
            //setting-up the X and Y coordinates of the document
            float x = 273;  //by default x increment left-right
            float y = 170;
            
            var pageSize3 = reader.GetPageSize(3);   //getting page size by giving page number=3

           // y = pageSize3.Height - (2 * y )+ 110; //making the y to increment top-Down

            float tempY = y;
            for (int i = 0; i < 13; i++)
            {
                Phrase p = new Phrase();
                string s = Form2_Salaries.pdfInputs1[i];
                p.Add(s);
                ColumnText.ShowTextAligned(canvas, Element.ALIGN_LEFT, p, x, tempY, 0);
                tempY += 17;
            }
            Phrase p1 = new Phrase();
            string s1 = Form2_Salaries.pdfInputs1[13];
            p1.Add(s1);
            ColumnText.ShowTextAligned(canvas, Element.ALIGN_LEFT, p1, x, pageSize3.Height-(2*420) +110, 0);
            

            Phrase p2 = new Phrase();
            string s2 = Form2_Salaries.pdfInputs1[14];
            p2.Add(s2);
            ColumnText.ShowTextAligned(canvas, Element.ALIGN_LEFT, p2, x, pageSize3.Height - (2 * 443) + 110, 0);

            Phrase p3 = new Phrase();
            string s3 = Form2_Salaries.pdfInputs1[15];
            p3.Add(s3);
            ColumnText.ShowTextAligned(canvas, Element.ALIGN_LEFT, p3, x, pageSize3.Height - (2 * 469) + 110, 0);

            Phrase p4 = new Phrase();
            string s4 = Form2_Salaries.pdfInputs1[16];
            p4.Add(s4);
            ColumnText.ShowTextAligned(canvas, Element.ALIGN_LEFT, p4, x, pageSize3.Height - (2 * 493) + 110, 0);

            Phrase p5 = new Phrase();
            string s5 = Form2_Salaries.pdfInputs1[17];
            p5.Add(s5);
            ColumnText.ShowTextAligned(canvas, Element.ALIGN_LEFT, p5, x, pageSize3.Height - (2 * 511) + 110, 0);


        }

        //write a single string on existing pdf file 
        private void WriteStringOnPdf(ref PdfContentByte canvas, ref PdfReader reader,int pageNo , string s, float posX,float posY)
        {
            var pageSize = reader.GetPageSize(pageNo);  //"pageSize" = giving "pageNo"
            posY = pageSize.Height - posY - 3;  //posY = position token from gimp
            Phrase p = new Phrase(s);          
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
