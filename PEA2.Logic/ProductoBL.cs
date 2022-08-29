using System;
using System.Collections.Generic;
using System.Text;
using PEA2.Dominio;
using PEA2.Data;

namespace PEA2.Logic
{
    public static class ProductoBL
    {
        public static List<Producto> Listar()
        {
            var productoData = new ProductoData();
            return productoData.Listar();
        }
        public static Producto BuscarPorId(int id)
        {
            var productoData = new ProductoData();
            return productoData.BuscarPorId(id);
        }

        //public static bool Parametros(Producto producto)
        //{
        //    //var productoData = new ProductoData();
        //    //return productoData.Parametros(producto);
        //}

            public static bool Insertar(Producto producto)
        {
            
            var productoData = new ProductoData();
            return productoData.Insertar(producto);
        }

        public static bool Actualizar(Producto producto)
        {
            var productoData = new ProductoData();
            return productoData.Actualizar(producto);
        }

        public static bool Eliminar(int id)
        {
            var productoData = new ProductoData();
            return productoData.Eliminar(id);
        }

    }
}
