using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticari.Entities.TurkiyeDb
{
    public class TblMahalle
    {
        public int MahalleId { get; set; }

        public short SemtId { get; set; }

        public string? MahalleAd { get; set; }

        public short? PkId { get; set; }
    }
}
