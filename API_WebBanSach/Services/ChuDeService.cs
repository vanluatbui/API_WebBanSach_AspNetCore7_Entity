using AutoMapper;
using Lib;
using QLBanSach_API.DTO;
using QLBanSach_API.Entity;
using QLBanSach_API.Respositories;

namespace QLBanSach_API.Services
{
        public class ChuDeService : IChuDeRespository
        {
            private ApplicationDbContext _context;
            private IMapper _mapper;

            public ChuDeService(ApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public void DeleteChuDe(string MaChuDe)
            {
                ChuDe CD = _context.ChuDes.FirstOrDefault(p => p.MaChuDe == MaChuDe);
                _context.ChuDes.Remove(CD);
                _context.SaveChanges();
            }

            public List<ChuDeDTO> GetAllChuDe()
            {
                List<ChuDe> ChuDes = _context.ChuDes.ToList();

            List<ChuDeDTO> listChuDe = ChuDes.Select
                          (
                            emp => _mapper.Map<ChuDe, ChuDeDTO>(emp)
                          ).ToList();

            return listChuDe;
            }

            public void InsertChuDe(ChuDeDTO newChuDe)
            {
                _context.ChuDes.Add(_mapper.Map<ChuDeDTO,ChuDe>(newChuDe));
                _context.SaveChanges();
            }

            public void UpdateChuDe(ChuDeDTO newChuDe)
            {
                _context.ChuDes.Update(_mapper.Map<ChuDeDTO, ChuDe>(newChuDe));
                _context.SaveChanges();
            }
        }
}
