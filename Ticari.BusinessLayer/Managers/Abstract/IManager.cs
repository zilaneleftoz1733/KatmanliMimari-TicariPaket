using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticari.DataAccsessLayer.GenericRepository.ECore.Abstract;
using Ticari.Entities.Entities.Abstract;

namespace Ticari.BusinessLayer.Managers.Abstract
{
    public interface IManager<T> :IRepository<T> where T :BaseEntity
    {
    }
}
