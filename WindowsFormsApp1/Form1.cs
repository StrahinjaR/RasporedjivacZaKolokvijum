using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;
using System.Reflection.Emit;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private string selected;
        string connString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=tes;Integrated Security=True";
        SqlConnection dataConnection = new SqlConnection();
        SqlCommand cmd = new SqlCommand();


        public Form1()
        {
            InitializeComponent();
            dataConnection.ConnectionString = connString;
            cmd.Connection = dataConnection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Studenti";

            dataConnection.Open();

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    Console.WriteLine($"Broj_Indexa: {dr["Broj_Indexa"]}, Ime: {dr["Ime"]}, Prezime: {dr["Prezime"]}");
                    // Add more columns as needed
                }
            }

        }
        private void TestConnection()
        {
            try
            {
                // Open the connection
                dataConnection.Open();

                // If the connection is successful, you can perform additional actions here
                MessageBox.Show("Connection successful!!!!!!");
            }
            catch (Exception ex)
            {
                // Handle the exception and show an error message
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                // Close the connection in the finally block to ensure it's closed
                if (dataConnection.State == ConnectionState.Open)
                {
                    dataConnection.Close();
                }
            }
        }

 
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TestConnection();

        }
    }
}

