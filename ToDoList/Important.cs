using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    internal class Important : Category
    {
        string important;
        public Important()
        {
            this.important = "Importante";
        }

        public override string ToString()
        {
            return this.important;
        }
    }
}
