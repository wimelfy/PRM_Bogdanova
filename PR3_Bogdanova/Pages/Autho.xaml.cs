using PR3_Bogdanova.Entities;
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
using System.ComponentModel.DataAnnotations;
using System.Windows.Threading;

namespace PR3_Bogdanova.Pages
{
    /// <summary>
    /// Логика взаимодействия для Autho.xaml
    /// </summary>
    public partial class Autho : Page
    {
        private DispatcherTimer cdtimer;    // создаем таймер 
        Entity entity = new Entity();        // привязываем модель
        int Neud = 0;                       // кол-во неудачных попыток входа
        int timertick = 0;                  // тики 
        
        public Autho()

        {
            InitializeComponent();

            // скрываем капчу по умолчанию
            txtCaptcha.Visibility = Visibility.Hidden;
            textBlockCaptcha.Visibility = Visibility.Hidden;

            // экземляр класса DispatcherTimer c параметрами интервала и привязкой метода интервала
            cdtimer = new DispatcherTimer();
            cdtimer.Interval = new TimeSpan(0,0,1);
            cdtimer.Tick += IntervalTick;
            // Блокировка доступа к системе
            if (!IsAsccessAllowed())
            {
                MessageBox.Show("Вход заблокирован. Подождите исчетения блокировки.");
                Application.Current.Shutdown();
            }
        }

        private void btnEnterGuest_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Client());
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text.Trim();

            // 3 некорректные попытки входа 
            if (Neud >= 3)
            {
                // открываем капчу, генерим
                txtCaptcha.Visibility = Visibility.Visible;
                textBlockCaptcha.Visibility = Visibility.Visible;
                GenerateCaptcha();
                if (txtCaptcha.Text != textBlockCaptcha.Text) // если неверно то по новой
                {
                    cdtimer.Start();
                    BlockLogin();
                    GenerateCaptcha();
                    return;
                }
                // открываем подсчет таймера и блокируем 
                cdtimer.Start();
                BlockLogin();
            }

            // параметры авторизации
            var worker = entity.Worker.Where(p => p.Login == login && p.Password == password).FirstOrDefault();

            // входим, обнуляем попытки и скрываем капчу. в противном случае увеличиваем попытки
            if (worker != null)
            {
                MessageBox.Show("Вы вошли под: " + worker.Post.Name);
                LoadForm(worker.Post.Name);
                Neud = 0;
                txtCaptcha.Visibility = Visibility.Hidden;
                textBlockCaptcha.Visibility = Visibility.Hidden;
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!");
                Neud++;
            }        
        }

        // Получение данных для блокировки доступа к системе
        private bool IsAsccessAllowed() 
        {
            int currentHour = DateTime.Now.Hour;                // получаем текущее время
            return currentHour >= 10 && currentHour <= 19;      // задаем временной интервал
        }


        // Блокировка окна авторизации
        public void IntervalTick(object sender,object e)
        {
            timertick++;                                // увеличиваем время
            TimerBlock.Text = timertick.ToString();     // выводим время на TextBlock
            if (timertick == 10)
            {                                           // останавливаем таймер, очищаем переменную
                cdtimer.Stop();                         // и блок вывода, блокируем поля и кнопки
                timertick = 0;
                TimerBlock.Text = string.Empty;
                OnLogin();
            }
        }

        // блокировка полей и кнопок
        private void BlockLogin() 
        {
            txtLogin.IsEnabled = false;         // логин
            txtPassword.IsEnabled = false;      // пароль
            txtCaptcha.IsEnabled = false;       // капча
            btnEnter.Visibility = Visibility.Hidden;         // вход
            btnEnterGuest.Visibility = Visibility.Hidden;     // гость
        }
        private void OnLogin()
        {
            txtLogin.IsEnabled = true;         // логин
            txtPassword.IsEnabled = true;      // пароль
            txtCaptcha.IsEnabled = true;       // капча
            btnEnter.Visibility = Visibility.Visible;         // вход
            btnEnterGuest.Visibility = Visibility.Visible;   // гость
        }



        // Капча
        private void GenerateCaptcha()
        {
            Random random = new Random();
            int rndmNum = random.Next(0, 3);

            switch (rndmNum)
            {
                case 1:
                    textBlockCaptcha.Text = "Jue5GH7jj";
                    textBlockCaptcha.TextDecorations = TextDecorations.Strikethrough;
                    break;

                case 2:
                    textBlockCaptcha.Text = "ikWE4l8g";
                    textBlockCaptcha.TextDecorations = TextDecorations.Strikethrough;
                    break;

                case 3:
                    textBlockCaptcha.Text = "Onwq6hD";
                    textBlockCaptcha.TextDecorations = TextDecorations.Strikethrough;
                    break;
            }
        }

        private void LoadForm(string _post)
        {
            switch (_post)
            {
                case "Клиент":
                    NavigationService.Navigate(new Client());
                    break;
                case "Администратор":
                    NavigationService.Navigate(new Admin());
                    break;
            }
        }

        //Метод-функция приветствования
        public string Time()
        {
            var time = DateTime.Now.Hour;
            if(time>10&&time<=12)
            {
                return "Утро";
            }
            if(time>12&&time<=17)
            {
                return "День";
            }
            if(time>17 && time<=19)
            {
                return "Вечер";
            }
            return "Вы взломали систему";
        }
    }
}
