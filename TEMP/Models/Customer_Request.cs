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
    
    public partial class Customer_Request
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer_Request()
        {
            this.Customer_Request1 = new HashSet<Customer_Request>();
            this.ManagerNotifications = new HashSet<ManagerNotification>();
        }
    
        public int id { get; set; }
        public string RequestNo { get; set; }
        public int ProductID { get; set; }
        public int CusID { get; set; }
        public Nullable<int> PlanID { get; set; }
        public string RequestDemoDay { get; set; }
        public Nullable<int> DealID { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
    
        public virtual contact contact { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer_Request> Customer_Request1 { get; set; }
        public virtual Customer_Request Customer_Request2 { get; set; }
        public virtual productMarketPlan productMarketPlan { get; set; }
        public virtual softwareProduct softwareProduct { get; set; }
        public virtual Deal Deal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ManagerNotification> ManagerNotifications { get; set; }
    }
}
