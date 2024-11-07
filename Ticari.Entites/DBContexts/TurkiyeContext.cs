using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticari.Entities.TurkiyeDb;

namespace Ticari.Entities.DBContexts
{
    public partial class TurkiyeContext : DbContext
    {
        public TurkiyeContext()
        {
        }

        public TurkiyeContext(DbContextOptions<TurkiyeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblIl> TblIls { get; set; }

        public virtual DbSet<TblIlce> TblIlces { get; set; }

        public virtual DbSet<TblMahalle> TblMahalles { get; set; }

        public virtual DbSet<TblPk> TblPks { get; set; }

        public virtual DbSet<TblSemt> TblSemts { get; set; }

        public virtual DbSet<VwTumunugoster> VwTumunugosters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseSqlServer("server=DESKTOP-2KPKJ12;Database=TicariPaket;Trusted_Connection=true;TrustServerCertificate=true");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblIl>(entity =>
            {
                entity.HasKey(e => e.IlId).HasName("PK_tbl_iller");

                entity.ToTable("tbl_il");

                entity.Property(e => e.IlId).HasColumnName("il_id");
                entity.Property(e => e.IlAd)
                    .HasMaxLength(16)
                    .UseCollation("Turkish_CI_AS")
                    .HasColumnName("il_ad");
            });

            modelBuilder.Entity<TblIlce>(entity =>
            {
                entity.HasKey(e => e.IlceId);

                entity.ToTable("tbl_ilce");

                entity.HasIndex(e => new { e.IlceId, e.IlId }, "IX_ilce");

                entity.Property(e => e.IlceId).HasColumnName("ilce_id");
                entity.Property(e => e.IlId).HasColumnName("il_id");
                entity.Property(e => e.IlceAd)
                    .HasMaxLength(32)
                    .UseCollation("Turkish_CI_AS")
                    .HasColumnName("ilce_ad");
            });

            modelBuilder.Entity<TblMahalle>(entity =>
            {
                entity.HasKey(e => e.MahalleId);

                entity.ToTable("tbl_mahalle");

                entity.HasIndex(e => new { e.MahalleId, e.SemtId }, "IX_mahalle");

                entity.Property(e => e.MahalleId).HasColumnName("mahalle_id");
                entity.Property(e => e.MahalleAd)
                    .HasMaxLength(40)
                    .UseCollation("Turkish_CI_AS")
                    .HasColumnName("mahalle_ad");
                entity.Property(e => e.PkId).HasColumnName("pk_id");
                entity.Property(e => e.SemtId).HasColumnName("semt_id");
            });

            modelBuilder.Entity<TblPk>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("tbl_pk");

                entity.Property(e => e.Kod)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))")
                    .IsFixedLength()
                    .UseCollation("Turkish_CI_AS")
                    .HasColumnName("kod");
                entity.Property(e => e.PkId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("pk_id");
            });

            modelBuilder.Entity<TblSemt>(entity =>
            {
                entity.HasKey(e => e.SemtId).HasName("PK_tbl_semtler");

                entity.ToTable("tbl_semt");

                entity.HasIndex(e => new { e.SemtId, e.IlceId }, "IX_semt");

                entity.Property(e => e.SemtId).HasColumnName("semt_id");
                entity.Property(e => e.IlceId).HasColumnName("ilce_id");
                entity.Property(e => e.SemtAd)
                    .HasMaxLength(32)
                    .UseCollation("Turkish_CI_AS")
                    .HasColumnName("semt_ad");
            });

            modelBuilder.Entity<VwTumunugoster>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("vw_tumunugoster");

                entity.Property(e => e.IlAd)
                    .HasMaxLength(16)
                    .UseCollation("Turkish_CI_AS")
                    .HasColumnName("il_ad");
                entity.Property(e => e.IlceAd)
                    .HasMaxLength(32)
                    .UseCollation("Turkish_CI_AS")
                    .HasColumnName("ilce_ad");
                entity.Property(e => e.Kod)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .UseCollation("Turkish_CI_AS")
                    .HasColumnName("kod");
                entity.Property(e => e.MahalleAd)
                    .HasMaxLength(40)
                    .UseCollation("Turkish_CI_AS")
                    .HasColumnName("mahalle_ad");
                entity.Property(e => e.SemtAd)
                    .HasMaxLength(32)
                    .UseCollation("Turkish_CI_AS")
                    .HasColumnName("semt_ad");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    } 
}
