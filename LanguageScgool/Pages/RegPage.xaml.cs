using LanguageScgool.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LanguageScgool.Pages
{
    /// <summary>
    /// Interaction logic for RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTb.Text.Trim().Length <= 0 || PasswordTb.Text.Trim().Length <= 0 || TwoPasswordTb.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Заполните все поля!");
            }
            else
            {
                if (PasswordTb.Text.Trim().Length != TwoPasswordTb.Text.Trim().Length)
                {
                    MessageBox.Show("Пароли не совпадают!");
                }

                else
                {

                    if (App.db.User.ToList().Find(x => x.Login == LoginTb.Text) != null)
                    {
                        MessageBox.Show("Такой пользователь уже есть!");
                    }
                    else
                    {
                        App.db.User.Add(new User()
                        {
                            Login = LoginTb.Text.Trim(),
                            Password = PasswordTb.Text.Trim(),
                            RoleId = 2
                        });
                        App.db.SaveChanges();
                        MessageBox.Show("Регистрауия прошла успешно!");
                        NavigationService.GoBack();
                    }
                }
            }
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            LoginTb.Clear();
            PasswordTb.Clear();
            TwoPasswordTb.Clear();
        }
    }
}

