using System.Collections.ObjectModel;
using System.Windows.Input;
using EasyShop.Models;
using EasyShop.Services;

namespace EasyShop.ViewModels;

public class CustomersViewModel : BaseViewModel
{
    private readonly CustomerService _service;

    public ObservableCollection<Customer> Customers { get; } = new();

    private string _name = "";
    public string Name { get => _name; set { _name = value; OnPropertyChanged(); } }

    private string _email = "";
    public string Email { get => _email; set { _email = value; OnPropertyChanged(); } }

    private string _message = "";
    public string Message { get => _message; set { _message = value; OnPropertyChanged(); } }

    public ICommand SaveCommand { get; }
    public ICommand LoadCommand { get; }

    public CustomersViewModel(CustomerService service)
    {
        _service = service;
        SaveCommand = new Command(Save);
        LoadCommand = new Command(Load);
    }

    private void Load()
    {
        Customers.Clear();
        foreach (var c in _service.GetAll())
            Customers.Add(c);
    }

    private void Save()
    {
        var (success, message) = _service.Register(Name, Email);
        Message = message;

        if (success)
        {
            Name = "";
            Email = "";
            Load();
        }
    }
}