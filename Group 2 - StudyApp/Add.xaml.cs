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
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        public Add()
        {
            InitializeComponent();
        }

        public int compulsory = 0;

        private void Btnaddpaper_Click(object sender, RoutedEventArgs e)
        {
            string Papercode = tbxPapercode.Text;
            string Name = tbxpapername.Text;
            string Description = tbxpaperdescription.Text;
            int Year = int.Parse(cbxYear.SelectedItem.ToString());
            string PreReq = tbxprereq.Text;

            if (chkcompulsory.IsChecked == true)
            {
                compulsory = 1;
            }


            string sqlquery = "INSERT INTO Paper(Paper_Code, Name, Description, Year, PreRequisite, Compulsory) " +
                "Values('" + Papercode + "', '" + Name + "', '" + Description + "', '" + Year + "', '" + PreReq + "', '" + compulsory + "')";

            SqlConnection con = new SqlConnection(Properties.Settings.Default.DataConString);
            SqlCommand cmd = new SqlCommand(sqlquery, con);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            new Window2().Show();
            this.Close();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            new Window2().Show();
            this.Close();
        }
    }
}
