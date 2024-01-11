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
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Data_Layer.Repository
{
    public class StudentRepository
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
    }
}