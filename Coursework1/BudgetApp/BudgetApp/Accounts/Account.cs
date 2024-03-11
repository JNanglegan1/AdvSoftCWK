using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Accounts
{
    internal class Account
    {
        private int AccountCode;
        private string AccountName;

        public Account(int accountCode, string accountName)
        {
            AccountCode = accountCode;
            AccountName = accountName;
        }
        public int GetAccountCode()
        {
            return AccountCode;
        }
        public string GetAccountName()
        {
            return AccountName;
        }
    }
}
