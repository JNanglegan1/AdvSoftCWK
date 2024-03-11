using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetApp.Transaction;

namespace BudgetApp
{
    internal class Category
    {
        private string categoryName;
        public Category(string cName) 
        {
            categoryName = cName;
        }

        public string GetCategory()
        {
            return categoryName;
        }
    }
}
