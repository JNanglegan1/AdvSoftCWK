using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Transaction
{
    internal class Transactions
    {
        private TransactionID transactionID;
        private string transactionName;
        private double transactionValue;
        private DateTime transactionDate;
        private Category category;
        private RecurringTransaction isRecurring;
        public Transactions(TransactionID tID, string tName, double tValue, DateTime tDate, Category tCat) //, RecurringTransaction? tIsRecurring)
        {
            transactionID = tID;
            transactionName = tName;
            transactionValue = tValue;
            transactionDate = tDate;
            category = tCat;
            //isRecurring = tIsRecurring;
        }
        public TransactionID GetTransactionID()
        {
            return transactionID;
        }
        public string GetTransactionName()
        {
            return transactionName;
        }
        public double GetTransactionValue()
        {
            return transactionValue;
        }
        public DateTime GetTransactionDate()
        {
            return transactionDate; //TODO: need to convert datetime to string
        }
        public Category GetCategory()
        {
            return category;
        }
        //Enum below: For MenuCatagories
        public enum TransactionType
        {
            Income,
            Expense,
            Null
        }

        public virtual void Display() //may need to override for others
        {
            Console.WriteLine("#------------------------#");
            Console.WriteLine("Name: " + transactionName);
            Console.WriteLine("Price: " + transactionValue);
            Console.WriteLine("Date of Transaction: " + transactionDate.ToString());
        }
    }
}
