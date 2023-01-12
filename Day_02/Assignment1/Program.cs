

namespace Assignment1
{
    internal class Program
    {
        static void Main()
        {
            Employee o1 = new Employee(EmpNo: 1, Name: "Anmol", Basic: 123465, DeptNo: 10) ;
            Console.WriteLine(o1);
            Console.WriteLine("---------------------------------");
            Employee o2 = new Employee(1, "Anmol", 123465);
            Console.WriteLine(o2);
            Console.WriteLine("---------------------------------");
            Employee o3 = new Employee(1, "Anmol");
            Console.WriteLine(o3);
            Console.WriteLine("---------------------------------");
            Employee o4 = new Employee(1);
            Console.WriteLine(o4);
            Console.WriteLine("---------------------------------");
            Employee o5 = new Employee();
            Console.WriteLine(o5);
            Console.WriteLine("---------------------------------");

            //Console.ReadLine();
        }
    }
    
    public class Employee
    {
        private string name;
        public string Name
        {
            // "   "
            set 
            {
                if (value != " " )
                    name = value;
                else
                    Console.WriteLine("name should not be blank");
            }
            get { return name; }
        }
        private int empNo;
        public int EmpNo 
        {
            get { return empNo; }

            set {
                if (value > 0)
                    empNo = value;
                else
                    Console.WriteLine("EmpNo must be greater than 0");
            }
        }
        private decimal basic;
        public decimal Basic {
            set
            {
                if(value>=40000 && value<150000)
                    basic= value;
            }
            get { return basic; }
        }
        private short deptNo;
        public short DeptNo {
            set
            {
                if (value > 0)
                    deptNo = value;
                else
                    Console.WriteLine("DeptNo must be greater than 0");
            }
            get { return deptNo; }
        }
       /* public Employee()
        {
            
        }*/
        public Employee(int EmpNo=0, string Name="not given", decimal Basic=40000, short DeptNo=0)
        {
            this.Name = Name;
           this.EmpNo = EmpNo;
            this.Basic = Basic;
          this.DeptNo = DeptNo;
        }
        private decimal netSalary;
        public void GetNetSalary()
        {
             netSalary = basic * (decimal)1.4;
            
        }

        // override toString method

        public override  String ToString()
        {
            return ("EmpNo: " + this.EmpNo + ", Name:" + this.Name+", Salary: "+this.Basic+", Department: "+this.DeptNo);


        }

    }
}