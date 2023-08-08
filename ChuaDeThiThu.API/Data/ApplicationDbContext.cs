using ChuaDeThiThu.Shared;
using Microsoft.EntityFrameworkCore;

namespace ChuaDeThiThu.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<UploadedFile> UploadedFiles { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
