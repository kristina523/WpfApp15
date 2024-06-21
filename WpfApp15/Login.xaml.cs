using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp15
{
    public partial class Login : Window
    {
        public Login()
        
            {
                InitializeComponent();
            }

            private void BtnLogin_Click(object sender, RoutedEventArgs e)
            {
                string username = txtUsername.Text;
                string password = txtPassword.Password;

                if (username == "пациент" && password == "123")
                {
                    lblMessage.Content = "Вошёл как Пациент.";
                }
                else if (username == "врач" && password == "456")
                {
                    lblMessage.Content = "Вошел как доктор";
                }
                else if (username == "администратор" && password == "789")
                {
                    lblMessage.Content = "Вошёл как администратор.";
                }
                else
                {
                    lblMessage.Content = "Неправильное имя пользователя или пароль.";
                }
            }
        }
    }
