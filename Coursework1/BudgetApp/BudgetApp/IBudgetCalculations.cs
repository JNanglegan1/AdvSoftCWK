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
        public double CalculateRemainingBudget(Budget b, Transactions t);
        public double CalculateTotalSpending();
    }
}
