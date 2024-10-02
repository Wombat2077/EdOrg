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
            List<Subjects> subjects;
            using(var context = new EdOrgEntities())
            {
                subjects = context.Subjects.ToList();
            }
            foreach(var subject in subjects)
            {
                cbxCurrentSubject.Items.Add(new comboBoxItem<Subjects> { Text = subject.Name, Value = subject });
            }
        }

        class comboBoxItem<T>
        {
            public string Text { get; set; }
            public T Value { get; set; }
            public override string ToString()
            {
                return Text;
            }
        }

        private void ChangeCurrentSubject(object sender, SelectionChangedEventArgs e)
        {
            comboBoxItem<Subjects> currentItem = cbxCurrentSubject.SelectedItem as comboBoxItem<Subjects>;
            currentSubject = currentItem.Value;
            dgMarks.ItemsSource = user.Marks.Where(m => m.Subjects.Id == currentSubject.Id).ToList();
        }
    }
}
