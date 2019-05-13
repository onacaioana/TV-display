using System;
using System.Data.Entity;

namespace WebSalt.Models
{
    public class HotarariContext : DbContext
    {

        const String DefaultConnectionName = "salaTestEntities2";

        #region "ctor"

        public HotarariContext() : this(DefaultConnectionName)
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        public HotarariContext(String sqlConnectionName) : base(String.Format("Name={0}", sqlConnectionName))
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        #endregion

        #region Collections Definitions

        public DbSet<Hotarari> Hotarari { get; set; }

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotarari>()
                        .ToTable("Hotarari")
                        .HasKey(t => t.id);

        }

    }
}