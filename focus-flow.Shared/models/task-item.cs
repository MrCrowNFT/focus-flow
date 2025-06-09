using System.Dynamic;

namespace focus_flow.Shared.models;

public class taskItem
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string? Description { get; set; }


    public DateTime StartDate { get; set; }
    public DateTime? DueDate { get; set; }

    public taskPriority Priority { get; set; } = taskPriority.Medium;
    public taskStatus Status { get; set; } = taskStatus.Pending;

    public List<tag> Tags { get; set; } = new();
}
