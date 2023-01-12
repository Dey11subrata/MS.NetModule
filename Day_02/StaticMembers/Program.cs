namespace StaticMembers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Hello, World!");*/
            Test test = new Test();
            test.i = 100;
            Test.s_i = 50;
            test.display();
            test.P = 499;
            Console.WriteLine(test.P);
            /*test.Sp = 100; 
            Console.WriteLine(test.Sp);*/ // when make Sp a public property

            Test.s_i = 10;
            Test.s_display();
            Test.Sp= 10;
            Console.WriteLine(Test.Sp);
        }
    }

    public class Test
    {
        public int i;
        public static int s_i;

        public void display()
        {
            Console.WriteLine("display called");
            Console.WriteLine(i);
            Console.WriteLine(s_i);
        }

        public static void s_display()
        {
            Console.WriteLine("static display called");
           /* Console.WriteLine(new Test().i = 90); // assigning value to non-static variable how it is printing the value*/
            Console.WriteLine(s_i);
        }

        private int p;
        public int P
        {
            get
            {
                return p;
            }
            set
            {
                if (value <= 500)
                    p = value;
                else
                    Console.WriteLine("value more than 500");
            }
        }

        private static int sp;
        public static int Sp
        {
            get
            {
                return sp;
            }
            set
            {
                if (value >= 100)
                    sp = value;
                else
                    Console.WriteLine("value is less than 100");
            }
        }

        /* public  int Sp
         {
             get
             {
                 return sp;
             }
             set
             {
                 if (value >= 100)
                     sp = value;
                 else
                     Console.WriteLine("value is less than 100");
             }
         }*/

        /*constructors*/

      public  Test()
        {
            Console.WriteLine("no arg non static constructor of class Test called");
        }

        static Test()
        {
            Console.WriteLine("no arg static constructor of class Test called");
        }
    }
}
/*code for static class is not done yet*/