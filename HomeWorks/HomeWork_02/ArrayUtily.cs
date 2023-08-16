class ArrayUtily
{
    public static int[] CreateArray(int size){
        int[] arr = new int[size];

        Random rnd = new Random();

        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = rnd.Next(-30, 31);
        }

        return arr;
    }

    public static void PrintArr(int[] arr){
        System.Console.WriteLine(string.Join(" ", arr));
    }
}