using BudgetApp.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BudgetApp.Menu
{
    internal class Menu_AddNewCategory : IMenuItem
    {
        private CategoryManager categoryManager;
        //private BudgetManager budgetManager;
        public Menu_AddNewCategory(CategoryManager categoryManager)
        {
            this.categoryManager = categoryManager;
        }
        public int OptionNumber => 3;
        public string OptionName => "Add New Category.";
        public void Action()
        {
            Console.Clear();
            Console.Write("Please enter the name of your new Category: ");
            string categoryName = Console.ReadLine();
            Category newCategory = new Category(categoryName);
            Console.Write("Please enter the Budget Goal for " + categoryName + ": ");
            string newBudgetGoal = Console.ReadLine();
            double newBudget = Convert.ToDouble(newBudgetGoal);
            newCategory.SetBudget(newBudget);
            categoryManager.AddCategory(newCategory);
            Console.WriteLine("Category added successfully!");
            Console.WriteLine();
            newCategory.Display();
            Console.WriteLine("Please press [ENTER] to proceed to Main Menu.");
            Console.Read();
        }
    }
}
