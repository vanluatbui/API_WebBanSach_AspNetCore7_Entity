using QLBanSach_API.Entity;

namespace QLBanSach_API.DTO
{
    public class SachDTO
    {
        public string MaSach { get; set; }
        public string TenSach { get; set; }
        public double GiaBan { get; set; }
        public string MoTa { get; set; }
        public string AnhBia { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public int SoLuongTon { get; set; }
        public string MaChuDe { get; set; }
        public string MaNXB { get; set; }
    }
}
