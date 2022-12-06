namespace ngchat.data.Entities
{
    public class Connections
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string SignalrId { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
