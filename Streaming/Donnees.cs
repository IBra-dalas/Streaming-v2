﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GestionEmail
{
    class Donnees
    {
        public string StackOverflowException(string messages)
        {
            string message = "Une exception";
            return message;
        }

        public SqlCommand cmd = new SqlCommand();
        public SqlDataAdapter dte = new SqlDataAdapter();

        public SqlConnection Con { get; set; } = new SqlConnection();

        public DataSet datSet = new DataSet();
        public void Connecter()
        {
            if (Con.State == ConnectionState.Closed)
            {
                Con.ConnectionString = "initial catalog=GestionDonnees;Data Source = (localdb)\\MSSQLlocalDB;integrated security=true";
               /* Con.ConnectionString = "initial catalog=GestionDonnees;data source=L2C9XQN2\\SQLEXPRESS;integrated security=true";*/
                Con.Open();
            }

           // Data Source = (localdb)\\MSSQLlocalDB; Initial Catalog = GestionDonnees; Integrated Security = True
        }

        public void Deconnecter()
        {
            if (Con.State == ConnectionState.Open)
            {
               Con.Close();
            }


        }

        public void RemplirGrid(string table, DataGridView dg)
        {
            Donnees d = new Donnees();
            d.Connecter();
            d.cmd.Connection = d.Con;
            d.cmd.CommandText = "SELECT * FROM " + table;
            d.dte.SelectCommand = d.cmd;

            if(datSet.Tables["DTCategorie"] != null)
            {
                datSet.Tables["DTCategorie"].Clear();
            }
            d.dte.Fill(d.datSet, "DT" + table);
            dg.DataSource = d.datSet.Tables["DTCategorie"];
            d.Deconnecter();
        }

        public int NbreLignes(string champs, string tables, int valeurs)
        {
            Connecter();
            cmd.Connection = Con;
            cmd.CommandText = "SELECT COUNT(*) FROM "+tables + " WHERE " + champs + "=" + valeurs;
            int cpt = int.Parse(cmd.ExecuteScalar().ToString());
            return cpt;
        }

       

    }
}
