using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Menu
{
    public interface IMenuItem
    {
        int OptionNumber { get; }
        string OptionName { get; }

        //This executes the menu action
        void Action();
    }
}
