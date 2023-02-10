using QLBanSach_API.DTO;
using QLBanSach_API.Entity;

namespace QLBanSach_API.Respositories
{
    public interface ITacGia_SachRespository
    {
        public List<TacGia_SachDTO> GetAllTacGia_Sach();
        public void InsertTacGia_Sach(TacGia_SachDTO newTacGia_Sach);
        public void UpdateTacGia_Sach(TacGia_SachDTO newTacGia_Sach);
        public void DeleteTacGia_Sach(string MaTacGia, string MaSach);
    }
}
