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
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {

        public SignUp()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {            
            new Login().Show();
            this.Close();
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            string Student_Id = tbxStuId.Text;
            string Firstname = tbxFName.Text;
            string Lastname = tbxLName.Text;
            string Password = pbxPass.Password;

            string sqlquery = "INSERT INTO Student(Student_Id, Firstname, Lastname, password) " +
                "Values('" + Student_Id + "', '" + Firstname + "', '" + Lastname + "', '" + Password + "')";

            SqlConnection con = new SqlConnection(Properties.Settings.Default.DataConString); // "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\1711971\\Source\\Repos\\Study-Application\\Group 2 - StudyApp\\D202 - Group 2.mdf; Integrated Security = True"
            try
            {
                SqlCommand cmd = new SqlCommand(sqlquery, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                MessageBox.Show("Cannot create account as " + Student_Id + " already has an account");
                tbxStuId.Clear();
                tbxFName.Clear();
                tbxLName.Clear();
                pbxPass.Clear();
                return;
            }
            finally
            {
                con.Close();
            }

            new Login().Show();
            this.Close();

        }

    }
}
