

namespace Disposible_Distructor_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Disposible disp = new Disposible();

            disp.Display();
            disp.Dispose();
        }
    }

    public class Disposible : IDisposable
    {
        public void Display()
        {
            Console.WriteLine("Display called...");
        }

        public void Dispose()
        {
            Console.WriteLine("Dispose called...");
            //throw new NotImplementedException();
        }
        ~Disposible() {
            Console.WriteLine("distructor called....");
        }
    }
}