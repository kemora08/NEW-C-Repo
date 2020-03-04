using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp
{
    class ItemRepository
    {
        public static ItemContext context = new ItemContext();

        //ItemRepositoryConstructor
        public ItemRepository()
        {
            context.Database.EnsureCreated();
        }

        public static void Add(string description)
        {
            ToDoItem toDoItem = new ToDoItem(description);
            context.Add(toDoItem);
            context.SaveChanges();
        }
        public List<ToDoItem> GetItems(string filterCmd)
        {
            List<ToDoItem> List = context.ToDoList.ToList();
            return List;
        }
        public void UpdateItem(int itemID, string Description, string Status)
        {
            ToDoItem UpdatedToDoItem = context.ToDoList.Where(x => x.ID == itemID).FirstOrDefault();

            if(Description != "")
            {
                UpdatedToDoItem.Description = Description;
            }

            if(Status != "")
            {
                UpdatedToDoItem.Status = Status;
            }

            context.Update(UpdatedToDoItem);
            context.SaveChanges();
        }
        public void DeleteItem(int ItemID)
        {
            ToDoItem DeleteItem = context.ToDoList.Where(x => x.ID == ItemID).FirstOrDefault();
            context.Remove(DeleteItem);
            context.SaveChanges();
        }

        internal void QuitProtocol()
        {
            throw new NotImplementedException();
        }

        internal static void AddItem(string newDesc)
        {
            throw new NotImplementedException();
        }

        internal bool ItemIDVerify(int delItemID)
        {
            throw new NotImplementedException();
        }
    }
}
