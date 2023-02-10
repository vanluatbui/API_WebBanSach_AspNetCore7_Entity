using QLBanSach_API.DTO;
using QLBanSach_API.Entity;

namespace QLBanSach_API.Respositories
{
    public interface INhaXuatBanRespository
    {
            public List<NhaXuatBanDTO> GetAllNhaXuatBan();
            public void InsertNhaXuatBan(NhaXuatBanDTO newNhaXuatBan);
            public void UpdateNhaXuatBan(NhaXuatBanDTO newNhaXuatBan);
            public void DeleteNhaXuatBan(string MaNhaXuatBan);
    }
}
