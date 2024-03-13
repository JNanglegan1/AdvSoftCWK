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

        public ExpenseTransaction (TransactionID tID, string tName, double tValue, DateTime tDate, Category tCat, bool isRecurring, RecurringTransaction? recurringObject, string eType, string ePayee) :
            base (tID, tName, tValue, tDate, tCat, isRecurring, recurringObject)
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
        public override void Display()
        {
            base.Display();
            Console.WriteLine("Expense Type: " + ExpenseType);
            Console.WriteLine("Payee: " + Payee);
            Console.WriteLine("#------------------------#");
        }
    }
}
