using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Transaction
{
    internal class ExpenseTransaction : Transactions
    {
        private string ExpenseType;
        private string Payee;

        public ExpenseTransaction (TransactionID tID, string tName, double tValue, DateTime tDate, Category tCat, bool isRecurring, RecurringTransaction? recurringObject, TransactionType transactionType, string eType, string ePayee) :
            base (tID, tName, tValue, tDate, tCat, isRecurring, recurringObject, transactionType)
        {
            ExpenseType = eType;
            Payee = ePayee;
        }
        public string GetType()
        {
            return ExpenseType;
        }
        public string GetPayee()
        {
            return Payee;
        }
        //Setters
        public void SetType(string newType)
        {
            ExpenseType = newType;
        }
        public void SetPayee(string newPayer)
        {
            Payee = newPayer;
        }
        public override void Display()
        {
            base.Display();
            Console.WriteLine("Expense Type: " + ExpenseType);
            Console.WriteLine("Payee: " + Payee);
            Console.WriteLine("#------------------------#");
        }
        public override void Stream(StreamWriter writer)
        {
            base.Stream(writer);
            writer.WriteLine("Expense Type: " + ExpenseType);
            writer.WriteLine("Payee: " + Payee);
            writer.WriteLine("#------------------------#");
        }
    }
}
