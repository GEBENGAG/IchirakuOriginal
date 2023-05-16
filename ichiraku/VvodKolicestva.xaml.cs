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

namespace ichiraku
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class VvodKolicestva : Window
    {
        public VvodKolicestva()
        {
            InitializeComponent();
            
        }

        string Count = "1";
        private void One_Click(object sender, RoutedEventArgs e)
        {

            CountText.Text = CountText.Text + "1";
        }

        private void Two_Click(object sender, RoutedEventArgs e)
        {
            CountText.Text = CountText.Text + "2";
        }

        private void Three_Click(object sender, RoutedEventArgs e)
        {
            CountText.Text = CountText.Text + "3";
        }

        private void Four_Click(object sender, RoutedEventArgs e)
        {
            CountText.Text = CountText.Text + "4";
        }

        private void Five_Click(object sender, RoutedEventArgs e)
        {
            CountText.Text = CountText.Text + "5";
        }

        private void Sex_Click(object sender, RoutedEventArgs e)
        {
            CountText.Text = CountText.Text + "6";
        }

        private void Seven_Click(object sender, RoutedEventArgs e)
        {
            CountText.Text = CountText.Text + "7";
        }

        private void Eight_Click(object sender, RoutedEventArgs e)
        {
            CountText.Text = CountText.Text + "8";
        }

        private void Nine_Click(object sender, RoutedEventArgs e)
        {
            CountText.Text = CountText.Text + "9";
        }

        private void Zero_Click(object sender, RoutedEventArgs e)
        {
            if (CountText.Text == "")
            {
                return;
            }
            else
            {
                CountText.Text = CountText.Text + "0";
            }
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            var selectedItem = Class1.tablicaZakaz.SelectedItem as Class1;
            
            selectedItem.count = int.Parse(CountText.Text);
            selectedItem.sum = selectedItem.count * selectedItem.cost;
            Class1.tablicaZakaz.ItemsSource = Class1.kassa.ToList();
        }

        private void X_Click(object sender, RoutedEventArgs e)
        {

            CountText.Text = null;

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
