using Microsoft.EntityFrameworkCore;
using PQGD.Models;

namespace PQGD.Data
{
    public class data_context : DbContext
    {
        public data_context()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {

            option.UseSqlServer("Server=LAPTOP-O9SMJSLO\\SQLEXPRESS; Database = PQGD;" +
                "User ID=sa;Password=123;Trusted_Connection=True;TrustServerCertificate=True;");
            
        }

        public DbSet<PhanQuyen> PhanQuyens { get; set; }
        public DbSet<GiaoVien> GiaoViens { get; set; }
        public DbSet<Lop> Lops { get; set; }
        public DbSet<MonHoc> MonHocs { get; set; }
        public DbSet<HocKy> HocKys { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình các mối quan hệ giữa các bảng
            modelBuilder.Entity<PhanQuyen>()
                .HasOne(pq => pq.GiaoVien)
                .WithMany()
                .HasForeignKey(pq => pq.id_giaovien);

            modelBuilder.Entity<PhanQuyen>()
                .HasOne(pq => pq.Lop)
                .WithMany()
                .HasForeignKey(pq => pq.id_lop);

            modelBuilder.Entity<PhanQuyen>()
                .HasOne(pq => pq.MonHoc)
                .WithMany()
                .HasForeignKey(pq => pq.id_monhoc);

            modelBuilder.Entity<PhanQuyen>()
                .HasOne(pq => pq.HocKy)
                .WithMany()
                .HasForeignKey(pq => pq.id_hocky);
        }
    }
}
