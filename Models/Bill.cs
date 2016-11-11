namespace TaacTapTerminalApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bill")]
    public partial class Bill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bill()
        {
            Payments = new HashSet<Payment>();
        }

        public int OrderId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
   
        public int BillId { get; set; }

        [Column(TypeName = "money")]
        public decimal SubTotal { get; set; }

        [Column(TypeName = "money")]
        public decimal TaxRate { get; set; }

        [Column(TypeName = "money")]
        public decimal? TipP { get; set; }

        public virtual Order Order { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
