namespace Serper.BLL.Entity.Authorization
{
    public sealed class AuthorizationParameters : IRegistration, IAuthorization
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

        public bool RememberMe { get; set; }
    }
}