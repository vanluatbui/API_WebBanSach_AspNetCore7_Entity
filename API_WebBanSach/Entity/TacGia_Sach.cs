using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QLBanSach_API.Entity
{
    [Table("TacGia_Sach")]
    public class TacGia_Sach
    {
        [Column(TypeName = "VARCHAR")]
        [MaxLength(5)]
        public string MaTacGia { get; set; }
        public TacGia TacGia { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength(5)]
        public string MaSach { get; set; }
        public Sach Sach { get; set; }
    }
}
