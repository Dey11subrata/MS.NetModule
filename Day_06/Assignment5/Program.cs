using System.Collections;

namespace Assignment5
{
    internal class Program
    {
        static int choice = 1;
        static void Menu()
        {
            Console.WriteLine("Enter 1 to add an employee:");
            Console.WriteLine("Enter 2 to search an employee:");
            Console.WriteLine("Enter 3 to display employee with highest salary:");
            Console.WriteLine("Enter 4 to display all employee:");
            Console.WriteLine("Enter 0 to Exit");
            choice = int.Parse(Console.ReadLine());
        }
        
        static void Main() {
            /*Console.WriteLine("Hello, World!");*/
         
          int eid;
         string ename;
         double esal;
            
            SortedList<int, Employee> list=new SortedList<int, Employee>();
            Menu();

            do
            {
                
                switch (choice)
                {
                    case 1:
                       
                        Console.WriteLine("enter emp no");
                        eid= int.Parse( Console.ReadLine());
                        Console.WriteLine("enter employee name");
                        ename= Console.ReadLine();
                        Console.WriteLine("enter salary of employee");
                        esal= double.Parse( Console.ReadLine());
                      
                        list.Add(eid, new Employee(eid, ename, esal));
                        // show menue
                        Menu();
                        
                        break;
                    case 2:
                        Console.WriteLine("enter employee number to search:");
                        int search=int.Parse(Console.ReadLine());
                        if (list.ContainsKey(search))
                        {
                            Console.WriteLine(list[search]);
                        }
                        Menu();
                        break;
                    case 3:
                        Console.WriteLine("employee with highest salary");
                        /*logic not entered*/
                        Menu();
                        break;
                    case 4:
                        Console.WriteLine("all the employees");
                      
                      /*logic not entered*/
                        break;
                        Menu();
                       default: Console.WriteLine("invalid choice");
                        Menu();
                        break;
                } 
                
            }while(choice != 0);

            
            // switch case
            
        }
    }

    public class Employee
    {
        private int empNo;
        public int EmpNo
        {
            get { return empNo; }
            set
            {
                if (value > 0)
                    empNo = value;

                else
                    Console.WriteLine("EmpNo must be greater than 0");
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }

        private double salary;
        public double Salary
        {
            get { return salary; }
            set
            {
                salary = value;
            }
        }
        // constructor

       public Employee(int EmpNo=0, string Name="employee", double Salary = 50000)
        {
            this.EmpNo = EmpNo;
            this.Name = Name;
            this.Salary = Salary;
        }
        public override string ToString()
        {
            return "empId:"+EmpNo+", name:"+Name+", salary:"+Salary;
        }
    }

}