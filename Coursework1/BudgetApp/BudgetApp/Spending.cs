using BudgetApp.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp
{
    internal class Spending
    {
        private double spendingValue;
        
        public Spending (double sValue)
        {
            spendingValue = sValue;
        }
        public double GetSpendingValue()
        {
            return spendingValue;
        }
        public void AddTransaction(double transactionValue)
        {
            spendingValue += transactionValue;
        }
        public void SetSpendingValue(double value)
        {
            spendingValue = value;
        }
    }
}
