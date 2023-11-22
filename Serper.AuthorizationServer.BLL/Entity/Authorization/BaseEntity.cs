namespace Serper.AuthorizationServer.BLL.Entity.Authorization
{
    public abstract class BaseEntity
    {
        public string? Password { get; set; }

        public string? UserName { get; set; }

        public string? Email
        {
            get => _email;
            set
            {
                UserName = value;
                _email = value;
            }
        }

        private string? _email;
    }
}