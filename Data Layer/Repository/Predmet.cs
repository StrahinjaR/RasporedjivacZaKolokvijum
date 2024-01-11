﻿using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Shared.Models;
using System.Data.SqlClient;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Repository
{
    public class Predmet
    {
        public List<Shared.Models.Predmet> GetPredmets()
        {

            SqlConnection sqlConnection = new SqlConnection(Constants.connString);
            // sqlConnection.ConnectionString = Constants.connectionString;
            sqlConnection.Open();

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT * FROM Predmeti";

            SqlDataReader dataReader = sqlCommand.ExecuteReader();

            List<Shared.Models.Predmet> listOfItems = new List<Shared.Models.Predmet>();

            while (dataReader.Read())
            {
                Shared.Models.Predmet item = new Shared.Models.Predmet();
                item.Id = dataReader.GetInt32(0);
                item.Naziv_Predmeta = dataReader.GetString(1);
                item.Broj_Studenta = dataReader.GetInt32(2);


                listOfItems.Add(item);
            }

            sqlConnection.Close();

            return listOfItems;
        }
        public int GetUkupno(String textBoxValue)
        {

            SqlConnection sqlConnection = new SqlConnection(Constants.connString);
            // sqlConnection.ConnectionString = Constants.connectionString;
            sqlConnection.Open();

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT Broj_Studenata FROM Predmeti WHERE Naziv_Predmeta = @Naziv";
            sqlCommand.Parameters.AddWithValue("@Naziv", textBoxValue);

            SqlDataReader dataReader = sqlCommand.ExecuteReader();

            int ukupno = 0;

            while (dataReader.Read())
            {
                ukupno = dataReader.GetInt32(0);
            }

            sqlConnection.Close();

            return ukupno;
        }
    }
}
