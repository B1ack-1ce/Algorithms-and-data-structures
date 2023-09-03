using System.Collections;

namespace LinkedList{
    class Employee : IComparable<Employee>
    {
        private string name;
        private int age;
        public string Name {
            get => name;
            set => name = value;
        }

        public int Age{
            get => age;
            set => age = value;
        }

        public Employee(Names name, int age){
            Name = name.ToString();
            Age = age;
        }

        public override bool Equals(object? obj)
        {
            if(this == obj)
                return true;
            if(obj is Employee){
                Employee employee = (Employee)obj;
                if(employee.Equals(Name) && employee.Age == this.Age)
                    return true;
            }
            return false;
        }

        public override string ToString() => $"{Name} - {Age}";

        public int CompareTo(Employee other)
        {
            if(this.age < other.age){
                return -1;
            }
            else if(this.age > other.age){
                return 1;
            }
            else{
                return other.Name.CompareTo(Name);
            }
        }
    }
}