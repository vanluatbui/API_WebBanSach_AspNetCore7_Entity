using AutoMapper;
using Lib;
using QLBanSach_API.DTO;
using QLBanSach_API.Entity;
using QLBanSach_API.Respositories;

namespace QLBanSach_API.Services
{
    public class NhaXuatBanService : INhaXuatBanRespository
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;

        public NhaXuatBanService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void DeleteNhaXuatBan(string MaNhaXuatBan)
        {
            NhaXuatBan NXB = _context.NhaXuatBans.FirstOrDefault(p => p.MaNXB == MaNhaXuatBan);
            _context.NhaXuatBans.Remove(NXB);
            _context.SaveChanges();
        }

        public List<NhaXuatBanDTO> GetAllNhaXuatBan()
        {
            List<NhaXuatBan> NhaXuatBans = _context.NhaXuatBans.ToList();

            List<NhaXuatBanDTO> listNhaXuatBan = NhaXuatBans.Select
                          (
                            emp => _mapper.Map<NhaXuatBan, NhaXuatBanDTO>(emp)
                          ).ToList();
            return listNhaXuatBan;
        }

        public void InsertNhaXuatBan(NhaXuatBanDTO newNhaXuatBan)
        {
            _context.NhaXuatBans.Add(_mapper.Map<NhaXuatBanDTO, NhaXuatBan>(newNhaXuatBan));
            _context.SaveChanges();
        }

        public void UpdateNhaXuatBan(NhaXuatBanDTO newNhaXuatBan)
        {
            _context.NhaXuatBans.Update(_mapper.Map<NhaXuatBanDTO, NhaXuatBan>(newNhaXuatBan));
            _context.SaveChanges();
        }
    }
}
