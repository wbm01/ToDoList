using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    internal class Study : Category
    {
        string study;
        public Study()
        {
            this.study = "Estudo";
        }

        public override string ToString()
        {
            return this.study;
        }
    }
}
