using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dorimuth_Backend.Data.Entities
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        public string Synopsis { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public int DurationMinutes { get; set; } // Duración en minutos

        [MaxLength(500)]
        public string ImageUrl { get; set; }

        public bool Active { get; set; } = true;

        // Relaciones
        public virtual ICollection<Showtime> Showtimes { get; set; }
    }
}
