

namespace Day_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Test Cases
            Employee o1 = new Employee("Amol", 123465, 10);
            Console.WriteLine(o1);
            Console.WriteLine("---------------------------");
            Employee o2 = new Employee("Amol", 123465);
            Console.WriteLine(o2);
            Console.WriteLine("---------------------------");
            Employee o3 = new Employee("Amol");
            Console.WriteLine(o3);
            Console.WriteLine("---------------------------");
            Employee o4 = new Employee();
            Console.WriteLine(o4);
            Console.WriteLine("---------------------------");

            // Printing employee numbers

            Console.WriteLine(o1.EmpNo);
            Console.WriteLine(o2.EmpNo);
            Console.WriteLine(o3.EmpNo);
            Console.WriteLine("---------------------------");
            Console.WriteLine(o3.EmpNo);
            Console.WriteLine(o2.EmpNo);
            Console.WriteLine(o1.EmpNo);

        }
    }

    public class Employee
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { 
                if(value!="")
                    name = value;
                else
                {
                    Console.WriteLine("no name provided");
                    name = "unknown";
                }
            }
        }
        static private int genEmpNo;
        private int empNo=0;
        public int EmpNo
        {
            set
            {
                empNo = value;
            }
            get { return empNo; }

        }
        
        private decimal basic;
        public decimal Basic
        {
            get { return basic; }
            set
            {
                if (value > 40000 && value < 150000)
                {
                    basic = value;
                }
                else
                {
                    Console.WriteLine("Basic must be between 40000 - 150000");
                basic = 4000;

                }
            }
        }
        private short deptNo;
        public short DeptNo
        {
            get { return deptNo; }
            set
            {
                if(value>0)
                    deptNo= value;
                else
                {
                    Console.WriteLine("dept must be greater than 0");
                    deptNo = 999;
                }
            }
        }
        private decimal netSalary;
        private decimal NetSalary
        {
            get { return GetNetSalary(); }
        }

        private decimal GetNetSalary()
        {
            return netSalary = Basic * (decimal)1.3;

        }

        public Employee(string Name = "", decimal Basic = 0, short DeptNo = 0)
        {
            // create a employee number
            // call method AssignEmpNo
            this.EmpNo=AssignEmpNo();
            this.Name = Name;
            this.Basic = Basic;
            this.DeptNo = DeptNo;
        }
        public int AssignEmpNo()
        {
            return ++genEmpNo;
        }

        public override string ToString()
        {
            return "[ EmpNo: "+this.EmpNo+", Name: "+this.Name+", Basic: "+this.Basic+", DeptNo: "+this.DeptNo+", NetSalary: "+this.NetSalary+" ]";
        }

    }
}