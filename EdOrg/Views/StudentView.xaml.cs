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
using System.Windows.Shapes;
using utils = EdOrg.Utils; 

namespace EdOrg.Views
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class StudentView : Window
    {
        Users user;
        Subjects currentSubject;
        public StudentView(Users user)
        {
            InitializeComponent();
            this.user = user;
            dgMarks.ItemsSource = user.Marks;

            // Добавление предметов в комбобокс предметов
            List<Subjects> subjects;
            using(var context = new EdOrgEntities())
            {
                subjects = context.Subjects.ToList();
            }
            cbxCurrentSubject.Items.Add(new utils.comboBoxItem<Subjects> { Text = "Все", Value = null });
            foreach (var subject in subjects)
            {
                cbxCurrentSubject.Items.Add(new utils.comboBoxItem<Subjects> { Text = subject.Name, Value = subject });
            }
            cbxCurrentSubject.SelectedIndex = 0;
        }

        private void ChangeCurrentSubject(object sender, SelectionChangedEventArgs e)
        {
            utils.comboBoxItem<Subjects> currentItem = cbxCurrentSubject.SelectedItem as utils.comboBoxItem<Subjects>;
            if (currentItem.Value == null) 
            {
                currentSubject = currentItem.Value;
                dgMarks.ItemsSource = user.Marks.ToList();
                return;
            }
            currentSubject = currentItem.Value;
            dgMarks.ItemsSource = user.Marks.Where(m => m.Subjects.Id == currentSubject.Id).ToList();
        }
        private void logout(object sender, EventArgs e)
        {
            App.logout(this);
        }
    }
}
