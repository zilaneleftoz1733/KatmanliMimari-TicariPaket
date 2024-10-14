using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticari.BusinessLayer.Managers.Abstract;
using Ticari.DataAccsessLayer.GenericRepository.ECore.Abstract;
using Ticari.DataAccsessLayer.GenericRepository.ECore.Concrete;
using Ticari.Entities.Entities.Abstract;

namespace Ticari.BusinessLayer.Managers.Concrete
{
    public class Manager<T> : Repository<T>,IManager<T> where T : BaseEntity
    {
    }
}
