namespace TaacTapTerminalApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Payment")]
    public partial class Payment
    {
        public int BillOrderId { get; set; }

        public int BillId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PaymentId { get; set; }

        [Column(TypeName = "money")]
        public decimal Amount { get; set; }

        [StringLength(20)]
        public string Type { get; set; }

        public virtual Bill Bill { get; set; }
    }
}
