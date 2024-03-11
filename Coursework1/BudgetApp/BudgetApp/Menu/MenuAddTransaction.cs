using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetApp;
using BudgetApp.Transaction;
using BudgetApp.Accounts;
using static BudgetApp.Transaction.Transactions;

namespace BudgetApp.Menu
{
    internal class MenuAddTransaction : IMenuItem
    {
        private BudgetManager budgetManager;

        public MenuAddTransaction(BudgetManager budgetManager)
        {
            this.budgetManager = budgetManager;
        }

        public int OptionNumber => 1;
        public string OptionName => "[1] Add Transaction to a Category.";
        public void Action()
        {
            if (budgetManager != null)
            {
                Console.WriteLine("Please select a Category: ");
                budgetManager.ListCategories();

                string categoryName;
                Category category;
                do
                {
                    categoryName = Console.ReadLine();
                    category = budgetManager.GetCategoryByName(categoryName);
                } while (category == null);


            Console.Write("Please select the transaction type [1]-Income [2]-Expense: ");
                string transactionTypeInput = Console.ReadLine();
                TransactionType transactionType;
                switch (transactionTypeInput)
                {
                    case "1":
                        transactionType = TransactionType.Income;
                        break;
                    case "2":
                        transactionType = TransactionType.Expense;
                        break;
                    default:
                        Console.WriteLine("Invalid transaction type. Please enter 1 or 2.");
                        transactionType = TransactionType.Null; 
                        transactionTypeInput = Console.ReadLine();
                        break;
                }

                string recurringTransactionInput;
                do
                {
                    Console.Write("Is your transaction a recurring one? [Y/N]: ");
                    recurringTransactionInput = Console.ReadLine().ToUpper(); // Read and convert to uppercase
                } while (recurringTransactionInput != "Y" && recurringTransactionInput != "N");
                bool isRecurring = recurringTransactionInput == "Y";


                Console.Write("Please input a unique transaction ID: ");
                string transactionID = Console.ReadLine();
                TransactionID inputtransactionID = new TransactionID(transactionID);

                Console.Write("Please input transaction name: ");
                string transactionName = Console.ReadLine();
                double transactionValue;
                while (true)
                {
                    Console.Write("Please input transaction value (must be a double!): ");
                    if (double.TryParse(Console.ReadLine(), out transactionValue)) { break; }
                    else { Console.WriteLine("Invalid input. Please type a double."); }
                }
                DateTime transactionDate;
                while (true)
                {
                    Console.Write("Please input the date the transaction was made [dd/mm/yyyy]: ");
                    if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out transactionDate)) { break; }
                    else { Console.WriteLine("Invalid input. Please type a date in format [dd/mm/yyyy]."); }
                }

                if (transactionType == TransactionType.Income)
                {
                    Console.Write("Please input the Income type (Payroll, One-off payment etc.): ");
                    string incomeType = Console.ReadLine();
                    Console.Write("Please input the Payer name: ");
                    string incomePayer = Console.ReadLine();
                    // Create Income object
                    IncomeTransaction incomeTransaction = new IncomeTransaction(inputtransactionID, transactionName, transactionValue, transactionDate, category, incomeType, incomePayer);
                    budgetManager.AddTransaction(incomeTransaction);
                }
                else if (transactionType == TransactionType.Expense)
                {
                    // Create Expense object
                    //ExpenseTransaction expenseTransaction = new ExpenseTransaction(transactionID, transactionName, transactionValue, transactionDate, isRecurring); // Assuming ExpenseTransaction constructor takes these parameters
                    //budgetManager.AddTransaction(expenseTransaction);
                }
                else
                {
                    Console.WriteLine("Error: Transaction type not specified!");
                }
            }
            else
            {
                Console.WriteLine("Error: Budget manager not initialized!");
            }
        }
    }
}