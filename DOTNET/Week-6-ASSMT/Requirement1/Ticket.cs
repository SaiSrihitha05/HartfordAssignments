using System;

namespace Requirement1
{
    public class Ticket
    {
        public Ticket()
        {
        }

        public Ticket(string _ticketNo, DateTime _parkedTime, double _cost)
        {
            this._ticketNo = _ticketNo;
            this._parkedTime = _parkedTime;
            this._cost = _cost;
        }

        private string _ticketNo;

        public string TicketNo
        {
            get { return _ticketNo; }
            set { _ticketNo = value; }
        }

        private DateTime _parkedTime;

        public DateTime ParkedTime
        {
            get { return _parkedTime; }
            set { _parkedTime = value; }
        }

        private double _cost;

        public double Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }
    }
}
