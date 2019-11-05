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

namespace Group_2___StudyApp
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            filldetails();
            filldatagrid();
        }

        public static string Firstname;
        public static string Lastname;
        public static string Major = "Unendorsed";

        void filldatagrid()
        {
            dataGrid.ItemsSource = MainWindow.dgdt.DefaultView;
        }
        void filldetails()
        {
            lblStudent_Id.Content = MainWindow.UserID;
            lblFirst_Name.Content = Firstname;
            lblLast_Name.Content = Lastname;
            lblmajor.Content = Major;
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        private void BtnPrint(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSave(object sender, RoutedEventArgs e)
        {

        }
    }
}
