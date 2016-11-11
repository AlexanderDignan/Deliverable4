namespace TaacTapTerminalApp.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int OrderId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("RestaurantTable")]
        public int TableId { get; set; }

        public string Status { get; set; }
        [Display(Name = "Time of Order")]
        public DateTime DateTimeCreated { get; set; }

        [Display(Name = "Total Price")]
        [Column(TypeName = "money")]
        public decimal TotalPrice { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual Bill Bill { get; set; }

        public virtual RestaurantTable RestaurantTable { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
