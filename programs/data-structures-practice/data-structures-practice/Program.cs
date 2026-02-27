namespace data_structures_practice;
class HTable<T>
{
    // An array[5] of arrays[5] of resizable linked-list stacks with head and tail pointers 
    private Stack<T>[,] table;
    private int tablesize;
    //Contructors 
    public HTable(int size = 5)
    {
        tablesize = size;
        table = new Stack<T>[size, size];
    }
    /*Each element is inserted using a pair of hash functions to determine the index,
     being inserted at the start of the chosen stack*/
    private int[] HashElement(T input)
    {
        //Error Detection 
        
        //Function
        int[] output = new int[2];
        string inputString = input.ToString();
//UNFINISHED
        return output;
    }

    public void AddElement(T input)
    {
//UNFINISHED
    }

    public void RemoveElement(T input)
    {
//UNFINISHED
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
    }
}