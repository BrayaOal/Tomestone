using System.Text.Json;

namespace Tomestone.Web.Components.Pages;

public partial class Home
{
    private const string ITEMS_FILE_PATH = "./MyLovelyItems.json";

    private List<ListItem> Items { get; set; } = [];

    private string ItemText { get; set; } = "";

    protected override void OnInitialized()
    {
        if (!File.Exists(ITEMS_FILE_PATH))
        {
            return;
        }

        var fileContent = File.ReadAllText(ITEMS_FILE_PATH);

        this.Items = JsonSerializer.Deserialize<List<ListItem>>(fileContent) ?? [];
    }

    private void AddItem()
    {
        if (this.ItemText is "")
        {
            return;
        }

        var newItem = new ListItem()
        {
            Description = this.ItemText,
        };

        this.Items.Add(newItem);

        this.ItemText = "";

        this.Save();
    }

    private void RemoveItem(ListItem item)
    {
        this.Items.Remove(item);

        this.Save();
    }

    private void ToggleItem(ListItem item)
    {
        item.IsComplete = !item.IsComplete;

        this.Save();
    }

    private void Save()
    {
        var itemsJson = JsonSerializer.Serialize(
            this.Items,
            new JsonSerializerOptions()
            {
                WriteIndented = true,
            }
        );

        File.WriteAllText(ITEMS_FILE_PATH, itemsJson);
    }
}