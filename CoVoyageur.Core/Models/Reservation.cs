using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoVoyageur.Core.Models
{
    [Table("Reservation")]
    public class Reservation
    {
        [Column("Id")]
        public int ID { get; set; }

        [Column("Id_Ride")]
        public int ID_Ride { get; set; }

        [Column("Id_Passenger")]
        public int ID_Passenger { get; set; }

        [Column("Statuts")]
        [Required]
        public Status? Statuts { get; set; } = Status.ONGOING;
        [ForeignKey("ID_Ride")]
        public Ride? Travel { get; set; }
        [ForeignKey("ID_Passenger")]
        public User? Passenger { get; set; }
    }
    public enum Status
    {
        ONGOING,
        FINISHED
    }
}
