using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        private void button1_Click(object sender, EventArgs e)
        {
            Student student = new Student()
            {
                Broj_Indexa = textBox1.Text,
                Ime = textBox2.Text,
                Prezime = textBox3.Text
            };
            StudentBiznis.AddStudent(student);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Student student = new Student()
            {
                Broj_Indexa = textBox1.Text,
            };
            StudentBiznis.DeleteStudent(student);
        }
    }
}
