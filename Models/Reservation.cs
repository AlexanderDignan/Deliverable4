namespace TaacTapTerminalApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Reservation")]
    public partial class Reservation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReservationId { get; set; }

        public int RestaurantTableId { get; set; }

        public int UserId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [StringLength(20)]
        public string Status { get; set; }

        public virtual RestaurantTable RestaurantTable { get; set; }

        public virtual User User { get; set; }
    }
}
