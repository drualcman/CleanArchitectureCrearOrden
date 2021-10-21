using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Views
{
    public class ErrorConsoleView
    {
        readonly Exception Model;

        public ErrorConsoleView(Exception model) => Model = model;

        public void ExecuteResult()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: {Model.Message}");
            Console.ResetColor();
        }
    }
}
