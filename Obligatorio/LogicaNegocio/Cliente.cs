using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Cliente : Usuario
    {
        private double _saldo;

        public double Saldo { get { return _saldo; } set { _saldo = value; } }

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

        /*Controla si el cliente tiene el saldo suficiente para cerrar una compra
        o para que le validen una oferta en una subasta*/
        public bool SaldoSuficiente(double precio)
        {
            if (this._saldo >= precio)
                return true;
            return false;
        }

        //Resta resta al saldo el costo de una compra realizada o de una subasta adjudicada
        public void RestarCompraAlSaldo(double precio)
        {
            this._saldo -= precio;
        }

        //Cargar saldo a la cuenta
        public void CargarSaldo(double monto)
        {
            if (monto <= 0)
                throw new Exception("El monto debe ser mayor a $ 0.");
            this._saldo += monto;
        }
    }
}
