

namespace Linq
{
    internal class Program
    {
        static List<Employee> employeeList = new List<Employee>();
        static List<Department> departmentList = new List<Department>();
        public static void AddRec()
        {
            departmentList.Add(new Department { DeptNo = 10, DeptName = "SALES" });
            departmentList.Add(new Department { DeptNo = 20, DeptName = "MKTG" });
            departmentList.Add(new Department { DeptNo = 30, DeptName = "IT" });
            departmentList.Add(new Department { DeptNo = 40, DeptName = "HR" });

            employeeList.Add(new Employee { EmpNo = 1, Name = "Vikram", Salary = 10000, DeptNo = 10, Gender = "M" });
            employeeList.Add(new Employee { EmpNo = 2, Name = "Vikas", Salary = 11000, DeptNo = 10, Gender = "M" });
            employeeList.Add(new Employee { EmpNo = 3, Name = "Abhijit", Salary = 12000, DeptNo = 20, Gender = "M" });
            employeeList.Add(new Employee { EmpNo = 4, Name = "Mona", Salary = 11000, DeptNo = 20, Gender = "F" });
            employeeList.Add(new Employee { EmpNo = 5, Name = "Shweta", Salary = 12000, DeptNo = 20, Gender = "F" });
            employeeList.Add(new Employee { EmpNo = 6, Name = "Sanjay", Salary = 11000, DeptNo = 30, Gender = "M" });
            employeeList.Add(new Employee { EmpNo = 7, Name = "Arpan", Salary = 10000, DeptNo = 30, Gender = "M" });
            employeeList.Add(new Employee { EmpNo = 8, Name = "Shraddha", Salary = 11000, DeptNo = 40, Gender = "F" });

        }
        static void Main1(string[] args)
        {
            AddRec(); // all the records entered into both respective lists

            // write query to select entire Employee object
            var elist = from emp in employeeList select emp;
            foreach (var emp in elist)
            {
                Console.WriteLine(emp);
                /* Console.WriteLine(emp.Name);
                 Console.WriteLine(emp.DeptNo);
                 Console.WriteLine(emp.Gender);
                 Console.WriteLine(emp.EmpNo);*/

            }
            var eNameList = from emp in employeeList select (emp.Name, emp.DeptNo);
            //from emp in employeeList select emp.Name, emp.Gender; // not working
            foreach (var emp in eNameList)
            {
                Console.WriteLine(emp);
            }
        }

        static void Main2()
        {
            AddRec();
            // 02. selection a particular col form the datasource. datatype of var varible depends upon return type from query.
            var res = from emp in employeeList select emp.EmpNo;
            foreach (var empno in res)
            {
                Console.WriteLine(empno);
            }
        }

       public static void Main3()
        {
            AddRec();
            // 03. query to select more than one col--- use anonymus class because datatype of var varible must be same as the datatype returned by query but in case of multiple row it is required to define an new class to handle that datatye, but it is not feasible to define new class for every query so it is better to go with anonymous class in such cases.

            var ano = from emp in employeeList select new { emp.Name, emp.Salary};
            foreach (var emp in ano)
            {
                Console.WriteLine(emp.Name);
                Console.WriteLine(emp.Salary);
              
            }






        }

        public static void Main4()
        {
            AddRec();
            //04. where keyword to put some restrictions

            var res = from emp in employeeList where emp.Salary>11000 select emp;

            foreach(var emp in res)
            {
                Console.WriteLine(emp);
            }
        }

        public static void Main5()
        {
            AddRec();

            var res = from emp in employeeList orderby emp.Name descending select emp;

            foreach(var emp in res)
            {
                Console.WriteLine(emp);
            }

            Console.WriteLine("-------------------");

            var res2 = from emp in employeeList orderby emp.DeptNo descending, emp.Name ascending select emp;

            foreach(var emp in res2)
            {
                Console.WriteLine(emp);
            }

        }

