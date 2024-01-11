using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Repository
{
    public class UpisaniPredmeti
    {
        public List<Shared.Models.UpisanPredmet> GetUpisanPredmets()
        {

            SqlConnection sqlConnection = new SqlConnection(Constants.connString);
            // sqlConnection.ConnectionString = Constants.connectionString;
            sqlConnection.Open();

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT * FROM Studenti";

            SqlDataReader dataReader = sqlCommand.ExecuteReader();

            List<Shared.Models.UpisanPredmet> listOfItems = new List<Shared.Models.UpisanPredmet>();

            while (dataReader.Read())
            {
                Shared.Models.UpisanPredmet item = new Shared.Models.UpisanPredmet();
                item.Id = dataReader.GetInt32(0);
                item.STUDENT_ID = dataReader.GetInt32(1);
                item.PREDMET_ID = dataReader.GetInt32(2);


                listOfItems.Add(item);
            }

            sqlConnection.Close();

            return listOfItems;
        }
    }
}

