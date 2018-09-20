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
        private bool taxable = false;
        private double maxPercentOfNonTaxable = 0.0;
        public List<double> maxNonTaxable = null;
        
       public SalaryConditionals( bool taxable, float maxPercentOfNonTaxable, List<double> maxNonTaxable)
        {
            this.taxable = taxable;
            this.maxPercentOfNonTaxable = maxPercentOfNonTaxable;
            this.maxNonTaxable = maxNonTaxable;    

        }
 
        public void setmaxNonTaxable(double newMaxNonTaxable)
        {
            maxNonTaxable[0] = newMaxNonTaxable;         
        }

        public double TaxableIncome(double income,double salaryType, int index)
        {
            double result = 0.0;
            //Base case
            if (taxable == true)
            {
                result = AnyTaxableIncome(income, salaryType, index);
            }
            else
                result = 0.0;

            // if you dont use return statement at the last of a non-void function it will show error
            return result;           
        }
        private double AnyTaxableIncome(double income,double salaryType, int index)
        {
            double result = 0.0;
            //look at percentage formula
            double t = (income * maxPercentOfNonTaxable);

            //base case
            if (t == 0 && maxNonTaxable[index] == 0)
            {
                return salaryType; // condition of full taxable income
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
