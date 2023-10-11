using System.ComponentModel.DataAnnotations;

namespace PQGD.Models
{
    public class GiaoVien
    {
		[Key]
       public int id_giaovien { get; set; }

        public string? hoten { get; set; }
        public string?  gioitinh { get; set; }
        public DateTime ngaysinh { get; set; }
        public string? sdt { get; set; }
        public string? email { get; set; }
        public string? takhoan { get; set; }
        public string? matkhau { get; set; }
        public bool admin { get; set; }

    }
}
