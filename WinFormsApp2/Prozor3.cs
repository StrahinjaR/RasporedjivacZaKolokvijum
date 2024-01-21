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
using Shared.Interfaces;
using Shared.Models;

namespace WinFormsApp2
{
    public partial class Prozor3 : Form
    {
        private readonly IBiznisStudent StudentBiznisaaaa;
        private readonly IBiznisPredmet BiznisPredmet;
        private readonly IBiznisUcionica BiznisUcionica;
        private readonly IBiznisUpisani BiznisUpisani;

        public Prozor3(IBiznisStudent studentBiznisaaaa, IBiznisPredmet BiznisPredmet, IBiznisUcionica BiznisUcionica, IBiznisUpisani BiznisUpisani)
        {
            this.BiznisPredmet = BiznisPredmet;
            this.BiznisUcionica = BiznisUcionica;
            this.BiznisUpisani = BiznisUpisani;
            this.StudentBiznisaaaa = studentBiznisaaaa;
            InitializeComponent();

        }


        private void Prozor3_Load(object sender, EventArgs e)
        {
            refreshListBox();
        }

        public void refreshListBox()
        {
            listBox1.Items.Clear();
            foreach (Student student in StudentBiznisaaaa.GetStudents())
            {

                listBox1.Items.Add($"{student.Broj_Indexa}  {student.Ime}  {student.Prezime}");

            }

            listBox2.Items.Clear();
            foreach (Shared.Models.Predmet predmet in BiznisPredmet.GetPredmets())
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
            if (textBox1.Text == "" ||
               textBox2.Text == "" ||
               textBox3.Text == "")
            {
                // prikaži poruku da sva polja moraju biti popunjena
                MessageBox.Show("Morate popuniti sva polja!", "Error",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                return;
            }
            Student student = new Student()
            {
                Broj_Indexa = textBox1.Text,
                Ime = textBox2.Text,
                Prezime = textBox3.Text
            };
            StudentBiznisaaaa.AddStudent(student);
            refreshListBox();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                // prikaži poruku da sva polja moraju biti popunjena
                MessageBox.Show("Morate popuniti polje broj indexa!", "Error",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                return;
            }
            Student student = new Student()
            {
                Broj_Indexa = textBox1.Text,
            };
            StudentBiznisaaaa.DeleteStudent(student);
            refreshListBox();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "" ||
               textBox5.Text == "" ||
               textBox6.Text == "")
            {
                // prikaži poruku da sva polja moraju biti popunjena
                MessageBox.Show("Morate popuniti sva polja!", "Error",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                return;
            }
            Shared.Models.Predmet predmet = new Shared.Models.Predmet()
            {
                Id = Convert.ToInt32(textBox6.Text),
                Naziv_Predmeta = textBox5.Text,
                Broj_Studenta = Convert.ToInt32(textBox4.Text)
            };
            BiznisPredmet.CreatePredmet(predmet);
            refreshListBox();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                // prikaži poruku da sva polja moraju biti popunjena
                MessageBox.Show("Morate popuniti polje za id!", "Error",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                return;
            }
            Shared.Models.Predmet predmet = new Shared.Models.Predmet()
            {
                Id = Convert.ToInt32(textBox6.Text),
            };
            BiznisPredmet.DeletePredmet(predmet);
            refreshListBox();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" ||
               textBox2.Text == "" ||
               textBox3.Text == "")
            {
                // prikaži poruku da sva polja moraju biti popunjena
                MessageBox.Show("Morate popuniti sva polja!", "Error",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                return;
            }
            Student student = new Student()
            {
                Broj_Indexa = textBox1.Text,
                Ime = textBox2.Text,
                Prezime = textBox3.Text
            };
            StudentBiznisaaaa.UpdateStudent(student);
            refreshListBox();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "" ||
               textBox5.Text == "" ||
               textBox6.Text == "")
            {
                // prikaži poruku da sva polja moraju biti popunjena
                MessageBox.Show("Morate popuniti sva polja!", "Error",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                return;
            }
            Predmet predmet = new Predmet()
            {
                Id = int.Parse(textBox6.Text),
                Naziv_Predmeta = textBox5.Text,
                Broj_Studenta = int.Parse(textBox4.Text)
            };
            BiznisPredmet.UpdatePredmet(predmet);
            refreshListBox();
        }
    }
}