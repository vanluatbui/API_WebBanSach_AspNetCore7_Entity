using QLBanSach_API.DTO;
using QLBanSach_API.Entity;

namespace QLBanSach_API.Respositories
{
    public interface IDonDatHangRespository
    {
        public List<DonDatHangDTO> GetAllDonDatHang();
        public void InsertDonDatHang(DonDatHangDTO newDonHang);
        public void UpdateDonDatHang(DonDatHangDTO newDonHang);
        public void DeleteDonDatHang(Guid MaDonHang);
    }
}
