using ClosedXML.Excel;
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
        public DbSet<CheckpointRunnerInfo> CheckpointRunnerInfo { get; set; }
        public DbSet<CheckpointAgeCategoryParticipation> CheckpointAgeCategoryParticipation { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<Log> Log { get; set; }

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

        public bool IsSaved { get; private set; } = true;
        public string? SavedFilePath { get; private set; } = null;


        public override int SaveChanges()
        {
            IsSaved = false;
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            IsSaved = false;
            return base.SaveChangesAsync(cancellationToken);
        }

        public void SaveToFile(string? filePath = null)
        {
            var path = filePath ?? SavedFilePath!;

            if (path[(path.LastIndexOf('.') + 1)..].ToLower() == "json")
                ExportToJson(path);
            else
                FileHelper.ExportToExcel(instance.Runner.Local.ToList(), path);
        }

        private void ExportToJson(string filePath)
        {
            var allData = new AllData()
            {
                Runners = instance.Runner.Local.ToList(),
                Teams = instance.Team.Local.ToList(),
                Referees = instance.Referee.Local.ToList(),
                Partners = instance.Partner.Local.ToList(),
                Checkpoints = instance.Checkpoint.Local.ToList(),
                CheckpointAgeCategoryParticipations = instance.CheckpointAgeCategoryParticipation.Local.ToList(),
                AgeCategories = instance.AgeCategory.Local.ToList()
            };

            FileHelper.ExportEverythingToJSON(allData, filePath);

            IsSaved = true;
            SavedFilePath = filePath;
        }

        public async static void LoadFromJson(string filePath)
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

                    await instance.SaveChangesAsync();
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
                new Checkpoint() { ID = 1,  Name = "Start/cíl",                        Disqualifiable = false },
                new Checkpoint() { ID = 2,  Name = "Odhad vzdálenosti",                Disqualifiable = true },
                new Checkpoint() { ID = 3,  Name = "Stavba a složení stanu",           Disqualifiable = true },
                new Checkpoint() { ID = 4,  Name = "Orientace mapy",                   Disqualifiable = false },
                new Checkpoint() { ID = 5,  Name = "Azimutové úseky",                  Disqualifiable = true },
                new Checkpoint() { ID = 6,  Name = "Lanová lávka",                     Disqualifiable = true },
                new Checkpoint() { ID = 7,  Name = "Uzlování",                         Disqualifiable = false },
                new Checkpoint() { ID = 8,  Name = "Plížení",                          Disqualifiable = true },
                new Checkpoint() { ID = 9,  Name = "Hod kriketovým míčkem",            Disqualifiable = false },
                new Checkpoint() { ID = 10, Name = "Turistické a topografické značky", Disqualifiable = false },
                new Checkpoint() { ID = 11, Name = "Dřeviny",                          Disqualifiable = false },
                new Checkpoint() { ID = 12, Name = "Kulturně poznávací činnost",       Disqualifiable = false },
                new Checkpoint() { ID = 13, Name = "Kontrola \"X\"",                   Disqualifiable = true }
            );

            modelBuilder.Entity<AgeCategory>().HasIndex(x => x.Code).IsUnique();
            modelBuilder.Entity<AgeCategory>().HasData(
                new AgeCategory() { ID = 1,  AgeMin = 0,  AgeMax = 10,   Name = "Nejmladší žáci",         Code = "NŽH",   Gender = Gender.MALE,       Color = "Bílá" },
                new AgeCategory() { ID = 2,  AgeMin = 0,  AgeMax = 10,   Name = "Nejmladší žákyně",       Code = "NŽD",   Gender = Gender.FEMALE,     Color = "Bílá" },
                new AgeCategory() { ID = 3,  AgeMin = 11, AgeMax = 12,   Name = "Mladší žáci",            Code = "MŽH",   Gender = Gender.MALE,       Color = "Bílá" },
                new AgeCategory() { ID = 4,  AgeMin = 11, AgeMax = 12,   Name = "Mladší žákyně",          Code = "MŽD",   Gender = Gender.FEMALE,     Color = "Bílá" },
                new AgeCategory() { ID = 5,  AgeMin = 13, AgeMax = 14,   Name = "Starší žáci",            Code = "SŽH",   Gender = Gender.MALE,       Color = "Bílá" },
                new AgeCategory() { ID = 6,  AgeMin = 13, AgeMax = 14,   Name = "Starší žákyně",          Code = "SŽD",   Gender = Gender.FEMALE,     Color = "Bílá" },
                new AgeCategory() { ID = 7,  AgeMin = 15, AgeMax = 16,   Name = "Mladší dorostenci",      Code = "MDH",   Gender = Gender.MALE,       Color = "Červená" },
                new AgeCategory() { ID = 8,  AgeMin = 15, AgeMax = 16,   Name = "Mladší dorostenky",      Code = "MDD",   Gender = Gender.FEMALE,     Color = "Červená" },
                new AgeCategory() { ID = 9,  AgeMin = 17, AgeMax = 18,   Name = "Starší dorostenci",      Code = "SDH",   Gender = Gender.MALE,       Color = "Červená" },
                new AgeCategory() { ID = 10, AgeMin = 17, AgeMax = 18,   Name = "Starší dorostenky",      Code = "SDD",   Gender = Gender.FEMALE,     Color = "Červená" },
                new AgeCategory() { ID = 11, AgeMin = 19, AgeMax = 35,   Name = "Dospělí A - Muži",       Code = "MA",    Gender = Gender.MALE,       Color = "Červená" },
                new AgeCategory() { ID = 12, AgeMin = 19, AgeMax = 35,   Name = "Dospělí A - Ženy",       Code = "ŽA",    Gender = Gender.FEMALE,     Color = "Červená" },
                new AgeCategory() { ID = 13, AgeMin = 36, AgeMax = null, Name = "Dospělí B - Muži",       Code = "MB",    Gender = Gender.MALE,       Color = "Červená" },
                new AgeCategory() { ID = 14, AgeMin = 36, AgeMax = null, Name = "Dospělí B - Ženy",       Code = "ŽB",    Gender = Gender.FEMALE,     Color = "Červená" },
                                                                                                          
                new AgeCategory() { ID = 15, AgeMin = 0,  AgeMax = 30,   Name = "Do 30 let",              Code = "30-",   Gender = Gender.IRRELEVANT, Color = "Červená", Type = CategoryType.DUOS },
                new AgeCategory() { ID = 16, AgeMin = 31, AgeMax = 70,   Name = "31 - 70 let",            Code = "31-70", Gender = Gender.IRRELEVANT, Color = "Červená", Type = CategoryType.DUOS },
                new AgeCategory() { ID = 17, AgeMin = 71, AgeMax = null, Name = "Nad 70 let",             Code = "70+",   Gender = Gender.IRRELEVANT, Color = "Červená", Type = CategoryType.DUOS },

                new AgeCategory() { ID = 18, AgeMin = 0,  AgeMax = 14,   Name = "Žáci 14 let a mladší",   Code = "H14-",  Gender = Gender.MALE,       Color = "Červená", Type = CategoryType.RELAY },
                new AgeCategory() { ID = 19, AgeMin = 0,  AgeMax = 14,   Name = "Žákyně 14 let a mladší", Code = "D14-",  Gender = Gender.FEMALE,     Color = "Červená", Type = CategoryType.RELAY },
                new AgeCategory() { ID = 20, AgeMin = 15, AgeMax = null, Name = "Muži 15 let a starší",   Code = "M15+",  Gender = Gender.MALE,       Color = "Červená", Type = CategoryType.RELAY },
                new AgeCategory() { ID = 21, AgeMin = 15, AgeMax = null, Name = "Ženy 15 let a starší",   Code = "Ž15+",  Gender = Gender.FEMALE,     Color = "Červená", Type = CategoryType.RELAY }
            );

            modelBuilder.Entity<Runner>().HasIndex(x => x.StartNumber).IsUnique();
            modelBuilder.Entity<Partner>();
            modelBuilder.Entity<Team>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Log>();
            modelBuilder.Entity<CheckpointRunnerInfo>();

            modelBuilder.Entity<Referee>().HasKey("ID");
            modelBuilder.Entity<Referee>().HasIndex(r => new { r.FirstName, r.LastName }).IsUnique();

            modelBuilder.Entity<CheckpointAgeCategoryParticipation>().HasData(
                GetCheckpointAgeCategoryParticipations()
            );
        }

        private static CheckpointAgeCategoryParticipation[] GetCheckpointAgeCategoryParticipations()
        {
            var res = new CheckpointAgeCategoryParticipation[21 * 13];

            var index = 0;
            for (int i = 1; i <= 21; i++)
            {
                for (int j = 1; j <= 13; j++)
                {
                    res[index++] = new CheckpointAgeCategoryParticipation()
                    {
                        AgeCategoryID = i,
                        CheckpointID = j,
                        IsParticipating = i switch
                        {
                            <= 2  => j is not 2 and not 3 and not 5 and not 13,
                            >= 18 => j is not 3 and not 13,
                            >= 15 => true,
                            >= 3  => j is not 3 and not 13
                        }
                    };
                }
            }

            return res;
        }
    }
}
