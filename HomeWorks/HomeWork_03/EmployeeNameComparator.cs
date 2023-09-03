namespace LinkedList{
    class EmployeeNameComparator : IComparer<Employee>
    {
        public int Compare(Employee? x, Employee? y)
        {
            return x.CompareTo(y);
        }
    }
}