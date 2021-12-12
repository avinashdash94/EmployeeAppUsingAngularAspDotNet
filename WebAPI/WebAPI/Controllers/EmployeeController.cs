using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        // GET: Employee
        public HttpResponseMessage Get()
        {
            string query = @"SELECT [EmployeeId],[EmployeeName]
                          ,[Department]
                          ,convert(varchar(10), DateOfJoining, 120) as DateOfJoining
                          ,[PhotoFileName] FROM  dbo.Employee";

            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            };


            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        public string Post(Employee emp)
        {
            try
            {
                string query = @"insert into dbo.Employee values
                                (
                                '" + emp.EmployeeName + @"'
                                ,'" + emp.Department + @"'
                                ,'" + emp.DateOfJoining + @"'
                                ,'" + emp.PhotoFileName + @"'
                                ) ";

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
                return "Failed to Add!!";
            }

            return "Added SucessFully!!";

        }

        public string Put(Employee emp)
        {
            try
            {
                string query = @"update dbo.Employee set 
                               EmployeeName = '" + emp.EmployeeName + @"',
                               Department = '" + emp.Department + @"',
                               DateOfJoining = '" + emp.DateOfJoining + @"',
                               PhotoFileName = '" + emp.PhotoFileName + @"'
                        Where EmployeeId =" + emp.EmployeeId + @"
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

        //[HttpDelete, Route("{id}")]
        //[Route("{id}")]
        public string DeleteEmployee(int id)
        {
            try
            {
                string query = @"delete from dbo.Employee
                                Where EmployeeId =" + id + @"
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
                return "Failed to Delete!!";
            }

            return "Deleted SucessFully!!";

        }

        [Route("api/Employee/GetAllDepartmentNames")]
        [HttpGet]
        public HttpResponseMessage GetAllDepartmentNames()
        {
            string query = @"SELECT DepartmentName FROM  dbo.Department";

            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            };


            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        [Route("api/Employee/SaveFile")]
        public string SaveFile()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                var postedFile = httpRequest.Files[0];
                var fileName = postedFile.FileName;
                var physicalPath = HttpContext.Current.Server.MapPath("~/Photos/" + fileName);
                postedFile.SaveAs(physicalPath);

                return fileName;
            }
            catch (Exception)
            {
                return "anonymous.png";
            }
        }
    }
}