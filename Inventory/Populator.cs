using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Populator
    {
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            for (int i = 5; i < 30; i++)
            {
                Console.WriteLine("INSERT INTO Item (Serial_Number, Model, Note, Employee_ID, Warehouse_ID)");
                Console.WriteLine("VALUES ('TestS/N" + i + "', 'Phone', 'This is test item " + i + "', 00001, null)" +
                    "\n");
            }
            
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
