using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp
{
    class ConsoleUtils
    {
        public ConsoleUtils()
        {
        }

        public List<ToDoItem> PrintList(List<ToDoItem> ConsoleList)
        {
            Console.Clear();
            Console.WriteLine("-- My Print ToDoList --");
            foreach (ToDoItem item in ConsoleList)
            {
                Console.WriteLine($"{item.ID} | {item.Description} | {item.Status}");
            }
            Console.WriteLine();
            return ConsoleList;
        }
        public string GetCommands()
        {
            Console.WriteLine("Type the command in parenthesis you wish to do");
            Console.WriteLine("(Add) item | (Delete) item | (Update) item");
            Console.WriteLine("(Filter) list | (Quit) program");
            string action = Console.ReadLine();
            string UserCmd = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(action);

            return UserCmd;
        }
        public string UpdateSelect(int itemID)
        {
            Console.WriteLine("Choose to update Item's Description of Status");
            string select = Console.ReadLine().ToLower();

            return select;
        }
        public static string GetDescription(bool descUpdate)
        {
            if (descUpdate == true)
            {
                Console.WriteLine("Enter in description of task");
            }
            else
            {
                Console.WriteLine("Hit [Enter] to continue");
            }
            string userInput = Console.ReadLine();
            string status = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(userInput);
            return status;
        }
        public static int GetItemID(string option)
        {
            if (option.ToLower() == "update")
            {
                Console.WriteLine("Enter the ID of the item to delete");
            }
            else
            {
               
            }

            string userInput = Console.ReadLine();
            int itemID = int.Parse(userInput);

            return itemID;
        }
        public string GetFilterType(string filterCmd)
        {
            Console.WriteLine("Do you want to filter a list by ( | All | Complete | Incomplete |):");
            string filterInput = Console.ReadLine();
            string filterType = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(filterInput);
            return filterType;
        }
        public static void QuitMessage()
        {
            Console.Clear();
            Console.WriteLine("Exciting program, saving items");
            Console.WriteLine("Goodbye!");
        }
        public static void BadID()
        {
            Console.WriteLine();
            Console.WriteLine("You entered an invalid ID. Please try again.");
            Console.WriteLine();
        }
        public static void BadFilter()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("You have entered an invalid filter type. Please try again.");
            Console.WriteLine();
        }
        public static void BadAction()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("You have to entered an invalid action. Please try again.");
            Console.WriteLine();
        }

    }
}
