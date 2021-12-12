using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class DepartmentController : ApiController
    {
        // GET: Department
        public HttpResponseMessage Get()
        {
            string query = @"SELECT * FROM  dbo.Department";

            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using(var cmd = new SqlCommand(query,con))
                using(var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            };


            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        public string Post(Department dep)
        {
            try
            {
                string query = @"insert into dbo.Department values(
                                            '"+dep.DepartmentName + @"') ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                };
            }
            catch(Exception ex)
            {
                return "Failed to Add!!";
            }

            return "Added SucessFully!!";

        }

        public string Put(Department dep)
        {
            try
            {
                string query = @"update dbo.Department set DepartmentName = 
                       '" + dep.DepartmentName + @"'
                        Where DepartmentId =" + dep.DepartmentId+ @"
                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                };
            }
            catch (Exception ex)
            {
                return "Failed to Update!!";
            }

            return "Update SucessFully!!";

        }

        public string DeleteDepartment(int id)
        {
            try
            {
                string query = @"delete from dbo.Department 
                                Where DepartmentId =" + id;

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                };
            }
            catch (Exception ex)
            {
                return "Failed to Delete!!";
            }

            return "Deleted SucessFully!!";

        }

       

    }
}