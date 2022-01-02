using InterfaceSegregation.Abstractions;

namespace InterfaceSegregation.Handlers
{
    public class NewsEditor : INewsEditor
    {
        public string BuildContent()
        {
            return default;
        }

        public bool GetApproval(string content)
        {
            return default;
        }

        public void PrepareDay(string content)
        {
        }
    }
}
