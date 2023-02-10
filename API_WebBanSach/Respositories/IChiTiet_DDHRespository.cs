using QLBanSach_API.DTO;
using QLBanSach_API.Entity;

namespace QLBanSach_API.Respositories
{
    public interface IChiTiet_DDHRespository
    {
        public List<ChiTietDDH_DTO> GetAllChiTiet_DDH();
        public void InsertChiTiet_DDH(ChiTietDDH_DTO newChiTiet_DDH);
        public void UpdateChiTiet_DDH(ChiTietDDH_DTO newChiTiet_DDH);
        public void DeleteChiTiet_DDH(Guid MaDonHang, string MaSach);
    }
}
