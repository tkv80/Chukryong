using System;
using System.Collections.Generic;

namespace Chukryong.Entity
{
    class Reservation
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Cost { get; set; }
        public int UserCount { get; set; }
        public SiteEntity Site{ get; set; }
        public ClientInfo Client { get; set; }
    }
}
