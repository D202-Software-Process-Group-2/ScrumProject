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
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

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
            filldatagrid();
        }
        public static DataTable dgdt = new DataTable();
        private string PK_ID;

        //Fill Datagrid with Major Selection method
        void filldatagrid()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.DataConString);
            con.Open();
            string sqlquery = "Select p.Paper_Code, p.Name, p.Description, p.Year, p.PreRequisite, p.Compulsory From Paper p ORDER BY Year";
            SqlCommand cmd = new SqlCommand(sqlquery, con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            adp.Fill(dgdt);

            dataGrid.ItemsSource = dgdt.DefaultView;
            con.Close();
        }

        private void btnDelete(object sender, RoutedEventArgs e)
        {
           
            var id1 = (DataRowView)dataGrid.SelectedItem;

            PK_ID = id1.Row["Paper_Code"].ToString();

            SqlConnection con = new SqlConnection(Properties.Settings.Default.DataConString);
            con.Open();
            string sqlquery = "delete from Paper Where Paper_Code='" + PK_ID + "' ";
            SqlCommand cmd = new SqlCommand(sqlquery, con);
            cmd.ExecuteNonQuery();

            filldatagrid();
        }

        private void BtnLog_Click(object sender, RoutedEventArgs e)
        {
            new Login().Show();
            this.Close();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Add().Show();
            this.Close();
        }
    }
}
