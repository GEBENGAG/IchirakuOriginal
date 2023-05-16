using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ichiraku
{
	/// <summary>
	/// Логика взаимодействия для PaymentWindow.xaml
	/// </summary>
	public partial class PaymentWindow : Window
	{
		public PaymentWindow()
		{
			InitializeComponent();
			tablicaZakaz.ItemsSource = Class1.kassa.ToList();

			Class1.Total = Class1.kassa.Sum(k => k.sum);
			totaltext.Content = "Итого: " + Class1.Total.ToString();
		}

		private void Back_Click(object sender, RoutedEventArgs e)
		{
			var win = new MainWindow();
			win.Show();
			this.Close();
		}

		private void Pay_Click(object sender, RoutedEventArgs e)
		{
            try
            {
                StreamWriter sw = new StreamWriter(Directory.GetParent(Directory.GetCurrentDirectory()).FullName + "\\check.txt"); //TODO

                sw.WriteLine("Ichiraku Ramen");
                sw.WriteLine($"Кассир: {Class1.kassirName} {Class1.kassirLastName}{Environment.NewLine}Дата: {DateTime.Now}");

                //foreach (String s in List.Class1.kassa) 
                //{
                //	sw.WriteLine(s);
                //}

                foreach (var item in Class1.kassa)
                {
                    sw.WriteLine(string.Format("Наименование: {0} - Цена: {1} - Количество: {2}", item.dishName, item.cost.ToString(), item.count.ToString()));
                }
                sw.WriteLine($"Итоговая стоимость: {Class1.Total} руб.");
                sw.Close();
                System.Windows.MessageBox.Show("Успешно");

            }


            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Ошибка {ex}");
            }

        }
    }
}
