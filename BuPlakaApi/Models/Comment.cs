using System.ComponentModel.DataAnnotations;

namespace BuPlakaApi.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public User? user { get; set; }
        public CarPlate? carPlate { get; set; }
        [MaxLength(50,ErrorMessage ="Yorum maksimum 50 karakter içermelidir")]
        public string comment { get; set; }
        public DateTime comment_Date { get; set; } = DateTime.Now;
    }
}
