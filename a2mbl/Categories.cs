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
    
    public partial class Categories
    {
        public Categories()
        {
            this.Products = new HashSet<Products>();
        }
    
        public int Pk_Product_Category { get; set; }
        public string Name { get; set; }
        public Nullable<int> Fk_Business { get; set; }
    
        public virtual ICollection<Products> Products { get; set; }
        public virtual Business Business { get; set; }
    }
}
