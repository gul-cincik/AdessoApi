namespace AdessoApi.Entities
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public ICollection<Team> Teams { get; set; } = new List<Team>();
    }
}
