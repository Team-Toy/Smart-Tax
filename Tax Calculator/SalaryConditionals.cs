﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tax_Calculator
{

    public class SalaryConditionals
    {
        //private string salaryType = "";
        private bool fullIncomeNonTaxable = false;
        private bool fullIncomeTaxable = false;
        private List<double> maxNonTaxable = null;
        private double maxPercentOfNonTaxable = 0.0;
       public SalaryConditionals( bool fullIncomeNonTaxable, bool fullIncomeTaxable, float maxPercentOfNonTaxable, List<double> maxNonTaxable)
        {
           // this.salaryType = salaryType;
            this.fullIncomeNonTaxable = fullIncomeNonTaxable;
            this.fullIncomeTaxable = fullIncomeTaxable;
            this.maxNonTaxable = maxNonTaxable;
            this.maxPercentOfNonTaxable = maxPercentOfNonTaxable;

        }
        public double getMaxPercentOfNonTaxable()
        {
            return maxPercentOfNonTaxable;
        }
        public void setmaxNonTaxable(List<double> maxNonTaxable)
        {
            this.maxNonTaxable = maxNonTaxable;
        }
        public double TaxableIncome(double income, int index)
        {
            double result = 0.0;
            //Base case
            if (fullIncomeNonTaxable == true)
            {
                return 0.0; // exit point
            }           
            else if (fullIncomeNonTaxable == false && fullIncomeTaxable == true)
            {
                result = income;
            }
                
            else if (fullIncomeNonTaxable == false && fullIncomeTaxable == false)
            {
                result = ConditionalTaxableIncome(income, index);
            }

            // if you dont use return statement at the last of a non-void function it will show error
            return result;           
        }
        private double ConditionalTaxableIncome(double income, int index)
        {
            //look at percentage formula
            double t = (income * maxPercentOfNonTaxable)/100.0;
            double result = 0.0;

            //base case
            if (t == 0 && maxNonTaxable[index] == 0)
            {
                return 0.0; // exit point
            }                
            else if (t != 0 && maxNonTaxable[index] != 0)
            {
                if (maxNonTaxable[index] < t)
                    result = (income - maxNonTaxable[index]);
                else if (t <= maxNonTaxable[index])
                    result = (income - t);
            }
            else if (t == 0)
            {
                result = (income - maxNonTaxable[index]);
            }
            //if maxNontaxable = 0
            else
                result = (income - t);

            // if you dont use return statement at the last of a non-void function it will show error
            return result;
        }

    }
}
