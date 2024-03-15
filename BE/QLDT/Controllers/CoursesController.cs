using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLDT.Models;
using QLDT.Models.req;
using System.Collections.Generic;

namespace QLSV.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CoursesController : ControllerBase
  {
    QlsvContext DB = new QlsvContext();
        [HttpPost("cousrebyterm")]
        public JsonResult cousrebyterm([FromBody] Courseterm course)
        {
            var lst = from c in DB.Courses
                      join t in DB.Terms on c.IdTerm equals t.Id
                      join dep in DB.Departments on c.IdDep equals dep.Id
                      join coh in DB.Cohorts on c.IdCoh equals coh.Id
                      where coh.CohortName == course.CohName && dep.DepartmentName == course.depname && (DateTime.Now >= t.StartDate && DateTime.Now<= t.EndDate)
                      select new { 
                          c.Id,
                          c.CourseName
                      };
            return new JsonResult(new {message="Success", data = lst});
        }
        [HttpGet("coursebyid")]
        public JsonResult coursebyid([FromQuery] string id)
        {
            var lst = DB.Courses.Where(x=>x.Id ==id).ToList();
            return new JsonResult(new { message = "Success", data = lst });

        }
        [HttpPost("dkymon")]
        public JsonResult dkymon([FromBody] Point point)
        {
            point.Number = 1;

            var lst = DB.Points.Any(x=>x.IdStu == point.IdStu && x.IdCour==point.IdCour && x.Number==point.Number);
            if (!lst)
            {
                DB.Add(point);
                DB.SaveChanges();
                return new JsonResult(new { message = "Success", data = point });
            }
            else
            {
                return new JsonResult(new { Message = "Error" });
            }
            

        }
        [HttpGet("coursebystuId")]
        public JsonResult coursebystuId([FromQuery] string id)
        {
            var lst = from c in DB.Courses 
                      join p in DB.Points on c.Id equals p.IdCour
                      join stu in DB.Students on p.IdStu equals stu.Id
                      where stu.Id == id
                      select new
                      {
                          c.Id,
                          c.CourseName
                      };
            return new JsonResult(new { message = "Success", data = lst });

        }
        [HttpGet("pointbyid")]
        public JsonResult pointbyid([FromQuery] string id)
        {
            var lst = from c in DB.Courses
                      join p in DB.Points on c.Id equals p.IdCour
                      join stu in DB.Students on p.IdStu equals stu.Id
                      where stu.Id == id && p.PointProcess !=null
                      select new
                      {
                          c.Id,
                          c.CourseName,
                          p.PointProcess,
                          p.PointTest,
                          DiemKT = Math.Round((float)(p.PointProcess * 0.4f + p.PointTest * 0.6f), 1)

                      };
            return new JsonResult(new { message = "Success", data = lst });

        }
        [HttpDelete("huydky")]
        public JsonResult huydky([FromQuery] string id)
        {
            var pointsToDelete = DB.Points.Where(x => x.IdCour == id).ToList();
            DB.Points.RemoveRange(pointsToDelete);
            DB.SaveChanges();
            return new JsonResult("Success");

        }
    }
}
