namespace Assignment3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

   public abstract class Employee {
        private string name;
        public string Name
        {
            set
            {
                if (value != "")
                {
                    name = value;
                }
                else
                {
                    Console.WriteLine("Name can't be empty");
                    name = "Anonymous";
                }
            }
            get { return Name; }
        }
        private int empNo;
        public int EmpNo
        {
            get { return empNo; }
          /*  set
            {
                // auto genereate code
            }*/

        }

        private short deptNo;
        public short DeptNo
        {
            get { return deptNo; }
            set { 
                if(value>0)
                    deptNo= value;
                else
                {
                    Console.WriteLine("DeptNo must be greater than 0");
                    deptNo= 0;
                }
            }
        }

        protected decimal basic;
        public abstract decimal Basic
        {
            set;
            get;
        }
        public abstract decimal CalcNetSalary();



    }

    public class Manager : Employee
    {
        public override decimal Basic
        {
            set
            {
                if(value>20000 && value<80000)
                  basic = value;
            }
            get { return basic; }
        }
        private string designation;
        public string Designation
        {
            set
            {
                if(value!="")
                    designation= value;
            }

            get { return designation; }
        }

        public override decimal CalcNetSalary()
        {
            return basic*(decimal)1.45;
        }
    }
    public class GeneralManager : Manager
    {
        public override decimal Basic
        {
            set
            {
                if (value > 50000 && value < 150000)
                    basic = value;
            }
            get { return basic; }
        }

        private string perk;
        public string Perk
        {
            set
            {
                perk= value;
            }
            get { return perk; }
        }
        public override decimal CalcNetSalary()
        {
            return basic * (decimal)1.25;
        }

        // Constructor
        puclic GeneralManager(string Name = "Nameless", short DeptNo = 99, decimal Basic = 40000, string Perk) : base (Name, DeptNo, Basic, Perk) {
            {

            }
            
    }

    public class CEO : Employee
    {

        // Constructor
       
        public override decimal Basic {
            set
            {
                if (value > 200000 && value < 800000)
                    basic = value;
            }
            get { return basic; }

            /*get => throw new NotImplementedException(); set => throw new NotImplementedException();*/
        }

            public CEO(string Name = "Nameless", short DeptNo = 99, decimal Basic = 40000) : base (Name, DeptNo, Basic)
            {

            }

            public sealed override decimal CalcNetSalary()
        {
            return basic * (decimal)1.15;
        }
    }
}