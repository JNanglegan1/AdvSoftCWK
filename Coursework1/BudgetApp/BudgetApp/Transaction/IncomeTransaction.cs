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

        public IncomeTransaction(TransactionID tID, string tName, double tValue, DateTime tDate, Category tCat, string iType, string iPayer) : 
            base ( tID, tName, tValue, tDate, tCat) //, isRecurring)
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
        public override void Display()
        {
            base.Display();
            Console.WriteLine("Income Type: " + IncomeType);
            Console.WriteLine("Payer: " + Payer);
            Console.WriteLine("#------------------------#");
        }
    }
}
