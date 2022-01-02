using InterfaceSegregation.Abstractions;

namespace InterfaceSegregation.Handlers
{
    public class WebEditor : IWebEditor
    {
        public IEnumerable<IBlogPost> BuildBlogPost()
        {
            return default;
        }

        public string BuildContent()
        {
            return default;
        }

        public string CreateSearchKeywords(string content)
        {
            return default;
        }
    }
}
