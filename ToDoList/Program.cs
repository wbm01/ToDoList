using System.ComponentModel;
using System.Net;
using Microsoft.VisualBasic;
using ToDoList;
using static System.Reflection.Metadata.BlobBuilder;

internal class Program
{
    //static int Menu()
    //{
    //    int menu;

    //    Console.Clear();
    //    Console.WriteLine(">>>> Menu Principal <<<<");
    //    Console.WriteLine("1- Adicionar tarefa ");
    //    Console.WriteLine("2- Adicionar pessoa");
    //    Console.WriteLine("3- Total das Tarefas Importantes");
    //    Console.WriteLine("4- Total das Tarefas Pessoais");
    //    Console.WriteLine("5- Total das Tarefas Profissionais");

    //    Console.WriteLine("?- Sair da execução");

    //    try
    //    {
    //        menu = int.Parse(Console.ReadLine());
    //    }

    //    catch
    //    {
    //        return '\n';
    //    }

    //    return menu;
    //}
    private static void Main(string[] args)
    {

        string arquivotarefa = "tarefa.txt";
        string arquivopessoa = "pessoa.txt";

        List<ToDo> listatarefa = new List<ToDo>();
        List<Person> listaperson = new List<Person>();

        listatarefa = CarregarListaTarefa(arquivotarefa);
        listaperson = CarregarListaPessoa(arquivopessoa);


        string name = "";
        Person pessoaAtual = new(name);

        if (listaperson.Count == 0)
        {
            pessoaAtual = CriarPerson();
            listaperson.Add(pessoaAtual);
            CriarArquivoPessoa(listaperson, arquivopessoa);
        }
        else
        {
            Console.Write("1- Entrar com usuário existente\n2-Criar novo usuário \nDeseja utilizar usuário exitente ou criar um novo?");
            int user = int.Parse(Console.ReadLine());

            if (user == 1)
            {
                foreach (var pessoa in listaperson)
                {
                    Console.WriteLine(pessoa.ToString());
                }

                name = Console.ReadLine();

                foreach (var pessoa in listaperson)
                {
                    if (pessoa.Name.Equals(name))
                    {
                        pessoaAtual = pessoa;
                    }
                }

            }
            else
            {
                pessoaAtual = CriarPerson();
                listaperson.Add(pessoaAtual);
                CriarArquivoTarefa(listatarefa, arquivopessoa);
            }

            //foreach (var pessoa in listaperson)
            //{
            //    if (name == pessoa.Name)
            //    {

            //    }
            //}

        }
        int Menu()
        {
            int menu;

            Console.Clear();
            Console.WriteLine(">>>> Menu Principal <<<<");
            Console.WriteLine("1- Adicionar tarefa ");
            Console.WriteLine("2- Adicionar pessoa");
            Console.WriteLine("3- Total das Tarefas Importantes");
            Console.WriteLine("4- Total das Tarefas Pessoais");
            Console.WriteLine("5- Total das Tarefas Profissionais");

            Console.WriteLine("6- Gravar programa e sair da execução");

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
        int op;
        do
        {
            op = Menu();

            switch (op)
            {
                case 1:
                    listatarefa.Add(CriarTarefa(pessoaAtual));
                    break;

                case 2:
                    CriarPerson();
                    break;

                case 3:

                    break;

                case 4:

                    break;

                case 5:

                    break;

                case 6:
                    CriarArquivoTarefa(listatarefa,arquivotarefa);
                    Console.WriteLine("Até mais :)");
                    Thread.Sleep(1500);
                    break;

                default:
                    Console.WriteLine("Digite um item válido do menu.");
                    break;
            }
        } while (op != 6);




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

        void CriarArquivoTarefa(List<ToDo>l,string s)
        {
            try
            {
                if (File.Exists(s))
                {
                    var temp = LerArquivo(s);
                    StreamWriter sw = new StreamWriter(s);
                    for (int i = 0; i < l.Count; i++)
                    {
                        sw.WriteLine(l[i].ToFile());
                    }


                    sw.Close();
                }
                else
                {
                    StreamWriter sw = new(s);
                    for (int i = 0; i < l.Count; i++)
                    {
                        sw.WriteLine(l[i].ToFile());
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

        void CriarArquivoPessoa(List<Person> l, string s)
        {
            try
            {
                if (File.Exists(s))
                {
                    var temp = LerArquivo(s);
                    StreamWriter sw = new StreamWriter(s);
                    for (int i = 0; i < l.Count; i++)
                    {
                        sw.WriteLine(l[i].ToString());
                    }


                    sw.Close();
                }
                else
                {
                    StreamWriter sw = new(s);
                    for (int i = 0; i < l.Count; i++)
                    {
                        sw.WriteLine(l[i].ToString());
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

                string textToDo = "";
                List<ToDo> listatarefa = new List<ToDo>();

                while ((textToDo = sr.ReadLine()) != null)
                {

                    string[] aux4 = sr.ReadLine().Split(";");

                    Person person = new Person(p);

                    string description = aux4[0];
                    string category = aux4[1];
                    person.Name = aux4[2].Split(";")[1];

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

                string textToDo = "";
                List<ToDo> listatarefa = new List<ToDo>();

                while ((textToDo = sr.ReadLine()) != null)
                {
                    //var aux3 = textToDo.Split(";");

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