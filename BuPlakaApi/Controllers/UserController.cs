using BuPlakaApi.Data;
using BuPlakaApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuPlakaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly RepositoryContext _context;
        public UserController(RepositoryContext context)
        {
            _context = context;
        }
        [HttpGet("Get")]
        public IActionResult Get()
        {
            var list = _context.Users.ToList();
            return Ok(list);
        }
        [HttpGet("Get/{id}")]
        public IActionResult Get(int? id)
        {
            if (id == null)
            {
                return NotFound("Böyle Bir id yok");
            }
            else
            {
                var user = _context.Users.FirstOrDefault(x => x.Id == id);
                if (user == null)
                {
                    return NotFound("Kullanıcı Bulunamadı");
                }
                else
                {
                    return Ok(user);
                }
            }
        }
        [HttpPost("Register")]
        public IActionResult Register(User user)
        {
            if (user == null)
            {
                return NotFound("Veri girilmemiş");
            }
            var User = _context.Users.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
            if (User != null)
            {
                return BadRequest("Böyle bir kullanıcı var!");
            }
            else
            {
                User.Role = 'U';
                _context.Users.Add(User);
                _context.SaveChanges();
                return Ok("Başarıyla Kayıt Olundu");
            }

        }
        [HttpPost("Login")]
        public IActionResult Login(User user)
        {
            if (user == null)
            {
                return BadRequest("input girilmedi");
            }
            else
            {
                var User = _context.Users.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
                if (User != null)
                {
                    return Ok("Başarıyla Giriş Yapıldı");
                }
                else
                {
                    return NotFound("Kullanıcı Bulunamadı");
                }

            }

        }
        [HttpPut("Put")]
        public IActionResult Put(User user)
        {
            if (user == null)
            {
                return BadRequest("İnput girilmedi");
            }
            else
            {
                var User = _context.Users.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
                if (User == null)
                {
                    return NotFound("Kullanıcı bulunamadı");
                }
                else
                {
                    user.Password = User.Password;
                    _context.SaveChanges();
                    return Ok("Şifre Güncellendi");
                }
            }

        }
        [HttpDelete("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound("İd bulunamadı");
            }
            else
            {
                var User = _context.Users.FirstOrDefault(x => x.Id == id);
                if(User != null) {
                    _context.Users.Remove(User);
                    _context.SaveChanges();
                    return Ok("Kullanıcı Kaydı Başarıyla Silindi");
                }
            }
        }


    }
}
