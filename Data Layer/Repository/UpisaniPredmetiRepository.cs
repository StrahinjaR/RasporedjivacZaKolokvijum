using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Interfaces;

namespace Data_Layer.Repository
{
    public class UpisaniPredmetiRepository :IUpisaniPredmetiRepository
    {
        public List<Shared.Models.UpisanPredmet> GetUpisanPredmets()
        {

            SqlConnection sqlConnection = new SqlConnection(Constants.connString);
            // sqlConnection.ConnectionString = Constants.connectionString;
            sqlConnection.Open();

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT * FROM UpisaniPredmeti";

            SqlDataReader dataReader = sqlCommand.ExecuteReader();

            List<Shared.Models.UpisanPredmet> listOfItems = new List<Shared.Models.UpisanPredmet>();

            while (dataReader.Read())
            {
                Shared.Models.UpisanPredmet item = new Shared.Models.UpisanPredmet();
                item.Id = dataReader.GetInt32(0);
                item.STUDENT_ID = dataReader.GetString(1);
                item.PREDMET_ID = dataReader.GetInt32(2);


                listOfItems.Add(item);
            }

            sqlConnection.Close();

            return listOfItems;
        }
        public List<Shared.Models.UpisanPredmet> GetUpisane(String textBoxValue)
        {

            SqlConnection sqlConnection = new SqlConnection(Constants.connString);
            // sqlConnection.ConnectionString = Constants.connectionString;
            sqlConnection.Open();

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT STUDENT_ID \r\nFROM UpisaniPredmeti \r\nWHERE PREDMET_ID IN (SELECT ID FROM Predmeti WHERE Naziv_Predmeta = @Test)";
            sqlCommand.Parameters.AddWithValue("@Test", textBoxValue);

            SqlDataReader dataReader = sqlCommand.ExecuteReader();

            List<Shared.Models.UpisanPredmet> listOfItems = new List<Shared.Models.UpisanPredmet>();

            while (dataReader.Read())
            {
                Shared.Models.UpisanPredmet item = new Shared.Models.UpisanPredmet();
                item.STUDENT_ID = dataReader.GetString(0);

                listOfItems.Add(item);
            }

            sqlConnection.Close();

            return listOfItems;
        }
    }
}

