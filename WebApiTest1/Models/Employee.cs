using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiTest1.Models
{
  public class Employee
  {
    public int employee_id { get; set; }
    public string employee_firstname { get; set; }

    public string employee_lastname { get; set; }

    public int department_id { get; set; }

    public string phone { get; set; }

    public string mail { get; set; }

    public string image_name { get; set; }

    public string image { get; set; }

    public int is_active { get; set; }

    public DateTime? joining_date { get; set; }

    public DateTime? modified_date { get; set; }

  }
}
