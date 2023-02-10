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
    public class TacGia_SachController : ControllerBase
    {
        private ILogger<TacGia_SachController> _logger;
        private ITacGia_SachRespository _TacGia_SachService;

        public TacGia_SachController(ILogger<TacGia_SachController> logger, ITacGia_SachRespository TacGia_SachService)
        {
            _logger = logger;
            _TacGia_SachService = TacGia_SachService;
        }

        [HttpGet("get-all-detail-sach")]
        public async Task<ActionResult> GetAllTacGia_Sach()
        {
            try
            {
                List<TacGia_SachDTO> listDetailSach = _TacGia_SachService.GetAllTacGia_Sach();
                return Ok(new { result = true, data = listDetailSach });
            }
            catch
            {
                return Ok(new { result = false, message = "Get all TacGia_Sach failed !" });
            }
        }

        [HttpPost("insert-detail-sach")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> InsertTacGia_Sach(TacGia_SachDTO newDetailSach)
        {
            try
            {
                _TacGia_SachService.InsertTacGia_Sach(newDetailSach);
                return Ok(new { result = true, message = "Insert TacGia_Sach successful !" });
            }
            catch
            {
                return Ok(new { result = false, message = "Insert TacGia_Sach failed !" });
            }
        }

        [HttpPut("update-detail-sach")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateTacGia_Sach(TacGia_SachDTO newDetailSach)
        {
            try
            {
                _TacGia_SachService.UpdateTacGia_Sach(newDetailSach);
                return Ok(new { result = true, message = "Update TacGia_Sach successful !" });
            }
            catch
            {
                return Ok(new { result = false, message = "Update TacGia_Sach failed !" });
            }
        }

        [HttpDelete("delete-detail-sach")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteTacGia_Sach(string MaTG, string MaSach)
        {
            try
            {
                _TacGia_SachService.DeleteTacGia_Sach(MaTG, MaSach);
                return Ok(new { result = true, message = "Delete TacGia_Sach successful !" });
            }
            catch
            {
                return Ok(new { result = false, message = "Delete TacGia_Sach failed !" });
            }
        }
    }
}
