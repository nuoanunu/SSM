﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SSMEntities : DbContext
    {
        public SSMEntities()
            : base("name=SSMEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ActTask> ActTasks { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<attributeOption> attributeOptions { get; set; }
        public virtual DbSet<company> companies { get; set; }
        public virtual DbSet<company_responsible> company_responsible { get; set; }
        public virtual DbSet<contact_resposible> contact_resposible { get; set; }
        public virtual DbSet<contact> contacts { get; set; }
        public virtual DbSet<customer> customers { get; set; }
        public virtual DbSet<Deal> Deals { get; set; }
        public virtual DbSet<Deal_Product> Deal_Product { get; set; }
        public virtual DbSet<Deal_SaleRep_Respon> Deal_SaleRep_Respon { get; set; }
        public virtual DbSet<Email_Template> Email_Template { get; set; }
        public virtual DbSet<License> Licenses { get; set; }
        public virtual DbSet<orderItemOption> orderItemOptions { get; set; }
        public virtual DbSet<orderItem> orderItems { get; set; }
        public virtual DbSet<order> orders { get; set; }
        public virtual DbSet<Plan_Step> Plan_Step { get; set; }
        public virtual DbSet<PrePurchase_FollowUp_Plan> PrePurchase_FollowUp_Plan { get; set; }
        public virtual DbSet<productAttribute> productAttributes { get; set; }
        public virtual DbSet<softwareProduct> softwareProducts { get; set; }
        public virtual DbSet<task_customer> task_customer { get; set; }
        public virtual DbSet<task_user> task_user { get; set; }
        public virtual DbSet<TaskStatu> TaskStatus { get; set; }
        public virtual DbSet<TaskType> TaskTypes { get; set; }
    }
}
