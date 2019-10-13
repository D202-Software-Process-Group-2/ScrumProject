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
    }
}
