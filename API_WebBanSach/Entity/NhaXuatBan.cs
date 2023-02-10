using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QLBanSach_API.Entity
{
    [Table("NhaXuatBan")]
    public class NhaXuatBan
    {
        public NhaXuatBan()
        {
            Sachs = new List<Sach>();
        }

        [Key]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(5)]
        public string MaNXB { get; set; }

        [MaxLength(50)]
        public string TenNXB { get; set; }

        [MaxLength(100)]
        public string DiaChi { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength(10)]
        public string DienThoai { get; set; }
        public List<Sach> Sachs { get; set; }
    }
}
