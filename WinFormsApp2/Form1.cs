using Shared.Models;
using System.Data;
using System.Data.SqlClient;
using Business_Layer;
using Data_Layer.Repository;
using OfficeOpenXml;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System.Linq;
using System;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace WinFormsApp2

{
    public partial class Form1 : Form
    {
        StudentBusiness student;
        PredmetBusiness predmet;
        UcionicaBusiness ucionica;
        UpisaniPredmeti upisani;
        StudentBusiness ustudenti;
        private string selected;
        string connString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=tes;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
        SqlConnection dataConnection = new SqlConnection();
        SqlCommand cmd = new SqlCommand();


        public Form1()
        {

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            InitializeComponent();
            student = new StudentBusiness();
            predmet = new PredmetBusiness();
            ucionica = new UcionicaBusiness();
            upisani = new UpisaniPredmeti();
            ustudenti = new StudentBusiness();
            dataConnection.ConnectionString = connString;
            cmd.Connection = dataConnection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Studenti";
            dataConnection.Open();
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
        }

        private void button1_Click(object sender, EventArgs e)
        {


            RefereshListBox();
            GetUkupn(textBox1.Text);
            GetTips(textBox3.Text);

        }
        public void RefereshListBox()
        {
            listBox1.Items.Clear();
            string textBoxValue = textBox1.Text;
            var listOfItems = GetStudenti();
            var listOfTips = GetTips(textBox3.Text);
            var listofUps = GetUpisane(textBox1.Text);
            int ukupno = GetUkupn(textBox1.Text);
            int brojac = 0;
            string tip = textBox3.Text;
            float broj;
            int neophodno;
            String text = "";
            int i = 0;
            List<Student> lista = new List<Student>();

            try
            {
                if (tip.ToLower() == "da")
                {
                    text = "Racunarska ";
                    brojac = 15;


                }
                else if (tip.ToLower() == "ne")
                {
                    text = "Ucionica ";
                    brojac = 20;


                }
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }

            if (ukupno / 2 > brojac)
                neophodno = 3;
            else neophodno = 2;
            broj = ukupno / neophodno;
            int mat = (int)Math.Ceiling(broj);
            foreach (var a in listofUps)
            {

                foreach (var items in listOfItems)
                {
                    Student ustudenti = new Student();
                    if (a.STUDENT_ID == items.Broj_Indexa)
                    {
                        ustudenti.Broj_Indexa = items.Broj_Indexa;
                        ustudenti.Ime = items.Ime;
                        ustudenti.Prezime = items.Prezime;
                        lista.Add(ustudenti);
                    }

                }

            }

            foreach (var item in listOfTips.Take(neophodno))
            {
                listBox1.Items.Add(text + item.Id);


                foreach (var a in lista.Skip(i).Take(mat))
                {

                    listBox1.Items.Add(a.Broj_Indexa + " " + a.Ime + " " + a.Prezime);
                    i++;


                }

            }

            ExportToExcel(neophodno, listOfTips, lista, Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "Raspored.xlsx"));
        }
        void ExportToExcel(int neophodno, List<Ucionica> listofTips, List<Student> listOfItems, string FilePath)
        {
            var excelPackage = new ExcelPackage();
            var worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");

            // Header
            worksheet.Cells[1, 1].Value = "Broj Indexa";
            worksheet.Cells[1, 2].Value = "Ime";
            worksheet.Cells[1, 3].Value = "Prezime";
            worksheet.Cells[1, 4].Value = "Ucionica";



            // Data
            int row = 2;
            foreach (var i in listofTips.Take(neophodno))
            {

                foreach (var item in listOfItems)
                {
                    worksheet.Cells[row, 1].Value = item.Broj_Indexa;
                    worksheet.Cells[row, 2].Value = item.Ime;
                    worksheet.Cells[row, 3].Value = item.Prezime;
                    worksheet.Cells[row, 4].Value = i.Id;
                    row++;
                }
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
        public List<Ucionica> GetTips(String a)

        {
            return this.ucionica.GetTips(a);
        }
        public List<UpisanPredmet> GetUpisane(String a)

        {
            return this.upisani.GetUpisane(a);
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Prozor3 secondForm = new Prozor3();


            secondForm.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
