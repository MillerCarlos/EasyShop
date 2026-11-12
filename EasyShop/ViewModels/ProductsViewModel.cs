using System.Collections.ObjectModel;
using System.Windows.Input;
using EasyShop.Models;
using EasyShop.Services;

namespace EasyShop.ViewModels;

public class ProductsViewModel : BaseViewModel
{
    private readonly ProductService _service;

    public ObservableCollection<Product> Products { get; } = new();

    private string _name = "";
    public string Name { get => _name; set { _name = value; OnPropertyChanged(); } }

    private string _priceText = "";
    public string PriceText { get => _priceText; set { _priceText = value; OnPropertyChanged(); } }

    private string _attributesText = "";
    public string AttributesText { get => _attributesText; set { _attributesText = value; OnPropertyChanged(); } }

    private string _message = "";
    public string Message { get => _message; set { _message = value; OnPropertyChanged(); } }

    public ICommand SaveCommand { get; }
    public ICommand LoadCommand { get; }

    public ProductsViewModel(ProductService service)
    {
        _service = service;
        SaveCommand = new Command(Save);
        LoadCommand = new Command(Load);
    }

    private void Load()
    {
        Products.Clear();
        foreach (var p in _service.GetAll())
            Products.Add(p);
    }

    private void Save()
    {
        var (success, message) = _service.Register(Name, PriceText, AttributesText);
        Message = message;

        if (success)
        {
            Name = "";
            PriceText = "";
            AttributesText = "";
            Load();
        }
    }
}