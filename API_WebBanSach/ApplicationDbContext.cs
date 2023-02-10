
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using QLBanSach_API.Entity;
using System;
using System.Diagnostics;
using System.Reflection.Emit;

namespace Lib
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<ChuDe> ChuDes { get; set; }
        public DbSet<DonDatHang> DonDatHangs { get; set; }
        public DbSet<NhaXuatBan> NhaXuatBans { get; set; }
        public DbSet<TacGia> TacGias { get; set; }
        public DbSet<TacGia_Sach> TacGia_Saches { get; set; }
        public DbSet<Sach> Saches { get; set; }
        public DbSet<ChiTietDDH> ChiTietDDHs { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //TABLE Sach :
  
                // ONE TO MANY
            builder.Entity<ChuDe>()
    .HasMany<Sach>(p => p.Sachs)
    .WithOne(q => q.ChuDe)
    .HasForeignKey(s => s.MaChuDe);

            builder.Entity<NhaXuatBan>()
   .HasMany<Sach>(p => p.Sachs)
   .WithOne(q => q.NhaXuatBan)
   .HasForeignKey(s => s.MaNXB);

          //TABLE DonDatHang :

            // ONE TO MANY
            builder.Entity<User>()
    .HasMany<DonDatHang>(p => p.donDatHangs)
    .WithOne(q => q.User)
    .HasForeignKey(s => s.MaKH);

        // TABLE TacGia_Sach :
            builder.Entity<TacGia_Sach>(entity =>
            {
                entity.HasKey(p => new { p.MaTacGia, p.MaSach});
            });

            // MANY TO MANY :
            builder.Entity<TacGia_Sach>()
    .HasOne<TacGia>(p => p.TacGia)
    .WithMany(q => q.TacGia_Saches)
    .HasForeignKey(s => s.MaTacGia);

            builder.Entity<TacGia_Sach>()
    .HasOne<Sach>(p => p.Sach)
    .WithMany(q => q.TacGia_Saches)
    .HasForeignKey(s => s.MaSach);

            // TABLE Chitiet_DDH :
            builder.Entity<ChiTietDDH>(entity =>
            {
                entity.HasKey(p => new { p.MaDonHang, p.MaSach });
            });

            // MANY TO MANY :
            builder.Entity<ChiTietDDH>()
    .HasOne<DonDatHang>(p => p.DonDatHang)
    .WithMany(q => q.chiTietDDHs)
    .HasForeignKey(s => s.MaDonHang);

            builder.Entity<ChiTietDDH>()
    .HasOne<Sach>(p => p.Sach)
    .WithMany(q => q.chiTietDDHs)
    .HasForeignKey(s => s.MaSach);
       }
    }
}
