using QLBanSach_API.Entity;

namespace QLBanSach_API.DTO
{
    public class ChiTietDDH_DTO
    {
        public Guid MaDonHang { get; set; }
        public string MaSach { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
    }
}
