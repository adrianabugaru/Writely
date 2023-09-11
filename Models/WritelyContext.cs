using Microsoft.EntityFrameworkCore;

namespace Writely.Models
{
    public class WritelyContext : DbContext

    {
        public WritelyContext (DbContextOptions<WritelyContext> options) : base(options) { }

        public DbSet<NotebooksMenu> NotebooksMenus { get; set; }
        public DbSet<Notebook> Notebooks { get; set; }
       
        public DbSet<QuickNote> QuickNotes { get; set; }
        
    }
}
