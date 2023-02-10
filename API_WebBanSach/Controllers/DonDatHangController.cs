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
    public class DonDatHangController : ControllerBase
    {
        private ILogger<DonDatHangController> _logger;
        private IDonDatHangRespository _DonDatHangService;

        public DonDatHangController(ILogger<DonDatHangController> logger, IDonDatHangRespository DonDatHangService)
        {
            _logger = logger;
            _DonDatHangService = DonDatHangService;
        }

        [HttpGet("get-all-don-dat-hang")]
        [Authorize(Roles = "Admin,Guest")]
        public async Task<ActionResult> GetAllDonDatHang()
        {
            try
            {
                List<DonDatHangDTO> listDDH = _DonDatHangService.GetAllDonDatHang();
                return Ok(new { result = true, data = listDDH });
            }
            catch
            {
                return Ok(new { result = false, message = "Get all DonDatHang failed !" });
            }
        }

        [HttpPost("insert-don-dat-hang")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> InsertDonDatHang(DonDatHangDTO newDDH)
        {
            try
            {
                _DonDatHangService.InsertDonDatHang(newDDH);
                return Ok(new { result = true, message = "Insert DonDatHang successful !" });
            }
            catch
            {
                return Ok(new { result = false, message = "Insert DonDatHang failed !" });
            }
        }

        [HttpPut("update-don-dat-hang")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateDonDatHang(DonDatHangDTO newDDH)
        {
            try
            {
                _DonDatHangService.UpdateDonDatHang(newDDH);
                return Ok(new { result = true, message = "Update DonDatHang successful !" });
            }
            catch
            {
                return Ok(new { result = false, message = "Update DonDatHang failed !" });
            }
        }

        [HttpDelete("delete-don-dat-hang")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteDonDatHang(Guid MaDDH)
        {
            try
            {
                _DonDatHangService.DeleteDonDatHang(MaDDH);
                return Ok(new { result = true, message = "Delete DonDatHang successful !" });
            }
            catch
            {
                return Ok(new { result = false, message = "Delete DonDatHang failed !" });
            }
        }
    }
}
