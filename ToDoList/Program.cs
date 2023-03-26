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
        Person p = new Person();
        ToDo todo = new ToDo();
        Console.WriteLine(todo.ToString());
        

    }
}