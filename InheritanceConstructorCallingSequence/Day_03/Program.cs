namespace Day_03_ConstructorCallingSequence
{
    internal class Program
    {
        static void Main1()
        {
            /*Console.WriteLine("Hello, World!");*/
            Child child = new Child();
            child = new Child(13, 14); /*
                                        when no explicit call to parent constructor is made by default child constructor calls no arg constructor of parent
                                        */
        }
    }

    public class Parent
    {
       public  int i;
        public Parent() {
            i = 10;
            Console.WriteLine("no arg const of parent");
        }

        public Parent(int i)
        {
            this.i = i;
            Console.WriteLine("one arg const of parent");
        }
    }

    public class Child : Parent
    {
        int j;
        public Child()
        {
            j = 20;
            Console.WriteLine("no arg of child");
        }

        public Child(int i, int j) : base(i)
        {

            this.j = j;
            Console.WriteLine("two arg const of child");
        }
    }
}

namespace Day_03_OverloadingHidingOverriding
{
    internal class Program
    {
        static void Main()
        {

        }
    }

    public class Parent
    {
        public void Display1()
        {
            Console.WriteLine("display1 of parent");
        }

        public void Display2()
        {
            Console.WriteLine("display2 of parent");
        }

      /**/
    }
}