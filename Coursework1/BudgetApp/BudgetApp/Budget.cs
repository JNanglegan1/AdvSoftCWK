using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp
{
    internal class Budget
    {
        private Category budgetCategory;
        private double budgetValue;

        public Budget(Category cat, double val)
        {
            budgetCategory = cat;
            budgetValue = val;
        }

        public Category GetBudgetCategory()
        {
            return budgetCategory;
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
