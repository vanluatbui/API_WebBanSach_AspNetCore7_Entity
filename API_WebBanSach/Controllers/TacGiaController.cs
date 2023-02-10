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
    public class TacGiaController : ControllerBase
    {
        private ILogger<TacGiaController> _logger;
        private ITacGiaRespository _TacGiaService;

        public TacGiaController(ILogger<TacGiaController> logger, ITacGiaRespository TacGiaService)
        {
            _logger = logger;
            _TacGiaService = TacGiaService;
        }

        [HttpGet("get-all-tac-gia")]
        public async Task<ActionResult> GetAllTacGia()
        {
            try
            {
                List<TacGiaDTO> listTG = _TacGiaService.GetAllTacGia();
                return Ok(new { result = true, data = listTG });
            }
            catch
            {
                return Ok(new { result = false, message = "Get all TacGia failed !" });
            }
        }

        [HttpPost("insert-tac-gia")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> InsertTacGia(TacGiaDTO newTG)
        {
            try
            {
                _TacGiaService.InsertTacGia(newTG);
                return Ok(new { result = true, message = "Insert TacGia successful !" });
            }
            catch
            {
                return Ok(new { result = false, message = "Insert TacGia failed !" });
            }
        }

        [HttpPut("update-tac-gia")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateTacGia(TacGiaDTO newTG)
        {
            try
            {
                _TacGiaService.UpdateTacGia(newTG);
                return Ok(new { result = true, message = "Update TacGia successful !" });
            }
            catch
            {
                return Ok(new { result = false, message = "Update TacGia failed !" });
            }
        }

        [HttpDelete("delete-tac-gia")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteTacGia(string MaTG)
        {
            try
            {
                _TacGiaService.DeleteTacGia(MaTG);
                return Ok(new { result = true, message = "Delete TacGia successful !" });
            }
            catch
            {
                return Ok(new { result = false, message = "Delete TacGia failed !" });
            }
        }
    }
}
