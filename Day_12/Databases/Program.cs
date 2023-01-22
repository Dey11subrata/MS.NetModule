using Microsoft.Data.SqlClient;
using System.Data;
namespace Databases
{
    internal class Program
    {
        
        static void Main1(string[] args)
        {
            //Connect();
            //Insert();
            Employee em = new Employee() { EmpNo = 10, DeptNo = 10, EmpName = "Person10", Salary = 10000 };
           // InsertEmp(em);
            //InsertEmpWithParameters(em);
            InsertWithStoredProcedure(em);
        }

        // update and delete  with parameter
        //01. update

        static void Main2()
        {
            Console.WriteLine("Emter EmpNo to update record");
            int updateId = int.Parse(Console.ReadLine());

            updateEmpWithParameter(updateId);
        }

        //02. delete
        static void Main3()
        {
            Console.WriteLine("Emter EmpNo to delete");
            int deleteId = int.Parse(Console.ReadLine());

            deleteEmpWithParameter(deleteId);
        }

        // update and delete  with stored procedure.......

        // 01. Update with storedprocedure
        static void Main4()
        {
            Console.WriteLine("Enter EmpNo to update record");
            int updateId = int.Parse(Console.ReadLine());

            updateEmpWithStoredProcedure(updateId);
        }

        // 02. Delete with storedprocedure
        static void Main5()
        {
            Console.WriteLine("Enter EmpNo to delete");
            int deleteId = int.Parse(Console.ReadLine());

            deleteEmpWithStoredProcedure(deleteId);
        }

        // singlevalue

        static void Main6()
        {
            SingleValue();
        }
        
        // Read MultipleValues
        static void Main7()
        {
            DataReader1();
        }

        static void Main8()
        {
         Employee emp= GetSingleUsingDataReader(2);
            Console.WriteLine(emp);
        }

        static void Main9()
        {
            MARS();
        }

        static void Main()
        {
            Transactions();

        }

