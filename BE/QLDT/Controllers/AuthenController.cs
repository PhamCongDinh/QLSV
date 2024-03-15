using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLDT.Models;
using QLDT.Models.req;

namespace QLSV.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthenController : ControllerBase
  {
    QlsvContext DB = new QlsvContext();

    [HttpPost("login")]
    public JsonResult login([FromBody] Account auth)
    {
      var lst = DB.Accounts.Where(x=>x.Id.Equals(auth.Id) && x.Password.Equals(auth.Password)).First();
      if (lst != null)
      {
        if (lst.Role == 1)
        {
          return new JsonResult(new { Message = "student", data = lst });
        }
        else if (lst.Role == 2)
        {
          return new JsonResult(new { Message = "teacher", data = lst });

        }
        else { return new JsonResult(new { Message = "admin", data = lst }); }

      }
      else return new JsonResult(new { Message = "Error authen" });
    }


    [HttpPost("register")]
    public JsonResult register([FromBody] Register res)
    {
      var check = DB.Accounts.Any(x=>x.Id == res.Id);
      if (!check)
      {
        string[] parts = res.classes.Split('_');
        if (parts.Length >= 2)
        {
          string a = parts[0];
          string b = a.Substring(0,a.Length-1);
          string c = parts[1];

          var lop = (from cls in DB.Classes
                    join coh in DB.Cohorts on cls.IdCoh equals coh.Id
                    join dep in DB.Departments on coh.IdDep equals dep.Id
                    where cls.Abbreviations == a &&
                        coh.Abbreviations == c &&
                        dep.Abbreviations == b
                    select cls.Id).FirstOrDefault();
          var acc = new Account
          {
            Id = res.Id,
            Username = res.Username,
            Password = res.Password,
            Email = res.Email,
            Role = 1
          };
          DB.Accounts.Add(acc);
          var stu = new Student
          {
            Id = res.Id,
            IdClass = Convert.ToInt32(lop),
          };
          DB.Students.Add(stu);
          DB.SaveChanges();
          return new JsonResult(new { Message = "Success", dataAcc=acc,datastu= stu });
        }
        else
        {
          return new JsonResult(new { Message = "Error" });

        }
      }
      else
      {
        return new JsonResult(new { Message = "Error, account had" , data=check});

      }
    }
        
    }
}
