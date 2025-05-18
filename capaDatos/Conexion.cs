﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaDatos
{
    public class Conexion
    {
        #region Singleton
        private static readonly Conexion unicaInstancia = new Conexion();

        public static Conexion Instancia
        {
            get { 
            
                   return Conexion.unicaInstancia;
            }
        
        }

        #endregion Singleton


        public SqlConnection Conectar()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=DESKTOP-HJ93MJO\\SQLEXPRESS;" +
                                  "Initial Catalog=Ventas;" +
                                  "Integrated Security=True;";
            return cn;
        }
    }
}
