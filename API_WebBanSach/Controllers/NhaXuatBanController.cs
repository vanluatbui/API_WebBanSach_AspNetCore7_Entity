using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBanSach_API.DTO;
using QLBanSach_API.Entity;
using QLBanSach_API.Respositories;
using QLBanSach_API.Services;
using System.Collections.Generic;
using System.Data;

namespace QLBanSach_API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhaXuatBanController : ControllerBase
    {
        private ILogger<NhaXuatBanController> _logger;
        private INhaXuatBanRespository _NhaXuatBanService;

        public NhaXuatBanController(ILogger<NhaXuatBanController> logger, INhaXuatBanRespository NhaXuatBanService)
        {
            _logger = logger;
            _NhaXuatBanService = NhaXuatBanService;
        }

        [HttpGet("get-all-nha-xuat-ban")]
        public async Task<ActionResult> GetAllNhaXuatBan()
        {
            try
            {
                List<NhaXuatBanDTO> listNXB = _NhaXuatBanService.GetAllNhaXuatBan();
                return Ok(new { result = true, data = listNXB });
            }
            catch
            {
                return Ok(new { result = false, message = "Get all NhaXuatBan failed !" });
            }
        }

        [HttpPost("insert-nha-xuat-ban")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> InsertNhaXuatBan(NhaXuatBanDTO newNXB)
        {
            try
            {
                _NhaXuatBanService.InsertNhaXuatBan(newNXB);
                return Ok(new { result = true, message = "Insert NhaXuatBan successful !" });
            }
            catch
            {
                return Ok(new { result = false, message = "Insert NhaXuatBan failed !" });
            }
        }

        [HttpPut("update-nha-xuat-ban")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateNhaXuatBan(NhaXuatBanDTO newNXB)
        {
            try
            {
                _NhaXuatBanService.UpdateNhaXuatBan(newNXB);
                return Ok(new { result = true, message = "Update NhaXuatBan successful !" });
            }
            catch
            {
                return Ok(new { result = false, message = "Update NhaXuatBan failed !" });
            }
        }

        [HttpDelete("delete-nha-xuat-ban")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteNhaXuatBan(string MaNXB)
        {
            try
            {
                _NhaXuatBanService.DeleteNhaXuatBan(MaNXB);
                return Ok(new { result = true, message = "Delete NhaXuatBan successful !" });
            }
            catch
            {
                return Ok(new { result = false, message = "Delete NhaXuatBan failed !" });
            }
        }
    }
}
