using AutoMapper;
using Lib;
using QLBanSach_API.DTO;
using QLBanSach_API.Entity;
using QLBanSach_API.Respositories;

namespace QLBanSach_API.Services
{
    public class SachService : ISachRespository
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;

        public SachService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void DeleteSach(string MaSach)
        {
            Sach s = _context.Saches.FirstOrDefault(p => p.MaSach == MaSach);
            _context.Saches.Remove(s);
            _context.SaveChanges();
        }

        public List<SachDTO> GetAllSach()
        {
            List<Sach> Sachs = _context.Saches.ToList();

            List<SachDTO> listSach = Sachs.Select
                          (
                            emp => _mapper.Map<Sach, SachDTO>(emp)
                          ).ToList();
            return listSach;
        }

        public void InsertSach(SachDTO newSach)
        {
            _context.Saches.Add(_mapper.Map<SachDTO, Sach>(newSach));
            _context.SaveChanges();
        }

        public void UpdateSach(SachDTO newSach)
        {
            _context.Saches.Update(_mapper.Map<SachDTO, Sach>(newSach));
            _context.SaveChanges();
        }
    }
}
