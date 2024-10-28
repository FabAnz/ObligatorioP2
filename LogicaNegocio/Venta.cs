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

        //Cerrar venta
        public override void CerrarPublicacion()
        {
            Sistema sistema = Sistema.Instancia;
            Cliente clienteActivo = (Cliente)sistema.UsuarioActivo;
            
            //Controlar que el cliente tenga saldo suficiente
            if (clienteActivo.SaldoSuficiente(this.CalcularPrecio()))
            {
                this.FinalizarPublicacion(clienteActivo);
            }
            else
            {
                throw new Exception($"Su saldo de $ {clienteActivo.Saldo} es insuficiente.");
            }
        }

        //Calcular el precio de la venta
        public override double CalcularPrecio()
        {
            double precio = 0;
            foreach (Articulo unArticulo in this.Articulos)
            {
                precio += unArticulo.PrecioVenta;
            }
            if (this._enOferta)
                precio *= 0.8;
            return precio;
        }
    }
}
