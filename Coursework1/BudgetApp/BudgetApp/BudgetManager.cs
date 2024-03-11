using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetApp.Transaction;
using BudgetApp.Accounts;
using System.Collections;

namespace BudgetApp
{
    internal class BudgetManager : IBudgetCalculations, IBudgetItems
    {
        //Our Lists: this is where all new transactions are stored
        List<Budget> budgetsList = new List<Budget>();
        List<Transactions> transactionsList = new List<Transactions> ();
        public List<Category> categories { get; private set; }
        public BudgetManager() 
        {
            //idk
        }

        public void AddBudget(Budget budget)
        {
            budgetsList.Add(budget);
        }

        public double CalculateRemainingBudget(Budget budget, Transactions transaction)
        {
            //Calculates the remaining budget
            double totalSpending = CalculateTotalSpendingForBudget(budget);
            return budget.GetBudgetValue() - totalSpending - transaction.GetTransactionValue();
        }

        private double CalculateTotalSpendingForBudget(Budget budget)
        {
            //Calculates the overall spending per category
            return transactionsList.Where(t => t.GetCategory() == budget.GetBudgetCategory())
                                  .Sum(t => t.GetTransactionValue());
        }

        public double CalculateTotalSpending()
        {
            return transactionsList.Sum(t => t.GetTransactionValue());
        }

        public void ListTransactions(Category category)
        {
            if (transactionsList.Count == 0)
            {
                Console.WriteLine("There are no transactions in this category");
            }
            else
            {
                Console.WriteLine();
                //For the specific category write the name
                Console.WriteLine("Category: " + category.GetCategory());
                //and the list
                foreach (Transactions t in transactionsList)
                {
                    t.Display();
                }
            }
        }
        public void ListOrderedTransactions(Category category)
        {
            //sorts all transactions per category in order of date
            var orderedTransactions = transactionsList.Where(t => t.GetCategory() == category)
                                             .OrderBy(t => t.GetTransactionDate());
            foreach (Transactions transaction in orderedTransactions)
            {
                transaction.Display();
            }
        }

        public bool AddTransaction(Transactions transaction)
        {
            if (transactionsList.Any(t => t.GetTransactionID() == transaction.GetTransactionID()))
            {
                return false; // ID already exists
            }

            transactionsList.Add(transaction);
            return true;
        }

        public bool EditTransaction(Transactions transaction)
        {
            // We find the specified Transaction using List.FindIndex 
            int index = transactionsList.FindIndex(t => t.GetTransactionID().Equals(transaction.GetTransactionID()));

            if (index != -1)
            {
                Transactions updatedTransaction = new Transactions(
                    transaction.GetTransactionID(),
                    transactionsList[index].GetTransactionName(),
                    transaction.GetTransactionValue(),
                    transactionsList[index].GetTransactionDate(),
                    transaction.GetCategory()
                );

                // Replace the existing transaction in the list with the updated one
                transactionsList[index] = updatedTransaction;

                return true;
            }
            else
            {
                Console.WriteLine("Error: This transaction does not exist!");
                return false;
            }
        }

        public bool DeleteTransaction(TransactionID transactionID)
        {
            // We find the specified TransactionID using List.FindIndex 
            int index = transactionsList.FindIndex(t => t.GetTransactionID().Equals(transactionID));

            if (index != -1)
            {
                transactionsList.RemoveAt(index);
                return true;
            }
            else
            {
                Console.WriteLine("Error: This transaction does not exist!");
                return false;
            }
        }

        public void ListCategories()
        {
            if (categories.Count == 0)
            {
                Console.WriteLine("There are no categories to list.");
            }
            else
            {
                Console.WriteLine("Available Categories:");
                foreach (Category category in categories)
                {
                    Console.WriteLine(category.GetCategory()); // Assuming a GetCategory() method exists in the Category class
                }
            }
        }
        public void AddCategory(Category category)
        {
            categories.Add(category);
        }
        public bool CategoryExists(string categoryName)
        {
            // Assuming categories is a List<Category>
            return categories.Any(category => category.GetCategory() == categoryName);
        }
        public Category GetCategoryByName(string categoryName)
        {
            Category category = categories.FirstOrDefault(c => c.GetCategory() == categoryName);
            if (category == null)
            {
                Console.WriteLine("Error: Category '{0}' does not exist. Please try again:", categoryName);
            }
            return category;
        }

        //Generate a report (flat-file in csv format)
        //Use streamwriter
    }
}
