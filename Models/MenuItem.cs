namespace TaacTapTerminalApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MenuItem")]
    public partial class MenuItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MenuItem()
        {
            
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int MenuItemId { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name="Item Name")]
        public string Name { get; set; }

        [Column(TypeName = "money")]
        [Range(1, 1000)]
        public decimal Price { get; set; }

        [StringLength(100)]
        public string Description { get; set; }
        [ForeignKey("Menu")]
        public int MenuId { get; set; }

        public virtual Menu Menu { get; set; }

    }
}
