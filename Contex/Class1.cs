using Microsoft.EntityFrameworkCore;

namespace McRobbie.Com
{
    public class Chinook : DbContext
    {
        public DbSet<Album> albums { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string currentDirectory = System.Environment.CurrentDirectory;
            string parentDirectory = System.IO.Directory.GetParent(currentDirectory).FullName;
            string path = System.IO.Path.Combine(parentDirectory, "chinook.db");
            optionsBuilder.UseSqlite($"Filename={path}");
        }
    }
}