namespace ArrayList
{
    internal class Program
    {
        static void Main(string[] args)
        {
          List<string> list = new List<string>();
            list.Add("souvick");
            list.Add("timy");
            list.Add("tushar");
            list.Add("subrata");

           /* foreach(string str in list)
            {
                Console.WriteLine(str);
            }*/

            list.ForEach(x => Console.WriteLine(x));
            Console.WriteLine(list.Contains("tushar"));
            Console.WriteLine(list.Contains("sri"));
            list.Remove("subrata");
            list.ForEach(x=>Console.WriteLine(x));
        }
    }
}