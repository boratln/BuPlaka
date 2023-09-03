using System.ComponentModel.DataAnnotations;

namespace BuPlakaApi.Models
{
    public class Vote
    {
        [Key]
        public int Id { get; set; }
        public Comment? comment { get; set; }
        public int Like { get; set; } = 0;
        public int Dislike { get; set; } = 0;
    }
}
