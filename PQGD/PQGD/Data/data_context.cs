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

            option.UseSqlServer("Server=DESKTOP-3DVT19E\\SQLEXPRESS; Database = PQGD;" +
                "User ID=sa;Password=123;Trusted_Connection=True;TrustServerCertificate=True;");
            //option.UseSqlServer("server=DESKTOP-3DVT19E\\SQLEXPRESS;database=zoo;trusted_connection=true;TrustServerCertificate=True;");
            //Integrated Security = False
        }

        public DbSet<PQGD.Models.GiaoVien>? GiaoVien { get; set; }

        public DbSet<PQGD.Models.PhanQuyen>? PhanQuyen { get; set; }

        public DbSet<PQGD.Models.HocKy>? HocKy { get; set; }


    }
}
