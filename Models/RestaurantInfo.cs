namespace TaacTapTerminalApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RestaurantInfo")]
    public partial class RestaurantInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RestaurantInfo()
        {
            Menus = new HashSet<Menu>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RestaurantInfoId { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(30)]
        public string Address { get; set; }

        [StringLength(30)]
        public string City { get; set; }

        [StringLength(30)]
        public string Phone { get; set; }

        public int? NumberOfTables { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Menu> Menus { get; set; }
    }
}
