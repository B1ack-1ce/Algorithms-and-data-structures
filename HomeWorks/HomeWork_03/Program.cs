using LinkedList;

class Program
{
    public static void Main(string[] args)
    {
        Random rnd = new Random();
        LinkedList.LinkedList<Employee> users = new LinkedList.LinkedList<Employee>();

        for (int i = 0; i < 6; i++)
        {
            users.AddFirst(new Employee((Names)rnd.Next(0, 5), rnd.Next(1, 11)));
        }
        System.Console.WriteLine("-----New Users-----");
        System.Console.WriteLine(users);

        users.Sort(new EmployeeNameComparator());
        System.Console.WriteLine("-----Sort-----");
        System.Console.WriteLine(users);

        // for (int i = 0; i < 3; i++)
        // {
        //     users.RemoveLast();
        // }
        // System.Console.WriteLine();
        // System.Console.WriteLine(users);

        System.Console.WriteLine("-----Reverse-----");
        users.Reverse();
        System.Console.WriteLine(users);
    }
}
