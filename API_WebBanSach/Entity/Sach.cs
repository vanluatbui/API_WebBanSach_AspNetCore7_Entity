using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QLBanSach_API.Entity
{
    [Table("Sach")]
    public class Sach
    {
        public Sach()
        {
            TacGia_Saches = new List<TacGia_Sach>();
            chiTietDDHs = new List<ChiTietDDH>();
        }

        [Key]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(5)]
        public string MaSach { get; set; }

        [MaxLength(50)]
        public string TenSach { get; set; }
        public double GiaBan { get; set; }

        [MaxLength(100)]
        public string MoTa { get; set; }

        [MaxLength(100)]
        public string AnhBia { get; set; }

        public DateTime NgayCapNhat { get; set; }
        public int SoLuongTon { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength(5)]
        public string MaChuDe { get; set; }
        public ChuDe ChuDe { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength(5)]
        public string MaNXB { get; set; }
        public NhaXuatBan NhaXuatBan { get; set; }
        public List<TacGia_Sach> TacGia_Saches { get; set; }
        public List<ChiTietDDH> chiTietDDHs { get; set; }
    }
}
