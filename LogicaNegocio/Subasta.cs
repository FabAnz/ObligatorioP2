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

        public void CerrarSubasta()
        {
            Oferta ofertaGanadora = new Oferta();
            foreach (Oferta unaOferta in this._ofertas)
            {
                if (unaOferta.Monto > ofertaGanadora.Monto && unaOferta.Cliente.SaldoSuficiente(unaOferta.Monto))
                {
                    ofertaGanadora = unaOferta;
                }
            }
            //En caso de que la subasta no tenga ofertas
            if (ofertaGanadora.Cliente == null)
            {
                Console.Write("\nLa subasta no tuvo ofertas");
                this.FinalizarPublicacion(null);
            }
            else
            {
                this.FinalizarPublicacion(ofertaGanadora.Cliente);
            }
        }
    }
}
