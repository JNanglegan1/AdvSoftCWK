using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Transaction
{
    internal class TransactionID
    {
        //private string transactionID;

        static int counter;
        private int transactionID;

        public TransactionID()
        {
            counter++;
            this.transactionID = counter;
        }
        public int GetTransactionID()
        {
            return transactionID;
        }
    }
}
