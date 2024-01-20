using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business_Layer;
using Shared;
using Shared.Models;

namespace WinFormsApp2
{
    public partial class Prozor3 : Form
    {
        public Prozor3()
        {
            InitializeComponent();
        }
        StudentBusiness StudentBiznis = new StudentBusiness();
        PredmetBusiness PredmetBiznis = new PredmetBusiness();

        private void Prozor3_Load(object sender, EventArgs e)
        {
            refreshListBox();
        }

        public void refreshListBox()
        {
            listBox1.Items.Clear();
            foreach (Student student in StudentBiznis.GetStudents())
            {

                listBox1.Items.Add($"{student.Broj_Indexa}  {student.Ime}  {student.Prezime}");

            }

            listBox2.Items.Clear();
            foreach (Shared.Models.Predmet predmet in PredmetBiznis.GetPredmets())
            {

                listBox2.Items.Add($"{predmet.Id}  {predmet.Naziv_Predmeta} - {predmet.Broj_Studenta}");

            }

            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Student student = new Student()
            {
                Broj_Indexa = textBox1.Text,
                Ime = textBox2.Text,
                Prezime = textBox3.Text
            };
            StudentBiznis.AddStudent(student);
            refreshListBox();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Student student = new Student()
            {
                Broj_Indexa = textBox1.Text,
            };
            StudentBiznis.DeleteStudent(student);
            refreshListBox();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Shared.Models.Predmet predmet = new Shared.Models.Predmet()
            {
                Id = Convert.ToInt32(textBox6.Text),
                Naziv_Predmeta = textBox5.Text,
                Broj_Studenta = Convert.ToInt32(textBox4.Text)
            };
            PredmetBiznis.CreatePredmet(predmet);
            refreshListBox();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Shared.Models.Predmet predmet = new Shared.Models.Predmet()
            {
                Id = Convert.ToInt32(textBox6.Text),
            };
            PredmetBiznis.DeletePredmet(predmet);
            refreshListBox();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Student student = new Student()
            {
                Broj_Indexa = textBox1.Text,
                Ime = textBox2.Text,
                Prezime = textBox3.Text
            };
            StudentBiznis.UpdateStudent(student);
            refreshListBox();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Predmet predmet = new Predmet()
            {
                Id = int.Parse(textBox6.Text),
                Naziv_Predmeta = textBox5.Text,
                Broj_Studenta = int.Parse(textBox4.Text)
            };
            PredmetBiznis.UpdatePredmet(predmet);
            refreshListBox();
        }
    }
}
