using AutoMapper;
using Lib;
using QLBanSach_API.DTO;
using QLBanSach_API.Entity;
using QLBanSach_API.Respositories;

namespace QLBanSach_API.Services
{
    public class DonDatHangService : IDonDatHangRespository
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;

        public DonDatHangService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void DeleteDonDatHang(Guid MaDonDatHang)
        {
            DonDatHang DDH = _context.DonDatHangs.FirstOrDefault(p => p.MaDonHang == MaDonDatHang);
            _context.DonDatHangs.Remove(DDH);
            _context.SaveChanges();
        }

        public List<DonDatHangDTO> GetAllDonDatHang()
        {
            List<DonDatHang> DonDatHangs = _context.DonDatHangs.ToList();

            List<DonDatHangDTO> listDonDatHang = DonDatHangs.Select
                          (
                            emp => _mapper.Map<DonDatHang, DonDatHangDTO>(emp)
                          ).ToList();
            return listDonDatHang;
        }

        public void InsertDonDatHang(DonDatHangDTO newDonDatHang)
        {
            _context.DonDatHangs.Add(_mapper.Map<DonDatHangDTO, DonDatHang>(newDonDatHang));
            _context.SaveChanges();
        }

        public void UpdateDonDatHang(DonDatHangDTO newDonDatHang)
        {
            _context.DonDatHangs.Update(_mapper.Map<DonDatHangDTO, DonDatHang>(newDonDatHang));
            _context.SaveChanges();
        }
    }
}
