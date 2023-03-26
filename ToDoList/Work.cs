using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    internal class Work : Category
    {
        string work;
        public Work()
        {
            this.work = "Trabalho";
        }

        public override string ToString()
        {
            return this.work;
        }
    }
}
