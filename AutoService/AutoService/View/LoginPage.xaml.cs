using System.Windows;
using System.Windows.Controls;
using AutoService.Contexts;
using AutoService.ViewModels;

namespace AutoService.View;

public partial class LoginPage : UserControl
{
    private MainWindow _mainWindow;
    public LoginPage(AuthDbContext context, MainWindow mainWindow)
    {
        InitializeComponent();
        _mainWindow = mainWindow;
        DataContext = new LoginViewModel(context);
    }

    private void btnLogin_Click(object sender, RoutedEventArgs e)
    {
        
        var vm = (LoginViewModel)DataContext;

        string login = txtLogin.Text ?? string.Empty;
        string password = txtPassword.Password ?? string.Empty;

        if (vm.SelectedClient(login, password) != null)
        {
            _mainWindow.ShowClientBage();
        }
        else
        {
            MessageBox.Show("Неверный логин или пароль!");
        }
    }
    
    private void btnRegister_Click(object sender, RoutedEventArgs e)
    {
        _mainWindow.ShowRegister();
    }
}