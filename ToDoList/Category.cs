using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    internal class Category
    {
        public string Importante { get; set; }
        public string Pessoal { get; set; }
        public string Profissional { get; set; }

        public Category()
        {

        }

        public string SetCategory()
        {
            Console.WriteLine("1-Importante\n2-Pessoal\n3-Profissional");
            Console.Write("Essa tarefa é: ");
            int c = int.Parse(Console.ReadLine());

            if (c == 1)
            {
                return Importante;
            }
            else
            {
                if (c == 2)
                {
                    return "Pessoal";
                }
                else
                {
                    return "Profissional";
                }
            }
        }
    }
}
