using EasyShop.Data;
using EasyShop.Models;

namespace EasyShop.Services;

public class CustomerService
{
    private readonly CustomerRepository _repository;

    public CustomerService(CustomerRepository repository)
    {
        _repository = repository;
    }

    public (bool Success, string Message) Register(string name, string email)
    {
        if (string.IsNullOrWhiteSpace(name))
            return (false, "Informe o nome completo.");

        if (string.IsNullOrWhiteSpace(email) || !email.Contains('@') || !email.Contains('.'))
            return (false, "Informe um e-mail válido.");

        _repository.Add(new Customer { Name = name.Trim(), Email = email.Trim() });
        return (true, "Cliente cadastrado com sucesso!");
    }

    public List<Customer> GetAll() => _repository.GetAll();
}