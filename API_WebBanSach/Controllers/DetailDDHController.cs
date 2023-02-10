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
    public class ChiTiet_DDHController : ControllerBase
    {
        private ILogger<ChiTiet_DDHController> _logger;
        private IChiTiet_DDHRespository _ChiTiet_DDHService;

        public ChiTiet_DDHController(ILogger<ChiTiet_DDHController> logger, IChiTiet_DDHRespository ChiTiet_DDHService)
        {
            _logger = logger;
            _ChiTiet_DDHService = ChiTiet_DDHService;
        }

        [HttpGet("get-all-detail-ddh")]
        [Authorize(Roles = "Admin,Guest")]
        public async Task<ActionResult> GetAllChiTiet_DDH()
        {
            try
            {
                List<ChiTietDDH_DTO> listDetailDDH = _ChiTiet_DDHService.GetAllChiTiet_DDH();
                return Ok(new { result = true, data = listDetailDDH });
            }
            catch
            {
                return Ok(new { result = false, message = "Get all ChiTiet_DDH failed !" });
            }
        }

        [HttpPost("insert-detail-ddh")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> InsertChiTiet_DDH(ChiTietDDH_DTO newDetailDDH)
        {
            try
            {
                _ChiTiet_DDHService.InsertChiTiet_DDH(newDetailDDH);
                return Ok(new { result = true, message = "Insert ChiTiet_DDH successful !" });
            }
            catch
            {
                return Ok(new { result = false, message = "Insert ChiTiet_DDH failed !" });
            }
        }

        [HttpPut("update-detail-ddh")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateChiTiet_DDH(ChiTietDDH_DTO newDetailDDH)
        {
            try
            {
                _ChiTiet_DDHService.UpdateChiTiet_DDH(newDetailDDH);
                return Ok(new { result = true, message = "Update ChiTiet_DDH successful !" });
            }
            catch
            {
                return Ok(new { result = false, message = "Update ChiTiet_DDH failed !" });
            }
        }

        [HttpDelete("delete-detail-ddh")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteChiTiet_DDH(Guid MaDH, string MaSach)
        {
            try
            {
                _ChiTiet_DDHService.DeleteChiTiet_DDH(MaDH, MaSach);
                return Ok(new { result = true, message = "Delete ChiTiet_DDH successful !" });
            }
            catch
            {
                return Ok(new { result = false, message = "Delete ChiTiet_DDH failed !" });
            }
        }
    }
}
