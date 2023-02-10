using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QLBanSach_API.Entity
{
    [Table("DonDatHang")]
    public class DonDatHang
    {
        public DonDatHang()
        {
            chiTietDDHs = new List<ChiTietDDH>();
        }

        [Key]
        public Guid MaDonHang { get; set; }

        [Column(TypeName = "BIT")]
        public bool DaThanhToan { get; set; }

        [Column(TypeName = "BIT")]
        public bool DaGiaoHang { get; set; }
        public DateTime NgayDat { get; set; }
        public DateTime NgayGiao { get; set; }
        public string MaKH { get; set; }
        public User User { get; set; }
        public List<ChiTietDDH> chiTietDDHs { get; set; }
    }
}
