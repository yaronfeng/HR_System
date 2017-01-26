using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Calculator
    {
        public Calculator() {
        }
        public int PersonalTax(decimal taxAmount)
        {
            int personalTax = 0;
            if (taxAmount < 1500)
            {
                personalTax = 3;//3%
            }
            else if (taxAmount > 1500 && taxAmount < 4500)
            {
                personalTax = 10;
            }
            else if (taxAmount > 4500 && taxAmount < 9000)
            {
                personalTax = 20;
            }
            else if (taxAmount > 9000 && taxAmount < 35000)
            {
                personalTax = 25;
            }
            else if (taxAmount > 3500 && taxAmount < 55000)
            {
                personalTax = 30;
            }
            else if (taxAmount > 5500 && taxAmount < 80000)
            {
                personalTax = 35;
            }
            else
            {
                personalTax = 45;
            }


            return personalTax;
        }
    }
}
