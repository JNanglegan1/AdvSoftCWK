using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetApp.Transaction;

namespace BudgetApp
{
    internal interface IBudgetCalculations
    {
        public void SetBudget(Category category, double addBudget);
        public double CalculateRemainingBudget(Category category, Transactions transaction);
        public void CalculateTotalSpending(Category category);
    }
}
