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

    public partial class Form2_Salaries : Form
    {
        public static List<SalaryConditionals> list = new List<SalaryConditionals>();
        private string[] data = {"false","true","0","0",
                               "false","true","0","0",
                               "false","true","0","0",
                                "false","false","0.05","30000",
                                "false","false","0.5","25000",
                                 "false","false","0.01","120000",";","1000000",
                                "false","true","0","0",
                                "false","true","0","0",
                                 "false","true","0","0",
                                 "false","true","0","0",
                                 "false","true","0","0",
                                 "false","true","0","0",
                                 "false","false","0.145","0",
                                 "false","false","0.05","60000",
                                 "false","false","0.25","0",
                                 "false","true","0","0"
                                };
        public Form2_Salaries()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            List<double> maxNonTaxable;
            for (int i = 0; i < data.Length - 4; i++)
            {
                bool fullIncomeNonTaxable = Boolean.Parse(data[i]);
                bool fullIncomeTaxable = Boolean.Parse(data[++i]);
                float maxPercentOfNonTaxable = float.Parse(data[++i]);
                maxNonTaxable = new List<double>();
                maxNonTaxable.Add(double.Parse(data[++i]));

                if (data[i + 1] == ";")
                {
                    maxNonTaxable.Add(double.Parse(data[i + 2]));
                    i += 2;

                }

                SalaryConditionals salaryType = new SalaryConditionals(fullIncomeNonTaxable, fullIncomeTaxable, maxPercentOfNonTaxable, maxNonTaxable);
                list.Add(salaryType);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3_InvestmentTaxCredit f = new Form3_InvestmentTaxCredit();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label57.Text = ""+list[0].TaxableIncome(double.Parse(textBox1.Text.ToString()),0);
        }
    }
}
