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
    
    public partial class Form1_Personal_info : Form
    {
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

        public static List<SalaryObject> list = new List<SalaryObject>();
        public Form1_Personal_info()
        {
            InitializeComponent();
        }

        private void Form1_Personal_info_Load(object sender, EventArgs e)
        {
            List<double> maxNonTaxable;
            for (int i = 0 ; i < data.Length-4 ; i++)
            {
                bool fullIncomeNonTaxable = Boolean.Parse(data[i]);
                bool fullIncomeTaxable = Boolean.Parse(data[++i]);
                float maxPercentOfNonTaxable = float.Parse(data[++i]);
                 maxNonTaxable = new List<double>();
                maxNonTaxable.Add(double.Parse(data[++i]));
       
                if (data[i+1] == ";")
                {
                    maxNonTaxable.Add(double.Parse(data[i+2]));
                    i+=2;
                   
                }

                SalaryObject salaryType = new SalaryObject(fullIncomeNonTaxable, fullIncomeTaxable, maxPercentOfNonTaxable, maxNonTaxable);
                list.Add(salaryType);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2_Salaries f = new Form2_Salaries();
            f.Show();
        }
    }
}
