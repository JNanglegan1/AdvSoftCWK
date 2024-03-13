using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetApp.Transaction;
using BudgetApp.Accounts;
using static BudgetApp.Transaction.Transactions;
using BudgetApp.Managers;

namespace BudgetApp.Menu
{
    internal class MenuAddTransaction : IMenuItem
    {
        private MenuManager menuManager;
        private CategoryManager categoryManager;
        private TransactionManager transactionManager;

        public MenuAddTransaction(MenuManager menuManager, TransactionManager transactionManager, CategoryManager categoryManager)
        {
            this.menuManager = menuManager;
            this.transactionManager = transactionManager;
            this.categoryManager = categoryManager;
        }

        public int OptionNumber => 1;
        public string OptionName => "Add Transaction to a Category.";
        public void Action()
        {
            if (menuManager != null)
            {
                Console.Clear();
                Console.WriteLine("DEBUG: menuManager is not null");

                //This part returns an error
                string categoryName;
                Category category;
                do
                {
                    categoryManager.ListCategories();
                    Console.Write("Please select a Category: ");
                    categoryName = Console.ReadLine();
                    category = categoryManager.GetCategoryByName(categoryName);
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

                //This part of making a transaction can be set to null if the user chose "N"
                RecurringTransaction recurringObject;
                if (isRecurring != true)
                {
                    recurringObject = null;
                }
                else
                {
                    Console.WriteLine("Please type in a payment interval (once a week, once a month etc.): ");
                    string recurringInterval = Console.ReadLine();
                    DateTime nextTransactionDate;
                    while (true)
                    {
                        Console.WriteLine("Please type in the Next Transaction Date [dd/mm/yyyy]: "); ;
                        if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out nextTransactionDate)) { break; }
                        else { Console.WriteLine("Invalid input. Please type a date in format [dd/mm/yyyy]."); }
                    }
                    DateTime endTransactionDate;
                    while (true)
                    {
                        Console.WriteLine("Please type in the Final Transaction Date [dd/mm/yyyy]: "); ;
                        if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out endTransactionDate)) { break; }
                        else { Console.WriteLine("Invalid input. Please type a date in format [dd/mm/yyyy]."); }
                    }
                    recurringObject = new RecurringTransaction(recurringInterval, nextTransactionDate, endTransactionDate);
                }

                //Generates a new Transaction ID
                TransactionID transactionID = new TransactionID();

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
                    IncomeTransaction incomeTransaction = new IncomeTransaction(transactionID, transactionName, transactionValue, transactionDate, category, isRecurring, recurringObject, incomeType, incomePayer);
                    transactionManager.AddTransaction(category, incomeTransaction);
                }
                else if (transactionType == TransactionType.Expense)
                {
                    Console.Write("Please input the Expense type (): ");
                    string expenseType = Console.ReadLine();
                    Console.Write("Please input the Payee name: ");
                    string expensePayee = Console.ReadLine();
                    ExpenseTransaction expenseTransaction = new ExpenseTransaction(transactionID, transactionName, transactionValue, transactionDate, category, isRecurring, recurringObject, expenseType, expensePayee); 
                    transactionManager.AddTransaction(category, expenseTransaction);
                }
                else
                {
                    Console.WriteLine("Error: Transaction type not specified!");
                }
            }
            else
            {
                Console.WriteLine("Error: Menu manager is not initialized!");
            }
            Console.WriteLine("Press [ENTER] to continue to Menu");
            Console.ReadLine();
        }
    }
}