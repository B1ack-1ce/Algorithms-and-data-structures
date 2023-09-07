namespace HashTable
{
    class Program
    {
        public static void Main(string[] args){
            HashMap<string, int> contacts = new HashMap<string, int>();
            System.Console.WriteLine("---------------");
            contacts.Put("Alex", 95);
            int first = contacts.Put("Alex", 85);
            System.Console.WriteLine(first);
            System.Console.WriteLine("--------------");
            int value = contacts.Get("Alex");
            System.Console.WriteLine(value);

            System.Console.WriteLine("---------------");
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                contacts.Put("User" + i, rnd.Next(0, 30));
            }
            foreach (HashMap<string, int>.Entity user in contacts){
                System.Console.WriteLine($"Name: {user.key} Number: {user.value}");
            }

            System.Console.WriteLine("---------------");
            int contact = contacts.Remove("Alex");
            System.Console.WriteLine(contact);

            System.Console.WriteLine("---------------");
            foreach (HashMap<string, int>.Entity user in contacts){
                System.Console.WriteLine($"Name: {user.key} Number: {user.value}");
            }

            System.Console.WriteLine("-------------");
            System.Console.WriteLine(contacts.Get("Bob"));

        }
    }
}
