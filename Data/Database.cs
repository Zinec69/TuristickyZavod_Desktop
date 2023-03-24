using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace turisticky_zavod.Data
{
    public sealed class Database : DbContext
    {
        public DbSet<Runner> Runner { get; set; }
        public DbSet<Partner> Partner { get; set; }
        public DbSet<AgeCategory> AgeCategory { get; set; }
        public DbSet<Checkpoint> Checkpoint { get; set; }

        private Database() { }

        private static readonly object _lock = new();
        private static Database instance = null;

        public static Database Instance
        {
            get
            {
                lock (_lock)
                {
                    instance ??= new Database();
                    
                    return instance;
                }
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("Data Source=../../../../Data/tz.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Checkpoint>().HasData(
                new Checkpoint() { CheckpointID = 1, Name = "Start/cíl" },
                new Checkpoint() { CheckpointID = 2, Name = "Odhad vzdálenosti" },
                new Checkpoint() { CheckpointID = 3, Name = "Stavba stanu" },
                new Checkpoint() { CheckpointID = 4, Name = "Orientace mapy" },
                new Checkpoint() { CheckpointID = 5, Name = "Azimutové úseky" },
                new Checkpoint() { CheckpointID = 6, Name = "Lanová lávka" },
                new Checkpoint() { CheckpointID = 7, Name = "Uzlování" },
                new Checkpoint() { CheckpointID = 8, Name = "Plížení" },
                new Checkpoint() { CheckpointID = 9, Name = "Hod kriketovým míčkem" },
                new Checkpoint() { CheckpointID = 10, Name = "Turistické a topografické značky" },
                new Checkpoint() { CheckpointID = 11, Name = "Poznávání dřevin" },
                new Checkpoint() { CheckpointID = 12, Name = "Kulturně poznávací činnost" }
            );

            modelBuilder.Entity<AgeCategory>(entity => entity.Property(e => e.ID).ValueGeneratedOnAdd());
            modelBuilder.Entity<AgeCategory>().HasData(
                new AgeCategory() { ID = 1, AgeMin = 0, AgeMax = 10, Name = "Nejmladší žáci a žákyně", Code = "K1", Color = "Bílá" },
                new AgeCategory() { ID = 2, AgeMin = 11, AgeMax = 12, Name = "Mladší žáci a žákyně", Code = "K2", Color = "Bílá" },
                new AgeCategory() { ID = 3, AgeMin = 13, AgeMax = 14, Name = "Starší žáci a žákyně", Code = "K3", Color = "Bílá" },
                new AgeCategory() { ID = 4, AgeMin = 15, AgeMax = 16, Name = "Mladší dorostenci a dorostenky", Code = "K4", Color = "Červená" },
                new AgeCategory() { ID = 5, AgeMin = 17, AgeMax = 18, Name = "Starší dorostenci a dorostenky", Code = "K5", Color = "Červená" },
                new AgeCategory() { ID = 6, AgeMin = 19, AgeMax = 35, Name = "Dospělí A", Code = "K6", Color = "Červená" },
                new AgeCategory() { ID = 7, AgeMin = 36, AgeMax = 1000, Name = "Dospělí B", Code = "K7", Color = "Červená" },
                new AgeCategory() { ID = 8, AgeMin = 0, AgeMax = 30, Name = "Do 30 let", Code = "K8", Color = "Červená", Duo = true },
                new AgeCategory() { ID = 9, AgeMin = 31, AgeMax = 70, Name = "31 - 70 let", Code = "K9", Color = "Červená", Duo = true },
                new AgeCategory() { ID = 10, AgeMin = 71, AgeMax = 1000, Name = "Nad 70 let", Code = "K10", Color = "Červená", Duo = true }
            );

            modelBuilder.Entity<Partner>().HasData(new Partner() { ID = 1, Name = "Milan Kundera", BirthYear = 2012 });

            modelBuilder.Entity<Runner>().HasData(
                new Runner() { ID = 1, RunnerID = 18, Name = "Jožin ZBažin", Team = "Ocean men", BirthYear = 2009, Disqualified = false, PartnerID = 1 },
                new Runner() { ID = 2, RunnerID = 59, Name = "Pepa ZDepa", Team = "Bzučáci", BirthYear = 1987, Disqualified = false }
            );
        }
    }
}
