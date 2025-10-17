using KSHOP1.BLL.Services.Interfaces;
using KSHOP1.DAL.DTO.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KSHOP1.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            this._brandService = brandService;
        }

        [HttpGet("")]
        public IActionResult GetAllBrands()
        {
            return Ok(_brandService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var category = _brandService.GetById(id);
            if (category == null) return NotFound();
            return Ok(category);
        }



        [HttpPost("")]
        public IActionResult Create([FromBody] BrandRequest request)
        {
            var id = _brandService.Create(request);
            return CreatedAtAction(nameof(Get), new { id = id }, new { massage = request });
        }



        [HttpPatch("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] BrandRequest request)
        {
            try
            {
                _brandService.Update(id, request);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }



        [HttpPatch("toggle-status/{id}")]
        public IActionResult ToggleStatus([FromRoute] int id)
        {
            try
            {
                var newStatus = _brandService.ToggleStatus(id);
                return Ok(new { isActive = newStatus });
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
