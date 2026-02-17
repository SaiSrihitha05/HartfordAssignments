using System.Globalization;

namespace BasicAuthentication.Models
{
    public class User
    {
        //(userid,firstname,lastname,email,
        //password,bool isActive=true,DateTime date= Datetime.now())
        public int userId { get; set; }
        public string firstName { get; set; }

        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public bool isActive { get; set; } = true;
        public DateTime date { get; set; } = DateTime.Now;

    }
}
