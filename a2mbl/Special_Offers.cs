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
    
    public partial class Special_Offers
    {
        public int Pk_Special_Offer { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public System.DateTime Start_Date { get; set; }
        public Nullable<System.DateTime> End_Date { get; set; }
        public Nullable<decimal> Min_Total_Amount { get; set; }
        public Nullable<int> Discount { get; set; }
        public Nullable<decimal> Fixed_Price { get; set; }
        public string Promotional_Code { get; set; }
        public Nullable<int> Fk_Business { get; set; }
        public Nullable<int> Fk_Product { get; set; }
        public Nullable<int> Fk_Product_Extender { get; set; }
    
        public virtual Business Business { get; set; }
        public virtual Product_Extender Product_Extender { get; set; }
        public virtual Product Product { get; set; }
    }
}
