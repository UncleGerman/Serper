namespace Serper.BLL.Service.Validate
{
    internal class ValueValidateService : IValueValidateService
    {
        public void CheckValue(object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
        }

        public void CheckValue(int id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("id");
            }
        }

        public void CheckValue(int id, int arrayCount)
        {
            if (id > arrayCount)
            {
                throw new ArgumentOutOfRangeException("id");
            }
        }
    }
}