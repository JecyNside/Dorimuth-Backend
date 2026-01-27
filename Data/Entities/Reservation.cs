using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dorimuth_Backend.Data.Entities
{
    public class Reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReservationId { get; set; }

        [Required]
        [MaxLength(20)]
        public string TicketNumber { get; set; }

        [Required]
        public DateTime ReservationDate { get; set; } = DateTime.Now;

        // Relaciones
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        public int ShowtimeId { get; set; }
        [ForeignKey("ShowtimeId")]
        public virtual Showtime Showtime { get; set; }
    }
}
