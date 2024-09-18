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
        public void CerrarVenta()
        {
            Sistema sistema = Sistema.Instancia;
            Cliente clienteActivo = (Cliente)sistema.UsuarioActivo;

            if (clienteActivo.SaldoSuficiente(this.CalcularPrecio()))
            {
                this.FinalizarPublicacion(clienteActivo);
                Console.WriteLine("\nCompra realizada con exito");
            }
            else
            {
                Console.WriteLine("\nSaldo insuficiente");
            }
        }

        //Calcular el precio de la venta
        public int CalcularPrecio()
        {
            int precio = 0;
            foreach (Articulo unArticulo in this.Articulos)
            {
                precio += unArticulo.PrecioVenta;
            }
            if (this._enOferta)
                precio *= (80 / 100);
            return precio;
        }
    }
}
