using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetApp.Transaction;

namespace BudgetApp
{
    internal interface IBudgetItems
    {
        public void ListTransactions(Category category);
        public void ListOrderedTransactions (Category category);
        public bool AddTransaction(Transactions transaction);
        public bool EditTransaction(Transactions transaction);
        public bool DeleteTransaction(TransactionID transactionID);
    }
}
