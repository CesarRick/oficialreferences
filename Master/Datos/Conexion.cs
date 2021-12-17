using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Master.Datos
{
    public class Conexion
    {

        protected SqlConnection conexion;

        // Abrir Conexion
        protected void Conectar()
        {
            try
            {
                conexion = new SqlConnection (ConfigurationManager.ConnectionStrings["GolanConnectionString"].ConnectionString);
                conexion.Open();                    
            }
            catch (Exception ex)
            {
                throw;                
            }
        }

        // Cerrar Conexion
        protected void Desconectar()
        {
            try
            {   
                    conexion.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}