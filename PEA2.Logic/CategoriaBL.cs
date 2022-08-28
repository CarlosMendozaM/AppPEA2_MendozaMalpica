using System;
using System.Collections.Generic;
using System.Text;
using PEA2.Dominio;
using PEA2.Data;

namespace PEA2.Logic
{
    public static class CategoriaBL
    {
        public static List<Categoria> Listar()
        {
            var categoriaData = new CategoriaData();
            return categoriaData.Listar();
        }
    }
}
