using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Oferta
    {
        private static int s_id = 0;

        private int _id;
        private Cliente _cliente;
        private int _monto;
        private DateTime _fecha;

        public int Id { get { return _id; } }
        public Cliente Cliente { get { return _cliente; } set { _cliente = value; } }
        public int Monto { get { return _monto; } set { _monto = value; } }
        public DateTime Fecha { get { return _fecha; } set { _fecha = value; } }

        public Oferta()
        {
            Oferta.s_id++;
            this._id = Oferta.s_id;
            this._fecha = DateTime.Today;
        }

        public Oferta(Cliente unCliente, int monto)
        {
            Oferta.s_id++;
            this._id = Oferta.s_id;
            this._cliente = unCliente;
            this._monto = monto;
            this._fecha = DateTime.Today;
        }
    }
}
