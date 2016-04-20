// *
// * @author  모바일 기술팀 KTG
// * @date    2013년 9월 6일 금요일 오전 10:49:21
// *

using System.Collections.Generic;
using System.Linq;
using Chukryong.Entity;

namespace Chukryong
{
    internal class SiteEntityManager
    {
        private readonly List<SiteEntity> _sites;

        public SiteEntityManager()
        {
            _sites = new List<SiteEntity>
            {
                new SiteEntity
                {
                    Type = ReservationType.축령산자연휴양림,
                    Facility = "야영데크",
                    SiteName = "야영데크101(6×6)",
                    SiteCode = "501",
                    Cost = 6000,
                },
                new SiteEntity
                {
                    Type = ReservationType.축령산자연휴양림,
                    Facility = "야영데크",
                    SiteName = "야영데크102(6×6)",
                    SiteCode = "502",
                    Cost = 6000,
                },
                new SiteEntity
                {
                    Type = ReservationType.축령산자연휴양림,
                    Facility = "야영데크",
                    SiteName = "야영데크103(3×3)",
                    SiteCode = "503",
                    Cost = 4000,
                },
                new SiteEntity
                {
                    Type = ReservationType.축령산자연휴양림,
                    Facility = "야영데크",
                    SiteName = "야영데크104(3×3)",
                    SiteCode = "504"
                },
                new SiteEntity
                {
                    Type = ReservationType.축령산자연휴양림,
                    Facility = "야영데크",
                    SiteName = "야영데크105(3×3)",
                    SiteCode = "505",
                    Cost = 4000,
                },
                new SiteEntity
                {
                    Type = ReservationType.축령산자연휴양림,
                    Facility = "야영데크",
                    SiteName = "야영데크106(6×6)",
                    SiteCode = "506",
                    Cost = 6000,
                },
                new SiteEntity
                {
                    Type = ReservationType.축령산자연휴양림,
                    Facility = "야영데크",
                    SiteName = "야영데크107(4×4)",
                    SiteCode = "507",
                    Cost = 4000,
                },
                new SiteEntity
                {
                    Type = ReservationType.축령산자연휴양림,
                    Facility = "야영데크",
                    SiteName = "야영데크108(3×3)",
                    SiteCode = "508",
                    Cost = 4000,
                },
                new SiteEntity
                {
                    Type = ReservationType.축령산자연휴양림,
                    Facility = "야영데크",
                    SiteName = "야영데크109(3×3)",
                    SiteCode = "509",
                    Cost = 4000,
                },
                new SiteEntity
                {
                    Type = ReservationType.축령산자연휴양림,
                    Facility = "야영데크",
                    SiteName = "야영데크110(3×3)",
                    SiteCode = "510",
                    Cost = 4000,
                },
                new SiteEntity
                {
                    Type = ReservationType.축령산자연휴양림,
                    Facility = "야영데크",
                    SiteName = "야영데크201(3×3)",
                    SiteCode = "601",
                    Cost = 4000,
                },
                new SiteEntity
                {
                    Type = ReservationType.축령산자연휴양림,
                    Facility = "야영데크",
                    SiteName = "야영데크202(3×3)",
                    SiteCode = "602",
                    Cost = 4000,
                },
                new SiteEntity
                {
                    Type = ReservationType.축령산자연휴양림,
                    Facility = "야영데크",
                    SiteName = "야영데크203(3×3)",
                    SiteCode = "603",
                    Cost = 4000,
                },
                new SiteEntity
                {
                    Type = ReservationType.축령산자연휴양림,
                    Facility = "야영데크",
                    SiteName = "야영데크204(6×6)",
                    SiteCode = "604",
                    Cost = 6000,
                },
                new SiteEntity
                {
                    Type = ReservationType.축령산자연휴양림,
                    Facility = "야영데크",
                    SiteName = "야영데크205(4×4)",
                    SiteCode = "605",
                    Cost = 4000,
                },
                new SiteEntity
                {
                    Type = ReservationType.축령산자연휴양림,
                    Facility = "야영데크",
                    SiteName = "야영데크206(3×3)",
                    SiteCode = "606",
                    Cost = 4000,
                },
                new SiteEntity
                {
                    Type = ReservationType.축령산자연휴양림,
                    Facility = "야영데크",
                    SiteName = "야영데크207(4×4)",
                    SiteCode = "607",
                    Cost = 4000,
                },
                new SiteEntity
                {
                    Type = ReservationType.축령산자연휴양림,
                    Facility = "야영데크",
                    SiteName = "야영데크208(3×3)",
                    SiteCode = "608",
                    Cost = 4000,
                },
                new SiteEntity
                {
                    Type = ReservationType.축령산자연휴양림,
                    Facility = "야영데크",
                    SiteName = "야영데크209(3×3)",
                    SiteCode = "609",
                    Cost = 4000,
                },
                new SiteEntity
                {
                    Type = ReservationType.축령산자연휴양림,
                    Facility = "야영데크",
                    SiteName = "야영데크210(4×4)",
                    SiteCode = "610",
                    Cost = 4000,
                },
                new SiteEntity
                {
                    Type = ReservationType.축령산자연휴양림,
                    Facility = "야영데크",
                    SiteName = "야영데크211(3×3)",
                    SiteCode = "611",
                    Cost = 4000,
                },
                new SiteEntity
                {
                    Type = ReservationType.축령산자연휴양림,
                    Facility = "야영데크",
                    SiteName = "야영데크212(4×4)",
                    SiteCode = "612",
                    Cost = 4000,
                },
                new SiteEntity
                {
                    Type = ReservationType.축령산자연휴양림,
                    Facility = "야영데크",
                    SiteName = "야영데크213(4×4)",
                    SiteCode = "613",
                    Cost = 4000,
                },
                new SiteEntity
                {
                    Type = ReservationType.축령산자연휴양림,
                    Facility = "야영데크",
                    SiteName = "야영데크214(4×4)",
                    SiteCode = "614",
                    Cost = 4000,
                },
                new SiteEntity
                {
                    Type = ReservationType.축령산자연휴양림,
                    Facility = "야영데크",
                    SiteName = "야영데크215(4×4)",
                    SiteCode = "615",
                    Cost = 4000,
                },
                new SiteEntity
                {
                    Type = ReservationType.축령산자연휴양림,
                    Facility = "야영데크",
                    SiteName = "야영데크216(4×4)",
                    SiteCode = "616",
                    Cost = 4000,
                },
                new SiteEntity
                {
                    Type = ReservationType.축령산자연휴양림,
                    Facility = "야영데크",
                    SiteName = "야영데크217(4×4)",
                    SiteCode = "617",
                    Cost = 4000,
                },
                new SiteEntity
                {
                    Type = ReservationType.축령산자연휴양림,
                    Facility = "야영데크",
                    SiteName = "야영데크301(4×4)",
                    SiteCode = "701",
                    Cost = 4000,
                },
                new SiteEntity
                {
                    Type = ReservationType.축령산자연휴양림,
                    Facility = "야영데크",
                    SiteName = "야영데크302(4×4)",
                    SiteCode = "702",
                    Cost = 4000,
                },
                new SiteEntity
                {
                    Type = ReservationType.축령산자연휴양림,
                    Facility = "야영데크",
                    SiteName = "야영데크303(4×4)",
                    SiteCode = "703",
                    Cost = 4000,
                },
                new SiteEntity
                {
                    Type = ReservationType.축령산자연휴양림,
                    Facility = "야영데크",
                    SiteName = "야영데크304(4×4)",
                    SiteCode = "704",
                    Cost = 4000,
                },
                new SiteEntity
                {
                    Type = ReservationType.축령산자연휴양림,
                    Facility = "야영데크",
                    SiteName = "야영데크305(4×4)",
                    SiteCode = "705",
                    Cost = 4000,
                },
                new SiteEntity
                {
                    Type = ReservationType.축령산자연휴양림,
                    Facility = "야영데크",
                    SiteName = "야영데크306(4×4)",
                    SiteCode = "706",
                    Cost = 4000,
                },
                new SiteEntity
                {
                    Type = ReservationType.축령산자연휴양림,
                    Facility = "야영데크",
                    SiteName = "야영데크307(4×4)",
                    SiteCode = "707",
                    Cost = 4000,
                },
                new SiteEntity
                {
                    Type = ReservationType.축령산자연휴양림,
                    Facility = "야영데크",
                    SiteName = "야영데크308(3×3)",
                    SiteCode = "708",
                    Cost = 4000,
                },
                new SiteEntity
                {
                    Type = ReservationType.축령산자연휴양림,
                    Facility = "야영데크",
                    SiteName = "야영데크309(4×4)",
                    SiteCode = "709",
                    Cost = 4000,
                },
                new SiteEntity
                {
                    Type = ReservationType.축령산자연휴양림,
                    Facility = "야영데크",
                    SiteName = "야영데크310(4×4)",
                    SiteCode = "710",
                    Cost = 4000,
                },
                new SiteEntity
                {
                    Type = ReservationType.축령산자연휴양림,
                    Facility = "야영데크",
                    SiteName = "야영데크311(3×3)",
                    SiteCode = "711",
                    Cost = 4000,
                },
                new SiteEntity
                {
                    Type = ReservationType.축령산자연휴양림,
                    Facility = "야영데크",
                    SiteName = "야영데크312(4×4)",
                    SiteCode = "712",
                    Cost = 4000,
                },
                new SiteEntity
                {
                    Type = ReservationType.축령산자연휴양림,
                    Facility = "야영데크",
                    SiteName = "야영데크313(4×4)",
                    SiteCode = "713",
                    Cost = 4000,
                },
                new SiteEntity
                {
                    Type = ReservationType.축령산자연휴양림,
                    Facility = "야영데크",
                    SiteName = "야영데크401(3×3)",
                    SiteCode = "801",
                    Cost = 4000,
                },
                new SiteEntity
                {
                    Type = ReservationType.축령산자연휴양림,
                    Facility = "야영데크",
                    SiteName = "야영데크402(4×4)",
                    SiteCode = "802",
                    Cost = 4000,
                },
                new SiteEntity
                {
                    Type = ReservationType.축령산자연휴양림,
                    Facility = "야영데크",
                    SiteName = "야영데크403(4×4)",
                    SiteCode = "803",
                    Cost = 4000,
                },
                new SiteEntity
                {
                    Type = ReservationType.축령산자연휴양림,
                    Facility = "야영데크",
                    SiteName = "야영데크404(4×4)",
                    SiteCode = "804",
                    Cost = 4000,
                },
                new SiteEntity
                {
                    Type = ReservationType.축령산자연휴양림,
                    Facility = "야영데크",
                    SiteName = "야영데크405(4×4)",
                    SiteCode = "805",
                    Cost = 4000,
                },
                new SiteEntity
                {
                    Type = ReservationType.축령산자연휴양림,
                    Facility = "야영데크",
                    SiteName = "야영데크406(4×4)",
                    SiteCode = "806",
                    Cost = 4000,
                },

            };

            #region 축령산

            #endregion

            //_sites
            //@"00000001|00000002|00000003|00000004|00000005|00000006|00000007|00000008|00000009|00000010|00000011|00000012|00000013|00000014|00000015|00000016|00000017|00000018|00000019|00000020|00000021|00000047|00000048|00000049|00000050|00000051|00000052|00000053|00000054|00000055|00000056|00000057|00000058|00000059|00000060|00000061|00000062|00000063|00000064|00000065|00000066|00000067|00000068|00000069|00000070|00000071|00000072|00000073|"
        }

        public List<SiteEntity> Sites(ReservationType type)
        {
            return _sites.Where(t => t.Type == type).ToList();
        }
    }
}