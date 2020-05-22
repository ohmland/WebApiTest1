using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiTest1.Models
{
  public class Department
  {
    public int department_id { get; set; }
    public string department_name { get; set; }

    public string group_name { get; set; }

    public DateTime? modified_date { get; set; }
  }
}
