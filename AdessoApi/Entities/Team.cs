namespace AdessoApi.Entities
{
    public class Team : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string DrawnBy { get; set; }
        public Guid CountryId { get; set; }
        public Guid? GroupId { get; set; }
        public Country? Country { get; set; }
        public Group? Group { get; set; }
    }
}
