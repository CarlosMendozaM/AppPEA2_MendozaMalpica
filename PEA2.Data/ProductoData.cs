using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using PEA2.Dominio;

namespace PEA2.Data
{
    public class ProductoData
    {
        string cadenaconexion = "Server=localhost; DataBase=Parcial; Integrated security=true";
        public List<Producto> Listar()
        {
            var listado = new List<Producto>();
            using (var conexion = new SqlConnection(cadenaconexion))
            {
                conexion.Open();
                using (var comando = new SqlCommand("SELECT * FROM Producto", conexion))
                {
                    using (var lector = comando.ExecuteReader())
                    {
                        if (lector != null && lector.HasRows)
                        {
                            Producto producto;
                            while (lector.Read())
                            {
                                producto = new Producto();
                                producto.ID = int.Parse(lector[0].ToString());
                                producto.Nombre = lector[1].ToString();
                                producto.Marca = lector[2].ToString();
                                producto.IdCategoria = int.Parse(lector[7].ToString());
                                producto.Precio = decimal.Parse(lector[3].ToString());
                                producto.Stock = int.Parse(lector[4].ToString());
                                listado.Add(producto);
                            }
                        }
                    }
                }
            }
            return listado;
        }
        public Producto BuscarPorId(int id)
        {
            var producto = new Producto();
            using (var conexion = new SqlConnection(cadenaconexion))
            {
                conexion.Open();
                using (var comando = new SqlCommand("SELECT * FROM Producto WHERE IdProducto = @id", conexion))
                {
                    comando.Parameters.AddWithValue("@id", id);
                    using (var lector = comando.ExecuteReader())
                    {
                        if (lector != null && lector.HasRows)
                        {
                            lector.Read();
                            producto = new Producto();
                            producto.ID = int.Parse(lector[0].ToString());
                            producto.Nombre = lector[1].ToString();
                            producto.Marca = lector[2].ToString();
                            producto.IdCategoria = int.Parse(lector[7].ToString());
                            producto.Precio = decimal.Parse(lector[3].ToString());
                            producto.Stock = int.Parse(lector[4].ToString());
                        }
                    }
                }
            }
            return producto;
        }

        public bool Insertar(Producto producto)
        {
            int filasInsertadas = 0;
            using (var conexion = new SqlConnection(cadenaconexion))
            {
                conexion.Open();
                var sql = "INSERT INTO [dbo].[Producto] (Nombre, Marca, " +
                                "IdCategoria, Stock, Precio)" +
                          "VALUES(@Nombre, @Marca, @IdCategoria, @Stock, @Precio)";
                using (var comando = new SqlCommand(sql, conexion))
                {
                                comando.Parameters.AddWithValue("@Nombre", producto.Nombre);
                                comando.Parameters.AddWithValue("@Marca", producto.Marca);
                                comando.Parameters.AddWithValue("@IdCategoria", producto.IdCategoria);
                                comando.Parameters.AddWithValue("@Precio", producto.Precio);
                                comando.Parameters.AddWithValue("@Stock", producto.Stock);
                                filasInsertadas = comando.ExecuteNonQuery();
                }
            }
            return filasInsertadas > 0;
        }

        public bool Actualizar(Producto producto)
        {
            int filasActualizadas = 0;
            using (var conexion = new SqlConnection(cadenaconexion))
            {
                conexion.Open();
                var sql = "UPDATE Producto SET Nombre = @Nombre, Marca = @Marca, " +
                    "IdCategoria = @IdCategoria, Stock = @Stock, Precio = @Precio " +
                    "WHERE IdProducto = @ID";
                using (var comando = new SqlCommand(sql, conexion))
                {
                  
                                comando.Parameters.AddWithValue("@Nombre", producto.Nombre);
                                comando.Parameters.AddWithValue("@Marca", producto.Marca);
                                comando.Parameters.AddWithValue("@IdCategoria", producto.IdCategoria);
                                comando.Parameters.AddWithValue("@Precio", producto.Precio);
                                comando.Parameters.AddWithValue("@Stock", producto.Stock);
                                comando.Parameters.AddWithValue("@ID", producto.ID);
                                filasActualizadas = comando.ExecuteNonQuery();
                }
            }
            return filasActualizadas > 0;
        }

        public bool Eliminar(int id)
        {
            int filasEliminadas = 0;
            using (var conexion = new SqlConnection(cadenaconexion))
            {
                conexion.Open();
                var sql = "DELETE FROM Producto WHERE IdProducto = @ID";
                using (var comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@ID", id);
                    filasEliminadas = comando.ExecuteNonQuery();
                }
            }
            return filasEliminadas > 0;
        }
    }
}
