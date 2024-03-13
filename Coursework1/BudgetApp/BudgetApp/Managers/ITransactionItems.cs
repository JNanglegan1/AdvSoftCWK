using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetApp.Transaction;

namespace BudgetApp
{
    internal interface ITransactionItems
    {
        public void ListTransactions(Category category);
        public void ListOrderedTransactions (Category category);
        public bool AddTransaction(Category category, Transactions transaction);
        public bool EditTransaction(Category category, Transactions transaction);
        public bool DeleteTransaction(Category category, TransactionID transactionID);
    }
}
