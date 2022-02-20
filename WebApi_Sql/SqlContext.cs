using Microsoft.EntityFrameworkCore;
using WebApi.Models.Entities;
using WebApi_Sql.Models.Entities;

namespace WebApi_Sql
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        {

        }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }

        public virtual DbSet<UserEntity> Users { get; set; }

        public virtual DbSet<ProductEntity> Products { get; set; }

        public virtual DbSet<CaseEntity> Cases { get; set; }

        public  virtual DbSet<CategoryEntity> Categories { get; set; }














    }
}
