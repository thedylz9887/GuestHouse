﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace cw2_cs
{
    /// <summary>
    /// Interaction logic for ADDCustomer.xaml
    /// </summary>
    public partial class ADDCustomer : Window
    {
        public ADDCustomer()
        {
            InitializeComponent();
        }


       

        private void SAVE_btn_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con =
             new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\dtd2509\Documents\Visual Studio 2015\Projects\cw2-csharp-db\cw2-csharp-db\sampledatabase.mdf; Integrated Security = True; Connect Timeout = 30");

            SqlCommand com = new SqlCommand("INSERT INTO Customer (Cus_Address,Cus_Name) VALUES (@Cus_Address,@Cus_Name)");
            com.CommandType = System.Data.CommandType.Text;
            com.Connection = con;
            com.Parameters.AddWithValue("@Cus_Address", Cus_Address_txtbx.Text);
            com.Parameters.AddWithValue("@Cus_Name", Cus_Name_txtbx.Text);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
    }
}