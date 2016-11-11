using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TaacTapTerminalApp.Models
{
    [Table("OrderDetails")]
    public partial class OrderDetails
    {
        public OrderDetails()
        {

        }
        [Key]
        public int OrderDetailsId { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        
        [ForeignKey("MenuItem")]
        public int MenuItemId { get; set; }

        public virtual Order Order { get; set; }

        public virtual MenuItem MenuItem { get; set; }
    }
}