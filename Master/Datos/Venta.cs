using Master.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Master.Datos
{
    public class Venta: Conexion
    {
        public int CreateVenta(VentaViewModel model)
        {
            Conectar();
            try
            {
                int identityValue = 0;

                SqlCommand command = new SqlCommand("spCrearVenta", conexion);
                command.CommandType = CommandType.StoredProcedure;
                               
                SqlParameter outIdentity = new SqlParameter("@Identity", SqlDbType.Int);
                outIdentity.Direction = ParameterDirection.Output;

                command.Parameters.Add(outIdentity);
                command.Parameters.AddWithValue("@ClienteID", model.ClienteID);

                command.ExecuteNonQuery();

                if (outIdentity.Value != DBNull.Value)
                    identityValue = Convert.ToInt32(outIdentity.Value);

                return identityValue;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                Desconectar();
            }
        } // Fin crear Venta

        public int CrearDetalle(Detalle model)
        {
            Conectar();
            try
            {
                int resultado = 0;
                SqlCommand command = new SqlCommand("spCrearDetalleVenta", conexion);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter outError = new SqlParameter("@Error", SqlDbType.Int);
                outError.Direction = ParameterDirection.Output;

                command.Parameters.Add(outError);
                command.Parameters.AddWithValue("@VentaID", model.VentaID);
                command.Parameters.AddWithValue("@ProductoID", model.ProductoID);
                command.Parameters.AddWithValue("@Precio", model.Precio);
                command.Parameters.AddWithValue("@Cantidad", model.Cantidad);

                command.ExecuteNonQuery();

                if (outError.Value != DBNull.Value)
                    resultado = Convert.ToInt32(outError.Value);

                return resultado;                
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                Desconectar();
            }
        }//

        
        public IEnumerable<ListaVentaViewModel> ConsultarVentas()
        {
            Conectar();
            List<ListaVentaViewModel> lista = new List<ListaVentaViewModel>();
            try
            {
                SqlCommand command = new SqlCommand("spListaVentas", conexion);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ListaVentaViewModel model = new ListaVentaViewModel()
                    {
                        VentaID = int.Parse(reader[0].ToString()),
                        Fecha =  Convert.ToDateTime(reader[1].ToString()),
                        ClienteID = int.Parse(reader[2].ToString()),
                        Nombre = reader[3] + "",
                        Total = decimal.Parse(reader[4].ToString())
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
    }
}