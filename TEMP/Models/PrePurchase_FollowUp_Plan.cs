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
    
    public partial class PrePurchase_FollowUp_Plan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PrePurchase_FollowUp_Plan()
        {
            this.Plan_Step = new HashSet<Plan_Step>();
        }
    
        public int id { get; set; }
        public int productID { get; set; }
        public System.DateTime createDate { get; set; }
        public string name { get; set; }
        public Nullable<System.DateTime> lastUpdate { get; set; }
        public bool isActive { get; set; }
        public Nullable<double> fullDuration { get; set; }
        public string Description { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Plan_Step> Plan_Step { get; set; }
        public virtual softwareProduct softwareProduct { get; set; }
    }
}
