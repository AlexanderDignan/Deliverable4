using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaacTapTerminalApp.Models.ViewModels
{
    public partial class OrdersOverview
    {
        public Order Order { get; set; }

        public RestaurantTable RestaurantTable { get; set; }

        public OrdersOverview(Order order)
        {
            
        }
    }
}