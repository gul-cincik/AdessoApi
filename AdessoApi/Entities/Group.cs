namespace AdessoApi.Entities
{
    public class Group : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Team> Teams { get; set; } = new List<Team>();

        
    }
}
