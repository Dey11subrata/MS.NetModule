using System.Text.RegularExpressions;

namespace Assignment4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Hello, World!");*/
        }
    }

    public class CdacKh
    {
        // number of batches
        
        
        public Array Institute()
        {
            Console.WriteLine("Enter batches in number:");
            int  batch = int.Parse(Console.ReadLine());

            int student;
            decimal mark = decimal.Parse(Console.ReadLine());
            int[][][] ycp = new int[batch][][];
            for(int i=1; i<=batch; i++)
            {
                Console.WriteLine($"enter number of students in batch{i}:   ");
                student = int.Parse(Console.ReadLine());

                for(int j=1; j<=student; j++)
                {

                }
            }
        }
        
        
    }
}