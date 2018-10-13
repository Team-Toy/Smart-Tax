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
        
       public SalaryConditionals( bool taxable, double maxPercentOfNonTaxable, List<double> maxNonTaxable)
        {
            this.taxable = taxable;
            this.maxPercentOfNonTaxable = maxPercentOfNonTaxable;
            this.maxNonTaxable = maxNonTaxable;    

        }  
        public void setmaxNonTaxable(double newMaxNonTaxable)
        {
            maxNonTaxable[0] = newMaxNonTaxable;         
        }

        public double TaxableIncome(double income,int index)
        {
            double percentage = income * maxPercentOfNonTaxable;
            return Math.Max(percentage, maxNonTaxable[index]);
        }
        public double TaxableIncome(double income, double salaryType, int index)
        {
            double result = 0.0;
            //Base case
            if (taxable == true)
            {
                result = AnyTaxableIncome(income, salaryType, index);
            }
            //check if salaryType is non-taxable source
            else
                result = 0.0;   

            // if you dont use return statement at the last of a non-void function it will show error
            return result;
        }
        private double AnyTaxableIncome(double income, double salaryType, int index)
        {
            double result = 0.0;
            //look at percentage formula
            double t = (income * maxPercentOfNonTaxable);

            //base case
            if (t == 0 && maxNonTaxable[index] == 0)
            {
                return salaryType; // condition of full taxable income
            }
            else if (t != 0 && maxNonTaxable[index] != 0)   //make suring "percentage of basicPay" and "max no-taxable" are non-zero
            {
                if (maxNonTaxable[index] < t)   //checking max no-taxable is smaller than or not
                {
                    return HelperFunction1(salaryType, maxNonTaxable[index]);
                }

                else if (t <= maxNonTaxable[index])  //checking "percentage of basicPay" is smaller than or not
                {
                    return HelperFunction2(salaryType, t);
                }

            }
            else if (t == 0)    //check if percentage of basic_salary is not given
            {
                return HelperFunction1(salaryType, maxNonTaxable[index]);

            }
            //if maxNontaxable = 0
            else
            {
                return HelperFunction2(salaryType, t);
            }

            // if you dont use return statement at the last of a non-void function it will show error
            return result;
        }

        private double HelperFunction1(double salaryType, double maxNonTaxable)
        {
            double result = 0.0;
            if (salaryType > maxNonTaxable)   //if "salary income source" > "maximum range of non-taxable income"
                result=(salaryType - maxNonTaxable); // return result as taxable income
            else
                result= 0.0;       //here salary type is under the maxNonTaxable
            return result;
        }

        private double HelperFunction2(double salaryType, double t)
        {
          double result = 0.0;
            if (salaryType > t)
                result = (salaryType - t);
            else
                result = 0.0;
          return result;
        }
    }
}
