using LiteDB;
using EasyShop.Models;

namespace EasyShop.Data;

public class ProductRepository
{
    private readonly ILiteCollection<Product> _collection;

    public ProductRepository()
    {
        var path = Path.Combine(FileSystem.AppDataDirectory, "products.db");
        var db = new LiteDatabase(path);
        _collection = db.GetCollection<Product>("products");
    }

    public void Add(Product product) => _collection.Insert(product);

    public List<Product> GetAll() => _collection.FindAll().ToList();
}