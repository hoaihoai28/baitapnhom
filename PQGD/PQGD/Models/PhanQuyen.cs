using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PQGD.Models
{
  
    public class PhanQuyen
    {
        [Key]
        public int id_phanquyen { get; set; }

        [ForeignKey("GiaoVien")]
        public int id_giaovien { get; set; }
        public GiaoVien GiaoVien { get; set; }

        [ForeignKey("Lop")]
        public int id_lop { get; set; }
        public Lop Lop{ get; set; }

        [ForeignKey("MonHoc")]
        public int id_monhoc { get; set; }
        public MonHoc MonHoc{ get; set; }

        [ForeignKey("HocKy")]
        public int id_hocky { get; set; }
        public HocKy HocKy { get; set; }
    }
}
