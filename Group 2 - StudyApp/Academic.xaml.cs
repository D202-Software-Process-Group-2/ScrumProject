﻿using System;
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
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Academic : Window
    {
        public Academic()
        {
            InitializeComponent();
            filldatagrid();
        }

        private DataTable dt = new DataTable();
        void filldatagrid()
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.DataConString);
            con.Open();
            string sqlquery = "Select p.Paper_Code, p.Name, p.Description, p.Year, p.PreRequisite, p.Compulsory From Paper p ORDER BY Year";
            SqlCommand cmd = new SqlCommand(sqlquery, con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            adp.Fill(dt);

            dataGrid.ItemsSource = dt.DefaultView;
            con.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (DataRowView drv in dataGrid.SelectedItems)
            {
                DataRow dr = drv.Row;
                MainWindow.dtSelections.ImportRow(dr);
            }

            new MainWindow().Show();
            this.Close();
        }

        private void btnCancel(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }
    }
}
