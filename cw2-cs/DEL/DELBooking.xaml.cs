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
using System.Data.SqlClient;

namespace cw2_cs
{
    /// <summary>
    /// Interaction logic for DELBooking.xaml
    /// </summary>
    public partial class DELBooking : Window
    {
        public int Cus_Ref_Search = 0;
        public int Book_Ref_Search = 0;


        ConnectionFacade DelBookFacade = new ConnectionFacade();

        public DELBooking()
        {
            InitializeComponent();
        }

        private void SAVE_btn_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = DelBookFacade.Connect();

            Customer c1 = new Customer();
            c1.Cus_Address = Cus_Address_txtbx.Text;
            c1.Cus_Name = Cus_Name_txtbx.Text;
            c1.Cus_Ref = Cus_Ref_Search;


            Booking b1 = new Booking();
            b1.Booking_Date = Booking_Date_txtbx.Text;
            b1.Date_Leaving = Booking_Leave_Date_txtbx.Text;
            b1.Cust = c1;
            b1.Booking_Ref = Book_Ref_Search;

            try
            {
                c1.SelectCus();
                b1.SelectCus();
                b1.SelectBooking();
                b1.DeleteBook();
            }
            catch (SqlException except)
            {
                MessageBox.Show(except.Message);
            }

            /*
            SqlCommand com = new SqlCommand("SELECT Cus_Name, Cus_Ref, Cus_Address FROM Customer WHERE Cus_Name=@Cus_Name AND Cus_Address=@Cus_Address");

            string query1 = "SELECT Booking_Date, Date_Leaving, BookingRef FROM Booking WHERE Booking_Date=@SELECT_Booking_Date AND Date_Leaving=@SELECT_Date_Leaving AND Customer_id=@REF_Cus_Ref";

            string query2 = "DELETE FROM Booking WHERE Customer_id=@Cus_Ref AND BookingRef=@BookingRef";

            com.Parameters.AddWithValue("@Cus_Address", Cus_Address_txtbx.Text);
            com.Parameters.AddWithValue("@Cus_Name", Cus_Name_txtbx.Text);
           
            com.CommandType = System.Data.CommandType.Text;
            com.Connection = con;

            con.Open();
            SqlDataReader rdr = com.ExecuteReader();
            while (rdr.Read())
            {
                Cus_Ref_Search = rdr["Cus_Ref"].ToString();
            }
            rdr.Close();
            MessageBox.Show(Cus_Ref_Search);

            com.CommandText = query1;
            com.Parameters.AddWithValue("@REF_Cus_Ref", Cus_Ref_Search);
            com.Parameters.AddWithValue("@SELECT_Booking_Date", Booking_Date_txtbx.Text);
            com.Parameters.AddWithValue("@SELECT_Date_Leaving", Booking_Leave_Date_txtbx.Text);
            int ralf1 = com.ExecuteNonQuery();
            MessageBox.Show(ralf1.ToString());

            SqlDataReader rdr2 = com.ExecuteReader();
            while (rdr2.Read())
            {
                Booking_Ref_Search = rdr2["BookingRef"].ToString();
            }
            rdr2.Close();
            MessageBox.Show(Booking_Ref_Search);
           


            com.CommandText = query2;
            com.Parameters.AddWithValue("@Cus_Ref", Cus_Ref_Search);
            com.Parameters.AddWithValue("@BookingRef",Booking_Ref_Search);
            int ralf2 = com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(ralf2.ToString());*/
        }
    }
}
