namespace Day_05
{
    internal class Program
    {
        static void Main1()
        {
            //Console.WriteLine("Hello, World!");
            int[] arr = new int[] { 10, 20, 30, 40, 50, 60 };

            /*printing data in 3 differernt ways*/
            //01.string concatination
            foreach(int i in arr)
            {
                Console.WriteLine("values are:"+i.ToString());
            }

            Console.WriteLine("---------------");
            //02.placeholder
            foreach (int i in arr)
            {
                Console.WriteLine("{0}value using placeholder: {0}", i);
            }
            Console.WriteLine("---------------");

            //03.using stringinterpollation
            foreach (int i in arr)
            {
                Console.WriteLine($"values using stringinterpollation: {i}");
            }

        }
    }

}


namespace inputFromUser
{
    internal class RealLine
    {
        public static void Main()
        {
            Console.WriteLine("enter your ");
            string name= Console.ReadLine();
            Console.WriteLine(name);
        }

    }
}