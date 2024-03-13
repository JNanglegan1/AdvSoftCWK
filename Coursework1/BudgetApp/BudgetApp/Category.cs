using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetApp.Transaction;

namespace BudgetApp
{
    internal class Category
    {
        private string categoryName;
        private Budget catBudget;
        private Spending catSpending;
        private List<Transactions> catTransactionList = new List<Transactions>();
        public Category(string cName) 
        {
            categoryName = cName;
            catBudget = new Budget(0.00);
            catSpending = new Spending(0.00);
            catTransactionList = new List<Transactions>();
        }

        public string GetCategory()
        {
            return categoryName;
        }
        public List<Transactions> GetTransactionList()
        {
            return catTransactionList;
        }
        public Budget GetBudget()
        {
            return catBudget;
        }
        public Spending GetSpending()
        {
            return catSpending;
        }

        //-----------------------------//

        public void SetBudget(double budget)
        {
            catBudget.SetBudgetValue(budget);
        }
        public void SetSpending(double spending)
        {
            catSpending.SetSpendingValue(spending);
        }

        public void Display()
        {
            Console.WriteLine("#####################################");
            // Category
            Console.WriteLine($"Category Name: {categoryName}");
            Console.WriteLine("#####################################");
            // Budget
            if (catBudget != null)
            {
                Console.WriteLine($"Budget: {catBudget.GetBudgetValue():C2}");
            }

            // Spending
            if (catSpending != null)
            {
                Console.WriteLine($"Spending: {catSpending.GetSpendingValue():C2}");
            }
            Console.WriteLine("-------------------------------------------------");
            // Transactions
            if (catTransactionList.Count > 0)
            {
                Console.WriteLine("List of Transactions:");
                foreach (var transaction in catTransactionList)
                {
                    transaction.Display();
                }
            }
            else
            {
                Console.WriteLine("There are no transactions for this category right now.");
            }
            Console.WriteLine("-------------------------------------------------");
        }
    }
}
