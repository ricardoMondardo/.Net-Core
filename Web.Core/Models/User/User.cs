namespace Web.Core.Models.User
{
    public class User : IEntityBase
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public int ActiveCode { get; set; }
    }
}
