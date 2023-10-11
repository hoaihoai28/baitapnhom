using System.ComponentModel.DataAnnotations;

namespace PQGD.Models
{
    public class MonHoc
    {
        [Key]
        public int id_monhoc { get; set; }
        public string? tenmonhoc { get; set; }
    }
}

