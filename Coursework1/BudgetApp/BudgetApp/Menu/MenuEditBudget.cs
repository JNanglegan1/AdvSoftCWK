using BudgetApp.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Menu
{
    internal class Menu_EditBudget : IMenuItem
    {
        private CategoryManager categoryManager;

        public Menu_EditBudget(CategoryManager categoryManager)
        {
            this.categoryManager = categoryManager;
        }

        public int OptionNumber => 4;
        public string OptionName => "Edit Category."; //Renamed to Edit Category - might as well combine both into one menu option

        public void Action()
        {
            Console.Clear();

            // List all categories
            categoryManager.ListCategories();

            string categoryName;
            do
            {
                categoryManager.ListCategories();
                Console.Write("Please type the name of the Category you wish to edit: ");
                categoryName = Console.ReadLine();
                if (!categoryManager.CategoryExists(categoryName))
                {
                    Console.WriteLine("Category not found. Please try again.");
                }
            } while (!categoryManager.CategoryExists(categoryName));

            Category category = categoryManager.GetCategoryByName(categoryName);
            Console.WriteLine("What would you like to changer for this category?");
            Console.WriteLine("1. Edit Category Name.");
            Console.WriteLine("2. Edit Budget.");
            Console.WriteLine("3. Edit both.");
            Console.WriteLine("Please select an option: ");
            int editChoice;
            if (int.TryParse(Console.ReadLine(), out editChoice))
            {
                switch (editChoice)
                {
                    case 1:
                        EditCategoryName(category);
                        break;
                    case 2:
                        EditBudget(category);
                        break;
                    case 3:
                        EditCategoryName(category);
                        EditBudget(category);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }

        }

        //Split into seperate methods for each choice in Action() because it's cleaner
        private void EditCategoryName(Category category)
        {
            Console.WriteLine("Enter the new name for the category: ");
            string newName = Console.ReadLine();
            category.SetName(newName);
            Console.WriteLine("Category name successfully changed!");
        }

        private void EditBudget(Category category)
        {
            double newBudget;
            while (true)
            {
                Console.WriteLine("Enter the new budget for the category: ");
                if (double.TryParse(Console.ReadLine(), out newBudget))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
            category.SetBudget(newBudget);
            Console.WriteLine("Budget successfully updated!");
        }
    }
}
