using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
namespace mvcASGEmployee.Models
{
    public class EmployeeModel
    {
        public DataTable GetAllEmployees()
            {
                DataTable dt = new DataTable();
                string strConString = @"Data Source=.; Initial Catalog=DBEmployeeDetail ;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(strConString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Select * from tblEmployee  ", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                return dt;
            }



            public DataTable GetEmployeeByID(int EmployeeID)
            {
                DataTable dt = new DataTable();

                string strConString = @"Data Source=.; Initial Catalog=DBEmployeeDetail ;Integrated Security=True";

                using (SqlConnection con = new SqlConnection(strConString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Select * from tblEmployee where EmployeeID =" + EmployeeID, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                return dt;
            }


            public int UpdateEmployee(int EmployeeID, string FirstName, string LastName, string Gender, string HiredDate, string Salary)
            {
                string strConString = @"Data Source=.; Initial Catalog=DBEmployeeDetail ;Integrated Security=True";

                using (SqlConnection con = new SqlConnection(strConString))
                {
                    con.Open();
                    string query = "Update tblEmployee  SET FirstName =@FirstName , LastName =@LastName  , Gender  =@Gender, HiredDate =@HiredDate, Salary =@Salary       where EmployeeID =@EmployeeID ";
                    SqlCommand cmd = new SqlCommand(query, con);
                 
                    cmd.Parameters.AddWithValue("@FirstName", FirstName);
                    cmd.Parameters.AddWithValue("@LastName", LastName);
                    cmd.Parameters.AddWithValue("@Gender", Gender);
                    cmd.Parameters.AddWithValue("@HiredDate", HiredDate);
                    cmd.Parameters.AddWithValue("@Salary", Salary);
                    return cmd.ExecuteNonQuery();
                }
            }


            public int InsertEmployee(int EmployeeID, string FirstName, string LastName, string Gender, string HiredDate, string Salary)
            {
                string strConString = @"Data Source=.; Initial Catalog=DBEmployeeDetail ;Integrated Security=True";

                using (SqlConnection con = new SqlConnection(strConString))
                {
                    con.Open();
                    string query = "Insert into tblEmployee (EmployeeID ,FirstName, LastName,Gender,HiredDate,Salary) values(@EmployeeID, @FirstName , @LastName,@Gender,@HiredDate, @Salary)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                    cmd.Parameters.AddWithValue("@FirstName", FirstName);
                    cmd.Parameters.AddWithValue("@LastName", LastName);
                    cmd.Parameters.AddWithValue("@Gender", Gender);
                    cmd.Parameters.AddWithValue("@HiredDate", HiredDate);
                    cmd.Parameters.AddWithValue("@Salary", Salary);
                    return cmd.ExecuteNonQuery();
                }
            }


            public int DeleteEmployee(int EmployeeID)
            {
                string strConString = @"Data Source=.; Initial Catalog=DBEmployeeDetail ;Integrated Security=True";

                using (SqlConnection con = new SqlConnection(strConString))
                {
                    con.Open();
                    string query = "Delete from tblEmployee where EmployeeID=@EmployeeID";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
