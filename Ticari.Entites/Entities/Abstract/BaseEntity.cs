﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticari.Entities.Entities.Abstract
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate{ get; set; } = DateTime.Now;
    }
}
