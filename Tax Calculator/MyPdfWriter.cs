using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Windows.Forms;

namespace Tax_Calculator
{
    public class MyPdfWriter
    {
        /** The original PDF file. */
        public static string oldFile = Application.StartupPath + @"\File\income tax form.pdf";
        private const string myFont = "Arial";   //text Font name to print
        private const int fontSize = 9;       //text font size to print
        private const string fontName2 = "ZAPFDINGBATS";    //tick-mark supported font
        private const int fontSize2 = 11;       //tick-mark font size to print

        public MyPdfWriter()
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

                pdfWrite_Form1(ref stamper, ref reader);    //Personal_info form print
                pdfWrite_Form2(ref stamper, ref reader);    //salaries form print
                pdfWrite_Form3(ref stamper, ref reader);    //Investment-tax-credit form print
                pdfWrite_Form5(ref stamper, ref reader);    //statement-of-salary form print
                pdfWrite_Form4(ref stamper, ref reader);    //Expenses form print
                pdfWrite_Form6(ref stamper, ref reader);    //Asset and Liabilities form print
                pdfWrite_Page8(ref stamper, ref reader);    //last page of tex return form
                stamper.Close();
            }
        }


        private void pdfWrite_Form1(ref PdfStamper stamper, ref PdfReader reader)
        {
            int pageNo = 1;     //page = 1 is; Personal Info form
            PdfContentByte canvas = stamper.GetOverContent(pageNo);
            Form1_HelperFunction(ref canvas, ref reader);
        }
        private void pdfWrite_Form2(ref PdfStamper stamper, ref PdfReader reader)
        {
            int pageNo = 3;     //page = 3 is Salaries form
            PdfContentByte canvas = stamper.GetOverContent(pageNo);
            Form2_HelperFunction(ref canvas, ref reader);

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
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form1_Personal_info.pdfInputs[0], 181, 121); //print "Name of Assessee"

            //set "TIN" number positon x=106 , y =143
            float tempX = 106; 
            float tempY = 143;
            string s = Form1_Personal_info.pdfInputs[3];    //get "TIN" as a string 
                                                            //print "TIN" above the "Expense form"
            for (int i = 0; i < s.Length; i++)
            {
                if (i == 3 || i == 6)    //checking to jump additionally
                {
                    tempX += 18;     // jump with difference of x=18 to right hand side box
                }

                WriteStringOnPdf(ref canvas, ref reader, pageNo, s[i] + "", tempX, tempY);    //print each of TIN number one by one
                tempX += 18;    // jump with difference of x=18 to right hand side box
            }
            //print "Expense" form
            Form5_HelperFunction(ref canvas, ref reader);

            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form1_Personal_info.pdfInputs[0], 184, 642); //print "name of assessee" in Receipt of income tax return
            float x = 460;
            float y = 664;
            for (int index =4; index < 6; index++)
            {
                //print "Circle" and "Taxes Zone" one by one in Receipt of income tax return
                WriteStringOnPdf(ref canvas, ref reader, pageNo, Form1_Personal_info.pdfInputs[index], x, y);
                y += 22;
            }
            
            y = 642;//set y for print assessment year
            //print "Assessment year"  in Receipt of income tax return
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form1_Personal_info.pdfInputs[6], x, y);

            float tempX1 = 137;  //set "TIN" number positon x=137 , y =680
                                 //print "TIN" under the "Expense form"
            for (int i = 0; i < s.Length; i++)
            {
                if (i == 3 || i == 6)    //checking to jump R.H.S. additionally
                {
                    tempX1 += 16;    // jump with difference of x=16 to right hand side box
                }
                WriteStringOnPdf(ref canvas, ref reader, pageNo, s[i] + "", tempX1, 680);
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

        //print on page 5
        private void pdfWrite_Form6(ref PdfStamper stamper, ref PdfReader reader)
        {
            int pageNo = 5;     //page = 5 is  ;Asset and Liabilities form
            PdfContentByte canvas = stamper.GetOverContent(pageNo);

            //'''''''''''''''''''''print for "Name of Assessee and TIN number"

            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form1_Personal_info.pdfInputs[0], 180, 85); //print "Name of Assessee"

            float tempX = 104;  //set "TIN" number positon x=104 
            float tempY = 104;   //set "TIN" number positon  y = 104
            string s = Form1_Personal_info.pdfInputs[3];    //get "TIN" as a string 
                                                            //print "TIN" above the "Expense form"
            for (int i = 0; i < s.Length; i++)
            {
                if (i == 3 || i == 6)    //checking to jump additionally
                {
                    tempX += 14;     // jump with difference of x=16 to right hand side box
                }

                WriteStringOnPdf(ref canvas, ref reader, pageNo, s[i] + "", tempX, tempY);    //print each of TIN number one by one
                tempX += 13;    // jump with difference of x=16 to right hand side box
            }

            //..........................

            Form6_HelperFunction1(ref canvas, ref reader);  //print on page 5;Asset and Liabilities form

            pageNo = 6;     //page = 6 is  ;Asset and Liabilities form
            canvas = stamper.GetOverContent(pageNo);
            Form6_HelperFunction2(ref canvas, ref reader);

        }

        private void pdfWrite_Page8(ref PdfStamper stamper, ref PdfReader reader)
        {
            int pageNo = 8;
            float x = 233;
            float y = 644;
            PdfContentByte canvas = stamper.GetOverContent(pageNo);
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form4_SatementOfSalary.pdfInputs[11], x, y);    //Print "Total income" from "Statement of Salary" form
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form4_SatementOfSalary.pdfInputs[19], 410, 648);   //print "Tax paid" from "Statement of Salary" form(serial no 16:"total")
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form6_AssetAndLiabilities.pdfInputs[26], x, 666);   //print "Net Wealth of Assessee" from "Assets and Liabilities" form(serial no 12)
                                                                                                              //.....................................................
        }

        private void Form1_HelperFunction(ref PdfContentByte canvas, ref PdfReader reader)
        {
            int pageNo = 1;
           // string tickMark = "\u0033";

            WriteStringOnPdf(ref canvas, ref reader, fontName2, pageNo, Form1_Personal_info.tickMarks[0], 414, 409); //print "Resident" tickmark sign on pdf
            WriteStringOnPdf(ref canvas, ref reader, fontName2, pageNo, Form1_Personal_info.tickMarks[1], 488, 408); //print "Non-resident" tickmark sign on pdf
            int x = 182;
            int y = 436;
            WriteStringOnPdf(ref canvas, ref reader, fontName2, pageNo, Form1_Personal_info.tickMarks[2], x, y); //print "Individual" tickmark sign on pdf
            x = 224;
            WriteStringOnPdf(ref canvas, ref reader, fontName2, pageNo, Form1_Personal_info.tickMarks[3], x, y); //print "Firm" tickmark sign on pdf
            x = 347;
            WriteStringOnPdf(ref canvas, ref reader, fontName2, pageNo, Form1_Personal_info.tickMarks[4], x, y); //print "Association of person" tickmark sign on pdf
            x = 479;
            WriteStringOnPdf(ref canvas, ref reader, fontName2, pageNo, Form1_Personal_info.tickMarks[5], x, y); //print "Hindu undivied family" tickmark sign on pdf

            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form1_Personal_info.pdfInputs[0], 200, 283);    //Print "Name of Assessee"
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form1_Personal_info.pdfInputs[1], 210, 303);   //print "National ID no"
                                                                                                            //.....................................................
                                                                                                            //setting x and y position for "UTIN" number
            x = 191;
            y = 325;
            string s = Form1_Personal_info.pdfInputs[2];    //taking "UTIN" number       
                                                            //printing UTIN number
            for (int i = 0; i < s.Length; i++)
            {
                if (i == 3 || i == 6)  //checking to jump down additionally
                {
                    x += 22;   // jump almost line go left with difference of x = 21
                }
                WriteStringOnPdf(ref canvas, ref reader, pageNo, s[i] + "", x, y);  //print each of the UTIN number
                x += 22;
            }
            //...................................................
            //update x and y position for TIN number position
            x = 191;
            y = 351;
            string s2 = Form1_Personal_info.pdfInputs[3];
            //printing TIN number
            for (int i = 0; i < s2.Length; i++)
            {
                if (i == 3 || i == 6)  //checking to jump down additionally
                {
                    x += 22;   // jump almost line go left with difference of x = 21
                }
                WriteStringOnPdf(ref canvas, ref reader, pageNo, s2[i] + "", x, y);  //print each of the TIN number
                x += 22;
            }
            //...............................................

            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form1_Personal_info.pdfInputs[4], 147, 381);   //print "Circle"
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form1_Personal_info.pdfInputs[5], 350, 381);   //print "Taxes Zone"
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form1_Personal_info.pdfInputs[6], 181, 410);   //print "Assessment Year"
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form1_Personal_info.pdfInputs[7], 328, 460);   //print "Name of employer/Business"
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form1_Personal_info.pdfInputs[8], 353, 483);   //print "Wife of Husband name"
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form1_Personal_info.pdfInputs[9], 171, 508);   //print "Father name"
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form1_Personal_info.pdfInputs[10], 176, 532);   //print "Mother name"

            //...............................................................
            //update x and y position for Date of birth number print position
            x = 283;
            y = 562;
            string s3 = Form1_Personal_info.pdfInputs[11];
            //printing Date of birth 
            for (int i = 0; i < s3.Length; i++)
            {
                if (s3[i] == '/') continue;

                WriteStringOnPdf(ref canvas, ref reader, pageNo, s3[i] + "", x, y);  //print each of the Date of birth numbers
                x += 29;
            }
            //...............................................................

            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form1_Personal_info.pdfInputs[12], 199, 602);   //print "Present address"
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form1_Personal_info.pdfInputs[13], 225, 665);   //print "Permanent address"
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form1_Personal_info.pdfInputs[14], 225, 726);   //print "Telephone"
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form1_Personal_info.pdfInputs[15], 388, 726);   //print "Resident"
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form1_Personal_info.pdfInputs[16], 266, 748);   //print "VAT Registration" number

        }

        private void Form2_HelperFunction(ref PdfContentByte canvas, ref PdfReader reader)
        {

            //'''''''''''''''''''''print for "Name of Assessee and TIN number"
            int pageNo = 3;
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form1_Personal_info.pdfInputs[0], 180, 66); //print "Name of Assessee"

            float tempX = 101;  //set "TIN" number positon x=101 
            float tempY = 89;   //set "TIN" number positon  y =89
            string s = Form1_Personal_info.pdfInputs[3];    //get "TIN" as a string 
                                                            //print "TIN" above the "Expense form"
            for (int i = 0; i < s.Length; i++)
            {
                if (i == 3 || i == 6)    //checking to jump additionally
                {
                    tempX += 15;     // jump with difference of x=15 to right hand side box
                }

                WriteStringOnPdf(ref canvas, ref reader, pageNo, s[i] + "", tempX, tempY);    //print each of TIN number one by one
                tempX += 13;    // jump with difference of x=13 to right hand side box
            }

            //..........................

            //setting-up the X and Y coordinates of the document
            float x = 273;  //by default x increment left-right
            float y = 170;
            int startIndex = 0;
            int endIndex = 18;
            //print each "amount of income" in "salaried" form(page 3)
            Form2_HelperFunction1(ref canvas, ref reader, x, y, startIndex, endIndex);  
            

            //print amount of reduced house rent
            WriteStringOnPdf(ref canvas, ref reader, pageNo,Form2_Salaries.reducedHomeRent + "", 276, 476);    //print amount of reduced house rent

            x += 103;   //x coordinate right shift(column)
            startIndex = 18;
            endIndex = 36;
            //print each of "Exempted income" in "salaried" form(page 3)
            Form2_HelperFunction1(ref canvas, ref reader, x, y, startIndex, endIndex);


            x += 103;   //x coordinate right shift(column)
            startIndex = 36;
            endIndex = 54;
            //print each of "Net Taxable income" in "salaried" form
            Form2_HelperFunction1(ref canvas, ref reader, x, y, startIndex, endIndex); 
            Form2_HelperFunction2(ref canvas, ref reader);  //print "House property income"

        }

        private void Form2_HelperFunction2(ref PdfContentByte canvas, ref PdfReader reader)
        {
            int pageNo = 3;
            float x = 71;
            float y = 593;
            string descriptionOfPerperty = Form2_Salaries.pdfInputs2[0];

            WriteStringOnPdf(ref canvas, ref reader, pageNo, descriptionOfPerperty, x, y);    //location and description of property

            //WriteStringOnPdf(ref canvas, ref reader, pageNo, Form2_Salaries.pdfInputs2[0]., 71, 593);    //location and description of property
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form2_Salaries.pdfInputs2[1], 469, 593);   //print annual rental income

            var pageSize3 = reader.GetPageSize(pageNo);   //getting page size by giving page number=3   
            //set x and y position
            x = 374;
            y = 627;
            //printing House property income under "salaries" form 
            for (int i = 2; i < 9; i++)
            {
                string s = Form2_Salaries.pdfInputs2[i];
                if (i == 6)  //checking to jump down additionally
                {
                    y += 8;   // jump half line down with difference of x=8 
                }
                WriteStringOnPdf(ref canvas, ref reader, pageNo, s, x, y);   //printing "House property income" from "annual rental income" to "others, if any"
                y += 17;    // jump one line down with difference of x=17 .          
            }

            x = 469;
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form2_Salaries.pdfInputs2[9], x, y);  //printing total "House property income"
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form2_Salaries.pdfInputs2[10], x, y + 17); //printing "Net income" from house
        }

        private void Form2_HelperFunction1(ref PdfContentByte canvas, ref PdfReader reader, float x, float y, int startIndex, int endIndex)
        {
            int pageNo = 3;
            var pageSize3 = reader.GetPageSize(pageNo);   //getting page size by giving page number=3 

            float tempY = y;    //set y positon
                                //printing "salaries" form
            for (; startIndex < endIndex - 5; startIndex++)
            {
                string s = Form2_Salaries.pdfInputs1[startIndex];   //get each of the salary amount
                WriteStringOnPdf(ref canvas, ref reader, pageNo, s, x, tempY);   //print from basicPay to "employer's contribution to recongnized provident fund"
                tempY += 17;    // jump one line down with difference of x=17
            }
            tempY += 17;    //jump one line shift down using difference of y =17
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form2_Salaries.pdfInputs1[startIndex], x, tempY);  //print interest accrued on recoginzed provient fund
            tempY += 17 * 2;  //jump two line shift down using difference of y =17
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
            int pageNo = 2;
            //setting-up the X and Y coordinates of the document
            float x = 453;   //by default x coordinate for "statement of income form"
            float y = 116;  //by default y increment top-down for "statement of income form"

            // printing "statement of income" entry
            for (int i = 0; i < 18; i++)
            {
                string s = Form4_SatementOfSalary.pdfInputs[i]; //getting each statement of salary info one by by
                if (i == 15 || i == 16 || i == 17) //checking to jump down additionally
                {
                    y += 11;    // jump half line down with difference of x=11
                }

                WriteStringOnPdf(ref canvas, ref reader, pageNo, s, x, y);   //print all entry "statement of income"
                y += 17;    // jump one line down with difference of x=17
            }

            y += 8; // jump half line down with difference of x=8
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form4_SatementOfSalary.pdfInputs[18], x, y);     //printing "Tax paid on the basis of this return (u/s 74)"
            y += 25;    // jump some lines down with difference of x=25
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form4_SatementOfSalary.pdfInputs[19], x, y);     //printing "Advance o Tax Refund (if any)"
            y += 22;    // jump almost one line down with difference of x=22
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form4_SatementOfSalary.pdfInputs[20], x, y);     //printing "Difference between serial no.15 and 16 (if any)"
            y += 17;    // jump one line down with difference of x=17
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form4_SatementOfSalary.pdfInputs[21], x, y);     //printing "Tax exempted and Tax free income"
            y += 17;    // jump one line down with difference of x=17
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form4_SatementOfSalary.pdfInputs[21], x, y);    //printing "Income tax paid in the last assessment year"
                                                                                                             //...........................................................................................................
                                                                                                             //Verfication part print
            x = 127;
            y = 636;
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form1_Personal_info.pdfInputs[0], x, y);   //print "Name of the Assessee" from "Personal info" form
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form1_Personal_info.pdfInputs[9], 371, y);   //print "Father name" from "Personal info" form

            //................................................
            //update only y position for TIN number position            
            y = 649;
            string TIN_number = Form1_Personal_info.pdfInputs[3];   //taking "TIN" number form "Personal info" form
                                                                    //printing TIN number
            for (int i = 0; i < TIN_number.Length; i++)
            {
                WriteStringOnPdf(ref canvas, ref reader, pageNo, TIN_number[i] + "", x, y);  //print each of the TIN number
                x += 8;
            }

            //.......................................................................
        }

        //print page=5; Statement of Assets and Liabilities 
        private void Form6_HelperFunction1(ref PdfContentByte canvas, ref PdfReader reader)
        {
            //setting-up the X and Y coordinates of the document
            float x = 401;   //by default x coordinate for "Asset and liabilities form"
            float y = 131;  //by default y increment top-down for "Asset and liabilities form"
            int pageNo = 5;
            int length = Form6_AssetAndLiabilities.pdfInputs.Length;
            //printing "Asset and Liabilities" form entry
            for (int i = 0; i < 2; i++)
            {
                string s = Form6_AssetAndLiabilities.pdfInputs[i];
                //print "Business Capital" and "Directors Shareholdings"  on page 5
                WriteStringOnPdf(ref canvas, ref reader, pageNo, s, x, y);   
                y += 17;   // jump half line down with difference of y=17
            }

            y = 232;    //set positions for "Non-agricultural property" and "Agicultral Property" 
            for (int i = 2; i < 4; i++)
            {
                string s = Form6_AssetAndLiabilities.pdfInputs[i];
                WriteStringOnPdf(ref canvas, ref reader, pageNo, s, x, y);   //print "Non-agricultural property" and "Agicultral Property" 
                y += 90;   // jump five lines down with difference of y=90
            }

            x = 321;    //set position x for "Investments"
            y = 429;    //set position y for "Investments"
            for (int i = 4; i < 9; i++)
            {
                string s = Form6_AssetAndLiabilities.pdfInputs[i];
                WriteStringOnPdf(ref canvas, ref reader, pageNo, s, x, y);   //print all "Investments" in "Asset and Liabilities" form
                y += 19;   // jump one line down with difference of y=19
            }
            //........................

            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form6_AssetAndLiabilities.pdfInputs[9], 397, 525);  //print "total investments"

            x = 320;    //set position x for "Motor vihicles"
            y = 566;    //set position y for "Motor vihicles"
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form6_AssetAndLiabilities.pdfInputs[10], x, y);   //print "Motor vihicles"
            y = 586;
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form6_AssetAndLiabilities.pdfInputs[11], x, y);   //print Jewellery
            y = 612;
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form6_AssetAndLiabilities.pdfInputs[12], x, y);   //print Furniture
            y = 626;
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form6_AssetAndLiabilities.pdfInputs[13], x, y);   //print Electronic Equipment


            x = 320;    //set position x for "Cash Asset Outside Business"
            y = 669;    //set position y for "Cash Asset Outside Business"
            for (int i = 14; i < 17; i++)
            {
                string s = Form6_AssetAndLiabilities.pdfInputs[i];
                WriteStringOnPdf(ref canvas, ref reader, pageNo, s, x, y);   //print each of "Cash Asset Outside Business"
                y += 19;   // jump one line down with difference of y=19
            }

            x = 397;    //set position x for "total" Cash Asset Outside Business
            y = 732;    //set position y for "total" Cash Asset Outside Business
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form6_AssetAndLiabilities.pdfInputs[17], x, y);   //print "total " Cash Asset Outside Business

        }

        //testing in page 6
        private void Form6_HelperFunction2(ref PdfContentByte canvas, ref PdfReader reader)
        {
            int pageNo = 6;
            //setting-up the X and Y coordinates of the document
            float x = 452;   //by default x coordinate for "statement of income form"
            float y = 130;  //by default y increment top-down for "statement of income form"

            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form6_AssetAndLiabilities.pdfInputs[18], x, 102);   //print "B/F" result

            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form6_AssetAndLiabilities.pdfInputs[19], x, y);   //print "Any other assets"
            y = 178;    //set position for "Less Liabilities"
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form6_AssetAndLiabilities.pdfInputs[20], x, y);   //print "total assets"

            x = 308;    //set position x for "total assets"
            y = 203;    //set position y for "total assets"
                        //printing "Less Liabilities" form entry
            for (int i = 21; i < 25; i++)
            {
                string s = Form6_AssetAndLiabilities.pdfInputs[i];

                WriteStringOnPdf(ref canvas, ref reader, pageNo, s, x, y);   //print each entries of "Less Liabilities"
                y += 19;   // jump one line down with difference of x=19
            }

            x = 452;    //position of x "total liabilties"
            y = 298;    //position of y "total liabilties"
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form6_AssetAndLiabilities.pdfInputs[25], x, y);   //print "total liabilties"

            y = 343;    //position of y "Net wealth " and "Accretion in wealth"
                        //printing "Net wealth " and "Accretion in wealth"
            for (int i = 26; i < 29; i++)
            {
                string s = Form6_AssetAndLiabilities.pdfInputs[i];

                WriteStringOnPdf(ref canvas, ref reader, pageNo, s, x, y);   //print each entries of "Less Liabilities"
                y += 21;   // jump one line down with difference of x=19
            }
            x = 452;
            y = 409;    //set position of y  for "Family expenditure"  
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form6_AssetAndLiabilities.pdfInputs[29], x, y);   //print each entries of "Number of dependent children"


            x = 116;    //set position of x  for "adult:
            y = 448;    //set position of y  for "adult
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form6_AssetAndLiabilities.pdfInputs[30], x, y);   //print entry of "adult"

            x = 208;   //set position of x  for "child"
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form6_AssetAndLiabilities.pdfInputs[31], x, y);   //print entry of "child"


            x = 452;    //set position of x  for "total Accretion of wealth"
            y = 486;    //set position of y  for "total Accretion of wealth"
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form6_AssetAndLiabilities.pdfInputs[32], x, y);   //print  "total Accretion of wealth"

            x = 308;    //position of x "Sources of fund"
            y = 518;    //position of y "Sources of fund"
             
            //printing "Sources of fund"
            for (int i = 33; i < 36; i++)
            {
                string s = Form6_AssetAndLiabilities.pdfInputs[i];

                WriteStringOnPdf(ref canvas, ref reader, pageNo, s, x, y);   //print each entries of "Sources of fund"
                y += 13;   // jump half line down with difference of y=13
            }


            x = 452;    //set position of x  for "total source of fund"
            y = 563;    //set position of y  for "total source of fund"
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form6_AssetAndLiabilities.pdfInputs[36], x, y);   //print "Total source of fund"
            y += 25;    //set position of y  for "Difference"
            WriteStringOnPdf(ref canvas, ref reader, pageNo, Form6_AssetAndLiabilities.pdfInputs[37], x, y);   //print "Difference"
        }

        //write a single string on existing pdf file 
        private void WriteStringOnPdf(ref PdfContentByte canvas, ref PdfReader reader, int pageNo, string s, float posX, float posY)
        {
            var pageSize = reader.GetPageSize(pageNo);  //"pageSize" = giving "pageNo"

            //making the y to increment top-Down
            posY = pageSize.Height - posY - 3;  //posY = position token from gimp
              //creating default font with font name ,size and font type BOLD
            iTextSharp.text.Font font = FontFactory.GetFont(myFont, fontSize,Font.BOLD);
            Phrase p = new Phrase(s, font);

            ColumnText.ShowTextAligned(canvas, Element.ALIGN_LEFT, p, posX, posY, 0);       //Here zero means "Rotation = 0" or  "no Rotation "
        }

        private void WriteStringOnPdf(ref PdfContentByte canvas, ref PdfReader reader,string fontName, int pageNo, string s, float posX, float posY)
        {
            var pageSize = reader.GetPageSize(pageNo);  //"pageSize" = giving "pageNo"

            //making the y to increment top-Down
            posY = pageSize.Height - posY - 3;  //posY = position token from gimp
                                                //creating default font with font name ,size and font type BOLD
                                                // iTextSharp.text.Font font = FontFactory.GetFont(myFont, fontSize, Font.BOLD);
                                                // iTextSharp.text.Font font = myfont;

            // Phrase p = new Phrase(new Chunk("\u0033", myfont));
            iTextSharp.text.Font font = FontFactory.GetFont(fontName, fontSize2);

            Phrase p = new Phrase(s, font);

            ColumnText.ShowTextAligned(canvas, Element.ALIGN_LEFT, p, posX, posY, 0);       //Here zero means "Rotation = 0" or  "no Rotation "
        }

    }
}
