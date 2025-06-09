namespace focus_flow.Shared.models;

public class tag
{
    public int Id { get; set; }
    public string Name { get; set; } = "";

    public List<taskItem> Tasks { get; set; } = new();
}