using System.ComponentModel;
using System.Net;
using Microsoft.VisualBasic;
using ToDoList;
using static System.Reflection.Metadata.BlobBuilder;

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

        string arquivotarefa = "tarefa.txt";
        string arquivopessoa = "pessoa.txt";

        List<ToDo> listatarefa = new List<ToDo>();
        List<Person> listaperson = new List<Person>();

        listatarefa = CarregarListaTarefa(arquivotarefa);
        listaperson = CarregarListaPessoa(arquivopessoa);

        Person CriarPerson()
        {
            Console.WriteLine("Digite o nome do usuário: ");
            string name = Console.ReadLine();

            Person person = new Person(name);

            return person;
        }



        ToDo CriarTarefa(Person person)
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


            ToDo todo = new ToDo(description, categoria, person);

            

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

        Person p = CriarPerson();
        listaperson.Add(p);
        listatarefa.Add(CriarTarefa(p));

        
       /* foreach(var item in listaperson)
        {
            Console.WriteLine(item.ToString());
        }*/

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

        void CriarArquivo(string s)
        {
            try
            {
                if (File.Exists(s))
                {
                    var temp = LerArquivo(s);
                    StreamWriter sw = new StreamWriter(s);
                    for (int i = 0; i < listatarefa.Count; i++)
                    {
                        sw.WriteLine(listatarefa[i].ToFile());
                    }
                    

                    sw.Close();
                }
                else
                {
                    StreamWriter sw = new(s);
                    for (int i = 0; i < listatarefa.Count; i++)
                    {
                        sw.WriteLine(listatarefa[i].ToFile());
                    }
                    sw.Close();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("ERRO: Não foi possível incluir as tarefas!");
            }
            finally
            {

                Thread.Sleep(1000);
                Console.WriteLine();
            }
        }

        string LerArquivo(string f)
        {

            string text = "";
            try
            {
                StreamReader sr = new StreamReader(f);
                text = sr.ReadToEnd();
                sr.Close();

            }
            catch (Exception)
            {
                Console.WriteLine("Lista vazia!");
            }
            return text;
        }

        List<ToDo> CarregarListaTarefa(string p)
        {
            if (File.Exists(p))
            {

                StreamReader sr = new StreamReader(p);

                string textContact = "";
                List<ToDo> listatarefa = new List<ToDo>();

                while ((textContact = sr.ReadLine()) != null)
                {
                    //var aux3 = textContact.Split(";");

                    /*ToDo todo = new ToDo();
                   

                    todo.id = aux3[0];
                    todo.Description = aux3[1];
                    todo.Category = aux3[2];
                    todo.Created = aux3[4];
                    todo.DueDate = aux3[5];*/

                    string[]aux4 = sr.ReadLine().Split(";");

                    Person person = new Person(p);

                    //string id = aux4[0];
                    string description = aux4[0];
                    string category = aux4[1];
                    //string created = aux4[3];
                    //string duedate = aux4[4];
                    person.Name = aux4[2].Split(";")[1];

                    //listatarefa.Add(new(id, description, category, created, duedate));

                    listatarefa.Add(new(description, category, person));

                }
                sr.Close();
                return listatarefa;
            }
            else
            {
                Console.WriteLine("Iniciando...");
                Thread.Sleep(1000);
                Console.Clear();

            }

            return listatarefa;

        }

        List<Person> CarregarListaPessoa(string p)
        {
            if (File.Exists(p))
            {

                StreamReader sr = new StreamReader(p);

                string textContact = "";
                List<ToDo> listatarefa = new List<ToDo>();

                while ((textContact = sr.ReadLine()) != null)
                {
                    //var aux3 = textContact.Split(";");

                    string[] aux5 = sr.ReadToEnd().Split(";");

                    string idperson = aux5[0];
                    string name = aux5[1];

                    listaperson.Add(new(idperson, name));

                }
                sr.Close();
                
            }
            else
            {
                Console.WriteLine("Iniciando...");
                Thread.Sleep(1000);
                Console.Clear();

            }

            return listaperson;

        }


    }

}