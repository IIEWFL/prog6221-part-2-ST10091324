using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeMaker2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //creates an instance of our menu class and calls the displayMenu method to display the console application
            Menu menuObj = new Menu();
            menuObj.displayMenu();
        }
    }
}
