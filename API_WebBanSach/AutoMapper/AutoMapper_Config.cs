
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using QLBanSach_API.DTO;
using QLBanSach_API.Entity;
using QLBanSach_API.Model;

namespace QLBanSach_API.Mapper
{
    public class AutoMapper_Config : Profile
    {
        public AutoMapper_Config()
        { 
            this.CreateMap<ChuDeDTO, ChuDe>();
            this.CreateMap<NhaXuatBanDTO, NhaXuatBan>();
            this.CreateMap<SachDTO, Sach>();
            this.CreateMap<TacGiaDTO, TacGia>();
            this.CreateMap<TacGia_SachDTO, TacGia_Sach>();
            this.CreateMap<DonDatHangDTO, DonDatHang>();
            this.CreateMap<ChiTietDDH_DTO, ChiTietDDH>();

            this.CreateMap<TokenModel, User>();

            this.CreateMap<ChuDe, ChuDeDTO>();
            this.CreateMap<NhaXuatBan, NhaXuatBanDTO>();
            this.CreateMap<Sach, SachDTO>();
            this.CreateMap<TacGia, TacGiaDTO>();
            this.CreateMap<TacGia_Sach, TacGia_SachDTO>();
            this.CreateMap<DonDatHang, DonDatHangDTO>();
            this.CreateMap<ChiTietDDH, ChiTietDDH_DTO>();

            this.CreateMap<User, TokenModel>().ForMember(des => des.Password, act => act.MapFrom(src => src.PasswordHash));

        }
    }
}