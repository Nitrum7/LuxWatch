namespace LuxWatch.Model
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public string WatchRefNum { get; set; }
        public virtual Watch Watch { get; set; }
    }
}
