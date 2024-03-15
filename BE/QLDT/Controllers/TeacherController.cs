using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLDT.Models;
using QLDT.Models.req;

namespace QLDT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        QlsvContext DB = new QlsvContext();
        [HttpGet("coursebyidteach")]
        public JsonResult coursebyidteach([FromQuery] string id)
        {
            var lst = from c in DB.Courses
                      join tlc in DB.TeacherClassCours on c.Id equals tlc.IdCour
                      join t in DB.Teachers on tlc.IdTeacher equals t.Id
                      where t.Id == id
                      select new
                      {
                          c.Id,
                          c.CourseName
                      };
            return new JsonResult(new { message = "Success", data = lst });
        }

        [HttpGet("studbyidcou")]
        public JsonResult studbyidcou([FromQuery] string id)
        {
            var lst = from c in DB.Courses
                      join p in DB.Points on c.Id equals p.IdCour
                      join stu in DB.Students on p.IdStu equals stu.Id
                      join ac in DB.Accounts on stu.Id equals ac.Id
                      join cl in DB.Classes on stu.IdClass equals cl.Id
                      join coh in DB.Cohorts on cl.IdCoh equals coh.Id
                      where c.Id == id
                      select new
                      {
                          c.Id,
                          c.CourseName,
                          studentid=ac.Id,
                          ac.Username,
                          cl.ClassesName,
                          coh.CohortName,
                          p.PointProcess,
                          p.PointTest

                      };
            return new JsonResult(new { message = "Success", data = lst });

        }






        [HttpPost("update-scores")]
        public JsonResult UpdateScores([FromBody] List<PointUpdateReq> pointUpdates)
        {
            try
            {
                foreach (var update in pointUpdates)
                {
                    var point = DB.Points.FirstOrDefault(p => p.IdStu == update.studentId && p.IdCour == update.courseId);
                    if (point != null)
                    {
                        point.PointProcess = update.pointProcess;
                        point.PointTest = update.pointTest;
                        DB.SaveChanges();
                    }
                    else
                    {
                        // Handle the case where the point doesn't exist
                    }
                }

                return new JsonResult("Scores updated successfully");
            }
            catch (Exception ex)
            {
                return new JsonResult(500, "An error occurred while updating scores: " + ex.Message);
            }
        }

    }
}
