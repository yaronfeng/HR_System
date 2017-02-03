using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Common
{
    public class Calculator
    {
        public Calculator() {
        }
        /// <summary>
        /// 个调税计算
        /// </summary>
        /// <param name="taxAmount"></param>
        /// <returns></returns>
        public static decimal PersonalTax(decimal taxAmount)
        {
            decimal personalTax = 0;
           
            decimal tmpTax = (taxAmount - 3500m) * 0.05m;

            decimal[] personalTaxAll = { (0.6m * tmpTax) - 5 * 0, 2 * tmpTax - 5 * 21, 4 * tmpTax - 5 * 111, 5 * tmpTax - 5 * 201, 6 * tmpTax - 5 * 551, 7 * tmpTax - 5 * 1101, 9 * tmpTax - 5 * 2701 };
            personalTax = personalTaxAll.Max();
            personalTax = personalTax < 0 ? 0 : personalTax;
            return personalTax;
        }
    }
}
