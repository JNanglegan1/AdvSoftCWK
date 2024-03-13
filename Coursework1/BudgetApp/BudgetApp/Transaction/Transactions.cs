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
        private bool isRecurring;
        private RecurringTransaction recurringObject;
        public Transactions(TransactionID tID, string tName, double tValue, DateTime tDate, Category tCat, bool IsRecurring, RecurringTransaction? RecurringObject) 
        {
            transactionID = tID;
            transactionName = tName;
            transactionValue = tValue;
            transactionDate = tDate;
            category = tCat;
            isRecurring = IsRecurring;
            recurringObject = RecurringObject;
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
            return transactionDate; 
        }
        public Category GetCategory()
        {
            return category;
        }
        public bool IsRecurring()
        {
            return isRecurring;
        }
        public RecurringTransaction RecurringObject()
        {
            return recurringObject;
        }
        //Enum below: For MenuCatagories
        public enum TransactionType
        {
            Income,
            Expense,
            Null
        }

        public virtual void Display()
        {
            Console.WriteLine("#------------------------#");
            Console.WriteLine("ID: " + transactionID.GetTransactionID());
            Console.WriteLine("Name: " + transactionName);
            Console.WriteLine($"Price: { transactionValue: C2}");
            Console.WriteLine("Date of Transaction: " + transactionDate.ToString());
            if (isRecurring != true)
            {
                Console.WriteLine("This is not a recurring Transaction.");
                recurringObject.Display();
            }
            else
            {
                Console.WriteLine("This is a recurring Transaction.");
            }
        }
    }
}
