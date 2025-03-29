using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ПР6_часть_2
{
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
        }

        public bool RegisterUser(string fio, string login, string password, string gender, string role, string phone, string photo)
        {
            if (string.IsNullOrEmpty(fio) || string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(gender) || string.IsNullOrEmpty(role) || string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Пожалуйста, заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            try
            {
                using (var db = new Entities())
                {
                    if (db.Userr.Any(u => u.Loginn == login))
                    {
                        MessageBox.Show("Пользователь с таким логином уже существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }

                    var newUser = new Userr
                    {
                        FIO = fio,
                        Loginn = login,
                        Passwordd = password,
                        Gender = gender,
                        Rolee = role,
                        Phone = phone,
                        Photo = photo
                    };

                    db.Userr.Add(newUser);
                    db.SaveChanges();

                    MessageBox.Show("Пользователь успешно зарегистрирован!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при регистрации: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            string fio = TextBoxFIO.Text;
            string login = TextBoxLogin.Text;
            string password = PasswordBox.Password;
            string gender = RadioMale.IsChecked == true ? "Мужской" : "Женский";
            string role = (CmbRole.SelectedItem as ComboBoxItem)?.Content.ToString();
            string phone = TextBoxPhone.Text;
            string photo = TextBoxPhoto.Text;

            RegisterUser(fio, login, password, gender, role, phone, photo);
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
