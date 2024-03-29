﻿using System;
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

        //If implemented, change the bool isRecurring to RecurringTransaction isRecurring
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

        //Setters
        public void SetInterval(string newInterval)
        {
            Interval = newInterval;
        }
        public void SetNextTransactionDate(DateTime ntdNew)
        {
            NextTransactionDate = ntdNew;
        }
        public void SetEndDate(DateTime endNew)
        {
            EndDate = endNew;
        }

        public void Display()
        {
            Console.WriteLine("#--- Recurring Transaction Info ---#");
            Console.WriteLine("Payment Interval: " + Interval);
            Console.WriteLine("Next Transaction Date: " + NextTransactionDate.ToString());
            Console.WriteLine("End Date: " + EndDate.ToString());
            Console.WriteLine("#------------------------#");
        }
        public void Stream(StreamWriter writer)
        {
            writer.WriteLine("#--- Recurring Transaction Info ---#");
            writer.WriteLine("Payment Interval: " + Interval);
            writer.WriteLine("Next Transaction Date: " + NextTransactionDate.ToString());
            writer.WriteLine("End Date: " + EndDate.ToString());
            writer.WriteLine("#------------------------#");
        }
    }
}
