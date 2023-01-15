namespace Assignment5_c
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee(101, "Employee1", 50000));
            employees.Add(new Employee(102, "Employee2", 60000));
            employees.Add(new Employee(103, "Employee3", 40000));
            employees.Add(new Employee(104, "Employee4", 70000));
            employees.Add(new Employee(105, "Employee5", 30000));

            employees.ForEach(e => Console.WriteLine(e));
            Employee[] empArr=employees.ToArray();

                Console.WriteLine("Array:---");
            foreach(Employee emp in empArr)
            {
                Console.WriteLine(emp);
            }
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