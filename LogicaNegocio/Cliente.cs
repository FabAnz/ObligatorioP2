using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Cliente : Usuario
    {
        private int _saldo;

        public int Saldo { get { return _saldo; } set { _saldo = value; } }

        public Cliente() : base()
        {
            this._saldo = 0;
        }

        public Cliente(string nombre,
            string apellido,
            string email,
            string pass) : base(nombre, apellido, email, pass)
        {
            this._saldo = 0;
        }

        public override string ToString()
        {
            return $"ID: {this.Id} - {this.Nombre} {this.Apellido}";
        }

        public bool SaldoSuficiente(int precio)
        {
            if (this._saldo >= precio)
                return true;
            return false;
        }
    }
}
