using SQLite;
using EasyShop.Models;

namespace EasyShop.Data;

public class CustomerRepository
{
    private readonly SQLiteConnection _db;

    public CustomerRepository()
    {
        var path = Path.Combine(FileSystem.AppDataDirectory, "customers.db3");
        _db = new SQLiteConnection(path);
        _db.CreateTable<Customer>();
    }

    public void Add(Customer customer) => _db.Insert(customer);

    public List<Customer> GetAll() => _db.Table<Customer>().ToList();
}