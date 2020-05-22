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
    public class EmployeeController : ApiController
    {

        public HttpResponseMessage Get()
        {
            DataTable dt = new DataTable();

            string query = @"
                             select
                                employee_id,
                                employee_firstname,
                                employee_lastname,
                                department_id,
                                phone,
                                mail,
                                image_name,
                                image,
                                is_active,
                                convert(varchar(10), joining_date, 120) as joining_date,
                                convert(varchar(10), modified_date, 120) as modified_date
                             from Employees
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

        public string Post(Employee emp)
        {
            try
            {
                DataTable dt = new DataTable();

                string query = @"insert into Employees
                                   (employee_firstname,
                                    employee_lastname,
                                    department_id,
                                    phone,
                                    mail)
                                 values (
                                    '" + emp.employee_firstname + @"'
                                    ,'" + emp.employee_lastname + @"'
                                    ,'" + emp.department_id + @"'
                                    ,'" + emp.phone + @"'
                                    ,'" + emp.mail + @"'
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

        public string Put(Employee emp)
        {
            try
            {
                DataTable dt = new DataTable();

                string query = @"
                                UPDATE Employees
                                SET employee_firstname = '" + emp.employee_firstname + @"',
                                    employee_lastname = '" + emp.employee_lastname + @"',
                                    department_id = '" + emp.department_id + @"',
                                    phone = '" + emp.phone + @"',
                                    mail = '" + emp.mail + @"',
                                    modified_date = '" + DateTime.Now + @"'
                                WHERE employee_id = " + emp.employee_id + @"
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

                string query = @"delete from Employees where employee_id = " + id;

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
