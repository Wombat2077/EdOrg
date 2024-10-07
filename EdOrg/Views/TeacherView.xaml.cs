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
        public TeacherView(Users user)
        {
            InitializeComponent();
            this.user = user;
            List<Groups> groups;
            List<Users> students;
            List<Marks> marks;
            using(var context = new EdOrgEntities())
            {
                groups = context.Groups.ToList();
                marks = context.Marks.ToList();
                students = context
                                .Users
                                .Where(u => u.Role == (int)utils.UserType.Student)
                                .ToList();
            }
            var gItems = utils.comboBoxItem<Groups>
                                                .ListFrom(groups.Select(g => (g.Name, g)).ToList());
            gItems.Add(new utils.comboBoxItem<Groups> {  Text = "Все группы", Value = null });
            cbxGroup.ItemsSource = gItems;
            
            cbxGroup.SelectedIndex = 0;
            var sItems = utils.comboBoxItem<Users>
                                                .ListFrom(students.Select(s => (s.fullName, s)).ToList());
            sItems.Add(new utils.comboBoxItem<Users> { Text = "Все студенты", Value = null });
            cbxStudent.ItemsSource = sItems;
        }
    }
}
