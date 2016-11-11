namespace TaacTapTerminalApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RestaurantTable")]
    public partial class RestaurantTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RestaurantTable()
        {
            Orders = new HashSet<Order>();
            Reservations = new HashSet<Reservation>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name ="Table")]
        public int RestaurantTableId { get; set; }
        public int TableNumber { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
