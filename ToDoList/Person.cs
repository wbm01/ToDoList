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


        Person(string m)
        {
            var temp = Guid.NewGuid();
            IdPerson = temp.ToString();
            SetName(m);
        }

        Person SetName(string name)
        {
            Console.WriteLine("Informe seu nome: ");
            name = Console.ReadLine();
            return new Person(name);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