        static void Connect() {
            SqlConnection cn = new SqlConnection();
            //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JkJan23;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
            cn.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog=JkJan23;Integrated Security=True;";

            try
            {
                cn.Open();
                Console.WriteLine("connected");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { cn.Close(); }

            
            
        }

        static void Insert()
        {
            SqlConnection cn = new SqlConnection();
            //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JkJan23;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
            cn.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog=JkJan23;Integrated Security=True;";

            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.CommandText = "insert into Employees values(7,'Person7', 30000, 40)";

                cmdInsert.ExecuteNonQuery(); // it is for execute query it returns number of rows affcted int.
                Console.WriteLine("inserted");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { cn.Close(); }



        }

        static void InsertEmp(Employee obj)
        {
            SqlConnection cn = new SqlConnection();
            //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JkJan23;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
            cn.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog=JkJan23;Integrated Security=True;";

            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.CommandText = $"insert into Employees values({obj.EmpNo},'{obj.EmpName}', {obj.Salary}, {obj.DeptNo})"; // we can't use this when there is any special character such as d'souza is in our data. other major problem - with string concatination is SQL injection. it leves us open to 2 problems now 1. special characters and 2. sql injection. hence never use string concationation. to avoid problems use parameters.

                cmdInsert.ExecuteNonQuery(); // it is for execute query it returns number of rows affcted int.
                Console.WriteLine("inserted");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { cn.Close(); }



        }

        static void InsertEmpWithParameters(Employee obj)
        {
            SqlConnection cn = new SqlConnection();
            //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JkJan23;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
            cn.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog=JkJan23;Integrated Security=True;";

            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.CommandText = $"insert into Employees values(@EmpNo, @EmpName, @EmpSalary, @EmpDeptNo)";

                cmdInsert.Parameters.AddWithValue("@EmpNo", obj.EmpNo);
                cmdInsert.Parameters.AddWithValue("@EmpSalary", obj.Salary);
                cmdInsert.Parameters.AddWithValue("@EmpName", obj.EmpName);
                cmdInsert.Parameters.AddWithValue("@EmpDeptNo", obj.DeptNo);

                cmdInsert.ExecuteNonQuery(); // it is for execute query it returns number of rows affcted int.
                Console.WriteLine("inserted");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { cn.Close(); }



        }

        static void InsertWithStoredProcedure(Employee obj)
        {
            SqlConnection cn = new SqlConnection();
            //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JkJan23;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
            cn.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog=JkJan23;Integrated Security=True;";

            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = CommandType.StoredProcedure;
                cmdInsert.CommandText = "InsertEmployee";

                cmdInsert.Parameters.AddWithValue("@EmpNo", obj.EmpNo);
                cmdInsert.Parameters.AddWithValue("@EmpSalary", obj.Salary);
                cmdInsert.Parameters.AddWithValue("@EmpName", obj.EmpName);
                cmdInsert.Parameters.AddWithValue("@EmpDeptNo", obj.DeptNo);

                cmdInsert.ExecuteNonQuery(); // it is for execute query it returns number of rows affcted int.
                Console.WriteLine("inserted");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { cn.Close(); }



        }

        static void updateEmpWithParameter(int id)
        {
            SqlConnection cn = new SqlConnection();
            //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JkJan23;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
            cn.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog=JkJan23;Integrated Security=True;";

            try
            {
                cn.Open();
                SqlCommand cmdUpdate = new SqlCommand();
                cmdUpdate.Connection = cn;
                cmdUpdate.CommandType = CommandType.Text;
                cmdUpdate.CommandText = "update Employees set Name=@EmpName where EmpNo=@Id";
                cmdUpdate.Parameters.AddWithValue("@EmpName", "Employee1");
                cmdUpdate.Parameters.AddWithValue("@Id", id);

                cmdUpdate.ExecuteNonQuery();
                // it is for execute query it returns number of rows affcted int.
                Console.WriteLine("updated record....");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { cn.Close(); }



        } 
        
        static void deleteEmpWithParameter(int id)
        {
            SqlConnection cn = new SqlConnection();
            //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JkJan23;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
            cn.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog=JkJan23;Integrated Security=True;";

            try
            {
                cn.Open();
                SqlCommand cmdDelete = new SqlCommand();
                cmdDelete.Connection = cn;
                cmdDelete.CommandType = CommandType.Text;
                cmdDelete.CommandText = "delete from Employees where EmpNo=@Id";

                cmdDelete.Parameters.AddWithValue("@Id", id);

                cmdDelete.ExecuteNonQuery();
                // it is for execute query it returns number of rows affcted int.
                Console.WriteLine("delete record....");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { cn.Close(); }



        }

        static void updateEmpWithStoredProcedure(int id)
        {
            SqlConnection cn = new SqlConnection();
            //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JkJan23;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
            cn.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog=JkJan23;Integrated Security=True;";

            try
            {
                cn.Open();
                SqlCommand cmdUpdate = new SqlCommand();
                cmdUpdate.Connection = cn;
                cmdUpdate.CommandType = CommandType.StoredProcedure;
                cmdUpdate.CommandText = "UpdateEmployee";
                cmdUpdate.Parameters.AddWithValue("@EmpName", "Employee2");
                cmdUpdate.Parameters.AddWithValue("@Id", id);

                cmdUpdate.ExecuteNonQuery();
                // it is for execute query it returns number of rows affcted int.
                Console.WriteLine("updated record....");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { cn.Close(); }



        }

        static void deleteEmpWithStoredProcedure(int id)
        {
            SqlConnection cn = new SqlConnection();
            //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JkJan23;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
            cn.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog=JkJan23;Integrated Security=True;";

            try
            {
                cn.Open();
                SqlCommand cmdDelete = new SqlCommand();
                cmdDelete.Connection = cn;
                cmdDelete.CommandType = CommandType.StoredProcedure;
                cmdDelete.CommandText = "DeleteEmployee";

                cmdDelete.Parameters.AddWithValue("@Id", id);

                cmdDelete.ExecuteNonQuery();
                // it is for execute query it returns number of rows affcted int.
                Console.WriteLine("delete record....");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { cn.Close(); }



        }

        static void SingleValue()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog=JkJan23;Integrated Security=True;";

            try
            {
                con.Open();
                SqlCommand cmdSingleValue = new SqlCommand();
                cmdSingleValue.Connection = con;
                cmdSingleValue.CommandType = CommandType.Text;
                //cmdSingleValue.CommandText = "select count(*) from Employees";
                cmdSingleValue.CommandText = "select Name from Employees where EmpNo=9";
                object rval=cmdSingleValue.ExecuteScalar();
                Console.WriteLine(rval);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { con.Close(); }
        }

        static void DataReader1()
        {
            // this program will demostrate how to read multiple lines/rows using DataReader

            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog=JkJan23;Integrated Security=True;";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                //cmdSingleValue.CommandText = "select count(*) from Employees";
                cmd.CommandText = "select * from Employees";
                SqlDataReader dReader = cmd.ExecuteReader();

                while (dReader.Read())
                {
                    Console.WriteLine(dReader[0]+", " + dReader[1]);
                    Console.WriteLine(dReader["EmpNo"]);
                }
                dReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { con.Close(); }
        }

        static Employee GetSingleUsingDataReader(int EmpNo)
        {
            Employee emp = null;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog=JkJan23;Integrated Security=True;";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Employees where EmpNo=@EmpNo";
                cmd.Parameters.AddWithValue("@EmpNo", EmpNo);

                SqlDataReader dReader = cmd.ExecuteReader();// this query will either give one employee or null if no record found

                if(dReader.Read())
                {
                    Console.WriteLine("data found");
                   emp = new Employee() { EmpNo = (int)dReader[0], EmpName = (string)dReader[1], DeptNo = (int)dReader[3], Salary = (decimal)dReader[2] };
                }
                
                    
               
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return emp;
        }

        static void MARS()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JkJan23;Integrated Security=true;MultipleActiveResultSets=true;";
            cn.Open();

            SqlCommand cmdDepts = new SqlCommand();
            cmdDepts.Connection = cn;
            cmdDepts.CommandType = CommandType.Text;
            cmdDepts.CommandText = "Select * from Departments";

            SqlCommand cmdEmps = new SqlCommand();
            cmdEmps.Connection = cn;
            cmdEmps.CommandType = CommandType.Text;

            SqlDataReader drDepts = cmdDepts.ExecuteReader();
            while (drDepts.Read())
            {
                Console.WriteLine((drDepts["DeptName"]));

                cmdEmps.CommandText = "Select * from Employees where DeptNo = " + drDepts["DeptNo"];//it will cause error because cmdDepts and cmdEmps both using same connection and in sql server when one connection is in use then that connection is locked by default and can't use by other. To avoid this issue MultipleActiveResultSets=true is used in connection string.
                SqlDataReader drEmps = cmdEmps.ExecuteReader();
                while (drEmps.Read())
                {
                    Console.WriteLine(("    " + drEmps["Name"]));
                }
                drEmps.Close();
            }
            drDepts.Close();
            cn.Close();

        }


        static void Transactions() 
        {
            SqlConnection con = new SqlConnection();
            //step 1 = create a connection object
            con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JkJan23;Integrated Security=True;";
            // step 2 = provide connectionsting i.e database details

            con.Open();
            // step 3 = open connection
            SqlTransaction trs = con.BeginTransaction();
            // it becomes compulsory for all commands using con connection to execute in transaction trs (same transaction) otherwise error will be thrown
           
            // now go for SqlCommands

            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con;
            cmd1.Transaction= trs;

            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "insert into Employees values(@EmpNo, @EmpName, @EmpSalary, @EmpDeptNo)";
            cmd1.Parameters.AddWithValue("@EmpNo", 11);
            cmd1.Parameters.AddWithValue("@EmpName", "Employee11");
            cmd1.Parameters.AddWithValue("@EmpSalary",67000);
            cmd1.Parameters.AddWithValue("@EmpDeptNo", 30);

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.Transaction = trs;

            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "insert into Employees values(@EmpNo, @EmpName, @EmpSalary, @EmpDeptNo)";
            cmd2.Parameters.AddWithValue("@EmpNo", 12);
            cmd2.Parameters.AddWithValue("@EmpName", "Employee12");
            cmd2.Parameters.AddWithValue("@EmpSalary", 50000);
            cmd2.Parameters.AddWithValue("@EmpDeptNo", 40);

            try
            {
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                trs.Commit();
                Console.WriteLine("commands commited and data inserted");
            }
            catch(Exception ex) {
                trs.Rollback();
                Console.WriteLine("transaction rollback");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

    }
    public class Employee
    {
        public int EmpNo { get; set; }
        public string EmpName { get; set; }
        public decimal Salary { get; set; }
        public int DeptNo { get; set; }

        public override string ToString()
        {
            return EmpNo + ", " + EmpName + ", " + Salary+", "+DeptNo ;
        }
    }

        
}