using System.ComponentModel.DataAnnotations;

namespace PQGD.Models
{
    public class Lop
    {
        [Key]
        public int id_lop { get; set; }
        public string? tenlop { get; set; }
    }
}
