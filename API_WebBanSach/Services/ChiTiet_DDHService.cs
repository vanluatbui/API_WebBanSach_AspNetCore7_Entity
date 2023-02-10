using AutoMapper;
using Lib;
using QLBanSach_API.DTO;
using QLBanSach_API.Entity;
using QLBanSach_API.Respositories;

namespace QLBanSach_API.Services
{
    public class ChiTiet_DDHService : IChiTiet_DDHRespository
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;

        public ChiTiet_DDHService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void DeleteChiTiet_DDH(Guid MaDonHang, string MaSach)
        {
            ChiTietDDH CT = _context.ChiTietDDHs.FirstOrDefault(p => p.MaDonHang == MaDonHang && p.MaSach == MaSach);
            _context.ChiTietDDHs.Remove(CT);
            _context.SaveChanges();
        }

        public List<ChiTietDDH_DTO> GetAllChiTiet_DDH()
        {
            List<ChiTietDDH> ChiTietDDHs = _context.ChiTietDDHs.ToList();

            List<ChiTietDDH_DTO> listDetail_DDH = ChiTietDDHs.Select
                           (
                             emp => _mapper.Map<ChiTietDDH, ChiTietDDH_DTO>(emp)
                           ).ToList();

            return listDetail_DDH;
        }

        public void InsertChiTiet_DDH(ChiTietDDH_DTO newChiTietDDH)
        {
            _context.ChiTietDDHs.Add(_mapper.Map<ChiTietDDH_DTO, ChiTietDDH>(newChiTietDDH));
            _context.SaveChanges();
        }

        public void UpdateChiTiet_DDH(ChiTietDDH_DTO newChiTietDDH)
        {
            _context.ChiTietDDHs.Update(_mapper.Map<ChiTietDDH_DTO, ChiTietDDH>(newChiTietDDH));
            _context.SaveChanges();
        }
    }
}
