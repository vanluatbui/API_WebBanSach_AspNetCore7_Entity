using AutoMapper;
using Lib;
using QLBanSach_API.DTO;
using QLBanSach_API.Entity;
using QLBanSach_API.Respositories;

namespace QLBanSach_API.Services
{
    public class TacGia_SachService : ITacGia_SachRespository
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;

        public TacGia_SachService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void DeleteTacGia_Sach(string MaTacGia, string MaSach)
        {
            TacGia_Sach ts = _context.TacGia_Saches.FirstOrDefault(p => p.MaTacGia == MaTacGia && p.MaSach== MaSach);
            _context.TacGia_Saches.Remove(ts);
            _context.SaveChanges();
        }

        public List<TacGia_SachDTO> GetAllTacGia_Sach()
        {
            List<TacGia_Sach> TacGia_Sachs = _context.TacGia_Saches.ToList();

            List<TacGia_SachDTO> listTacGia_Sach = TacGia_Sachs.Select
                          (
                            emp => _mapper.Map<TacGia_Sach, TacGia_SachDTO>(emp)
                          ).ToList();
            return listTacGia_Sach;
        }

        public void InsertTacGia_Sach(TacGia_SachDTO newTacGia_Sache)
        {
            _context.TacGia_Saches.Add(_mapper.Map<TacGia_SachDTO, TacGia_Sach>(newTacGia_Sache));
            _context.SaveChanges();
        }

        public void UpdateTacGia_Sach(TacGia_SachDTO newTacGia_Sache)
        {
            _context.TacGia_Saches.Update(_mapper.Map<TacGia_SachDTO, TacGia_Sach>(newTacGia_Sache));
            _context.SaveChanges();
        }
    }
}
