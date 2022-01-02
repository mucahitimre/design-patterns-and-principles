namespace InterfaceSegregation.Abstractions;

public interface INewsEditor : IEditor
{
    void PrepareDay(string content);

    bool GetApproval(string content);
}