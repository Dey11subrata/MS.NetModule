using System.Net.Http.Headers;

namespace Constructor1
{
    internal class Program
    {
        static void Main1()
        {
            //Console.WriteLine("Hello, World!");
            Constructor cons = new Constructor(10, 20, 30);
            Console.WriteLine(cons.i+"-"+cons.j+cons.k);

        }
    }

    public class Constructor
    {
        public int i { get; set; }
        public int j { get; set; }
        public int k { get; set; }

        public Constructor(int i, int j, int k)
        {
            this.i = i;
            this.j = j;
            this.k = k;
        }


    }
}

namespace Constructor
{
    internal class Program
    {
        static void Main()
        {
            //Console.WriteLine("Hello, World!");
            /*Constructor cons = new Constructor(10, 20, 30);*/
            Constructor cons = new Constructor() { i=10, j=20, k=300 };
            Constructor cons2 = new Constructor { i = 4, j = 5, k = 7 };

            Console.WriteLine(cons.i + "-" + cons.j + "-" + cons.k);
            Console.WriteLine(cons2.i + "-" + cons2.j + "-" + cons2.k);

        }
    }

    public class Constructor
    {
        public int i { get; set; }
        public int j { get; set; }
        public int k { get; set; }

       /* public Constructor(int i, int j, int k)
        {
            this.i = i;
            this.j = j;
            this.k = k;
        }*/


    }
}