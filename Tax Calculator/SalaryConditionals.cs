using System;
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
        public List<double> maxNonTaxable = null;
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
        public void setmaxNonTaxable(double newMaxNonTaxable)
        {
            //delete previous maxNonTaxable data
           // this.maxNonTaxable = null;
            maxNonTaxable[0] = newMaxNonTaxable;
           
        }
        //testing purpose
        public double getMaxNonTaxable()
        {
            return maxNonTaxable[0];
        }
        public double TaxableIncome(double income,double salaryType, int index)
        {
            double result = 0.0;
            //Base case
            if (fullIncomeNonTaxable == true)
            {
                return 0.0; // exit point
            }           
            else if (fullIncomeNonTaxable == false && fullIncomeTaxable == true)
            {
                result = salaryType;
            }
                
            else if (fullIncomeNonTaxable == false && fullIncomeTaxable == false)
            {
                result = ConditionalTaxableIncome(income, salaryType,index);
            }

            // if you dont use return statement at the last of a non-void function it will show error
            return result;           
        }
        private double ConditionalTaxableIncome(double income,double salaryType, int index)
        {
            //look at percentage formula
            double t = (income * maxPercentOfNonTaxable);
            double result = 0.0;

            //base case
            if (t == 0 && maxNonTaxable[index] == 0)
            {
                return 0.0; // exit point
            }                
            else if (t != 0 && maxNonTaxable[index] != 0)
            {
                if (maxNonTaxable[index] < t)
                {
                    if(salaryType > maxNonTaxable[index])
                        return (salaryType - maxNonTaxable[index]);
                    else
                        result = 0.0;       //here salary type is under the maxNonTaxable
                }
                    
                else if (t <= maxNonTaxable[index])
                {
                    if (salaryType > t)
                        return (salaryType - t);
                    else
                        return 0.0;      //here salary type is under the percent of basic salary
                }
                    
            }
            else if (t == 0)
            {
                if (salaryType > maxNonTaxable[index])
                    result= (salaryType - maxNonTaxable[index]);
                else
                    result = 0.0;

            }
            //if maxNontaxable = 0
            else
            {
                if (salaryType > t)
                    return (salaryType - t);
                else
                    return 0.0;
            }

            // if you dont use return statement at the last of a non-void function it will show error
            return result;
        }

    }
}
