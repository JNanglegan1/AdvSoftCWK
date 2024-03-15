using BudgetApp.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Menu
{
    internal class Menu_PrintCategory : IMenuItem
    {
        private CategoryManager categoryManager;

        public Menu_PrintCategory(CategoryManager categoryManager)
        {
            this.categoryManager = categoryManager;
        }

        public int OptionNumber => 8;
        public string OptionName => "Print Category.";

        public void Action()
        {
            Console.Clear();

            string filePath = "BudgetInfo.txt";

            string categoryName;
            do
            {
                categoryManager.ListCategories();
                Console.Write("Please type the name of the Category you wish to print: ");
                categoryName = Console.ReadLine();
                if (!categoryManager.CategoryExists(categoryName))
                {
                    Console.WriteLine("Category not found. Please try again.");
                }
            } while (!categoryManager.CategoryExists(categoryName));
            Category category = categoryManager.GetCategoryByName(categoryName);

            category.Display();

            Console.WriteLine("Is this the category you would like to print?[Y/N]: ");
            string printChoice = Console.ReadLine().ToUpper();
            if (printChoice == "Y")
            {
                GenerateTransactionReport(category, filePath);
                Console.WriteLine("Category sucessfully printed!");
            }
            else
            {
                Console.WriteLine("Returning to menu...");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }
        public void GenerateTransactionReport(Category category, string filePath)
        {
            string projectFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string fullFilename = Path.Combine(projectFolder, filePath);
            Console.WriteLine("Report has been created to: " + fullFilename);

            using (StreamWriter writer = new StreamWriter(fullFilename))
            {
                writer.WriteLine("~~~Budget App~~~");
                writer.WriteLine("Category Report generated on " + DateTime.Now.ToString());
                writer.WriteLine("");
                //Print the chosen category.Display() 
                category.Stream(writer);
            }
        }
    }
}
