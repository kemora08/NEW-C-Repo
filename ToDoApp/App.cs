using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp
{
    internal class App
    {
        private ItemRepository Itemrepo;
        public ConsoleUtil ConsoleUtil;
        private string command;

        public App()
        {
            Itemrepo = new ItemRepository();
            ConsoleUtil = new ConsoleUtil();
        }
        private void DisplayAll()
        {
            string filterCmd = "All";

            List<ToDoItem> List = Itemrepo.GetItems(filterCmd);
            ConsoleUtil.PrintList(List);
        }
        private void DisplayFilter()
        {
            string filterCmd = "";
            string filter = ConsoleUtil.GetFilterType(filterCmd);

            switch (filter)
            {
                case "Complete":
                    List<ToDoItem> comList = Itemrepo.GetItems(filter);
                    ConsoleUtil.PrintList(comList);
                    break;

                case "Incomplete":
                    List<ToDoItem> incomList = Itemrepo.GetItems(filter);
                    ConsoleUtil.PrintList(incomList);
                    break;

                case "All":
                    List<ToDoItem> allList = Itemrepo.GetItems(filter);
                    ConsoleUtil.PrintList(allList);
                    break;

                default:
                    ConsoleUtil.BadFilter();
                    break;
            }
        }
        public void Start()
        {
            DisplayAll();
            string Command = ConsoleUtil.GetCommands();
            bool quit = false;
            bool update = false;
            string updateSelect = "";
            bool verifyID = true;
            bool verifyStat = true;

            while (!quit)
            {
                CommandValidate(command);
                if (CommandValidate(command) == false)
                {
                    ConsoleUtil.BadAction();
                }


                switch (command)
                {
                    case "Add":
                        update = true;
                        string newDesc = ConsoleUtil.GetDescription(update);
                        ItemRepository.AddItem(newDesc);
                        DisplayAll();
                        break;

                    case "Delete":
                        do
                        {
                            int delItemID = ConsoleUtil.GetItemID(command);
                            verifyID = Itemrepo.ItemIDVerify(delItemID);
                            if (verifyID == false)
                            {
                                DisplayAll();
                                ConsoleUtil.BadID();
                            }
                            else
                            {
                                Itemrepo.DeleteItem(delItemID);
                                DisplayAll();
                            }


                        } while (!verifyID);
                        DisplayAll();
                        break;

                    case "Update":
                        do
                        {
                            update = true;

                            int itemID = ConsoleUtil.GetItemID(command);

                            verifyID = Itemrepo.ItemIDVerify(itemID);
                            if (verifyID == false)
                            {
                                ConsoleUtil.BadID();
                            }
                            else
                            {
                                updateSelect = ConsoleUtil.UpdateSelect(itemID);

                                if (updateSelect == "description")
                                {
                                    bool statUpdate = false;

                                    newDesc = ConsoleUtil.GetDescription(update);

                                    string newStat = ConsoleUtil.GetStatus(statUpdate);

                                    Itemrepo.UpdateItem(itemID, newDesc, newStat);
                                }
                                else if (updateSelect == "status")
                                {
                                    do
                                    {
                                        bool descUpdate = false;

                                        string newStat = ConsoleUtil.GetStatus(update);

                                        verifyStat = StatusValidate(newStat);
                                        if (verifyStat == false)
                                        {

                                            ConsoleUtil.BadStatus();
                                        }
                                        else
                                        {
                                            newDesc = ConsoleUtil.GetDescription(descUpdate);
                                            Itemrepo.UpdateItem(itemID, newDesc, newStat);
                                        }
                                    } while (verifyStat == false);
                                }
                                else
                                {
                                    ConsoleUtil.BadAction();
                                    verifyID = false;
                                }
                            }

                        } while (!verifyID);

                        DisplayAll();
                        break;

                    case "Filter":
                        DisplayFilter();
                        break;

                    case "Quit":
                        Itemrepo.QuitProtocol();
                        quit = true;
                        break;
                }
                if (quit == true)
                {
                    ConsoleUtil.QuitMessage();
                }
                else
                {
                    command = ConsoleUtil.GetCommands();
                }

            }
        }
        public static bool CommandValidate(string command)
        {
            bool valid = false;
            if (command.ToLower() == "done" || command.ToLower() == "add" || command.ToLower() == "delete" || command.ToLower() == "update" ||
                command.ToLower() == "filter" || command.ToLower() == "quit")
            {
                valid = true;
            }
            return valid;
        }
        public static bool StatusValidate(string status)
        {
            bool valid = false;
            if (status.ToLower() == "complete" || status.ToLower() == "incomplete")
            {
                valid = true;
            }
            return valid;
        }

      

    }
}
