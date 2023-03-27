using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace ToDoList
{
    internal class ToDo
    {
        public string id;

        public string Description { get; set; }
        public string Category { get; set; }

        public Person Owner { get; set; }

        public bool Status { get; set; }
        public DateTime Created { get; set; }
        public DateTime DueDate { get; set; }

        public ToDo(string description, string categoria, Person person)
        {
            var temp = Guid.NewGuid();
            id = temp.ToString();
            this.Description = description;
            this.Status = false;
            this.Owner = person;
            this.Created = new DateTime();
            this.DueDate = new DateTime();
            this.Category = categoria;
        }

        public override string ToString()
        {
            string x;
            if (!Status)
                x = "Tarefa não concluída.";
            else
                x = "Tarefa concluída.";

            return "\nId: " + id + "\nDescription: " + Description + "\nCategory: " + Category + "\nData de criação: " + Created + "\nPrevisão de conclusão: " + DueDate
                + "\nStatus: " + x + "\nNome do usuário: " + Owner.Name;
        }

        public string ToFile()
        {
            return id + ";" + Description + ";" + Category + ";" + Created + ";" + DueDate + ";" + Owner.Name;
        }

        public string EditDescription(string description)
        {
            this.Description = description;
            return description;
        }

        public DateTime EditDueDate(DateTime dueDate)
        {
            this.DueDate = dueDate;
            return dueDate;
        }

        public string EditCategory(string category)
        {
            this.Category = category;
            return category;
        }
    }
}