        public static void Main6()
        {
            AddRec();

            //05. join tables 

            var res1 = from emp in employeeList
                      join dept in departmentList
                      on emp.DeptNo equals dept.DeptNo
                     // select emp; // due to this all te records availble to usid of employee only.
            select dept; // due to this all te records availble to usid of dept only.
            foreach (var emp in res1)
            {
                //Console.WriteLine(emp.Name);
                Console.WriteLine(emp.DeptName);
            }
            Console.WriteLine("-----------------------");

            var res2 = from emp in employeeList
                       join dept in departmentList
                       on emp.DeptNo equals dept.DeptNo
                       select new { emp, dept }; // anonymus class hence res2 is also of type iEnumerable of anonymus

            foreach(var emp in res2)
            {
                Console.WriteLine(emp.emp.Name);
                Console.WriteLine(emp.dept.DeptName);
            }
            Console.WriteLine("-----------------------");

            var res3 = from emp in employeeList
                       join dept in departmentList
                       on emp.DeptNo equals dept.DeptNo
                       select new {emp.Name, dept.DeptName}; // only two col are taken into result hence while displaying resule only these cols available.

            foreach(var emp in res3)
            {
                Console.WriteLine(emp.Name);
                Console.WriteLine(emp.DeptName);
            }
        }

       

        public class Department
        {
            public int DeptNo;
            public string DeptName;
        }

        public class Employee
        {
            public int EmpNo;
            public string Name;
            public int DeptNo;
            public string Gender;
            public decimal Salary;

            public override string ToString()
            {
                return EmpNo + ", " + Name + ", " + DeptNo + ", " + Gender + ", " + Salary;
            }
        }


    }
}

namespace Linq2
{
    internal class Program
    {
        static List<Employee> employeeList = new List<Employee>();
        static List<Department> departmentList = new List<Department>();
        public static void AddRec()
        {
            departmentList.Add(new Department { DeptNo = 10, DeptName = "SALES" });
            departmentList.Add(new Department { DeptNo = 20, DeptName = "MKTG" });
            departmentList.Add(new Department { DeptNo = 30, DeptName = "IT" });
            departmentList.Add(new Department { DeptNo = 40, DeptName = "HR" });

            employeeList.Add(new Employee { EmpNo = 101, Name = "Vikram", Salary = 10000, DeptNo = 10, Gender = "M" });
            employeeList.Add(new Employee { EmpNo = 202, Name = "Vikas", Salary = 11000, DeptNo = 10, Gender = "M" });
            employeeList.Add(new Employee { EmpNo = 303, Name = "Abhijit", Salary = 12000, DeptNo = 20, Gender = "M" });
            employeeList.Add(new Employee { EmpNo = 404, Name = "Mona", Salary = 11000, DeptNo = 20, Gender = "F" });
            employeeList.Add(new Employee { EmpNo = 505, Name = "Shweta", Salary = 12000, DeptNo = 20, Gender = "F" });
            employeeList.Add(new Employee { EmpNo = 606, Name = "Sanjay", Salary = 11000, DeptNo = 30, Gender = "M" });
            employeeList.Add(new Employee { EmpNo = 707, Name = "Arpan", Salary = 10000, DeptNo = 30, Gender = "M" });
            employeeList.Add(new Employee { EmpNo = 808, Name = "Shraddha", Salary = 11000, DeptNo = 40, Gender = "F" });

        }

        // change in coding style using lambda and other keywords
        // LINQ query using shorter syntax

       /* static Employee GetEmployee(Employee obj)
        {
            // this function is only returnning the object sent to it to the calling function
            return obj;
        }*/


        static void Main1(string[] args)
        {
            AddRec(); // all the records entered into both respective lists

            // write query to select entire Employee object

            //01.
            //var res = employeeList.Select(GetEmployee); //deligate

            //02.
            /*   var res = employeeList.Select(delegate(Employee obj)
               {
                   // using anonymous function
                   return obj;
               });*/

            //03. using lambda
            var res = employeeList.Select(obj => obj);

            foreach(var item in res)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("using anonymus func and lambda");
        }

        static void Main2()
        {
            AddRec();
            // 02. selection a particular col form the datasource. datatype of var varible depends upon return type from query.
            //var res = from emp in employeeList select emp.EmpNo;

            // using anonymous function
            /* var res = employeeList.Select(delegate (Employee obj)
             {
                 return obj.EmpNo;
             });*/

            // using lambda 
            var res = employeeList.Select(emp => emp.Gender);

            foreach (var empno in res)
            {
                Console.WriteLine(empno);
            }
            Console.WriteLine("using anonymous function and lambda");
        }  

