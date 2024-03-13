using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Managers
{
    internal class PrintManager
    {
        //Uses StreamWriter to print all transactions, budget and total spending for a specific Category to a text file
        public void GenerateTransactionReport(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("~~~Budget App~~~");
                //TO-DO
            }
        }
    }
}
