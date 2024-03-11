using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp
{
    internal class Spending
    {
        private Category spendingCategory;
        private double spendingValue;
        
        public Spending (Category sCat, double sValue)
        {
            spendingCategory = sCat;
            spendingValue = sValue;
        }
    }
}
