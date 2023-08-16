class Program
{
    public static void Main(string[] args)
    {
        int[] arr = ArrayUtily.CreateArray(10);

        ArrayUtily.PrintArr(arr);

        Sorting.HeapSort(arr);

        ArrayUtily.PrintArr(arr);
    }

    
}
