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
using System.Data.SqlClient;
using System.Data;

namespace ichiraku
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    { 
        
        

        SqlConnection cn1 = new SqlConnection(@"data source=DESKTOP-LUU6HL9;initial catalog=ichiraku;integrated security=True");

        public AuthWindow()
        {
            InitializeComponent();
            
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            bool success = false;
            SqlConnection cn1 = new SqlConnection(@"data source=DESKTOP-LUU6HL9;initial catalog=ichiraku;integrated security=True");
            cn1.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn1;
            cmd.CommandText = @"Select * from Сотрудники where Пароль='" + TbPass.Password + "'";
            
            using (var dataReader = cmd.ExecuteReader())
            {
                success = dataReader.Read();
                DataTable checkUser = Select(@"Select * from Сотрудники where and Пароль='" + TbPass.Password + "'");
                if (checkUser.Rows.Count > 0)
                {
                    Class1.kassirName = checkUser.Rows[0][1].ToString();
                    Class1.kassirLastName = checkUser.Rows[0][2].ToString();


                }             
            }
            if(success)
            {
                MainWindow perehod = new MainWindow();
                perehod.Show();
                cmd.ExecuteNonQuery();
                cn1.Close();
                this.Close();
                Class1.context.SaveChanges();
            }
            else
            {
                MessageBox.Show("Неверный Логин или Пароль!");
            }
        }

        public DataTable Select(string selectSQL)
        {
            DataTable dataTable = new DataTable("dataBase");
            cn1.Open();
            SqlCommand sqlCommand = cn1.CreateCommand();
            sqlCommand.CommandText = selectSQL;
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            adapter.Fill(dataTable);
            cn1.Close();
            return dataTable;
        }
    }
}
