using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp
{
    internal class Budget
    {
        private double budgetValue;

        public Budget(double val)
        {
            budgetValue = val;
        }

        public double GetBudgetValue()
        {
            return budgetValue;
        }

        public void SetBudgetValue(double val)
        {
            budgetValue = val;
        }
    }
}
