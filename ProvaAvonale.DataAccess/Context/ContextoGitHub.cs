using ProvaAvonale.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ProvaAvonale.DataAccess.Context
{
    public class ContextoGitHub : DbContext
    {
        #region Construtor
        static ContextoGitHub()
        {
            Database.SetInitializer<ContextoGitHub>(null);
        }

        public ContextoGitHub() : base("ContextoGitHub")
        {
            //this.Configuration.LazyLoadingEnabled = true;
            ////this.Configuration.ProxyCreationEnabled = false;
        }
        #endregion

        #region DbSet
        public DbSet<Repositorio> Usuarios { get; set; }
        #endregion

        #region OnModelCreating
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Properties<string>().Configure(property => property.HasColumnType("varchar"));
            modelBuilder.Properties<string>().Configure(property => property.HasMaxLength(150));
            modelBuilder.Configurations.AddFromAssembly(typeof(ContextoGitHub).Assembly);

            base.OnModelCreating(modelBuilder);
        }
        #endregion
    }
}
