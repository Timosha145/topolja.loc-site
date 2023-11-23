namespace topolja.loc_site.Models
{
    public class Footballer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Gender { get; set; }
        public DateOnly Birthday { get; set; }
        public int TeamId { get; set; }
        public string? Country { get; set; }

        public Team? Team { get; set; }
    }
}
