namespace QLDT.Models.req
{
    public class Register
    {
        public string Id { get; set; } = null!;

        public string? Username { get; set; }

        public string? Email { get; set; }

        public string Password { get; set; } = null!;

        public DateOnly? Dateofbirth { get; set; }

        public string? Town { get; set; }

        public string? Images { get; set; }

        public int Role { get; set; }
        public string classes { get; set; }


    }
}
