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

        private void Button_Click(object sender, RoutedEventArgs e)
        {            
            new Login().Show();
            this.Close();
        }

        private void CreAcc_Click_1(object sender, RoutedEventArgs e)
        {
            int Student_Id = int.Parse(tbxStuId.Text);
            string Firstname = tbxFName.Text;
            string Lastname = tbxLName.Text;
            string Password = pbxPass.Password;

            string sqlquery = "INSERT INTO Student(Student_Id, Firstname, Lastname, password) " +
                "Values('" + Student_Id + "', '" + Firstname + "', '" + Lastname + "', '" + Password + "')";

            SqlConnection con = new SqlConnection(Properties.Settings.Default.DataConString);
            try
            {
                SqlCommand cmd = new SqlCommand(sqlquery, con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Connection Successful");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("There is an Error" + ex);
            }
            finally
            {
                con.Close();
            }

           // new Login().Show();
           // this.Close();
        }
    }
}
