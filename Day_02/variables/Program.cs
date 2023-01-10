namespace variables
{
    internal class Program
    {
        static void Main1()
        {
            int i;//
            i = 0;
           // Console.WriteLine(i);

            Class1 obj;
            obj = new Class1();
            // obj.j = 20;// in accessible as it is a private member;
            // Console.WriteLine(obj.j);// in accessible as it is a private member;
            // use setj and getj functions to access data
            obj.setj(30);
            Console.WriteLine(obj.getj());


            // complete this operation- o.j = ++o.j + o.j++ - --o.j - o.j--;  --> use property

        }
    }

    // code to validate varirables or field
    public class Class1
    {
        public int i;
        private int j;

        // how to access j from class program --- use getter and setter

        public void setj(int val)
        {
            if (val < 100)
            { j = val; 
                Console.WriteLine("value set");
            }
            
            
            else
                Console.WriteLine("invalid j value entered must be less than 100");
                      
        }

        public int getj()
        {
            return j;
        }
    }
}

namespace Properties
{
    public class Program
    {
        static void Main()
        {
            Class_A a = new Class_A();
            a.I = 9; 
            Console.WriteLine(a.I);
            Console.WriteLine(a.Str);
            a.P5 = "automatic";
            Console.WriteLine(a.P5);
        }
    }

    public class Class_A
    {

        private int i;
        public int I // property
        {
            set
            {
                if (value < 19)
                {
                    i = value; // value is a keyword 
                }
                else
                    Console.WriteLine("invalid input");
            }

            get
            {
                return i;
            }
        }
        private String str;
        public string Str
        {
            get
            {
                return "read only";
            }
        }
        
        public string P5 { get; set; }
    }
}