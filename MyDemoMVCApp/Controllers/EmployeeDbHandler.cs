using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MyDemoMVCApp.Models;

namespace MyDemoMVCApp.Controllers
{
    public class EmployeeDbHandler
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["MVCDBCONN"].ConnectionString;
            con = new SqlConnection(constring);
        }

        // **************** ADD NEW EMPLOYEE *********************
        public bool AddEmployee(Employee emodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AddNewEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@first_name", emodel.FirstName);
            cmd.Parameters.AddWithValue("@last_name", emodel.LastName);
            cmd.Parameters.AddWithValue("@email", emodel.Email);
            cmd.Parameters.AddWithValue("@department", emodel.Department);
            cmd.Parameters.AddWithValue("@job_position", emodel.JobPosition);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********** VIEW EMPLOYEE DETAILS ********************
        public List<Employee> GetEmployee()
        {
            connection();
            List<Employee> employeeList = new List<Employee>();
            SqlCommand cmd = new SqlCommand("GetEmployeeDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                employeeList.Add(
                    new Employee
                    {
                        ID = Convert.ToInt32(dr["id"]),
                        FirstName = Convert.ToString(dr["first_name"]),
                        LastName = Convert.ToString(dr["last_name"]),
                        Email = Convert.ToString(dr["email"]),
                        Department = Convert.ToString(dr["department"]),
                        JobPosition = Convert.ToString(dr["job_position"])
                    });
            }
            return employeeList;
        }

        // ***************** UPDATE EMPLOYEE DETAILS *********************
        public bool UpdateDetails(Employee emodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateEmployeeDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", emodel.ID);
            cmd.Parameters.AddWithValue("@first_name", emodel.FirstName);
            cmd.Parameters.AddWithValue("@last_name", emodel.LastName);
            cmd.Parameters.AddWithValue("@email", emodel.Email);
            cmd.Parameters.AddWithValue("@department", emodel.Department);
            cmd.Parameters.AddWithValue("@job_position", emodel.JobPosition);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********************** DELETE EMPLOYEE DETAILS *******************
        public bool DeleteEmployee(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DeleteEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ID", id);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }        
    }
}