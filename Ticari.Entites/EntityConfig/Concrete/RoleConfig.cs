﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticari.Entities.Entities.Concrete;
using Ticari.Entities.EntityConfig.Abstract;

namespace Ticari.Entities.EntityConfig.Concrete
{
    public class RoleConfig : BaseConfig<Role>
    {
        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.RoleAdi)
                .HasMaxLength(50);
            builder.HasIndex(p => p.RoleAdi).IsUnique();
        }
    }
}
