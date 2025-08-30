using System.Collections.ObjectModel;
using System.Windows.Input;
using AutoService.Contexts;
using AutoService.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AutoService.ViewModels;

public class RegisterAndSaveViewModel : ObservableObject
{
    private readonly AuthDbContext _context;

    public RegisterAndSaveViewModel(AuthDbContext context)
    {
        _context = context;
        SaveClientCommand = new RelayCommand(SaveClient);
    }
    
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
    
    public ICommand SaveClientCommand { get; }
    private void SaveClient()
    {
        var client = new Client
        {
            Name = this.Name,
            Password = this.Password
        };

        _context.Clients.Add(client);
        _context.SaveChanges();

        Name = string.Empty;
        Password = string.Empty;
        
        System.Windows.MessageBox.Show("Клиент зарегистрирован!");
    }
    

}