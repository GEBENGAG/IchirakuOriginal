using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
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

namespace ichiraku
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ichirakuEntities2 ichiraku;

        public MainWindow()
        {
            InitializeComponent();
            ichiraku = new ichirakuEntities2();
            txtbNameKassir.Text = $"Кассир:{Environment.NewLine}{Class1.kassirName}";
            kategorii.ItemsSource = ichiraku.Группа.ToList();
            infoNet();
            Class1.tablicaZakaz = tablicaZakaz;
            tablicaZakaz.ItemsSource = Class1.kassa.ToList();



        }


        private void kategorii_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Class1.DataBaseInitialize();
            Class1.cn1.Open();
            SqlCommand cmd = new SqlCommand("Command String", Class1.cn1);
            cmd.CommandText = $"select ИдГруппы from Группа where НаименованиеГруппы = '{((ichiraku.Группа)kategorii.SelectedItem).НаименованиеГруппы }'";
            object resolt = cmd.ExecuteScalar();
            tablicaMenu.ItemsSource = Class1.context.Блюда.Where(k => k.ИдГруппы.ToString().Contains(resolt.ToString())).ToList();


            
            

        }

        //private void settings_Click(object sender, RoutedEventArgs e)
        //{
        //    var win = new Window1();
        //    win.Show();



        //}

        private void number_Click(object sender, RoutedEventArgs e)
        {


            VvodKolicestva passwordWindow = new VvodKolicestva();
            if (passwordWindow.ShowDialog() == true)
            { 

            }


        }
        //public Visibility visibility
        //{
        //    get { return kover.Visibility; }
        //    set { kover.Visibility = value; }
            
        //}

        private void add_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = tablicaMenu.SelectedItem;
            if(selectedItem != null)
            {
                Class1.kassa.Add(new Class1()
                {
                    Id = (int)((ichiraku.Блюда)tablicaMenu.SelectedItem).ИдБлюда,
                    dishName = ((ichiraku.Блюда)tablicaMenu.SelectedItem).Название.ToString(),
                    cost = (double)((ichiraku.Блюда)tablicaMenu.SelectedItem).Стоимость,
                    count = 1,
                    sum = (double)((ichiraku.Блюда)tablicaMenu.SelectedItem).Стоимость
                });
                tablicaZakaz.ItemsSource = Class1.kassa.ToList();
            }
            else
            {
                MessageBox.Show(
                    "Выберите строку",
                    "Информация",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            


           
        }

        private void plus_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = tablicaZakaz.SelectedItem as Class1;

            if (selectedItem != null)
            {
                selectedItem.count += 1;
                selectedItem.sum = selectedItem.count* selectedItem.cost;
                tablicaZakaz.ItemsSource = Class1.kassa.ToList();
            }

            else
            {
                MessageBox.Show(
                    "Выберите поле",
                    "Информация",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }

        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            var del = tablicaZakaz.SelectedItem as Class1;

            if (del != null)
            {
                Class1.kassa.Remove(del);
                tablicaZakaz.ItemsSource = Class1.kassa.ToList();
            }
            else
            {
                MessageBox.Show(
                    "Выберите поле",
                    "Информация",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
        }

        private void minus_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = tablicaZakaz.SelectedItem as Class1;

            if (selectedItem != null)
            {
                if(selectedItem.count <= 1)
                {

                }
                else
                {
                    selectedItem.count -= 1;
                    selectedItem.sum = selectedItem.count * selectedItem.cost;
                }
                tablicaZakaz.ItemsSource = Class1.kassa.ToList();
            }
            else
            {
                MessageBox.Show(
                    "Выберите поле",
                    "Информация",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
        }

       
      

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        

        private async void infoNet()
        {
            while (true)
            {
                IPStatus status = IPStatus.Unknown;
                try
                {
                    status = new Ping().Send("ya.ru").Status;
                }
                catch { }

                if (status == IPStatus.Success)
                {
                    imageNet.Source = new BitmapImage(new Uri("image/ZELENII.png", UriKind.Relative));
                }
                else
                {
                    imageNet.Source = new BitmapImage(new Uri("image/KRASNII.png", UriKind.Relative));
                }
                await Task.Delay(5000);
            }

        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

		

        private void next_Click(object sender, RoutedEventArgs e)
        {
            var win = new PaymentWindow();
            win.Show();
            this.Close();
        }
    }
}
