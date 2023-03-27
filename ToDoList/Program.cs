using System.ComponentModel;
using ToDoList;

internal class Program
{
    static int Menu()
        {
            int menu;

            Console.Clear();
            Console.WriteLine(">>>> Menu Principal <<<<");
            Console.WriteLine("1- Adicionar tarefa ");
            Console.WriteLine("2- tot Tarefas Importantes");
            Console.WriteLine("3- tot Tarefas de Trabalho");
            Console.WriteLine("4- tot Tarefas de Estudo");
            Console.WriteLine("5- tot Tarefas concluídas");
            Console.WriteLine("6- tot Tarefas a concluir");

            Console.WriteLine("?- Sair da execução");

            try
            {
                menu = int.Parse(Console.ReadLine());
            }

            catch
            {
                return '\n';
            }

            return menu;
        }
    private static void Main(string[] args)
    {

    

        List<ToDo> listatarefa = new List<ToDo>();
        List<Person> listaperson = new List<Person>();

        Person CriarPerson()
        {
            Console.WriteLine("Digite o nome do usuário: ");
            string name = Console.ReadLine();

            Person person = new Person(name);

            return person;
        }



        ToDo CriarTarefa()
        {
            Console.Write(" Descrição da tarefa: ");
            string description = Console.ReadLine();

            /*Console.WriteLine("Essa tarefa está concluída? N- não  | S - sim");
            char answer = char.Parse(Console.ReadLine().ToUpper());
            bool status;

            if (answer == 'N')
            {
                status = false;
            }
            else
            {
                status = true;
            }*/

            string categoria = SetCategory();


            ToDo todo = new ToDo(description, categoria);

            

            DateTime date = DateTime.Now;
            string formattedDate = date.ToString("dd/MM/yyyy HH:mm:ss");
            Console.WriteLine(" Essa tarefa foi criada em: " + formattedDate);
            todo.Created = date;

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
            todo.DueDate = dueDate;

            return todo;
        }

        listaperson.Add(CriarPerson());
        listatarefa.Add(CriarTarefa());

        
        foreach(var item in listaperson)
        {
            Console.WriteLine(item.ToString());
        }

        foreach(var item in listatarefa)
        {
            Console.WriteLine(item.ToString());
        }

        string SetCategory()
        {
            Console.WriteLine("1-Importante\n2-Pessoal\n3-Profissional");
            Console.Write("Essa tarefa é: ");
            int c = int.Parse(Console.ReadLine());

            if (c == 1)
            {
                return "Importante";
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