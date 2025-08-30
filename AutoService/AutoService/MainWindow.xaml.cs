using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AutoService.Contexts;
using AutoService.View;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AutoService;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private AuthDbContext _context;
    private LoginPage _loginPage;
    private RegisterPage _registerPage;
    private ClientBage _clientBage;
    public MainWindow()
    {
        InitializeComponent();

        var configuration = new ConfigurationBuilder()
            .SetBasePath(System.IO.Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        
        var connectionString = configuration.GetConnectionString("Default");
        
        var options = new DbContextOptionsBuilder<AuthDbContext>()
            .UseSqlServer(connectionString)
            .Options;

        _context = new AuthDbContext(options);
        
        _loginPage = new LoginPage(_context, this);
        _registerPage = new RegisterPage(_context, this);
        
        MainContent.Content = _loginPage;
    }
    public void ShowLogin() => MainContent.Content = _loginPage;
    public void ShowRegister() => MainContent.Content = _registerPage;
    public void ShowClientBage() => MainContent.Content = _clientBage;

}