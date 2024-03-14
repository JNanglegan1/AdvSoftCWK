using BudgetApp.Managers;
using BudgetApp.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BudgetApp.Transaction.Transactions;

namespace BudgetApp.Menu
{
    internal class Menu_DeleteTransaction : IMenuItem
    {
        private MenuManager menuManager;
        private CategoryManager categoryManager;
        private TransactionManager transactionManager;

        public Menu_DeleteTransaction(MenuManager menuManager, CategoryManager categoryManager, TransactionManager transactionManager)
        {
            this.menuManager = menuManager;
            this.categoryManager = categoryManager;
            this.transactionManager = transactionManager;
        }
        public int OptionNumber => 5;
        public string OptionName => "Delete Transaction.";
        public void Action()
        {
            Console.Clear();
            string categoryName;
            do
            {
                categoryManager.ListCategories();
                Console.WriteLine("Please select the Category you would like to view: ");
                categoryName = Console.ReadLine();
                if (!categoryManager.CategoryExists(categoryName))
                {
                    Console.WriteLine("Category not found. Please try again.");
                }
            } while (!categoryManager.CategoryExists(categoryName));
            Category category = categoryManager.GetCategoryByName(categoryName);

            int id;
            do
            {
                category.Display();
                Console.WriteLine("Please select the ID of the Transaction you would like to remove: ");
                id = Convert.ToInt32(Console.ReadLine());
                if (!transactionManager.TransactionExists(category, id))
                {
                    Console.WriteLine("Transaction not found. Please try again.");
                }
            } while (!transactionManager.TransactionExists(category, id));
            Transactions transaction = transactionManager.GetTransactionByID(category, id);

            //Don't forget to remove the spending info too  
            double newSpendingValue = category.GetSpending().GetSpendingValue();
            double transactionValue = transaction.GetTransactionValue();
            if (transaction.GetTransactionType() == TransactionType.Income)
            {
                newSpendingValue = category.GetSpending().GetSpendingValue() + transactionValue;
            }
            else
            {
                newSpendingValue = category.GetSpending().GetSpendingValue() - transactionValue;
            }
            category.GetSpending().SetSpendingValue(newSpendingValue);

            transactionManager.DeleteTransaction(category, transaction);
            Console.WriteLine("Transaction successfully removed.");
            Console.WriteLine("Please press [ENTER] to proceed to Main Menu.");
            Console.Read();
        }
    }
}
