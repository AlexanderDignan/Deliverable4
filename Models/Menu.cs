namespace TaacTapTerminalApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menu")]
    public partial class Menu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Menu()
        {
            MenuItems = new HashSet<MenuItem>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MenuId { get; set; }

        [StringLength(30)]
        [Display(Name ="Menu")]
        public string MenuName { get; set; }

        public int RestaurantInfoId { get; set; }

        public virtual RestaurantInfo RestaurantInfo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MenuItem> MenuItems { get; set; }
    }
}
