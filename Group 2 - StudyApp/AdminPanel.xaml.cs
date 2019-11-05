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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void btnDelete(object sender, RoutedEventArgs e)
        {
            //--Current Code deletes data in the database so it is--
            //--commented until alternative code is implemented--

            //var id1 = (DataRowView)dataGrid.SelectedItem;

            //PK_ID = Convert.ToInt32(id1.Row["Id"].ToString());

            //SqlConnection con = new SqlConnection(Properties.Settings.Default.DataConString);
            //con.Open();
            //string sqlquery = "delete from Major where Major_Id='" + PK_ID + "' ";
            //SqlCommand cmd = new SqlCommand(sqlquery, con);
            //cmd.ExecuteNonQuery();

            //filldatagrid();
        }

        private void BtnLog_Click(object sender, RoutedEventArgs e)
        {
            new Login().Show();
            this.Close();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
