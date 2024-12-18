﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public abstract class Publicacion
    {
        private static int s_id = 0;

        private int _id;
        private string _nombre;
        private EstadoPublicacion _estado;
        private DateTime _fechaPublicacion;
        private List<Articulo> _articulos = new List<Articulo>();
        private Cliente _comprador;
        private Usuario _finalizoCompra;
        private DateTime _fechaFinalizacion;

        public int Id { get { return _id; } }
        public string Nombre { get { return _nombre; } set { _nombre = value; } }
        public EstadoPublicacion Estado { get { return _estado; } set { _estado = value; } }
        public DateTime FechaPublicacion { get { return _fechaPublicacion; } set { _fechaPublicacion = value; } }
        public List<Articulo> Articulos { get { return _articulos; } }
        public Cliente Comprador { get { return _comprador; } set { _comprador = value; } }
        public Usuario FinalizoCompra { get { return _finalizoCompra; } set { _finalizoCompra = value; } }
        public DateTime FechaFinalizacion { get { return _fechaFinalizacion; } set { _fechaFinalizacion = value; } }

        public Publicacion()
        {
            Publicacion.s_id++;
            this._id = Publicacion.s_id;
            this._estado = EstadoPublicacion.Abierta;
            this._fechaPublicacion = DateTime.Today;
        }

        public Publicacion(string nombre)
        {
            Publicacion.s_id++;
            this._id = Publicacion.s_id;
            this._nombre = nombre;
            this._estado = EstadoPublicacion.Abierta;
            this._fechaPublicacion = DateTime.Today;
        }

        public void AgregarArticulo(Articulo unArticulo)
        {
            try
            {
                _articulos.Add(unArticulo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public abstract void CerrarPublicacion(string email);

        //Metodo para finalizar una publicacion
        public void FinalizarPublicacion(Cliente comprador, Usuario finalizador)
        {
            Sistema sistema = Sistema.Instancia;

            if (comprador == null)
            {
                this._estado = EstadoPublicacion.Cancelada;
                this._finalizoCompra = finalizador;
                this._fechaFinalizacion = DateTime.Today;
            }
            else if (comprador.SaldoSuficiente(this.CalcularPrecio()))
            {
                this._estado = EstadoPublicacion.Cerrada;
                this._finalizoCompra = finalizador;
                this._fechaFinalizacion = DateTime.Now;
                this._comprador = comprador;
                comprador.RestarCompraAlSaldo(this.CalcularPrecio());
            }
            else
            {
                throw new Exception($"Su saldo (${comprador.Saldo}) es insuficiente.");
            }
        }

        public abstract double CalcularPrecio();
    }
}

