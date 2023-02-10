using QLBanSach_API.DTO;
using QLBanSach_API.Entity;

namespace QLBanSach_API.Respositories
{
    public interface ISachRespository
    {
        public List<SachDTO> GetAllSach();
        public void InsertSach(SachDTO newSach);
        public void UpdateSach(SachDTO newSach);
        public void DeleteSach(string MaSach);
    }
}
