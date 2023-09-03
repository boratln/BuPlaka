using System.ComponentModel.DataAnnotations;

namespace BuPlakaApi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(30)]
        public string Surname { get; set; }
        [MaxLength(40)]
        public string Email { get; set; }
        [MinLength(6,ErrorMessage ="Minimum 6 karakterli olmalıdır")]
        [MaxLength(15,ErrorMessage ="Maximum 15 karakterli olmalıdır")]
        public string Password { get; set; }
        [MinLength(6, ErrorMessage = "Minimum 6 karakterli olmalıdır")]
        [MaxLength(15, ErrorMessage = "Maximum 15 karakterli olmalıdır")]
        public string RePassword { get; set; }
        public char Role { get; set; }//kullanıcı admin mi kontrolü için
    }
}
