using System;
using System.Windows;
using System.Windows.Media;
using System.Data.SQLite;
using System.IO;

namespace WpfApp15
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            string fullName = txtFullName.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Password;

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                lblMessage.Content = "Все поля обязательны для заполнения.";
                return;
            }

            if (!IsValidEmail(email))
            {
                lblMessage.Content = "Неверный формат электронной почты.";
                return;
            }

            bool isRegistered = RegisterUser(fullName, email, password);

            if (isRegistered)
            {
                lblMessage.Foreground = new SolidColorBrush(Colors.Green);
                lblMessage.Content = "Регистрация прошла успешно!";
            }
            else
            {
                lblMessage.Foreground = new SolidColorBrush(Colors.Red);
                lblMessage.Content = "Регистрация не удалась.";
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool RegisterUser(string fullName, string email, string password)
        {
            try
            {
                using (var connection = new SQLiteConnection($"Data Source=;Version=3;"))
                {
                    connection.Open();
                    string sql = "INSERT INTO Users (FullName, Email, Password) VALUES (@FullName, @Email, @Password)";
                    using (var command = new SQLiteCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@FullName", fullName);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Password", password);
                        command.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                lblMessage.Content = $"Error: {ex.Message}";
                return false;
            }
        }
    }
}