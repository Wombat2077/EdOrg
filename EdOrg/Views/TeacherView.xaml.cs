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
using utils = EdOrg.Utils;

namespace EdOrg.Views
{
    /// <summary>
    /// Логика взаимодействия для TeacherView.xaml
    /// </summary>
    public partial class TeacherView : Window
    {
        Users user;
        int? currentStudent;
        int? currentGroup;
        List<Marks> marks;
        public TeacherView(Users user)
        {
            InitializeComponent();
            this.user = user;
            List<Groups> groups;
            List<Users> students;
            List<Subjects> subjects;
            using (var context = new EdOrgEntities())
            {
                groups = context.Groups.ToList();
                marks = context.Marks.ToList();

                students = context
                                .Users
                                .Where(u => u.Role == (int)utils.UserType.Student)
                                .ToList();
                subjects = context.Subjects.ToList();

                var gItems = utils.comboBoxItem<Groups>
                                                    .ListFrom(groups.Select(g => (g.Name, g)).ToList());
                gItems.Insert(0, new utils.comboBoxItem<Groups> { Text = "Все группы", Value = null });
                cbxGroup.ItemsSource = gItems;

                cbxGroup.SelectedIndex = 0;
                var sItems = utils.comboBoxItem<Users>
                                                    .ListFrom(students.Select(s => (s.fullName, s)).ToList());
                sItems.Insert(0, new utils.comboBoxItem<Users> { Text = "Все студенты", Value = null });
                cbxStudent.ItemsSource = sItems;
                cbxStudent.SelectedIndex = 0;

                dgMarks.ItemsSource = marks;
            }
        }

        private void StudentChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentItem = cbxGroup.SelectedItem as utils.comboBoxItem<Users>;
            this.currentGroup = currentItem.Value?.Id;
            dgMarks.ItemsSource = marks.Where(m => m.UserId == currentStudent | currentStudent == 0)
                                       .Where(m => m.Users.GroupId == currentGroup | currentGroup == 0).ToList();
        }

        private void GroupChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentItem = cbxGroup.SelectedItem as utils.comboBoxItem<Groups>;
            this.currentGroup = currentItem.Value?.Id;
            dgMarks.ItemsSource = marks.Where(m => m.Users.GroupId == currentGroup | currentGroup == 0)
                                       .Where(m => m.Users.GroupId == currentGroup | currentGroup == 0).ToList();
        }
    }

}
