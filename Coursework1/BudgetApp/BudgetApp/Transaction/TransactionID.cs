using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Transaction
{
    internal class TransactionID
    {
        private string transactionID;

        public TransactionID(string transactionID)
        {
            this.transactionID = transactionID;
        }
        public string GetTransactionID()
        {
            return transactionID;
        }
    }
}
