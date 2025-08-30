using System.ComponentModel;

namespace AutoService.Models;

public class Client : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    
    protected void OnPropertyChanged(string propertyName) 
    => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    public string Id { get; set; } =  Guid.NewGuid().ToString();
    
    private string _name;
    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged(nameof(Name));
        }
    }

    private string _password;
    public string Password
    {
        get => _password;
        set
        {
            _password = value;
            OnPropertyChanged(nameof(Password));
        }
    }
    
    public ICollection<Car> Cars { get; set; }
    public ICollection<Order> Orders { get; set; }
    
}