using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Patient
    {
        public int Id { get; set; }

        public int UserId { get; set; }   

        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }

        public ICollection<Appointment>? Appointments { get; set; }
        public User? User { get; set; }
        public bool IsProfileCompleted { get; set; } = false;
    }
}
