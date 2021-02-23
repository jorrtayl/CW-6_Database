using System;
using System.Collections.Generic;
using System.Data.OleDb;
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

namespace CW_6___Database
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OleDbConnection cn;
        string EmployeesDBConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\EmployeesDB.accdb";

        public MainWindow()
        {
            InitializeComponent();
            cn = new OleDbConnection(EmployeesDBConnectionString);
        }

        private void btnAssets_Click(object sender, RoutedEventArgs e)
        {
            string query = "select* from Assets";
            string data = "";

            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                data += read[0].ToString() + "\n";
            }
        }

        private void ShowAssets(object sender, RoutedEventArgs e)
        {
            // Needed for the connection
            string query = "select * from Assets";
            OleDbCommand cmd = new OleDbCommand(query, cn);

            // Open the connection
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();

            // Hold the data from the database
            string data = "";

            // Show all fields for Assets Table
            if (A_EmployeeID.Text == "EmployeeID")
            {
                while (read.Read())
                {
                    data += read[0].ToString() + "\n";
                }

                A_EmployeeID.Text = data;
            }
            else if (A_AssetID.Text == "AssetID")
            {
                while (read.Read())
                {
                    data += read[1].ToString() + "\n";
                }

                A_AssetID.Text = data;
            }
            else if (A_Description.Text == "Description")
            {
                while (read.Read())
                {
                    data += read[2].ToString() + "\n";
                }

                A_Description.Text = data;
            }

            // Close the connection
            cn.Close();
        }

        private void ShowEmployees(object sender, RoutedEventArgs e)
        {
            // Needed for the connection
            string query = "select * from Employees";
            OleDbCommand cmd = new OleDbCommand(query, cn);

            // Open the connection
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();

            // Hold the data from the database
            string data = "";

            // Show all fields for Employees Table
            if (E_EmployeeID.Text == "EmployeeID")
            {
                while (read.Read())
                {
                    data += read[0].ToString() + "\n";
                }

                E_EmployeeID.Text = data;
            }
            else if (E_LastName.Text == "LastName")
            {
                while (read.Read())
                {
                    data += read[1].ToString() + "\n";
                }

                E_LastName.Text = data;
            }
            else if (E_FirstName.Text == "FirstName")
            {
                while (read.Read())
                {
                    data += read[2].ToString() + "\n";
                }

                E_FirstName.Text = data;
            }

            // Close the connection
            cn.Close();
        }
    }
}
