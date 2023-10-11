using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PQGD.Models
{
    [PrimaryKey( nameof(id_giaovien), nameof(id_lop),  nameof(id_monhoc), nameof(id_hocky))]
    public class PhanQuyen
    {
  
        public int id_giaovien { get; set; }


        public int id_lop { get; set; }


        public int id_monhoc { get; set; }
    

        public int id_hocky { get; set; }

    }
}
