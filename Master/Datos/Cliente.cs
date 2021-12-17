using Master.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Master.Datos
{
    public class Cliente: Conexion
    {
        /// <summary>
        /// Hace un listado de todos los clientes registrados en base de datos.
        /// Usa un objeto Lista y un sp para obtener la información.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ClientModel> Consultar()
        {
            Conectar();
            List<ClientModel> lista = new List<ClientModel>();
            try
            {
                SqlCommand command = new SqlCommand("spGetClientList", conexion);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ClientModel model = new ClientModel()
                    {
                        ClienteID = int.Parse(reader[0].ToString()),
                        Nit = reader[1] + "",
                        Nombre = reader[2] + "",
                        Direccion = reader[3] + ""                        
                    };
                    lista.Add(model);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                Desconectar();
            }
            return lista;
            
        }
        // Fin Consultar

            /// <summary>
            /// Crear un nuevo registro de Cliente. 
            /// Parametro modelo ClientModel
            /// </summary>
            /// <param name="model"></param>
        public void CreateClient(ClientModel model)
        {
            Conectar();
            try
            {
                SqlCommand command = new SqlCommand("spCreateClient", conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Nit", model.Nit);
                command.Parameters.AddWithValue("@Nombre", model.Nombre);
                command.Parameters.AddWithValue("@Direccion", model.Direccion);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                Desconectar();
            }
        }
        // Fin Crear Cliente

            /// <summary>
            /// Funcion para buscar un Cliente especifico.
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
        public ClientModel EditClient(int id)
        {
            Conectar();            
            ClientModel model = new ClientModel();
            try
            {                                
                SqlCommand command = new SqlCommand("spListClientByID", conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ClientID", id);
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
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Desconectar();                
            }
            return model;
        }

        public bool EditClientById(ClientModel model)
        {
            Conectar();
            try
            {
                SqlCommand command = new SqlCommand("spEditClientById", conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ClienteID", model.ClienteID);
                command.Parameters.AddWithValue("@Nit", model.Nit);
                command.Parameters.AddWithValue("@Nombre", model.Nombre);
                command.Parameters.AddWithValue("@Direccion", model.Direccion);
                command.ExecuteNonQuery();                
            }
            catch (Exception ex)
            {

                throw;
                return false;
            }
            finally
            {
                Desconectar();
            }

            return true;
        }

    }
}
