using EasyShop.Data;
using EasyShop.Models;

namespace EasyShop.Services;

public class ProductService
{
    private readonly ProductRepository _repository;

    public ProductService(ProductRepository repository)
    {
        _repository = repository;
    }

    public (bool Success, string Message) Register(string name, string priceText, string attributesText)
    {
        if (string.IsNullOrWhiteSpace(name))
            return (false, "Informe o nome do produto.");

        if (!decimal.TryParse(priceText?.Replace(',', '.'),
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture,
                out var price) || price < 0)
            return (false, "Informe um preço válido.");

        var product = new Product
        {
            Name = name.Trim(),
            Price = price,
            Attributes = ParseAttributes(attributesText)
        };

        _repository.Add(product);
        return (true, "Produto cadastrado com sucesso!");
    }

    public List<Product> GetAll() => _repository.GetAll();

    private static Dictionary<string, string> ParseAttributes(string? text)
    {
        var result = new Dictionary<string, string>();
        if (string.IsNullOrWhiteSpace(text)) return result;

        foreach (var part in text.Split(';', StringSplitOptions.RemoveEmptyEntries))
        {
            var pair = part.Split('=', 2);
            if (pair.Length == 2 && !string.IsNullOrWhiteSpace(pair[0]))
                result[pair[0].Trim()] = pair[1].Trim();
        }
        return result;
    }
} 