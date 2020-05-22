using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using WebApiTest1.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApiTest1.Controllers
{
    public class DepartmentController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable dt = new DataTable();

            string query = @"
                             select
                                department_id,
                                department_name,
                                group_name,
                                convert(varchar(10), modified_date, 120) as modified_date
                             from Departments
                            ";

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var dta = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                dta.Fill(dt);
            }

            return Request.CreateResponse(HttpStatusCode.OK, dt);
        }

        public string Post(Department dep)
        {
            try
            {
                DataTable dt = new DataTable();

                string query = @"insert into Departments (
                                    department_name,
                                    group_name)
                                 values (
                                    '" + dep.department_name + @"'
                                    ,'" + dep.group_name + @"'
                                 )";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var dta = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    dta.Fill(dt);
                }

                return "Added Successfully";
            }
            catch (Exception err)
            {
                return "Failed to Add Becuase " + err.Message;
            }
        }

        public string Put(Department dep)
        {
            try
            {
                DataTable dt = new DataTable();

                string query = @"
                                 UPDATE Departments
                                 SET department_name = '" + dep.department_name + @"',
                                     group_name = '" + dep.group_name + @"',
                                     modified_date = '" + DateTime.Now + @"'
                                 WHERE department_id = " + dep.department_id + @"
                                ";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var dta = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    dta.Fill(dt);
                }

                return "Update Successfully";
            }
            catch (Exception err)
            {
                return "Failed to Update Becuase " + err.Message;
            }
        }

        public string Delete(int id)
        {
            try
            {
                DataTable dt = new DataTable();

                string query = @"delete from Departments where department_id = " + id;

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var dta = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    dta.Fill(dt);
                }

                return "Deleted Successfully";
            }
            catch (Exception err)
            {
                return "Failed to delete Becuase " + err.Message;
            }
        }

    }
}
