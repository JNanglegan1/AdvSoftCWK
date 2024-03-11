using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Transaction
{
    internal class RecurringTransaction
    {
        private string Interval;
        private DateTime NextTransactionDate;
        private DateTime EndDate;

        //public RecurringTransaction(TransactionID tID, string tName, double tValue, DateTime tDate, Category tCat, RecurringTransaction isRecurring, string interval, DateTime ntd, DateTime ed) :
        //    base (tID, tName, tValue, tDate, tCat, isRecurring)
        public RecurringTransaction(string interval, DateTime ntd, DateTime ed)
        {
            Interval = interval;
            NextTransactionDate = ntd;
            EndDate = ed;
        }

        public string GetInterval()
        {
            return Interval;
        }
        public DateTime GetNextTransactionDate()
        {
            return NextTransactionDate;
        }
        public DateTime GetEndDate()
        {
            return EndDate;
        }
        //public override void Display()
        public void Display()
        {
            //base.Display();
            Console.WriteLine("Payment Interval: " + Interval);
            Console.WriteLine("Next Transaction Date: " + NextTransactionDate.ToString());
            Console.WriteLine("End Date: " + EndDate.ToString());
            Console.WriteLine("#------------------------#");
        }
    }
}
