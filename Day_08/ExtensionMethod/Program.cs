namespace ExtensionMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OldClass old= new OldClass();
            old.Method1();
            old.Method2();
            old.Method3();
            old.Method4(20);
            Console.WriteLine(old.Method5(2, 3));
            
        }
    }

    public class OldClass
    {
        public int x = 100;
        public void Method1()
        {
            Console.WriteLine("method 1 of old class " + x);
        }
        
        public void Method2()
        {
            Console.WriteLine("method 2 of old clas");
        }
    }
/*
    going for extension methods:
    step1: create a static class
    step2: define static metode in it. 
    step3: put old class reference in parameter list as first parameter following this keyword.
    
 */

    public static class NewClass
    {
        public static void Method3(this OldClass old)
        {
            Console.WriteLine("method 3 of new class");
        } 
        public static void Method4(this OldClass old, int y)
        {
            Console.WriteLine("method 3 of new class"+y);
        }
        public static int Method5(this OldClass old, int y, int z)
        {
            Console.WriteLine("method 5 of new class");
            return y + z;
        }
    }
}