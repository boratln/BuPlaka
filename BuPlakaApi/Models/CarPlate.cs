using System.ComponentModel.DataAnnotations;

namespace BuPlakaApi.Models
{
    public class CarPlate
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(12,ErrorMessage ="Maximum 12 karakterli olmalıdır")]
        [Required]
        public string Name { get; set; }
    }
}
