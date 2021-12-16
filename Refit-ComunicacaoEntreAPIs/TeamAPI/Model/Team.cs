namespace TeamAPI.Model
{
    public class Team
    {
        public string? Name { get; set; }
        public string? Apelido { get; set; }
        public List<PlayerResponse>? Players { get; set; }
    }
}
