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
        public void DeleteTransaction(Category category, Transactions transaction);
        public bool TransactionExists(Category category, int transactionID);
        public Transactions GetTransactionByID(Category category, int transactionID);
    }
}
