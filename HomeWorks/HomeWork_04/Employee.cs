namespace HashTable
{
    class Employee
    {
        public string Name {get; set;}
        public int Age {get; set;}

        public Employee(string name, int age){
            Name = name;
            Age = age;
        }

        public override string ToString() => $"Name: {Name} Age: {Age}";
    }
}