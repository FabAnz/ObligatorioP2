using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Usuario
    {
        private static int s_id = 0;

        private int _id;
        private string _nombre;
        private string _apellido;
        private string _email;
        private string _pass;

        public int Id { get { return _id; } }
        public string Nombre { get { return _nombre; } set { _nombre = value; } }
        public string Apellido { get { return _apellido; } set { _apellido = value; } }
        public string Email { get { return _email; } set { _email = value; } }
        public string Pass { get { return _pass; } set { _pass = value; } }

        public Usuario()
        {
            Usuario.s_id++;
            this._id = Usuario.s_id;
        }

        public Usuario(
            string nombre,
            string apellido,
            string email,
            string pass)
        {
            Usuario.s_id++;
            this._id = Usuario.s_id;
            this._nombre = nombre;
            this._apellido = apellido;
            this._email = email;
            this._pass = pass;
        }
    }
}
