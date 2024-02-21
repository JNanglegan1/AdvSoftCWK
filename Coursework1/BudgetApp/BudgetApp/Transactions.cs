using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp
{
    internal class Transactions
    {
        private string transactionName;
        private double transactionValue;
        private DateTime transactionDate;
        public Transactions(string tName, double tValue, DateTime tDate) 
        {
            transactionName = tName;
            transactionValue = tValue;
            transactionDate = tDate;
        }

        //GetMethods
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

        public void Display() //may need to override
        {
            Console.WriteLine("" + transactionName);
            Console.WriteLine("Price:" + transactionValue);
            //Console.WriteLine("" + transactionDateTime);
        }
    }
}
