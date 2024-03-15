namespace QLDT.Models.req
{
    public class PointUpdateReq
    {
        public string studentId { get; set; }
        public string courseId { get; set; }
        public float pointProcess {  get; set; }
        public float pointTest { get; set; }
    }
}
