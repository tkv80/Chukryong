using System;

namespace Chukryong.Entity
{
    internal class SiteEntity
    {
        public string Facility { get; set; }

        public int FacilityCode
        {
            get
            {
                var code = (FacilityType)Enum.Parse(typeof(FacilityType), this.Facility);
                return (int)code;
            }
            
        }
        public ReservationType Type { get; set; }
        public string SiteName { get; set; }
        public string SiteCode { get; set; }
        public int Cost { get; set; }
    }
}