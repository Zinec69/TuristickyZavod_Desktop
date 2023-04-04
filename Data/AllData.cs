
namespace turisticky_zavod.Data
{
    public class AllData
    {
        public List<Runner> Runners {  get; set; }
        public List<AgeCategory> AgeCategories { get; set; }
        public List<Checkpoint> Checkpoints { get; set; }
        public List<Partner> Partners { get; set; }
        public List<Team> Teams { get; set; }
        public List<Referee> Referees { get; set; }
        public List<CheckpointAgeCategoryParticipation> CheckpointAgeCategoryParticipations { get; set; }
    }
}
