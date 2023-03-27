using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    internal class Person
    {
        public string IdPerson;
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


        public string SetName()
        {

            Console.WriteLine("Digite o nome do usuário: ");
            string name = Console.ReadLine();
            this.Name = name;
            return name;
        }

        public string GetName()
        {
            return this.Name;
        }

        public override string ToString()
        {
            return IdPerson + ";" + Name;
        }
    }
}
