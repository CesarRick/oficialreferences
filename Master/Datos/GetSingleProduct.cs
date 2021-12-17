using Master.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;

namespace Master.Datos
{
    public class GetSingleProduct: Conexion
    {
        public ProductViewModel GetProduct(int id)
        {
            Conectar();
            ProductViewModel model = new ProductViewModel();
            try
            {
                SqlCommand command = new SqlCommand("spGetProductById", conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProductoID", id);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    model.ProductoID = int.Parse(reader[0].ToString());
                    model.Nombre = reader[1] + "";
                    model.Stock = decimal.Parse(reader[2].ToString());
                    model.Precio = decimal.Parse(reader[3].ToString());
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