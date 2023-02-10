using QLBanSach_API.Entity;

namespace QLBanSach_API.DTO
{
    public class DonDatHangDTO
    {
        public Guid MaDonHang { get; set; }
        public bool DaThanhToan { get; set; }
        public bool DaGiaoHang { get; set; }
        public DateTime NgayDat { get; set; }
        public DateTime NgayGiao { get; set; }
        public string MaKH { get; set; }
    }
}
