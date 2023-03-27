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
            Console.Write("1- Entrar com usuário existente\n2-Criar novo usuário \n\nSelecione a opção desejada: ");
            int user = int.Parse(Console.ReadLine());

            if (user == 1)
            {
                foreach (var pessoa in listaperson)
                {
                    Console.WriteLine(pessoa.ToString());
                }
                Console.Write("\nDigite o nome do usuário: ");

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

        

        }
        int Menu()
        {
            int menu;

            Console.Clear();
            Console.WriteLine(">>>> Menu Principal <<<<");
            Console.WriteLine("1- Adicionar tarefa");
            Console.WriteLine("2 - Todas as tarefas");
            Console.WriteLine("3 - Tarefas a concluir");
            Console.WriteLine("4- Gravar programa e sair da execução");

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
                    foreach(var tarefa in listatarefa)
                    {
                        Console.WriteLine(tarefa.ToString());
                    }
                    Console.WriteLine("Pressione qualquer tecla para retornar ao menu.");
                    Console.ReadKey();
                    break;

                case 3:
                    foreach (var tarefa in listatarefa)
                    {
                        if(tarefa.Status == false)
                        {
                            Console.WriteLine(tarefa.ToString());
                            Console.WriteLine("Deseja finalizar essa tarefa? S - Sim | N - Não ");
                            char check = char.Parse(Console.ReadLine().ToUpper());

                            if(check == 'S')
                            {
                                tarefa.Status = true;
                            }
                        }
                    }
                    break;

                case 4:
                    CriarArquivoTarefa(listatarefa, arquivotarefa);
                    Console.WriteLine("Até mais :)");
                    Thread.Sleep(1500);
                    break;

               
                default:
                    Console.WriteLine("Digite um item válido do menu.");
                    break;
            }
        } while (op != 4);




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
                

                while ((textToDo = sr.ReadLine()) != null)
                {

                    var aux4 = textToDo.Split(";");

                    Person person = new Person(p);
                   
                    string id = aux4[0];
                    string description = aux4[1];
                    string category = aux4[2];

                    ToDo td = new ToDo(description,category,person);

                    var aux = td.Created.ToString();
                    aux = aux4[3];

                    var aux2 = td.DueDate.ToString();
                    aux2 = aux4[4];

                    td.Owner.Name = aux4[5];



                    //person.Name = aux4[3].Split(";")[1];

                    listatarefa.Add(td);

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


                while ((textToDo = sr.ReadLine()) != null)
                {

                    var aux4 = textToDo.Split(";");

                    

                    string id = aux4[0];
                    string name = aux4[1];
                    

                    listaperson.Add(new(id,name));

                }
                sr.Close();
                return listaperson;
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