using System.Collections.ObjectModel;
using System.Windows.Input;
using AutoService.Contexts;
using AutoService.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AutoService.ViewModels;

public class LoginViewModel : ObservableObject
{
    private readonly AuthDbContext _context;

    public LoginViewModel(AuthDbContext context)
    {
        _context = context;
        Clients = new ObservableCollection<Client>(context.Clients);
    }
    
    public ObservableCollection<Client> Clients {get; set;}
    
    public Client? SelectedClient(string name, string password)
    {
        foreach (Client client in _context.Clients)
        {
            if (client.Name == name && client.Password == password)
            {
                return client;
            }
        }
        return null;
    }
}