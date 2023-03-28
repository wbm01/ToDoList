using System;
using System.ComponentModel;
using System.Net;
using System.Reflection.Metadata;
using Microsoft.VisualBasic;
using ToDoList;
using static System.Reflection.Metadata.BlobBuilder;

internal class Program
{
    private static void Main(string[] args)
    {
        int user;
        bool escolha=false;

        string taskFile = "tarefa.txt";
        string personFile = "person.txt";

        List<ToDo> taskList = new List<ToDo>();
        List<Person> personList = new List<Person>();

        taskList = LoadTaskList(taskFile);
        personList = LoadPersonList(personFile);


        string name = "";
        Person currentPerson = new(name);

        if (personList.Count == 0)
        {
            currentPerson = CreatePerson();
            personList.Add(currentPerson);
            CreatePersonFile(personList, personFile);
        }
        else
        {
            while (escolha = true)
            {
                try
                {
                    Console.WriteLine("Bem-vindo(a)!");
                    Console.Write("\n(1)- Entrar com usuário existente;\n(2)- Criar novo usuário; \n\nSelecione a opção desejada: ");
                    user = int.Parse(Console.ReadLine());

                    if (user == 1)
                    {
                        foreach (var person in personList)
                        {
                            Console.WriteLine(person.ToString());
                        }
                        Console.Write("\nDigite o nome do usuário: ");

                        name = Console.ReadLine();

                        foreach (var pessoa in personList)
                        {
                            if (pessoa.Name.Equals(name))
                            {
                                currentPerson = pessoa;
                            }
                        }
                        //escolha = false;
                        break;
                    }
                    else if (user == 2)
                    {
                        currentPerson = CreatePerson();
                        personList.Add(currentPerson);
                        CreateTaskFile(taskList, personFile);
                        //escolha = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nDigite apenas o número da opção desejada!");
                        Thread.Sleep(1500);
                        Console.Clear();
                        escolha = true;
                    }
                }
                catch
                {
                    Console.WriteLine("\nDigite apenas o número da opção desejada!");
                    Thread.Sleep(1500);
                    Console.Clear();
                    escolha = true;
                }
            }
           
        }

        int op;
        do
        {
            op = Menu();

            switch (op)
            {
                case 1:  // add tarefa
                    taskList.Add(CreateTask(currentPerson));

                    break;

                case 2: //todas as tarefas
                    Console.Clear();

                    if(taskList.Count == 0)
                    {
                        Console.WriteLine("\nLista de tarefas vazia!");
                    }
                    else
                    {
                        foreach (var tarefa in taskList)
                        {
                            Console.WriteLine(tarefa.ToString());

                        }
                    }
                    Console.WriteLine("\nPressione qualquer tecla para retornar ao menu.");
                    Console.ReadKey();

                    break;

                case 3:// tarefas a concluir
                    Console.Clear();
                    foreach (var tarefa in taskList)
                    {
                        if (tarefa.Status == false)
                        {
                            Console.WriteLine(tarefa.ToString());
                            Console.WriteLine("\nDeseja finalizar essa tarefa? S - Sim | N - Não ");
                            char check = char.Parse(Console.ReadLine().ToUpper());

                            if (check == 'S')
                            {
                                tarefa.Status = true;
                            }
                        }
                    }
                    break;

                case 4:// tarefas concluídas
                    Console.Clear();
                    foreach (var tarefa in taskList)
                    {
                        if (tarefa.Status == true)
                        {
                            Console.WriteLine(tarefa.ToString());
                            Console.WriteLine("\nRefazer essa tarefa? S - Sim | N - Não ");
                            char check = char.Parse(Console.ReadLine().ToUpper());

                            if (check == 'S')
                            {
                                tarefa.Status = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nNão há tarefas disponíveis!");
                            Console.WriteLine("\nPressione qualquer tecla para retornar ao menu.");
                            Console.ReadKey();
                        }
                    }
                    break;

                case 5: //remover tarefa
                    Console.Clear();
                    foreach (var tarefa in taskList)
                    {
                        Console.WriteLine(tarefa);
                    }
                    taskList.Remove(DeleteTask());
                    Console.WriteLine("\nPressione qualquer tecla para retornar ao menu.");
                    Console.ReadKey();
                    break;

                case 6: //remover pessoa
                    Console.Clear();
                    foreach (var pessoa in personList)
                    {
                        Console.WriteLine(pessoa);
                    }
                    personList.Remove(DeletePerson());
                    Console.WriteLine("\nPressione qualquer tecla para retornar ao menu.");
                    Console.ReadKey();
                    break;

                case 7: // editar tarefa
                    foreach (var tarefa in taskList)
                    {
                        Console.WriteLine(tarefa);
                    }
                    Console.Write("\nDigite FIELMENTE uma parte da descrição da tarefa a alterada: ");
                    string aux = Console.ReadLine();

                    Console.WriteLine("\n1- Alterar a descrição da tarefa \n2- Alterar a data prevista de conclusão" +
                        "\n3- Alterar a categoria da tarefa");
                    Console.Write("\nDigite o número da opção que deseja alterar: ");
                    int aux2 = int.Parse(Console.ReadLine());

                    switch(aux2)
                        {
                        case 1:
                            foreach(var task in taskList)
                            {
                                if (task.Description.Contains(aux))
                                {
                                    Console.Write("\nInforme a nova descrição: ");
                                    string aux3 = Console.ReadLine();

                                    string retornodescricao = task.EditDescription(aux3);
                                }
                            }
                            break;

                            case 2:
                            foreach (var task in taskList)
                            {
                                if (task.Description.Contains(aux))
                                {
                                    Console.Write("\nDia previsto de conclusão: ");
                                    int dia = int.Parse(Console.ReadLine());
                                    Console.Write("\nMês previsto de conclusão: ");
                                    int mes = int.Parse(Console.ReadLine());
                                    Console.Write("\nAno previsto de conclusão: ");
                                    int ano = int.Parse(Console.ReadLine());

                                    Console.Write("\nHora prevista de conclusão: ");
                                    int hora = int.Parse(Console.ReadLine());
                                    Console.Write("\nMinuto previsto de conclusão: ");
                                    int min = int.Parse(Console.ReadLine());
                                    int seg = 0;

                                    DateTime dueDate = new DateTime(ano, mes, dia, hora, min, seg);
                                    var retornodataprevista = task.EditDueDate(dueDate);
                                }
                            }
                            break;

                            case 3:
                            foreach (var task in taskList)
                            {
                                if (task.Description.Contains(aux))
                                {
                                    var retornocategoria = task.EditCategory(SetCategory());
                                }
                            }
                            break;
                    }
                    break;

                case 8: // sair
                    CreateTaskFile(taskList, taskFile);
                    Console.WriteLine("Até mais! :)");
                    Thread.Sleep(1500);
                    break;

                default:
                    Console.WriteLine("\nDigite um item válido do menu.");
                    break;
            }
        } while (op != 8);


        // métodos:

        int Menu()
        {
            int menu;

            Console.Clear();
            Console.WriteLine(">>>> Menu Principal <<<<\n");
            Console.WriteLine("1- Adicionar tarefa");
            Console.WriteLine("2- Todas as tarefas");
            Console.WriteLine("3- Tarefas a concluir");
            Console.WriteLine("4- Tarefas concluídas");
            Console.WriteLine("5- Remover tarefa");
            Console.WriteLine("6- Remover pessoa");
            Console.WriteLine("7- Editar tarefa");
            Console.WriteLine("8- Gravar e Sair da execução...");

            try
            {
                Console.Write("\nSelecione a opção desejada: ");
                menu = int.Parse(Console.ReadLine());
            }

            catch
            {
                return '\n';
            }

            return menu;
        }
       
        Person CreatePerson()
        {
            Console.Write("\nDigite o nome do usuário: ");
            string name = Console.ReadLine();

            Person person = new Person(name);

            return person;
        }

        ToDo CreateTask(Person person)
        {
            try
            {
                Console.Clear();
                Console.Write("Descrição da tarefa: ");
                string description = Console.ReadLine();

                string categoria = SetCategory();

                ToDo todo = new ToDo(description, categoria, person);

                DateTime date = DateTime.Now;
                string formattedDate = date.ToString("dd/MM/yyyy HH:mm:ss");
                Console.WriteLine("\nEssa tarefa foi criada em: " + formattedDate);
                todo.Created = date;

                Console.Write("\nDia previsto de conclusão: ");
                int dia = int.Parse(Console.ReadLine());
                Console.Write("\nMês previsto de conclusão: ");
                int mes = int.Parse(Console.ReadLine());
                Console.Write("\nAno previsto de conclusão: ");
                int ano = int.Parse(Console.ReadLine());

                Console.Write("\nHora prevista de conclusão: ");
                int hora = int.Parse(Console.ReadLine());
                Console.Write("\nMinuto previsto de conclusão: ");
                int min = int.Parse(Console.ReadLine());
                int seg = 0;

                DateTime dueDate = new DateTime(ano, mes, dia, hora, min, seg);
                todo.DueDate = dueDate;

                return todo;
            }
            catch
            {
                Console.WriteLine("\nErro. Não foi possível gravar a tarefa :( ");
                Thread.Sleep(1500);
            }
            finally
            {
                Console.WriteLine("\nTarefa concluída com sucesso! S2");
                Thread.Sleep(1500);
            }
            return null;
        }

        string SetCategory()
        {
            Console.WriteLine("\n1-Importante\n2-Pessoal\n3-Profissional");
            Console.Write("\nEssa tarefa é: ");
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

        void CreateTaskFile(List<ToDo> l, string s)
        {
            try
            {
                if (File.Exists(s))
                {
                    var temp = ReadFile(s);
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
                Console.WriteLine("\nERRO: Não foi possível incluir as tarefas!");
            }
            finally
            {

                Thread.Sleep(1000);
                Console.WriteLine();
            }
        }

        void CreatePersonFile(List<Person> l, string s)
        {
            try
            {
                if (File.Exists(s))
                {
                    var temp = ReadFile(s);
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
                Console.WriteLine("\nERRO: Não foi possível incluir as tarefas!");
            }
            finally
            {

                Thread.Sleep(1000);
                Console.WriteLine();
            }
        }

        string ReadFile(string f)
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

        List<ToDo> LoadTaskList(string p)
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

                    ToDo td = new ToDo(description, category, person);

                    var aux = td.Created.ToString();
                    aux = aux4[3];

                    var aux2 = td.DueDate.ToString();
                    aux2 = aux4[4];

                    td.Owner.Name = aux4[5];



                    //person.Name = aux4[3].Split(";")[1];

                    taskList.Add(td);

                }
                sr.Close();
                return taskList;
            }
            else
            {
                Console.WriteLine("Iniciando...");
                Thread.Sleep(1000);
                Console.Clear();

            }

            return taskList;

        }

        List<Person> LoadPersonList(string p)
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


                    personList.Add(new(id, name));

                }
                sr.Close();
                return personList;
            }
            else
            {
                Console.WriteLine("Iniciando...");
                Thread.Sleep(1000);
                Console.Clear();

            }

            return personList;

        }

        ToDo DeleteTask()
        {
            try
            {
                Console.Write("\nDigite FIELMENTE uma parte da descrição da tarefa a ser removida: ");
                var n = Console.ReadLine();
                foreach (var tarefa in taskList)
                {
                    if (tarefa.Description.Contains(n))
                    {
                        return tarefa;
                    }
                }
            }
            catch
            {
                Console.WriteLine("\nTarefa não encontrada.");

            }
            finally
            {
                Console.WriteLine("\nTarefa deletada com sucesso! :)");
                Thread.Sleep(1500);
            }
            return null;
        }

        Person DeletePerson()
        {
            try
            {
                Console.Write("\nDigite o nome do usuário a ser removido: ");
                var n = Console.ReadLine();
                foreach (var pessoa in personList)
                {
                    if (personList.Count == 1)
                    {
                        Console.WriteLine("Impossível remover o único usuário!");
                        break;
                    }
                    else
                    {
                        if (pessoa.Name.Contains(n))
                        {
                            Console.WriteLine("\nUsuário deletado com sucesso! :)");
                            Thread.Sleep(1500);
                            return pessoa;
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("\nUsuário não encontrada.");

            }
            return null;
        }
    }
}