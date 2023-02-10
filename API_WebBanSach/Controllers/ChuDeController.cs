using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBanSach_API.DTO;
using QLBanSach_API.Entity;
using QLBanSach_API.Respositories;
using QLBanSach_API.Services;
using System.Collections.Generic;

namespace QLBanSach_API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChuDeController : ControllerBase
    {
        private ILogger<ChuDeController> _logger;
        private IChuDeRespository _ChuDeService;

        public ChuDeController(ILogger<ChuDeController> logger, IChuDeRespository ChuDeService)
        {
            _logger = logger;
            _ChuDeService = ChuDeService;
        }

        [HttpGet("get-all-chu-de")]
        public async Task<ActionResult> GetAllChuDe()
        {
            try
            {
                List<ChuDeDTO> listCD = _ChuDeService.GetAllChuDe();
                return Ok(new { result = true, data = listCD });
            }
            catch
            {
                return Ok(new { result = false, message = "Get all ChuDe failed !" });
            }
        }

        [HttpPost("insert-chu-de")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> InsertChuDe(ChuDeDTO newCD)
        {
            try
            {
                _ChuDeService.InsertChuDe(newCD);
                return Ok(new { result = true, message = "Insert ChuDe successful !" });
            }
            catch (Exception ex)
            {
                return Ok(new { result = false, message = "Insert ChuDe failed !" , winx = ex.Message });
            }
        }

        [HttpPut("update-chu-de")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateChuDe(ChuDeDTO newCD)
        {
            try
            {
                _ChuDeService.UpdateChuDe(newCD);
                return Ok(new { result = true, message = "Update ChuDe successful !" });
            }
            catch(Exception ex)
            {
                return Ok(new { result = false, message = "Update ChuDe failed ! -- "+ex.Message});
            }
        }

        [HttpDelete("delete-chu-de")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteChuDe(string MaCD)
        {
            try
            {
                _ChuDeService.DeleteChuDe(MaCD);
                return Ok(new { result = true, message = "Delete ChuDe successful !" });
            }
            catch
            {
                return Ok(new { result = false, message = "Delete ChuDe failed !" });
            }
        }
    }
}
