
namespace turisticky_zavod.Data
{
    public class Log
    {
        public int ID { get; set; }

        private string message;
        public string Message
        {
            get => message;
            set
            { 
                message = value;
                Timestamp = DateTime.Now;
            }
        }

        public string Type { get; set; }

        public DateTime Timestamp { get; private set; }

        public override string ToString()
            => $"{Timestamp:HH:mm:ss} [{Type.ToUpper()}] {Message}";
    }
}
