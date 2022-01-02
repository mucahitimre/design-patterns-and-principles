namespace InterfaceSegregation.Abstractions;

public interface IWebEditor : IEditor
{
    string CreateSearchKeywords(string content);

    IEnumerable<IBlogPost> BuildBlogPost();
}