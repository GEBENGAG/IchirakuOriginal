using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ichiraku
{
    class Class1
       
    {
        public static double Total=0;

        #region /*список кассы*/

        public string dishName { get; set; }
        public int Id { get; set; }
        public double cost { get; set; }
        public int count { get; set; }
        public double sum { get; set; }
        
        public static string kassirName { get; set; }
        public static string kassirLastName { get; set; }

        public static DataGrid tablicaZakaz { get; set; }


        public static List<Class1> kassa = new List<Class1>();

        #endregion

        static public ichirakuEntities context = new ichirakuEntities();

        static public SqlConnection cn1;
        static public void DataBaseInitialize()
        {
            try
            {
                var path = Directory.GetParent(Directory.GetCurrentDirectory()).FullName + "\\strokaPodklucheniya.txt";

                 StreamReader stream = new StreamReader(path);

                string ConnectionLink = stream.ReadLine();

                cn1 = new SqlConnection(ConnectionLink);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex);
            }

        }
    }
}
