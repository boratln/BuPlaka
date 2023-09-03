using BuPlakaApi.Data;
using BuPlakaApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuPlakaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPlateController: ControllerBase
    {
        private readonly RepositoryContext _context;
        public CarPlateController(RepositoryContext context)
        {
            _context = context;
        }
        [HttpGet("Get")]
        public IActionResult Get()
        {
          var list=  _context.CarPlate.ToList();
            return Ok(list);
        }
        [HttpGet("Get/{id}")]
        public IActionResult Get(int? id)
        {
            if (id == null)
            {
                return BadRequest("id girilmedi");
            }
            else
            {
                var carplate= _context.CarPlate.FirstOrDefault(x=>x.Id==id);
                if(carplate == null)
                {
                    return NotFound("Böyle bir plaka bulunamadı");
                }
                else
                {
                    return Ok(carplate);
                }
            }
        }
        [HttpPost("Post")]
        public IActionResult Post(CarPlate plate)
        {
            if (plate == null)
            {
                return NotFound("değer girilmedi");
            }
            else
            {
                _context.CarPlate.Add(plate);
                _context.SaveChanges();
                return Ok("Kayıt işlemi başarılı");
            }
        }
        [HttpPut("Put")]
        public IActionResult Put(CarPlate plate)
        {
            if(plate == null)
            {
                return NotFound("değer girilmedi");
            }
            else
            {
                var plaka = _context.CarPlate.FirstOrDefault(x => x.Id == plate.Id);
                if(plaka == null)
                {
                    return NotFound("Plaka bulunamadı");
                }
                else
                {
                    plate.Name = plaka.Name;
                    _context.SaveChanges();
                    return Ok("Güncelleme işlemi başarılı");
                }
            }
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound("id girilmedi");
            }
            else
            {
                var plaka = _context.CarPlate.FirstOrDefault(x => x.Id == id);
                if (plaka == null)
                {
                    return NotFound("Plaka bulunamadı");
                }
                else
                {
                    _context.CarPlate.Remove(plaka);
                    _context.SaveChanges();
                    return Ok("Silme işlemi başarılı");
                }
            }
        }
    }
}
