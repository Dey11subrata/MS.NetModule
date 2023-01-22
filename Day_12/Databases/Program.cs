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
        static void Main()
        {
            Console.WriteLine("Enter EmpNo to delete");
            int deleteId = int.Parse(Console.ReadLine());

            deleteEmpWithStoredProcedure(deleteId);
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



    }
    public class Employee
    {
        public int EmpNo { get; set; }
        public string EmpName { get; set; }
        public decimal Salary { get; set; }
        public int DeptNo { get; set; }
    }

        
}