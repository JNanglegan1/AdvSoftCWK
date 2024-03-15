using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Transaction
{
    internal class IncomeTransaction : Transactions
    {
        private string IncomeType;
        private string Payer;

        public IncomeTransaction(TransactionID tID, string tName, double tValue, DateTime tDate, Category tCat, bool isRecurring, RecurringTransaction? recurringObject, TransactionType transactionType, string iType, string iPayer) : 
            base ( tID, tName, tValue, tDate, tCat, isRecurring, recurringObject, transactionType)
        {
            IncomeType = iType;
            Payer = iPayer;

        }

        public string GetType()
        {
            return IncomeType;
        }
        public string GetPayer()
        {
            return Payer;
        }

        //Setters
        public void SetType(string newType)
        {
            IncomeType = newType;
        }
        public void SetPayer(string newPayer)
        {
            Payer = newPayer;
        }
        public override void Display()
        {
            base.Display();
            Console.WriteLine("Income Type: " + IncomeType);
            Console.WriteLine("Payer: " + Payer);
            Console.WriteLine("#------------------------#");
        }
        public override void Stream(StreamWriter writer)
        {
            base.Stream(writer);
            writer.WriteLine("Income Type: " + IncomeType);
            writer.WriteLine("Payer: " + Payer);
            writer.WriteLine("#------------------------#");
        }
    }
}
