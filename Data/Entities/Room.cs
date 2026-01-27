using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dorimuth_Backend.Data.Entities
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public int Capacity { get; set; }

        public bool Active { get; set; } = true;

        // Relaciones
        public virtual ICollection<Showtime> Showtimes { get; set; }
    }
}
