using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticari.Entities.Entities.Concrete;
using Ticari.Entities.EntityConfig.Abstract;

namespace Ticari.Entities.EntityConfig.Concrete
{
    public class Gsm116Config : BaseConfig<Gsm116>
    {
        public override void Configure(EntityTypeBuilder<Gsm116> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.Gsm)
                .HasMaxLength(20);

            builder.Property(p => p.TcNo)
                .HasMaxLength(20);
        }
    }
}
