namespace UserProject.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string Username { get; set; }
        public string EmailId { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }

        public int Age { get; private set; } // Computed column
        
    }
}
