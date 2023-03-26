using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace ToDoList
{
    internal class Todo
    {
        private string id;

        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime DueDate { get; set; }
        public bool Status { get; set; }

        public Todo(string description)
        {
            var temp = Guid.NewGuid();
            id = temp.ToString();

            this.Description = description;

            var date = new DateTime();
            date = DateTime.Now.ToUniversalTime();
            Console.WriteLine(date);

            Console.WriteLine("");

            //incrementar outras variáveis


        }

        public override string ToString()
        {
            return "Id: " + id + "Description: " + Description + "Category: "+ "Date Created: " + Created + "DateTime: " + DateTime.ToString()
                + "Status: " + Status;
        }

        string ToFile()
        { //ver sobre o retorno da categoria
            return id + ";" + Description + ";" + Created + ";" + DateTime.ToString() + Status;
        }

        bool SetStatus()
        {

        }

        Person SetPerson()
        {

        }
    }
}