        public static void Main3()
        {
            AddRec();
            // 03. query to select more than one col--- use anonymus class because datatype of var varible must be same as the datatype returned by query but in case of multiple row it is required to define an new class to handle that datatye, but it is not feasible to define new class for every query so it is better to go with anonymous class in such cases.

            //var ano = from emp in employeeList select new { emp.Name, emp.Salary };

            // using anonymous method
           /* var res = employeeList.Select(delegate (Employee obj)
            {
                return new { obj.Name, obj.DeptNo };
            });*/

            // using lambda

            var res = employeeList.Select(obj=> new {obj.Name, obj.DeptNo});
           
            foreach (var emp in res)
            {
                Console.WriteLine(emp.Name+", "+emp.DeptNo);
                

            }
            Console.WriteLine("using anonymous method and lambda");

        }

        public static void Main4()
        {

            static bool IsSalaryGreaterThan11000(Employee obj)
            {
                return obj.Salary > 11000;

                /*if (obj.Salary > 11000)
                    return true;
                return false;*/

                /*return obj.Salary > 11000 ? true : false;*/
            }
            AddRec();
            //04. where keyword to put some restrictions

            //var res = from emp in employeeList where emp.Salary > 11000 select emp;

            // using func
            //var res = employeeList.Where(IsSalaryGreaterThan11000);

            // using lambda
            var res = employeeList.Where(emp => emp.Salary > 11000); 
            // Note: the condition which is given in "where" as a normal statment will be given in lambda.
            foreach (var emp in res)
            {
                Console.WriteLine(emp);
            }

            // suppose it is required to listout names of all the employees whose salary is greater than 11000
            //var res = employeeList.Where(emp => emp.Salary > 11000);// will not work
            var res1 = employeeList.Where(emp => emp.Salary > 11000).Select(emp => emp.Name);
            //var res2 = employeeList.Select(emp => emp.Name).Where(emp => emp.Salary > 11000);// this also not work NOTE: output from initial statement will act as an input for next statement. here initial statement filters name property from the list and return iEnumerable of string, there is no property such as "salary" defined for string hence next statement will not result desired output and gives compilation error.

            foreach(var emp in res1)
            {
                Console.WriteLine(emp);
            }
        }

        public static void Main5()
        {
            AddRec();

            //var res = from emp in employeeList orderby emp.Name descending select emp;

            // using lambda

            var res = employeeList.OrderBy(emp => emp.Salary);

            foreach (var emp in res)
            {
                Console.WriteLine(emp);
            }

            Console.WriteLine("-------------------");

            //var res2 = from emp in employeeList orderby emp.DeptNo descending, emp.Name ascending select emp;

            var res2 = employeeList.OrderBy(emp=>emp.Salary).ThenBy(emp=>emp.Name);
            // if second statement is also entered by using order by then the new llist will be filtered on the basis of the results received from the just preceeding list. to avoid this issue use of "ThenBy"

            foreach (var emp in res2)
            {
                Console.WriteLine(emp);
            }

        }

        public static void Main()
        {
            AddRec();

            //05. join tables 

            /*var res1 = from emp in employeeList
                       join dept in departmentList
                       on emp.DeptNo equals dept.DeptNo
                       // select emp; // due to this all te records availble to usid of employee only.
                       select dept; // due to this all te records availble to usid of dept only.*/
            var res1 = employeeList.Join(employeeList, emp => emp.DeptNo, dept => dept.DeptNo, (emp, dept) => emp);
            foreach (var emp in res1)
            {
                Console.WriteLine(emp);
                //Console.WriteLine(emp.DeptName);
            }
            Console.WriteLine("-----------------------");

            var res2 = from emp in employeeList
                       join dept in departmentList
                       on emp.DeptNo equals dept.DeptNo
                       select new { emp, dept }; // anonymus class hence res2 is also of type iEnumerable of anonymus

            foreach (var emp in res2)
            {
                Console.WriteLine(emp.emp.Name);
                Console.WriteLine(emp.dept.DeptName);
            }
            Console.WriteLine("-----------------------");

            var res3 = from emp in employeeList
                       join dept in departmentList
                       on emp.DeptNo equals dept.DeptNo
                       select new { emp.Name, dept.DeptName }; // only two col are taken into result hence while displaying resule only these cols available.

            foreach (var emp in res3)
            {
                Console.WriteLine(emp.Name);
                Console.WriteLine(emp.DeptName);
            }
        }



        public class Department
        {
            public int DeptNo;
            public string DeptName;
        }

        public class Employee
        {
            public int EmpNo;
            public string Name;
            public int DeptNo;
            public string Gender;
            public decimal Salary;

            public override string ToString()
            {
                return EmpNo + ", " + Name + ", " + DeptNo + ", " + Gender + ", " + Salary;
            }
        }


    }
}

