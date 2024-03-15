using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLDT.Models;

namespace QLSV.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class StudentsController : ControllerBase
  {
    QlsvContext DB = new QlsvContext();

    [HttpGet("studentbyid")]

    public JsonResult studentbyid([FromQuery] string id)
    {
      var lst = from a in DB.Accounts
                join st in DB.Students on a.Id equals st.Id
                join cl in DB.Classes on st.IdClass equals cl.Id
                join co in DB.Cohorts on cl.IdCoh equals co.Id
                join dep in DB.Departments on co.IdDep equals dep.Id
                where st.Id == id
                select new
                {
                  st.Id,
                  a.Username,
                  a.Email,
                  a.Dateofbirth,
                  ClassName = cl.ClassesName,
                  CohortName = co.CohortName,
                  DepartmentName = dep.DepartmentName
                };

      
      if(lst.Any())
      {
        return new JsonResult(new { Message = "Succes", data = lst });
      }
      else { return new JsonResult(new { Message = "Error" });
      }

    }
        [HttpGet("hocky")]
        public JsonResult hocky() {
            var date = DateTime.Now;
            var lst = DB.Terms.Where(x => x.StartDate <= date && date <= x.EndDate);
            return new JsonResult(new { Message = "susses", data = lst });
        }
  }
}
