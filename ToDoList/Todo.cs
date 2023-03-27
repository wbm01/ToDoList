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
        private string id;

        public string Description { get; set; }
        public string Category { get; set; }

        public Person Owner { get; set; }

        public bool Status { get; set; }
        public DateTime Created { get; set; }
        public DateTime DueDate { get; set; }

        /*public ToDo(string description, string categoria)
        {
            var temp = Guid.NewGuid();
            id = temp.ToString();

            Description = description;
            Status = false;
            Category = categoria;
        }*/

        public ToDo(string description, string categoria)
        {
            var temp = Guid.NewGuid();
            id = temp.ToString();
            this.Description = description;
            this.Status = false;
            this.Owner = new Person();
            this.Created = new DateTime();
            this.DueDate = new DateTime();
            this.Category = categoria;
        }

            /*Console.Write(" Descrição da tarefa: ");
            string description;
            description = Console.ReadLine();
            this.Description = description;*/

            /*Category category = new();
            this.category = category.SetCategory();

            DateTime date = DateTime.Now;
            string formattedDate = date.ToString("dd/MM/yyyy HH:mm:ss");
            Console.WriteLine(" Essa tarefa foi criada em: " + formattedDate);
            this.Created = date;

            Console.WriteLine("Dia previsto de conclusão: ");
            int dia = int.Parse(Console.ReadLine());
            Console.WriteLine("Mês previsto de conclusão: ");
            int mes = int.Parse(Console.ReadLine());
            Console.WriteLine("Ano previsto de conclusão: ");
            int ano = int.Parse(Console.ReadLine());

            Console.WriteLine("Hora prevista de conclusão: ");
            int hora = int.Parse(Console.ReadLine());
            Console.WriteLine("Minuto previsto de conclusão: ");
            int min = int.Parse(Console.ReadLine());
            int seg = 0;

            DateTime dueDate = new DateTime(ano, mes, dia, hora, min, seg);
            this.DueDate = dueDate;
            Console.WriteLine(dueDate);

            Console.WriteLine("Essa tarefa está concluída? N- não  | S - sim");
            char answer = char.Parse(Console.ReadLine().ToUpper());
            bool status = this.Status;
            
            if(answer == 'N')
            {
                status = false;
            }
            else
                status = true;*/

            //incrementar outras variáveis

        public override string ToString()
        {
            return "\nId: " + id + "\nDescription: " + Description + "\nCategory: " + Category + "\nData de criação: " + Created + "\nPrevisão de conclusão: " + DueDate
                + "\nStatus: " + Status;
        }

        string ToFile()
        { //ver sobre o retorno da categoria
            return id + ";" + Description + ";" + Created + ";" + ";" + Created + ";" + Status;
        }

        //bool SetStatus()
        //{

        //}

        //Person SetPerson()
        //{

        //}
    }
}
