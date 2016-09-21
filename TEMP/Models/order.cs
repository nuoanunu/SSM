//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SSM.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public order()
        {
            this.MarketPlanPurchaseds = new HashSet<MarketPlanPurchased>();
        }
    
        public int id { get; set; }
        public int customerID { get; set; }
        public int orderNumber { get; set; }
        public double total { get; set; }
        public Nullable<double> VAT { get; set; }
        public Nullable<double> subtotal { get; set; }
        public System.DateTime createDate { get; set; }
        public Nullable<System.DateTime> lastModifiedDate { get; set; }
        public int status { get; set; }
        public Nullable<System.DateTime> completedDate { get; set; }
    
        public virtual customer customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MarketPlanPurchased> MarketPlanPurchaseds { get; set; }
    }
}
