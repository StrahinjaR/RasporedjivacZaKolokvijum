using Shared.Models;
using System.Data;
using System.Data.SqlClient;
using Business_Layer;
using Data_Layer.Repository;
using OfficeOpenXml;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace WinFormsApp2

{
    public partial class Form1 : Form
    {
        StudentBusiness student;
        PredmetBusiness predmet;
        private string selected;
        string connString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=tes;Integrated Security=True";
        SqlConnection dataConnection = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        

        public Form1()
        {
            Console.WriteLine("Test1");
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            InitializeComponent();
            student = new StudentBusiness();
            predmet = new PredmetBusiness();
            dataConnection.ConnectionString = connString;
            cmd.Connection = dataConnection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Studenti";
            dataConnection.Open();
            string textBoxValue = textBox1.Text;
            Controls.Add(textBox1);

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    System.Diagnostics.Debug.WriteLine($"Broj_Indexa: {dr["Broj_Indexa"]}, Ime: {dr["Ime"]}, Prezime: {dr["Prezime"]}");
                    Console.WriteLine("Test2");

                    // Add more columns as needed
                }
            }
        }
        private void TestConnection()
        {
            try
            {
                // Open the connection
                Console.WriteLine("Test1");
                dataConnection.Close();
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
            string textBoxValue = textBox1.Text;

            RefereshListBox();
            GetUkupn(textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string textBoxValue = textBox1.Text;

            RefereshListBox();
            GetUkupn(textBox1.Text);

        }
        public void RefereshListBox()
        {
            listBox1.Items.Clear();
            string textBoxValue = textBox1.Text;
            var listOfItems = GetStudenti();
            var brojac = 0;
            foreach (var item in listOfItems)
            {

                listBox1.Items.Add(item.Broj_Indexa + ": " + item.Ime + " " + item.Prezime);

            }
            listBox1.Items.Add(GetUkupn(textBoxValue));
            System.Diagnostics.Debug.WriteLine(textBoxValue + GetUkupn(textBoxValue));


            ExportToExcel(listOfItems, Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "Raspored.xlsx"));
        }
        void ExportToExcel(List<Student> listOfItems, string FilePath)
        {
            var excelPackage = new ExcelPackage();
            var worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");

            // Header
            worksheet.Cells[1, 1].Value = "Broj Indexa";
            worksheet.Cells[1, 2].Value = "Ime";
            worksheet.Cells[1, 3].Value = "Prezime";

            // Data
            int row = 2;
            foreach (var item in listOfItems)
            {
                worksheet.Cells[row, 1].Value = item.Broj_Indexa;
                worksheet.Cells[row, 2].Value = item.Ime;
                worksheet.Cells[row, 3].Value = item.Prezime;
                row++;
            }

            // Save the file
            FileInfo fileInfo = new FileInfo(FilePath);
            excelPackage.SaveAs(fileInfo);
        }

        public List<Student> GetStudenti()
        {
            return this.student.GetStudents();


        }
        public int GetUkupn(String a)
        {
            return this.predmet.Ukupno(a);
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
