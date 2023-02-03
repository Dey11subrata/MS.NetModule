//using Microsoft.CodeAnalysis;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Primitives;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace StudentProgManagment.Models
{
    public class Projects
    {
        private static int lastProjectId;
        public int ProjectId { get; set; }
        [Required(ErrorMessage ="Enter Project Title")]
        public string ProjectName { get; set; }
        [Required(ErrorMessage ="Describe your Project")]
        [DataType(DataType.MultilineText)]
        public string ProjectDescription { get; set; }
        [Required(ErrorMessage ="Enter Start Date")]
        [DataType(DataType.Date)]
        public string StartDate { get; set; }
        [Required(ErrorMessage = "Enter End Date")]
        [DataType(DataType.Date)]
        public string EndDate { get; set; }
        [Required(ErrorMessage = "Enter Status")]
        public string ProjectStatus { get; set; }
        public int StudentId { get; set; }


        public static void InsertProjects(Projects project)
        {
            SqlConnection conn = GetConnection();

            try
            {
                conn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = conn;
                cmdInsert.CommandType = CommandType.StoredProcedure;
                cmdInsert.CommandText = "AddProjects";

                List<Projects> list = GetAllProjects();
                if(list.Count>0)
                {
                    lastProjectId = ++list.ElementAt(list.Count - 1).ProjectId;
                }
                else
                {
                    lastProjectId = 1;
                }
                cmdInsert.Parameters.AddWithValue("@ProjectId", lastProjectId);
                cmdInsert.Parameters.AddWithValue("@ProjectDescription", project.ProjectDescription);
                cmdInsert.Parameters.AddWithValue("@StartDate", project.StartDate);
                cmdInsert.Parameters.AddWithValue("@ProjectName", project.ProjectName);
                cmdInsert.Parameters.AddWithValue("@EndDate", project.EndDate);
                cmdInsert.Parameters.AddWithValue("@ProjectStatus", project.ProjectStatus);
                cmdInsert.Parameters.AddWithValue("@StudentId", project.StudentId);
               

                cmdInsert.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { conn.Close(); }

        }

        public static void DeleteProject(int id)
        {
            SqlConnection conn = GetConnection();

            try
            {
                conn.Open();
                SqlCommand cmdDelete = new SqlCommand();
                cmdDelete.Connection = conn;
                cmdDelete.CommandType = CommandType.StoredProcedure;
                cmdDelete.CommandText = "DeleteProjects";
                cmdDelete.Parameters.AddWithValue("@ProjectId", id);


                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { conn.Close(); }

        }


        public static void UpdateProject(Projects project)
        {
            SqlConnection conn = GetConnection();

            try
            {
                conn.Open();
                SqlCommand cmdUpdate = new SqlCommand();
                cmdUpdate.Connection = conn;
                cmdUpdate.CommandType = CommandType.StoredProcedure;
                cmdUpdate.CommandText = "UpdateProjects";
                cmdUpdate.Parameters.AddWithValue("@ProjectId", project.ProjectId);
                cmdUpdate.Parameters.AddWithValue("@ProjectDescription", project.ProjectDescription);
                cmdUpdate.Parameters.AddWithValue("@StartDate", project.StartDate);
          
                cmdUpdate.Parameters.AddWithValue("@ProjectName", project.ProjectName);
                cmdUpdate.Parameters.AddWithValue("@EndDate", project.EndDate);
                cmdUpdate.Parameters.AddWithValue("@ProjectStatus", project.ProjectStatus);
               

                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { conn.Close(); }

        }

        public static List<Projects> GetAllProjects()
        {
            SqlConnection conn = GetConnection();
            List<Projects> list = new List<Projects>();


            try
            {
                conn.Open();
                SqlCommand select = new SqlCommand();
                select.Connection = conn;
                select.CommandType = CommandType.StoredProcedure;
                select.CommandText = "SelectAllProjects";
                SqlDataReader dr = select.ExecuteReader();

                while (dr.Read())
                {
                    Projects proj = new Projects
                    {
                        ProjectId = dr.GetInt32("ProjectId"),
                        ProjectName = dr.GetString("ProjectName"),
                        ProjectDescription = dr.GetString("ProjectDescription"),
                        StartDate = dr.GetString("StartDate"),
                        //StartDate = dr.GetDateTime("StartDate").ToShortDateString(),
                        EndDate = dr.GetString("EndDate"),
                        ProjectStatus = dr.GetString("ProjectStatus"),
                        StudentId = dr.GetInt32("StudentId")
                    };
                    list.Add(proj);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { conn.Close(); }
            return list;

        }

        public static Projects GetProjectsById( int id )
        {
            SqlConnection conn = GetConnection();

            Projects proj=null;

            try
            {
                conn.Open();
                SqlCommand selectById = new SqlCommand();
                selectById.Connection = conn;
                selectById.CommandType = CommandType.StoredProcedure;
                selectById.CommandText = "SelectProjectsById";
                selectById.Parameters.AddWithValue("@ProjectId", id);
                SqlDataReader dr = selectById.ExecuteReader();

                if (dr.Read())
                {
                    proj = new Projects
                    {
                        ProjectId = dr.GetInt32("ProjectId"),
                        ProjectName = dr.GetString("ProjectName"),
                        ProjectDescription = dr.GetString("ProjectDescription"),
                        StartDate = dr.GetString("StartDate"),
                        //StartDate = dr.GetDateTime("StartDate").ToShortDateString(),
                        EndDate = dr.GetString("EndDate"),
                        ProjectStatus = dr.GetString("ProjectStatus"),
                        StudentId = dr.GetInt32("StudentId")
                    };
                   
                }
                    
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { conn.Close(); }
            return proj;

        }

        public static List<Projects> GetProjectsByStudentId(int? id)
        {
            SqlConnection conn = GetConnection();
            List<Projects> list = new List<Projects>();


            try
            {
                conn.Open();
                SqlCommand select = new SqlCommand();
                select.Connection = conn;
                select.CommandType = CommandType.Text;
                select.CommandText = "select * from Projects where StudentId = @StudentId";
                select.Parameters.AddWithValue("@StudentId", id);
                SqlDataReader dr = select.ExecuteReader();

                while (dr.Read())
                {
                    Projects proj = new Projects
                    {
                        ProjectId = dr.GetInt32("ProjectId"),
                        ProjectName = dr.GetString("ProjectName"),
                        ProjectDescription = dr.GetString("ProjectDescription"),
                        StartDate = dr.GetString("StartDate"),
                        //StartDate = dr.GetDateTime("StartDate").ToShortDateString(),
                        EndDate = dr.GetString("EndDate"),
                        ProjectStatus = dr.GetString("ProjectStatus"),
                        StudentId = dr.GetInt32("StudentId")
                    };
                    list.Add(proj);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { conn.Close(); }
            return list;

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
