using QLBanSach_API.DTO;
using QLBanSach_API.Entity;

namespace QLBanSach_API.Respositories
{
    public interface ITacGiaRespository
    {
        public List<TacGiaDTO> GetAllTacGia();
        public void InsertTacGia(TacGiaDTO newTacGia);
        public void UpdateTacGia(TacGiaDTO newTacGia);
        public void DeleteTacGia(string MaTacGia);
    }
}
