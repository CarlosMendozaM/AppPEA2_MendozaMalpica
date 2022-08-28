using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using PEA2.Dominio;

namespace PEA2.Data
{
    public class CategoriaData
    {
        string cadenaconexion = "Server=localhost; DataBase=Parcial; Integrated security=true";
        public List<Categoria> Listar()
        {
            var listado = new List<Categoria>();
            using (var conexion = new SqlConnection(cadenaconexion))
            {
                conexion.Open();
                using (var comando = new SqlCommand("SELECT * FROM Categoria", conexion))
                {
                    using (var lector = comando.ExecuteReader())
                    {
                        if (lector != null && lector.HasRows)
                        {
                            Categoria tipo;
                            while (lector.Read())
                            {
                                tipo = new Categoria();
                                tipo.ID = int.Parse(lector[0].ToString());
                                tipo.Nombre = lector[2].ToString();
                                listado.Add(tipo);
                            }
                        }
                    }
                }
            }
            return listado;
        }
        public Categoria BuscarPorId(int id)
        {
            var categoria = new Categoria();
            return categoria;
        }
    }
}
