using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Managers
{
    internal class PrintManager
    {
        //Uses StreamWriter to print all transactions, budget and total spending for a specific Category to a text file
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
