using System.ComponentModel.DataAnnotations;

namespace PQGD.Models
{
    public class HocKy
    {
        [Key]
        public int Id_hocky { get; set; }
        public string? tenhocky { get; set; }
        public string? namhoc { get; set; }
    }
}
