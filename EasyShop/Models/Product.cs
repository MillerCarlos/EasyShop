using LiteDB;

namespace EasyShop.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public decimal Price { get; set; }
    public Dictionary<string, string> Attributes { get; set; } = new();

    [BsonIgnore]
    public string AttributesText =>
        Attributes.Count == 0
            ? "Sem atributos"
            : string.Join(", ", Attributes.Select(a => $"{a.Key}: {a.Value}"));
}