using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetApp.Transaction;

namespace BudgetApp.Managers
{
    internal class TransactionManager : ITransactionItems
    {
        public void ListTransactions(Category category)
        {
            Console.WriteLine("Transactions in " + category.GetCategory());
            if (category.GetTransactionList().Count == 0)
            {
                Console.WriteLine("There are no transactions in this category");
            }
            else
            {
                Console.WriteLine();
                //For the specific category write the name
                Console.WriteLine("Category: " + category.GetCategory());
                //and the list
                foreach (Transactions t in category.GetTransactionList())
                {
                    t.Display();
                }
            }
        }
        public void ListOrderedTransactions(Category category)
        {
            //sorts all transactions per category in order of date
            var orderedTransactions = category.GetTransactionList().Where(t => t.GetCategory() == category)
                                             .OrderBy(t => t.GetTransactionDate());
            foreach (Transactions transaction in orderedTransactions)
            {
                transaction.Display();
            }
        }

        public bool AddTransaction(Category category, Transactions transaction)
        {
            // Check if a transaction with the same ID already exists
            if (category.GetTransactionList().Any(t => t.GetTransactionID() == transaction.GetTransactionID()))
            {
                Console.WriteLine("Error: Transaction with ID " + transaction.GetTransactionID() + " already exists in this category."); // Example logging
                return false;
            }

            category.GetTransactionList().Add(transaction);
            Console.WriteLine("Transaction successfully added!");
            return true;
        }

        public bool EditTransaction(Category category, Transactions transaction)
        {
            // We find the specified Transaction using List.FindIndex 
            int index = category.GetTransactionList().FindIndex(t => t.GetTransactionID().Equals(transaction.GetTransactionID()));

            if (index != -1)
            {
                Transactions updatedTransaction = new Transactions(
                    transaction.GetTransactionID(),
                    category.GetTransactionList()[index].GetTransactionName(),
                    transaction.GetTransactionValue(),
                    category.GetTransactionList()[index].GetTransactionDate(),
                    transaction.GetCategory(),
                    transaction.IsRecurring(),
                    transaction.RecurringObject()
                );

                // Replace the existing transaction in the list with the updated one
                category.GetTransactionList()[index] = updatedTransaction;

                return true;
            }
            else
            {
                Console.WriteLine("Error: This transaction does not exist!");
                return false;
            }
        }

        public bool DeleteTransaction(Category category, TransactionID transactionID)
        {
            // We find the specified TransactionID using List.FindIndex 
            int index = category.GetTransactionList().FindIndex(t => t.GetTransactionID().Equals(transactionID));

            if (index != -1)
            {
                category.GetTransactionList().RemoveAt(index);
                return true;
            }
            else
            {
                Console.WriteLine("Error: This transaction does not exist!");
                return false;
            }
        }
    }
}
