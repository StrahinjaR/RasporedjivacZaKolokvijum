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
using Shared.Interfaces;

namespace WinFormsApp2

{
    public partial class Form1 : Form
    {

        private readonly IBiznisStudent StudentBiznisa;
        private readonly IBiznisPredmet BiznisPredmet;
        private readonly IBiznisUcionica BiznisUcionica;
        private readonly IBiznisUpisani BiznisUpisani;


        // IPredmetRepository PredmetRepo = new PredmetRepository();
        //  IUpisaniPredmetiRepository UpisaniRepo = new UpisaniPredmetiRepository();
        // IUcionicaRepository UcionicaRepo = new UcionicaRepository();


        public Form1(IBiznisStudent StudentBiznisa, IBiznisPredmet BiznisPredmet, IBiznisUcionica BiznisUcionica, IBiznisUpisani BiznisUpisani)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            this.StudentBiznisa = StudentBiznisa;
            this.BiznisPredmet = BiznisPredmet;
            this.BiznisUcionica = BiznisUcionica;
            this.BiznisUpisani  = BiznisUpisani;
            
            InitializeComponent();
           
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
                   
                    System.Diagnostics.Debug.WriteLine(ukupno);
                   

                    i++;

                }

            }

            ExportToExcel(neophodno, listOfTips, lista, Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "Raspored.xlsx"));
           
        }
        void ExportToExcel(int neophodno, List<Ucionica> listofTips, List<Student> listOfItems, string FilePath)
        {
            var excelPackage = new ExcelPackage();
            var worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");

            worksheet.Cells[1, 1].Value = "Broj Indexa";
            worksheet.Cells[1, 2].Value = "Ime";
            worksheet.Cells[1, 3].Value = "Prezime";
            worksheet.Cells[1, 4].Value = "Ucionica";



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

            FileInfo fileInfo = new FileInfo(FilePath);
            excelPackage.SaveAs(fileInfo);
        }

        public List<Student> GetStudenti()
        {
            
            return this.StudentBiznisa.GetStudents();
        }
        public int GetUkupn(String a)
        {
            return this.BiznisPredmet.Ukupno(a);

        }
        public List<Ucionica> GetTips(String a)

        {
            return this.BiznisUcionica.GetTips(a);
        }
        public List<UpisanPredmet> GetUpisane(String a)

        {
            return this.BiznisUpisani.GetUpisane(a);
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Prozor3 secondForm = new Prozor3(StudentBiznisa, BiznisPredmet, BiznisUcionica, BiznisUpisani);

        secondForm.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
