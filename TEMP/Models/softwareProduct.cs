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
    
    public partial class softwareProduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public softwareProduct()
        {
            this.Deal_Product = new HashSet<Deal_Product>();
            this.Licenses = new HashSet<License>();
            this.orderItems = new HashSet<orderItem>();
            this.PrePurchase_FollowUp_Plan = new HashSet<PrePurchase_FollowUp_Plan>();
            this.productAttributes = new HashSet<productAttribute>();
        }
    
        public int id { get; set; }
        public string SKU { get; set; }
        public string name { get; set; }
        public string keywords { get; set; }
        public string shortDescription { get; set; }
        public string fullDescription { get; set; }
        public bool isActive { get; set; }
        public double unitPrice { get; set; }
        public Nullable<double> altPrice1 { get; set; }
        public Nullable<double> altPrice2 { get; set; }
        public string screenShots { get; set; }
        public string icon { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Deal_Product> Deal_Product { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<License> Licenses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<orderItem> orderItems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PrePurchase_FollowUp_Plan> PrePurchase_FollowUp_Plan { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<productAttribute> productAttributes { get; set; }
    }
}
