//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MortgageDAL.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class MortgageEntities : DbContext
    {
        public MortgageEntities()
            : base("name=MortgageEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Mortgage> Mortgages { get; set; }
        public virtual DbSet<ExceptionLogger> ExceptionLoggers { get; set; }
    
        public virtual ObjectResult<SelectMortgagesData_Result> SelectMortgagesData()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SelectMortgagesData_Result>("SelectMortgagesData");
        }
    }
}
