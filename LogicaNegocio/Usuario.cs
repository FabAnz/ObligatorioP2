using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public abstract class Usuario : IValidable
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

        public void Validar()
        {
            if (string.IsNullOrEmpty(this._nombre))
                throw new Exception("El nombre no puede estar vacio.");
            if (string.IsNullOrEmpty(this._apellido))
                throw new Exception("El apellido no puede estar vacio.");
            if (string.IsNullOrEmpty(this._email))
                throw new Exception("El email no puede estar vacio.");
            ValidarPass();
        }

        public void ValidarPass()
        {
            bool contieneLetra = false;
            bool contieneNum = false;

            int i = 0;
            while ((!contieneLetra || !contieneNum) && i < this._pass.Length)
            {
                if (Char.IsLetter(this._pass[i]))
                    contieneLetra = true;
                if (Char.IsDigit(this._pass[i]))
                    contieneNum = true;
                i++;
            }

            if (!contieneLetra)
                throw new Exception("El password debe tener al menos una letra");
            else if (!contieneNum)
                throw new Exception("El password debe tener al menos un numero");
            else if (this._pass.Length <= 8)
                throw new Exception("El password debe tener mas de 8 caracteres");
        }

        public Rol ObtenerRol()
        {
            Rol rolActivo = Rol.Administrador;
            if (this is Cliente)
                rolActivo = Rol.Cliente;
            return rolActivo;
        }

        //Verifica que el rol del usuario sea el correcto para la vista a la que se quiere acceder
        public void VerificarRol(Rol unRol)
        {
            if (this.ObtenerRol() != unRol)
                throw new Exception("No tiene permiso para acceder a esta sección.");
        }
    }
}
