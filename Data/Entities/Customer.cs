using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dorimuth_Backend.Data.Entities
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        [MaxLength(20)]
        public string Gender { get; set; } // Masculino, Femenino

        [Required]
        [MaxLength(50)]
        public string DocumentType { get; set; } // DNI, Pasaporte, CE, etc.

        [Required]
        [MaxLength(20)]
        public string DocumentNumber { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        // Relaciones
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
