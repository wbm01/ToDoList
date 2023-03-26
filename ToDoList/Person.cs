using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    internal class Person
    {
        private string IdPerson;
        public string Name { get; set; }


       public Person(string name)
        {
            var temp = Guid.NewGuid();
            IdPerson = temp.ToString();
            this.Name = name;
        }

        public Person(string id, string name)
        {
            this.IdPerson = id;
            this.Name = name;
        }

        public void SetName(string name)
        {
            
            this.Name = name;
        }

        public override string ToString()
        {
            return IdPerson + ";" + Name;
        }
    }
}
