namespace turisticky_zavod.Data
{
    public class Runner
    {
        public int? ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get { return $"{FirstName} {LastName}"; } }
        public int BirthYear { get; set; }
        public string Team { get; set; }
        public long StartTime { get; set; }
        public long? FinishTime { get; set; }
        public int TimeWaited { get; set; }
        public int PenaltySeconds { get; set; }
        public bool Disqualified { get; set; }
        public Runner? Partner { get; set; }
        public AgeCategory AgeCategory { get { return new AgeCategory(BirthYear, Partner != null); } }
    }
}
