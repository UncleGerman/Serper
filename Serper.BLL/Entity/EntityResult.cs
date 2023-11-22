namespace Serper.BLL.Entity
{
    public sealed class EntityResult
    {
        public bool Success { get; set; } = false;

        public string? ErrorMessage { get; set; } = null;
    }
}