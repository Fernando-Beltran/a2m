//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace a2mbl
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order_Status
    {
        public Order_Status()
        {
            this.Order_Movements = new HashSet<Order_Movements>();
            this.Orders = new HashSet<Orders>();
        }
    
        public int Pk_Order_Status { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Order_Movements> Order_Movements { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
