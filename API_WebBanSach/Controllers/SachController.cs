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
    public class SachController : ControllerBase
    {
        private ILogger<SachController> _logger;
        private ISachRespository _SachService;

        public SachController(ILogger<SachController> logger, ISachRespository SachService)
        {
            _logger = logger;
            _SachService = SachService;
        }

        [HttpGet("get-all-sach")]
        public async Task<ActionResult> GetAllSach()
        {
            try
            {
                List<SachDTO> listSach = _SachService.GetAllSach();
                return Ok(new { result = true, data = listSach });
            }
            catch
            {
                return Ok(new { result = false, message = "Get all Sach failed !" });
            }
        }

        [HttpPost("insert-sach")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> InsertSach(SachDTO newSach)
        {
            try
            {
                _SachService.InsertSach(newSach);
                return Ok(new { result = true, message = "Insert Sach successful !" });
            }
            catch
            {
                return Ok(new { result = false, message = "Insert Sach failed !" });
            }
        }

        [HttpPut("update-sach")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateSach(SachDTO newSach)
        {
            try
            {
                _SachService.UpdateSach(newSach);
                return Ok(new { result = true, message = "Update Sach successful !" });
            }
            catch
            {
                return Ok(new { result = false, message = "Update Sach failed !" });
            }
        }

        [HttpDelete("delete-sach")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteSach(string MaSach)
        {
            try
            {
                _SachService.DeleteSach(MaSach);
                return Ok(new { result = true, message = "Delete Sach successful !" });
            }
            catch
            {
                return Ok(new { result = false, message = "Delete Sach failed !" });
            }
        }
    }
}
