using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticari.Entities.TurkiyeDb
{
    public partial class TblIlce
    {
        public short IlceId { get; set; }

        public short IlId { get; set; }

        public string? IlceAd { get; set; }
    }
}