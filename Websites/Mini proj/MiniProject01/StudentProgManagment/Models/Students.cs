using Microsoft.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using StudentProgManagment.ViewModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace StudentProgManagment.Models
{
    public class Students
    {
        // Annotaions not working
        private static int lastStudentId;
        public int StudentId { get; set; }
        [Required (ErrorMessage ="test")]
        
        [StringLength(10, ErrorMessage ="short in length")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Enter Full Name")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Enter Password")]
       
        public string Password { get; set; }
        [Required(ErrorMessage = "Select Gender")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Enter Email")]
        public string EmailId { get; set; }
        [Required(ErrorMessage = "Select City")]
        public int CityId { get; set; }
        [Required(ErrorMessage = "Enter Phone")]
        public string Phone { get; set; }

        public static void InsertStudent(Students student)
        {
           SqlConnection conn = GetConnection();

            try
            {
                conn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = conn;
                cmdInsert.CommandType = CommandType.StoredProcedure;
                cmdInsert.CommandText = "AddStudents";
                List<Students> index = GetAllStudent();
                if (index.Count > 0)
                {
                    lastStudentId = ++index.ElementAt(index.Count - 1).StudentId;
                }
                else lastStudentId = 1;

                cmdInsert.Parameters.AddWithValue("@StudentId", lastStudentId);
                cmdInsert.Parameters.AddWithValue("@UserName", student.UserName);
                cmdInsert.Parameters.AddWithValue("@FullName", student.FullName);
                cmdInsert.Parameters.AddWithValue("@Password", student.Password);
                cmdInsert.Parameters.AddWithValue("@Gender", student.Gender);
                cmdInsert.Parameters.AddWithValue("@EmailId", student.EmailId);
                cmdInsert.Parameters.AddWithValue("@CityId", student.CityId);
                cmdInsert.Parameters.AddWithValue("@Phone", student.Phone);

                cmdInsert.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { conn.Close(); }
            
        }

        public static void DeleteStudent(int id)
        {
            SqlConnection conn = GetConnection();

            try
            {
                conn.Open();
                SqlCommand cmdDelete = new SqlCommand();
                cmdDelete.Connection = conn;
                cmdDelete.CommandType = CommandType.StoredProcedure;
                cmdDelete.CommandText = "DeleteStudents";
                cmdDelete.Parameters.AddWithValue("@StudentId", id);


                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { conn.Close(); }

        }


        public static void UpdateStudent(Students student)
        {
            SqlConnection conn = GetConnection();

            try
            {
                conn.Open();
                SqlCommand cmdUpdate = new SqlCommand();
                cmdUpdate.Connection = conn;
                cmdUpdate.CommandType = CommandType.StoredProcedure;
                cmdUpdate.CommandText = "UpdateStudents";
                cmdUpdate.Parameters.AddWithValue("@StudentId", student.StudentId);
               
                cmdUpdate.Parameters.AddWithValue("@FullName", student.FullName);
               
                cmdUpdate.Parameters.AddWithValue("@Gender", student.Gender);
                
                cmdUpdate.Parameters.AddWithValue("@CityId", student.CityId);
                cmdUpdate.Parameters.AddWithValue("@Phone", student.Phone);

                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { conn.Close(); }

        }

        public static List<Students> GetAllStudent()
        {
            SqlConnection conn = GetConnection();
            List<Students> list = new List<Students>();
            

            try
            {
                conn.Open();
                SqlCommand select = new SqlCommand();
                select.Connection = conn;
                select.CommandType = CommandType.StoredProcedure;
                select.CommandText = "SelectAllStudents";
                SqlDataReader dr = select.ExecuteReader();

                while (dr.Read())
                {
                    Students stud = new Students
                    { StudentId = dr.GetInt32("StudentId"), 
                        UserName = dr.GetString("UserName"), 
                        FullName = dr.GetString("FullName"), 
                        Password = dr.GetString("Password"), 
                        Gender = dr.GetString("Gender"), 
                        EmailId = dr.GetString("EmailId"), 
                        CityId = dr.GetInt32("CityId"), 
                        Phone = dr.GetString("Phone") 
                    };
                    list.Add(stud);
                }
              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { conn.Close(); }
            return list;

        }

        public static Students GetStudentById(int? id)
        {
            SqlConnection conn = GetConnection();
            Students stud = null;
            try
            {
                conn.Open();
                SqlCommand cmdSelect = new SqlCommand();
                cmdSelect.Connection = conn;
                cmdSelect.CommandType = CommandType.Text;
                cmdSelect.CommandText = "select * from Students where StudentId=@StudentId";
                cmdSelect.Parameters.AddWithValue("@StudentId", id);

                SqlDataReader dr = cmdSelect.ExecuteReader();

                while (dr.Read())
                {
                    stud = new Students
                    {
                        StudentId = dr.GetInt32("StudentId"),
                        UserName = dr.GetString("UserName"),
                        FullName = dr.GetString("FullName"),
                        Password = dr.GetString("Password"),
                        Gender = dr.GetString("Gender"),
                        EmailId = dr.GetString("EmailId"),
                        CityId = dr.GetInt32("CityId"),
                        Phone = dr.GetString("Phone")
                    };
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { conn.Close(); }
            return stud;
        }


        public static int validLogin(LoginViewModel students) {
            int id = -1;
            SqlConnection conn = GetConnection();
          
            try
            {
                conn.Open();
                SqlCommand select = new SqlCommand();
                select.Connection = conn;
                select.CommandType = CommandType.Text;
                select.CommandText = "select * from Students where UserName Like @Username And Password Like @Password";
                select.Parameters.AddWithValue("@UserName", students.UserName);
                select.Parameters.AddWithValue("@Password", students.Password);

                SqlDataReader dr = select.ExecuteReader();

                if(dr.Read())
                {
                    id = dr.GetInt32("StudentId");
                }
              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { conn.Close(); }

            return id;
        }

        public static SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection();
            //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudentProjects;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudentProjects;Integrated Security=True;";

            return conn;

        }
    }
}
