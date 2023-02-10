using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QLBanSach_API.Entity
{
    [Table("TacGia")]
    public class TacGia
    {
        public TacGia()
        {
            TacGia_Saches = new List<TacGia_Sach>();
        }

        [Key]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(5)]
        public string MaTacGia { get; set; }

        [MaxLength(50)]
        public string TenTacGia { get; set; }

        [MaxLength(100)]
        public string DiaChi { get; set; }
        public List<TacGia_Sach> TacGia_Saches { get; set; }
    }
}
