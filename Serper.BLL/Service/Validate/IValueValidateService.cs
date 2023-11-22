namespace Serper.BLL.Service.Validate
{
    internal interface IValueValidateService
    {
        public void CheckValue(object value);

        public void CheckValue(int id);

        public void CheckValue(int id, int arrayCount);
    }
}