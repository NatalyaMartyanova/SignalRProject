﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ORM
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBConnectionString : DbContext
    {
        public DBConnectionString()
            : base("name=DBConnectionString")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Автомобиль> Автомобиль { get; set; }
        public virtual DbSet<Заказ> Заказ { get; set; }
        public virtual DbSet<Модель> Модель { get; set; }
        public virtual DbSet<Отзыв> Отзыв { get; set; }
        public virtual DbSet<Пользователь> Пользователь { get; set; }
    }
}