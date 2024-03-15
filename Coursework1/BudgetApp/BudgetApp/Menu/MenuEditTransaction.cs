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
    internal class Menu_EditTransaction : IMenuItem
    {
        private CategoryManager categoryManager;
        private TransactionManager transactionManager;

        public Menu_EditTransaction(CategoryManager categoryManager, TransactionManager transactionManager)
        {
            this.categoryManager = categoryManager;
            this.transactionManager = transactionManager;
        }
        public int OptionNumber => 5;
        public string OptionName => "Edit Transaction.";
        public void Action()
        {
            Console.Clear();
            categoryManager.ListCategories();

            string categoryName;
            do
            {
                categoryManager.ListCategories();
                Console.Write("Please type the name of the Category you wish to view: ");
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
                Console.WriteLine("Please select the ID of the Transaction you would like to edit: ");
                id = Convert.ToInt32(Console.ReadLine());
                if (!transactionManager.TransactionExists(category, id))
                {
                    Console.WriteLine("Transaction not found. Please try again.");
                }
            } while (!transactionManager.TransactionExists(category, id));
            Transactions transaction = transactionManager.GetTransactionByID(category, id);


            string transactionName;
            double transactionValue;
            DateTime transactionDate;
            TransactionType newTransactionType;

            Console.Write("Please enter the new name for the transaction: ");
            transactionName = Console.ReadLine();
            Console.Write("Please enter the new value for the transaction: ");
            transactionValue = Convert.ToDouble(Console.ReadLine());

            DateTime newDate;
            while (true)
            {
                Console.WriteLine("Please type in the Next Transaction Date [dd/mm/yyyy]: "); ;
                if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out newDate)) { break; }
                else { Console.WriteLine("Invalid input. Please type a date in format [dd/mm/yyyy]."); }
            }


            string newTypeInput;
            do
            {
                Console.Write("Please enter the new transaction type (Income or Expense): ");
                newTypeInput = Console.ReadLine().ToLower();
                if (newTypeInput != "income" && newTypeInput != "expense")
                {
                    Console.WriteLine("Invalid transaction type. Please try again.");
                }
            } while (newTypeInput != "income" && newTypeInput != "expense");
            newTransactionType = newTypeInput == "income" ? TransactionType.Income : TransactionType.Income;



            transaction.SetTransactionName(transactionName);
            transaction.SetTransactionValue(transactionValue);
            transaction.SetTransactionDate(newDate);
            transaction.SetTransactionType(newTransactionType);

            //Remove old transaction-spending info
            double newSpendingValue = category.GetSpending().GetSpendingValue();
            double oldTransactionValue = transaction.GetTransactionValue();
            if (newTransactionType == TransactionType.Income)
            {
                newSpendingValue = category.GetSpending().GetSpendingValue() - oldTransactionValue;
            }
            else
            {
                newSpendingValue = category.GetSpending().GetSpendingValue() + oldTransactionValue;
            }
            category.GetSpending().SetSpendingValue(newSpendingValue);

            //Update transaction type info with new changes to spending
            double newSpending = 0;
            if (newTransactionType == TransactionType.Income)
            {
                Console.Write("Please input the new Income type (Payroll, One-off payment etc.): ");
                string incomeType = Console.ReadLine();
                ((IncomeTransaction)transaction).SetType(incomeType);

                Console.Write("Please input the new Payer name: ");
                string incomePayer = Console.ReadLine();
                ((IncomeTransaction)transaction).SetPayer(incomePayer);
                newSpending = category.GetSpending().GetSpendingValue() - transactionValue;
            }
            else if (newTransactionType == TransactionType.Expense)
            {
                Console.Write("Please input the new Expense type (): ");
                string expenseType = Console.ReadLine();
                ((ExpenseTransaction)transaction).SetType(expenseType);

                Console.Write("Please input the new Payee name: ");
                string expensePayee = Console.ReadLine();
                ((ExpenseTransaction)transaction).SetPayee(expensePayee);
                newSpending = category.GetSpending().GetSpendingValue() + transactionValue;
            }
            else
            {
                Console.WriteLine("Error: Transaction type not specified!");
            }
            category.GetSpending().SetSpendingValue(newSpending);


            Console.Write("Is the transaction recurring? (Y/N): ");
            string recurringInput = Console.ReadLine().ToUpper();
            bool isRecurring = recurringInput == "Y";

            if (isRecurring)
            {
                if (transaction.RecurringObject == null)
                {
                    Console.Write("Please type in a payment interval (once a week, once a month etc.): ");
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
                    RecurringTransaction recurringObject = new RecurringTransaction(recurringInterval, nextTransactionDate, endTransactionDate);
                    transaction.SetRecurringObject(recurringObject);
                }
                else
                {
                    Console.Write("Do you want to edit the recurring details? (Y/N): ");
                    string editRecurringDetails = Console.ReadLine().ToUpper();
                    if (editRecurringDetails == "Y")
                    {
                        Console.Write("Please type in a new payment interval (once a week, once a month etc.): ");
                        string recurringInterval = Console.ReadLine();
                        transaction.RecurringObject().SetInterval(recurringInterval);

                        DateTime nextTransactionDate;
                        while (true)
                        {
                            Console.WriteLine("Please type in the new Next Transaction Date [dd/mm/yyyy]: "); ;
                            if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out nextTransactionDate)) { break; }
                            else { Console.WriteLine("Invalid input. Please type a date in format [dd/mm/yyyy]."); }
                        }
                        transaction.RecurringObject().SetNextTransactionDate(nextTransactionDate);

                        DateTime endTransactionDate;
                        while (true)
                        {
                            Console.WriteLine("Please type in the new Final Transaction Date [dd/mm/yyyy]: ");
                            if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out endTransactionDate))
                            {
                                // Ensure EndDate is not before NextTransactionDate
                                if (endTransactionDate < nextTransactionDate)
                                {
                                    Console.WriteLine("Invalid input. End Date cannot be earlier than Next Transaction Date.");
                                }
                                else
                                {
                                    transaction.RecurringObject().SetEndDate(endTransactionDate);
                                    break;
                                }
                            }
                            else { Console.WriteLine("Invalid input. Please type a date in format [dd/mm/yyyy]."); }
                        }
                    }
                    else
                    {
                        transaction.SetIsRecurring(false); // Set recurring to false if user selects "N"
                        transaction.SetRecurringObject(null); // Clear recurring object
                    }

                    Console.WriteLine("Transaction successfully edited!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();

                }
            }
        }
    }
}
