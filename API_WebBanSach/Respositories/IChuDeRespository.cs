using QLBanSach_API.DTO;
using QLBanSach_API.Entity;

namespace QLBanSach_API.Respositories
{
    public interface IChuDeRespository
    {
            public List<ChuDeDTO> GetAllChuDe();
            public void InsertChuDe(ChuDeDTO newChuDe);
            public void UpdateChuDe(ChuDeDTO newChuDe);
            public void DeleteChuDe(string MaChuDe);
    }
}
