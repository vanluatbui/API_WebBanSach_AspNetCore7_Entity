using AutoMapper;
using Lib;
using QLBanSach_API.DTO;
using QLBanSach_API.Entity;
using QLBanSach_API.Respositories;

namespace QLBanSach_API.Services
{
    public class TacGiaService : ITacGiaRespository
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;

        public TacGiaService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void DeleteTacGia(string MaTacGia)
        {
            TacGia TG = _context.TacGias.FirstOrDefault(p => p.MaTacGia == MaTacGia);
            _context.TacGias.Remove(TG);
            _context.SaveChanges();
        }

        public List<TacGiaDTO> GetAllTacGia()
        {
            List<TacGia> TacGias = _context.TacGias.ToList();

            List<TacGiaDTO> listTacGia = TacGias.Select
                          (
                            emp => _mapper.Map<TacGia, TacGiaDTO>(emp)
                          ).ToList();
            return listTacGia;
        }

        public void InsertTacGia(TacGiaDTO newTacGia)
        {
            _context.TacGias.Add(_mapper.Map<TacGiaDTO, TacGia>(newTacGia));
            _context.SaveChanges();
        }

        public void UpdateTacGia(TacGiaDTO newTacGia)
        {
            _context.TacGias.Update(_mapper.Map<TacGiaDTO, TacGia>(newTacGia));
            _context.SaveChanges();
        }
    }
}
