using System.Windows;
using System.Windows.Controls;
using AutoService.Contexts;
using AutoService.ViewModels;

namespace AutoService.View;

public partial class RegisterPage : UserControl
{
    private AuthDbContext _context;
    private MainWindow _mainWindow;
    public RegisterPage(AuthDbContext context,  MainWindow mainWindow)
    {
        InitializeComponent();
        _context = context;
        _mainWindow = mainWindow;
        DataContext = new RegisterAndSaveViewModel(context);
    }

    private void btnRegister_Click(object sender, RoutedEventArgs e)
    {
        
        var vm = (RegisterAndSaveViewModel)DataContext;

        vm.Name = txtLogin.Text;
        vm.Password = txtPassword.Password;
        if (txtPassword.Password != txtConfirmPassword.Password)
        {
            MessageBox.Show("Пароли не совпадают!");
            return;
        }

        vm.SaveClientCommand.Execute(null);
    }
    
    private void btnCancel_Click(object sender, RoutedEventArgs e)
    {
        _mainWindow.ShowLogin();
    }
}