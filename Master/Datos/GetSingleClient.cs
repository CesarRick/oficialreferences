using Master.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Master.Datos
{
    public class GetSingleClient: Conexion
    {
        public ClientViewModel GetClient(string id)
        {
            Conectar();
            ClientViewModel model = new ClientViewModel();
            try
            {
                SqlCommand command = new SqlCommand("spGetClientById", conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Nit", id);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    model.ClienteID = int.Parse(reader[0].ToString());
                    model.Nit = reader[1] + "";
                    model.Nombre = reader[2] + "";
                    model.Direccion = reader[3] + "";
                }
                reader.Close();
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                Desconectar();
            }

            return model;
        }
    }
}