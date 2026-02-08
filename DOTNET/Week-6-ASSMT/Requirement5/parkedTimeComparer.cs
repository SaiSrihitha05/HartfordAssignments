using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirement5
{
    // Compares vehicles based on parked time
    public class parkedTimeComparer:IComparer<Vehicle>
    {
        public int Compare(Vehicle? x, Vehicle? y)
        {
            return x.Ticket.ParkedTime.CompareTo(y.Ticket.ParkedTime);
        }

    }
}
