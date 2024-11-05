using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Articulo
    {
        private static int s_id = 0;

        private int _id;
        private string _nombre;
        private Categoria _categoria;
        private int _precioVenta;

        public int Id { get { return _id; } }
        public string Nombre { get { return _nombre; } set { _nombre = value; } }
        public Categoria Categoria { get { return _categoria; } set { _categoria = value; } }
        public int PrecioVenta { get { return _precioVenta; } set { _precioVenta = value; } }

        public Articulo()
        {
            Articulo.s_id++;
            this._id = Articulo.s_id;
        }

        public Articulo(
            string nombre,
            Categoria categoria,
            int precioVenta
            )
        {
            Articulo.s_id++;
            this._id = Articulo.s_id;
            this._nombre = nombre;
            this._categoria = categoria;
            this._precioVenta = precioVenta;
        }
    }
}
