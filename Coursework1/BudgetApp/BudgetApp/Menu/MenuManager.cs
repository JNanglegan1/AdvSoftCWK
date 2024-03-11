using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Menu
{
    public class MenuManager
    {
        private readonly List<IMenuItem> menuItems;

        public MenuManager(List<IMenuItem> menuItems)
        {
            this.menuItems = menuItems;
        }

        public void DisplayMenu()
        {
            Console.WriteLine("Please select an option:");
            foreach (var item in menuItems)
            {
                Console.WriteLine($"{item.OptionNumber}. {item.OptionName}");
            }
        }

        public IMenuItem GetSelectedOption()
        {
            int userInput;
            do
            {
                Console.Write("Enter your choice: ");
            } while (!int.TryParse(Console.ReadLine(), out userInput) || !IsValidChoice(userInput));

            return menuItems.FirstOrDefault(item => item.OptionNumber == userInput);
        }

        private bool IsValidChoice(int optionNumber)
        {
            return menuItems.Any(item => item.OptionNumber == optionNumber);
        }

        public void RunMenu()
        {
            DisplayMenu();
            var selectedItem = GetSelectedOption();
            if (selectedItem != null)
            {
                selectedItem.Action();
            }
        }
    }
    
}
