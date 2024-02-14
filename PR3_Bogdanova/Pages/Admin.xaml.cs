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
using PR3_Bogdanova.Entities;
using PR3_Bogdanova.Resources;

namespace PR3_Bogdanova.Pages
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        Entity entity = new Entity();   
        public Admin()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<information> a = new List<information>();
            var info = entity.Worker.Include("Post").ToList();

            foreach(var f in info)
            { 
                information c = new information() 
                {

                Surname = f.Surname,
                Name = f.Name,
                Patronymic = f.Patronymic,
                PostName = f.Post.Name,
                FIO = f.Surname + " " + f.Name + " " + f.Patronymic,
                Birthday = f.Birthday,
                Login = f.Login,
                Password = f.Password,
                };
                a.Append(c);
            }
            MessageBox.Show(a.Count.ToString());
            LViewWorker.ItemsSource = a;

        }
    }
}
