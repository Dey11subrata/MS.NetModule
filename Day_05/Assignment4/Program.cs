namespace Assignment4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Hello, World!");*/
            Console.WriteLine("enter number of batches: ");
            int batch= int.Parse(Console.ReadLine());
            
           
            Student[][] studentArr = new Student[batch][];

            for(int i=0; i<batch; i++)
            {
                Console.WriteLine($"enter number of students in batchNo.{i+1}: ");
                int student = int.Parse(Console.ReadLine());
                for (int j = 0; j < student;j++)
                {
                    Console.WriteLine($"enter marks of student.{j}: ");
                    studentArr[j] = new Student().marks;
                }
            }
        }
    }

    public class Student
    {

      public  decimal marks;
        
    }
}