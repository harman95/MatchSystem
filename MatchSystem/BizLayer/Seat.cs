using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchSystem.BizLayer
{
    public class Seat
    {
        public int ID { get; set; }
        public int SeatNumber { get; set; }
        public string SeatSide { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
