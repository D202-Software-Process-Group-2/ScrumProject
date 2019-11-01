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
        //For delete function
        //static int PK_ID;

        public MainWindow()
        {
            InitializeComponent();
            fillcombobox();
            fillCourses();
        }

        public static DataTable dtSelections = new DataTable();
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

        void fillCourses()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.DataConString);
            con.Open();
            string sqlquery = "Select * FROM Paper Order by year";
            SqlCommand cmd = new SqlCommand(sqlquery, con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adp.Fill(dt);

            dt.Columns.Add("Course", typeof(string), "Paper_Code + ' ' + Name");

            cbxCourses.DataContext = dt;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cbxCourses.Items.Add(dt.Rows[i]["Name"].ToString());
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

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            new Login().Show();
            this.Close();
        }

        private void RbtYr1_Checked(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.DataConString);
            con.Open();
            string sqlquery = "SELECT * FROM Paper WHERE Year = 1";
            SqlCommand cmd = new SqlCommand(sqlquery, con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adp.Fill(dt);

            dt.Columns.Add("Course", typeof(string), "Paper_Code + ' ' + Name");

            cbxCourses.DataContext = dt;
            cbxCourses.Items.Clear();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cbxCourses.Items.Add(dt.Rows[i]["Name"].ToString());
                }
            }
            con.Close();
        }

        private void RbtYr2_Checked(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.DataConString);
            con.Open();
            string sqlquery = "SELECT * FROM Paper WHERE Year = 2";
            SqlCommand cmd = new SqlCommand(sqlquery, con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adp.Fill(dt);

            dt.Columns.Add("Course", typeof(string), "Paper_Code + ' ' + Name");

            cbxCourses.DataContext = dt;
            cbxCourses.Items.Clear();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cbxCourses.Items.Add(dt.Rows[i]["Name"].ToString());
                }
            }
            con.Close();
        }

        private void RbtYr3_Checked(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.DataConString);
            con.Open();
            string sqlquery = "SELECT * FROM Paper WHERE Year = 3";
            SqlCommand cmd = new SqlCommand(sqlquery, con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adp.Fill(dt);

            dt.Columns.Add("Course", typeof(string), "Paper_Code + ' ' + Name");

            cbxCourses.DataContext = dt;
            cbxCourses.Items.Clear();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cbxCourses.Items.Add(dt.Rows[i]["Name"].ToString());
                }
            }
            con.Close();
        }

        private void BtnAcademic_Click(object sender, RoutedEventArgs e)
        {
            new Academic().Show();
            this.Hide();
        }

        private void RbtAll_Checked(object sender, RoutedEventArgs e)
        {
            cbxCourses.Items.Clear();
            fillCourses();
        }

        private void BtnInfo_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.DataConString);
            con.Open();
            string sqlquery = "SELECT Description FROM Paper WHERE Name = ('" + cbxCourses.SelectedItem.ToString() + "')";
            SqlCommand cmd = new SqlCommand(sqlquery, con);

            var description = (string)cmd.ExecuteScalar();
            con.Close();
            MessageBox.Show(description);
        }
    }
}