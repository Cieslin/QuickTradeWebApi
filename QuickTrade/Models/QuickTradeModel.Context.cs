﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuickTrade.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QuickTradeModelContainer : DbContext
    {
        public QuickTradeModelContainer()
            : base("name=QuickTradeModelContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Account> AccountSet { get; set; }
        public virtual DbSet<Advert> AdvertSet { get; set; }
        public virtual DbSet<Images> ImagesSet { get; set; }
    }
}
