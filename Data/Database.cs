using Microsoft.EntityFrameworkCore;

namespace turisticky_zavod.Data
{
    public sealed class Database : DbContext
    {
        public DbSet<Runner> Runner { get; set; }
        public DbSet<Partner> Partner { get; set; }
        public DbSet<Referee> Referee { get; set; }
        public DbSet<AgeCategory> AgeCategory { get; set; }
        public DbSet<Checkpoint> Checkpoint { get; set; }
        public DbSet<CheckpointAgeCategoryParticipation> CheckpointAgeCategoryParticipation { get; set; }

        public DbSet<Team> Team { get; set; }

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

        public bool IsSaved { get; private set; } = false;
        public string? SavedFilePath { get; private set; } = null;


        public override int SaveChanges()
        {
            IsSaved = false;
            return base.SaveChanges();
        }

        public bool SaveToFile(string? filePath = null)
        {
            try
            {
                var allData = new AllData()
                {
                    Runners = instance.Runner.ToList(),
                    Teams = instance.Team.ToList(),
                    Referees = instance.Referee.ToList(),
                    Partners = instance.Partner.ToList(),
                    Checkpoints = instance.Checkpoint.ToList(),
                    CheckpointAgeCategoryParticipations = instance.CheckpointAgeCategoryParticipation.ToList(),
                    AgeCategories = instance.AgeCategory.ToList()
                };

                FileHelper.ExportEverythingToJSON(allData, filePath ?? SavedFilePath!);

                IsSaved = true;
                SavedFilePath = filePath;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async static void LoadFromFile(string filePath)
        {
            var allData = FileHelper.LoadEverythingFromJSON(filePath);

            using var transaction = await instance.Database.BeginTransactionAsync();

            try
            {
                foreach (var entity in instance.AgeCategory)
                {
                    var newDataItem = allData.AgeCategories.FirstOrDefault(x => x.ID == entity.ID);
                    if (newDataItem != null)
                    {
                        instance.Entry(entity).CurrentValues.SetValues(newDataItem);
                    }
                    else
                    {
                        instance.AgeCategory.Remove(entity);
                    }
                }

                foreach (var newDataItem in allData.AgeCategories.Where(x => !instance.AgeCategory.Any(y => y.ID == x.ID)))
                {
                    instance.AgeCategory.Add(newDataItem);
                }

                foreach (var entity in instance.Checkpoint)
                {
                    var newDataItem = allData.Checkpoints.FirstOrDefault(x => x.ID == entity.ID);
                    if (newDataItem != null)
                    {
                        instance.Entry(entity).CurrentValues.SetValues(newDataItem);
                    }
                    else
                    {
                        instance.Checkpoint.Remove(entity);
                    }
                }

                foreach (var newDataItem in allData.Checkpoints.Where(x => !instance.Checkpoint.Any(y => y.ID == x.ID)))
                {
                    instance.Checkpoint.Add(newDataItem);
                }

                foreach (var entity in instance.CheckpointAgeCategoryParticipation)
                {
                    var newDataItem = allData.CheckpointAgeCategoryParticipations
                                             .FirstOrDefault(x => x.AgeCategoryID == entity.AgeCategoryID && x.CheckpointID == entity.CheckpointID);
                    if (newDataItem != null)
                    {
                        instance.Entry(entity).CurrentValues.SetValues(newDataItem);
                    }
                    else
                    {
                        instance.CheckpointAgeCategoryParticipation.Remove(entity);
                    }
                }

                foreach (var newDataItem in allData.CheckpointAgeCategoryParticipations
                                                   .Where(x => !instance.CheckpointAgeCategoryParticipation
                                                                        .Any(y => y.AgeCategoryID == x.AgeCategoryID && y.CheckpointID == x.CheckpointID)))
                {
                    instance.CheckpointAgeCategoryParticipation.Add(newDataItem);
                }

                foreach (var entity in instance.Partner)
                {
                    var newDataItem = allData.Partners.FirstOrDefault(x => x.ID == entity.ID);
                    if (newDataItem != null)
                    {
                        instance.Entry(entity).CurrentValues.SetValues(newDataItem);
                    }
                    else
                    {
                        instance.Partner.Remove(entity);
                    }
                }

                foreach (var newDataItem in allData.Partners.Where(x => !instance.Partner.Any(y => y.ID == x.ID)))
                {
                    instance.Partner.Add(newDataItem);
                }

                foreach (var entity in instance.Runner)
                {
                    var newDataItem = allData.Runners.FirstOrDefault(x => x.ID == entity.ID);
                    if (newDataItem != null)
                    {
                        instance.Entry(entity).CurrentValues.SetValues(newDataItem);
                    }
                    else
                    {
                        instance.Runner.Remove(entity);
                    }
                }

                foreach (var newDataItem in allData.Runners.Where(x => !instance.Runner.Any(y => y.ID == x.ID)))
                {
                    instance.Runner.Add(newDataItem);
                }

                foreach (var entity in instance.Team)
                {
                    var newDataItem = allData.Teams.FirstOrDefault(x => x.ID == entity.ID);
                    if (newDataItem != null)
                    {
                        instance.Entry(entity).CurrentValues.SetValues(newDataItem);
                    }
                    else
                    {
                        instance.Team.Remove(entity);
                    }
                }

                foreach (var newDataItem in allData.Teams.Where(x => !instance.Team.Any(y => y.ID == x.ID)))
                {
                    instance.Team.Add(newDataItem);
                }

                foreach (var entity in instance.Referee)
                {
                    var newDataItem = allData.Referees.FirstOrDefault(x => x.ID == entity.ID);
                    if (newDataItem != null)
                    {
                        instance.Entry(entity).CurrentValues.SetValues(newDataItem);
                    }
                    else
                    {
                        instance.Referee.Remove(entity);
                    }
                }

                foreach (var newDataItem in allData.Referees.Where(x => !instance.Referee.Any(y => y.ID == x.ID)))
                {
                    instance.Referee.Add(newDataItem);
                }

                await instance.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite(@$"Data Source={Path.GetFullPath("../../../../Data/tz.db")}") // TODO
                .EnableSensitiveDataLogging()
                .ConfigureWarnings(b => b.Ignore());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Checkpoint>().HasData(
                new Checkpoint() { ID = 1, Name = "Start/cíl" },
                new Checkpoint() { ID = 2, Name = "Odhad vzdálenosti" },
                new Checkpoint() { ID = 3, Name = "Stavba stanu" },
                new Checkpoint() { ID = 4, Name = "Orientace mapy" },
                new Checkpoint() { ID = 5, Name = "Azimutové úseky" },
                new Checkpoint() { ID = 6, Name = "Lanová lávka" },
                new Checkpoint() { ID = 7, Name = "Uzlování" },
                new Checkpoint() { ID = 8, Name = "Plížení" },
                new Checkpoint() { ID = 9, Name = "Hod kriketovým míčkem" },
                new Checkpoint() { ID = 10, Name = "Turistické a topografické značky" },
                new Checkpoint() { ID = 11, Name = "Poznávání dřevin" },
                new Checkpoint() { ID = 12, Name = "Kulturně poznávací činnost" },
                new Checkpoint() { ID = 13, Name = "Kontrola \"X\"" }
            );

            modelBuilder.Entity<AgeCategory>(entity => entity.Property(e => e.ID).ValueGeneratedOnAdd());
            modelBuilder.Entity<AgeCategory>().HasData(
                new AgeCategory() { ID = 1, AgeMin = 0, AgeMax = 10, Name = "Nejmladší žáci a žákyně", Code = "K1", Color = "Bílá" },
                new AgeCategory() { ID = 2, AgeMin = 11, AgeMax = 12, Name = "Mladší žáci a žákyně", Code = "K2", Color = "Bílá" },
                new AgeCategory() { ID = 3, AgeMin = 13, AgeMax = 14, Name = "Starší žáci a žákyně", Code = "K3", Color = "Bílá" },
                new AgeCategory() { ID = 4, AgeMin = 15, AgeMax = 16, Name = "Mladší dorostenci a dorostenky", Code = "K4", Color = "Červená" },
                new AgeCategory() { ID = 5, AgeMin = 17, AgeMax = 18, Name = "Starší dorostenci a dorostenky", Code = "K5", Color = "Červená" },
                new AgeCategory() { ID = 6, AgeMin = 19, AgeMax = 35, Name = "Dospělí A", Code = "K6", Color = "Červená" },
                new AgeCategory() { ID = 7, AgeMin = 36, AgeMax = null, Name = "Dospělí B", Code = "K7", Color = "Červená" },
                new AgeCategory() { ID = 8, AgeMin = 0, AgeMax = 30, Name = "Do 30 let", Code = "K8", Color = "Červená", Duo = true },
                new AgeCategory() { ID = 9, AgeMin = 31, AgeMax = 70, Name = "31 - 70 let", Code = "K9", Color = "Červená", Duo = true },
                new AgeCategory() { ID = 10, AgeMin = 71, AgeMax = null, Name = "Nad 70 let", Code = "K10", Color = "Červená", Duo = true }
            );

            //modelBuilder.Entity<Partner>().HasData(new Partner() { ID = 1, Name = "Milan Kundera", BirthYear = 2012 });

            //modelBuilder.Entity<Team>().HasData(new Team() { ID = 1, Name = "Divočákos" });

            //modelBuilder.Entity<Runner>().HasData(
            //    new Runner() { ID = 1, StartNumber = 18, Name = "Jožin ZBažin", TeamID = 1, BirthYear = 2009, Disqualified = false, PartnerID = 1 },
            //    new Runner() { ID = 2, StartNumber = 59, Name = "Pepa ZDepa", TeamID = 1, BirthYear = 1987, Disqualified = false }
            //);

            modelBuilder.Entity<Runner>().HasIndex(x => x.StartNumber).IsUnique();
            modelBuilder.Entity<Partner>();
            modelBuilder.Entity<Team>().HasIndex(x => x.Name).IsUnique();

            modelBuilder.Entity<Referee>().HasKey("ID");
            modelBuilder.Entity<Referee>().HasIndex(r => new { r.FirstName, r.LastName }).IsUnique();

            modelBuilder.Entity<CheckpointAgeCategoryParticipation>().HasData(
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 1, CheckpointID = 1, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 1, CheckpointID = 2, IsParticipating = false },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 1, CheckpointID = 3, IsParticipating = false },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 1, CheckpointID = 4, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 1, CheckpointID = 5, IsParticipating = false },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 1, CheckpointID = 6, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 1, CheckpointID = 7, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 1, CheckpointID = 8, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 1, CheckpointID = 9, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 1, CheckpointID = 10, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 1, CheckpointID = 11, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 1, CheckpointID = 12, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 1, CheckpointID = 13, IsParticipating = false },

                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 2, CheckpointID = 1, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 2, CheckpointID = 2, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 2, CheckpointID = 3, IsParticipating = false },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 2, CheckpointID = 4, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 2, CheckpointID = 5, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 2, CheckpointID = 6, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 2, CheckpointID = 7, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 2, CheckpointID = 8, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 2, CheckpointID = 9, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 2, CheckpointID = 10, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 2, CheckpointID = 11, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 2, CheckpointID = 12, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 2, CheckpointID = 13, IsParticipating = false },

                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 3, CheckpointID = 1, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 3, CheckpointID = 2, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 3, CheckpointID = 3, IsParticipating = false },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 3, CheckpointID = 4, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 3, CheckpointID = 5, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 3, CheckpointID = 6, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 3, CheckpointID = 7, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 3, CheckpointID = 8, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 3, CheckpointID = 9, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 3, CheckpointID = 10, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 3, CheckpointID = 11, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 3, CheckpointID = 12, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 3, CheckpointID = 13, IsParticipating = false },

                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 4, CheckpointID = 1, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 4, CheckpointID = 2, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 4, CheckpointID = 3, IsParticipating = false },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 4, CheckpointID = 4, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 4, CheckpointID = 5, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 4, CheckpointID = 6, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 4, CheckpointID = 7, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 4, CheckpointID = 8, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 4, CheckpointID = 9, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 4, CheckpointID = 10, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 4, CheckpointID = 11, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 4, CheckpointID = 12, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 4, CheckpointID = 13, IsParticipating = false },

                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 5, CheckpointID = 1, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 5, CheckpointID = 2, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 5, CheckpointID = 3, IsParticipating = false },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 5, CheckpointID = 4, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 5, CheckpointID = 5, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 5, CheckpointID = 6, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 5, CheckpointID = 7, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 5, CheckpointID = 8, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 5, CheckpointID = 9, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 5, CheckpointID = 10, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 5, CheckpointID = 11, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 5, CheckpointID = 12, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 5, CheckpointID = 13, IsParticipating = false },

                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 6, CheckpointID = 1, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 6, CheckpointID = 2, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 6, CheckpointID = 3, IsParticipating = false },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 6, CheckpointID = 4, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 6, CheckpointID = 5, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 6, CheckpointID = 6, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 6, CheckpointID = 7, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 6, CheckpointID = 8, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 6, CheckpointID = 9, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 6, CheckpointID = 10, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 6, CheckpointID = 11, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 6, CheckpointID = 12, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 6, CheckpointID = 13, IsParticipating = false },

                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 7, CheckpointID = 1, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 7, CheckpointID = 2, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 7, CheckpointID = 3, IsParticipating = false },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 7, CheckpointID = 4, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 7, CheckpointID = 5, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 7, CheckpointID = 6, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 7, CheckpointID = 7, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 7, CheckpointID = 8, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 7, CheckpointID = 9, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 7, CheckpointID = 10, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 7, CheckpointID = 11, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 7, CheckpointID = 12, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 7, CheckpointID = 13, IsParticipating = false },

                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 8, CheckpointID = 1, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 8, CheckpointID = 2, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 8, CheckpointID = 3, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 8, CheckpointID = 4, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 8, CheckpointID = 5, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 8, CheckpointID = 6, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 8, CheckpointID = 7, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 8, CheckpointID = 8, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 8, CheckpointID = 9, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 8, CheckpointID = 10, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 8, CheckpointID = 11, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 8, CheckpointID = 12, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 8, CheckpointID = 13, IsParticipating = true },

                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 9, CheckpointID = 1, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 9, CheckpointID = 2, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 9, CheckpointID = 3, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 9, CheckpointID = 4, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 9, CheckpointID = 5, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 9, CheckpointID = 6, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 9, CheckpointID = 7, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 9, CheckpointID = 8, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 9, CheckpointID = 9, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 9, CheckpointID = 10, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 9, CheckpointID = 11, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 9, CheckpointID = 12, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 9, CheckpointID = 13, IsParticipating = true },

                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 10, CheckpointID = 1, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 10, CheckpointID = 2, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 10, CheckpointID = 3, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 10, CheckpointID = 4, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 10, CheckpointID = 5, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 10, CheckpointID = 6, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 10, CheckpointID = 7, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 10, CheckpointID = 8, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 10, CheckpointID = 9, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 10, CheckpointID = 10, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 10, CheckpointID = 11, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 10, CheckpointID = 12, IsParticipating = true },
                new CheckpointAgeCategoryParticipation() { AgeCategoryID = 10, CheckpointID = 13, IsParticipating = true }
            );
        }
    }
}
