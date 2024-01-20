using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Shared.Models;
using System.Data.SqlClient;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Interfaces;




namespace Data_Layer.Repository
{
    public class StudentRepository :IStudentRepository
    {
        public List<Student> GetStudents()
        {

            SqlConnection sqlConnection = new SqlConnection(Constants.connString);
            // sqlConnection.ConnectionString = Constants.connectionString;
            sqlConnection.Open();

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT * FROM Studenti";

            SqlDataReader dataReader = sqlCommand.ExecuteReader();

            List<Student> listOfItems = new List<Student>();

            while (dataReader.Read())
            {
                Student item = new Student();
                item.Broj_Indexa = dataReader.GetString(0);
                item.Ime = dataReader.GetString(1);
                item.Prezime = dataReader.GetString(2);


                listOfItems.Add(item);
            }

            sqlConnection.Close();

            return listOfItems;
        }
        public int CreateStudent(Student student)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = string.Format("INSERT INTO Studenti VALUES('{0}','{1}','{2}')",
                    student.Broj_Indexa, student.Ime, student.Prezime);
                return sqlCommand.ExecuteNonQuery();
            }
        }
        public int DeleteStudent(Student student)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = string.Format("DELETE FROM STUDENTI WHERE Broj_Indexa=@brojindexa");
                sqlCommand.Parameters.AddWithValue("@brojindexa", student.Broj_Indexa);
                return sqlCommand.ExecuteNonQuery();
            }
        }

        public int UpdateStudent(Student student)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = string.Format("UPDATE STUDENTI SET Ime=@ime, Prezime=@prezime WHERE Broj_Indexa=@brojindexa");
                sqlCommand.Parameters.AddWithValue("@ime", student.Ime);
                sqlCommand.Parameters.AddWithValue("@prezime",student.Prezime);
                sqlCommand.Parameters.AddWithValue("@brojindexa",student.Broj_Indexa);
                return sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
