using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Venta : Publicacion
    {
        private bool _enOferta;

        public bool EnOferta { get { return _enOferta; } set { _enOferta = value; } }

        public Venta() : base() { }

        public Venta(
            string nombre,
            bool enOferta) : base(nombre)
        {
            this._enOferta = enOferta;
        }
    }
}
