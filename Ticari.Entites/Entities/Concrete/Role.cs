using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticari.Entities.Entities.Abstract;

namespace Ticari.Entities.Entities.Concrete
{
    public class Role : BaseEntity
    {
        public string RoleAdi { get; set; }
        public List<MyUser> Users { get; set; }
    }
}
