namespace Serper.BLL.Entity.Identity
{
    public sealed class ApplicationUserDTO
    {
        public Guid Id { get; set; }

        public string? UserName { get; set; }

        public string? PasswordHash { get; set; }

        public string? Email { get; set; }

        public string? RoleName { get; set; }
    }
}