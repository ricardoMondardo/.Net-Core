namespace Web.Core.Models
{
    public class Todo : IEntityBase
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public bool Active { get; set; }
        public string UserId { get; set; }

      
    }
}
