using System;
using System.Collections.Generic;
using System.Data.Entity;
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



using utils = EdOrg.Utils;
using views = EdOrg.Views;


namespace EdOrg
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginHandler(object sender, RoutedEventArgs e)
        {
            string login = bxLogin.Text;
            string password = bxPassword.Password;
            if (string.IsNullOrEmpty(login)) 
            {
                MessageBox.Show("Заполните логин!");
            }
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Заполните пароль!");
            }
            using (var context = new EdOrgEntities())
            {
                string hash = utils.Hasher.Hash(password);
                var user = context
                            .Users
                            .Where(u => u.Login == login)
                            .Where(u => hash == u.Password)
                            .AsNoTracking()
                            .FirstOrDefault();
                if (user == null)
                {
                    MessageBox.Show("Неправильный логин и пароль");
                    return;
                }
                switch ((utils.UserType)(user.Role)) 
                {
                    case utils.UserType.Student:
                        new views.StudentView(user).Show();
                        this.Close();
                        break;
                    case utils.UserType.Teacher:
                        new views.TeacherView(user).Show();
                        this.Close();
                        break;

                }
            }
        }
    }
    
}
