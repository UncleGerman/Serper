namespace Serper.BLL.Entity.Authorization
{
    public interface IAuthorization
    {
        public string Password { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public bool RememberMe { get; set; }
    }
}