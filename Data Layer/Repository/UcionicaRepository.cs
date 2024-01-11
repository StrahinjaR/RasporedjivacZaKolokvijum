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

namespace Data_Layer.Repository
{
    public class UcionicaRepository
    {
        public List<Shared.Models.Ucionica> GetUcionicas()
        {

            SqlConnection sqlConnection = new SqlConnection(Constants.connString);
            // sqlConnection.ConnectionString = Constants.connectionString;
            sqlConnection.Open();

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT * FROM Ucionice";

            SqlDataReader dataReader = sqlCommand.ExecuteReader();

            List<Shared.Models.Ucionica> listOfItems = new List<Shared.Models.Ucionica>();

            while (dataReader.Read())
            {
                Shared.Models.Ucionica item = new Shared.Models.Ucionica();
                item.Id = dataReader.GetInt32(0);
                item.Broj_Mesta = dataReader.GetInt32(1);
                item.Racunaraska = dataReader.GetString(2);


                listOfItems.Add(item);
            }

            sqlConnection.Close();

            return listOfItems;
        }

    }
}
