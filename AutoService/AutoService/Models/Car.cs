
namespace AutoService.Models;
using System.ComponentModel;
using CommunityToolkit.Mvvm;

public class Car : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    
    protected void OnPropertyChanged(string propertyName)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    public string Id { get; set; } =  Guid.NewGuid().ToString();
    
    private string _carname;
    public string CarName
    {
        get => _carname;
        set
        {
            _carname = value;
            OnPropertyChanged(nameof(CarName));
        }
    }
    
    public string ClientId { get; set; }
    public Client Client { get; set; }
    
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}