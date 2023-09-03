using BuPlakaApi.Data;
using BuPlakaApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuPlakaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly RepositoryContext _context;
        public CommentController(RepositoryContext context)
        {
            _context = context;
        }
        [HttpGet("Get")]
        public IActionResult Get()
        {
            var list=_context.Comments.ToList();
            return Ok(list);
        }
        [HttpGet("Get/{id}")]
        public IActionResult Get(int? id)
        {
            if(id== null)
            {
                return NotFound("id girilmedi");
            }
            else
            {
                var comment=_context.Comments.FirstOrDefault(x=>x.Id == id);
                if(comment == null)
                {
                    return NotFound("Yorum bulunamadı");
                }
                else
                {
                    return Ok(comment);
                }
            }
        }
        [HttpPost("Post")]
        public IActionResult Post(Comment comment)
        {
            if (comment == null)
            {
                return NotFound("input girilmeli");
            }
            var user=_context.Users.FirstOrDefault(x=>x.Id==comment.user.Id);
            if(user == null)
            {
                return NotFound("Kullanıcı bulunamadı");
            }
            else
            {
                _context.Comments.Add(comment);
                return Ok("Kayıt işlemi başarılı");
            }

        }
        [HttpPut("Put")]
        public IActionResult Put(Comment comment)
        {
            if (comment == null)
            {
                return NotFound("input girilmeli");
            }
            var user = _context.Users.FirstOrDefault(x => x.Id == comment.user.Id);
            if (user == null)
            {
                return NotFound("Kullanıcı bulunamadı");
            }
            else
            {
               var com=
            }
        }
    }
}
