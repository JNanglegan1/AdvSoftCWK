using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetApp.Transaction;
using BudgetApp.Accounts;
using System.Collections;

namespace BudgetApp.Managers
{
    internal class BudgetManager : IBudgetCalculations
    {
        public void SetBudget(Category category, double addBudget)
        {
            //changes the default budget from £0.00 to a specifcied double
            category.SetBudget(addBudget);
        }

        public double CalculateRemainingBudget(Category category, Transactions transaction)
        {
            double totalSpending = category.GetTransactionList().Sum(t => t.GetTransactionValue());
            double budgetValue = category.GetBudget().GetBudgetValue();
            return budgetValue - totalSpending - transaction.GetTransactionValue();
        }
        public void CalculateTotalSpending(Category category)
        {
            //also sets our Spending object in the category from £0.00 to sum of all transactions
            double totalSpending = category.GetTransactionList().Sum(t => t.GetTransactionValue());
            category.GetSpending().SetSpendingValue(totalSpending);
        }
    }
}
