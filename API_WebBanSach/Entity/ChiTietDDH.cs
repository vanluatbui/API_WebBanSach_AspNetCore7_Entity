using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QLBanSach_API.Entity
{
    [Table("ChiTiet_DonDatHang")]
    public class ChiTietDDH
    {
        public Guid MaDonHang { get; set; }
        public DonDatHang DonDatHang { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength(5)]
        public string MaSach { get; set; }
        public Sach Sach { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
    }
}
