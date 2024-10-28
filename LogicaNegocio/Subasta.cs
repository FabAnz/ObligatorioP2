using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Subasta : Publicacion
    {
        private List<Oferta> _ofertas = new List<Oferta>();

        public List<Oferta> Ofertas { get { return _ofertas; } }

        public Subasta() : base() { }

        public Subasta(string nombre) : base(nombre) { }

        public void AgregarOferta(Oferta unaOferta)
        {
            try
            {
                _ofertas.Add(unaOferta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Retorna la oferta ganadora de la subasta
        public Oferta OfertaGanadora()
        {
            Oferta ganadora = new Oferta();

            //Cargar a ganadora la oferta mas alta controlando que el cliente tenga saldo
            foreach (Oferta unaOferta in this._ofertas)
            {
                if (unaOferta.Monto > ganadora.Monto && unaOferta.Cliente.SaldoSuficiente(unaOferta.Monto))
                {
                    ganadora = unaOferta;
                }
            }
            return ganadora;
        }

        public override void CerrarPublicacion()
        {
            Oferta ganadora = OfertaGanadora();
           
            //En caso de que la subasta no tenga ofertas
            if (ganadora.Cliente == null)
            {
                Console.Write("\nLa subasta no tuvo ofertas");
                this.FinalizarPublicacion(null);
            }
            else
            {
                this.FinalizarPublicacion(ganadora.Cliente);
            }
        }

        public override double CalcularPrecio()
        {
            return OfertaGanadora().Monto;
        }
    }
}
