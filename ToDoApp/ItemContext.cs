using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp
{
    public class ToDoItem
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        //Constructor
        public ToDoItem(string iDescription)
        {
            this.Description = iDescription;
            this.Status = "Incomplete";
        }
    }
}
