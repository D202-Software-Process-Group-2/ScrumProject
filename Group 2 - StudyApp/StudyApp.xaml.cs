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
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace Group_2___StudyApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            fillcombobox();
        }

        void fillcombobox()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.DataConString);
            con.Open();
            string sqlquery = "select * from Major";
            SqlCommand cmd = new SqlCommand(sqlquery, con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adp.Fill(dt);

            Mcombobox.DataContext = dt;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Mcombobox.Items.Add(dt.Rows[i]["Name"].ToString());
                }
            }
        }

        void filldatagrid()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.DataConString);
            con.Open();
            string sqlquery = "Select p.Paper_Code, p.Name, p.Description, p.Year, p.PreRequisite, p.Compulsory, c.Semester From Paper p Inner Join Class c On c.Paper_Code=p.Paper_Code Inner Join Major m ON m.Major_Id=c.Major_Id Where m.Name = ('" + Mcombobox.SelectedItem.ToString() + "') ORDER BY Year, Semester";
            SqlCommand cmd = new SqlCommand(sqlquery, con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adp.Fill(dt);

            dataGrid.ItemsSource = dt.DefaultView;
            con.Close();
        }

        private void Mcombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            filldatagrid();
        }
    }
}
