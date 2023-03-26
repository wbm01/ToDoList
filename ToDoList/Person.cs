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


       public Person()
        {
            var temp = Guid.NewGuid();
            IdPerson = temp.ToString();
            SetName();
        }

        string SetName()
        {
            Console.WriteLine("Informe seu nome: ");
            string name = Console.ReadLine();
            return name;
        }

        public override string ToString()
        {
            return IdPerson + ";" + Name;
        }
    }
}
