using System.Collections.Generic;

namespace Assignment5_b
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int eid;
            string ename;
            double esal;
            // Array of Employee Objects:

            Employee[] empArr = new Employee[3];
            for(int i=0; i<empArr.Length; i++)
            {
                Console.WriteLine("enter emp no");
                eid = int.Parse(Console.ReadLine());
                Console.WriteLine("enter employee name");
                ename = Console.ReadLine();
                Console.WriteLine("enter salary of employee");
                esal = double.Parse(Console.ReadLine());
                                
                empArr[i] = new Employee(eid, ename,esal);
            }
            List<Employee> list = new List<Employee>(empArr);
            list.ForEach(e => Console.WriteLine(e));
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

        public Employee(int EmpNo = 0, string Name = "employee", double Salary = 50000)
        {
            this.EmpNo = EmpNo;
            this.Name = Name;
            this.Salary = Salary;
        }
        public override string ToString()
        {
            return "empId:" + EmpNo + ", name:" + Name + ", salary:" + Salary;
        }
    }
}