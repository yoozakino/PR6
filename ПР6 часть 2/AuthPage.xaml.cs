using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ПР6_часть_2
{
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        // Новый метод для авторизации
        public bool Auth(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пожалуйста, заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            try
            {
                using (var db = new Entities())
                {
                    // Поиск пользователя в базе данных
                    var user = db.Userr.FirstOrDefault(u => u.Loginn == login && u.Passwordd == password);

                    if (user != null)
                    {
                        MessageBox.Show($"Здравствуйте, {user.Rolee} {user.Loginn}!", "Успешная авторизация", MessageBoxButton.OK, MessageBoxImage.Information);
                        return true; // Успешная авторизация
                    }
                    else
                    {
                        MessageBox.Show("Пользователь с такими данными не найден!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false; // Ошибка авторизации
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при авторизации: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            // Вызов метода Auth с параметрами из полей ввода
            bool isAuthenticated = Auth(TextBoxLogin.Text, PasswordBox.Password);
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            // Переход на страницу регистрации
            NavigationService.Navigate(new RegPage());
        }
    }
}
