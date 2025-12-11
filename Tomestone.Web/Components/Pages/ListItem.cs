namespace Tomestone.Web.Components.Pages;

public class ListItem
{
    public required string Description { get; set; }

    public bool IsComplete { get; set; }

    public DateTimeOffset CreationDate { get; init; } = DateTimeOffset.UtcNow;
}