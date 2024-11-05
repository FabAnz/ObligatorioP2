using System.Linq.Expressions;

namespace LogicaNegocio
{
    public class Sistema
    {
        private static Sistema s_instancia;
        private List<Usuario> _usuarios = new List<Usuario>();
        private List<Articulo> _articulos = new List<Articulo>();
        private List<Publicacion> _publicaciones = new List<Publicacion>();

        public static Sistema Instancia
        {
            get
            {
                if (s_instancia == null)
                {
                    s_instancia = new Sistema();
                }
                return s_instancia;
            }
        }
        public List<Usuario> Usuarios { get { return _usuarios; } }
        public List<Articulo> Articulos { get { return _articulos; } }
        public List<Publicacion> Publicaciones { get { return _publicaciones; } }

        private Sistema()
        {
            this.PrecargarDatos();
        }

        public void AgregarCliente(Cliente unCliente)
        {
            try
            {
                unCliente.Validar();
                if (this.ExisteEmail(unCliente.Email))
                    throw new Exception("Ya hay un usuario registrado con ese email.");
                this._usuarios.Add(unCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AgregarAdministrador(Administrador unAdmin)
        {
            try
            {
                unAdmin.Validar();
                this._usuarios.Add(unAdmin);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AgregarArticulo(Articulo unArticulo)
        {
            try
            {
                this._articulos.Add(unArticulo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AgregarVenta(Venta unaVenta)
        {
            try
            {
                this._publicaciones.Add(unaVenta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AgregarSubasta(Subasta unaSubasta)
        {
            try
            {
                this._publicaciones.Add(unaSubasta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void PrecargarDatos()
        {
            this.PrecargarClientes();
            this.PrecargarAdministradores();
            this.PrecargarArticulos();
            this.PrecargarVentas();
            this.PrecargarSubastas();
        }

        private void PrecargarClientes()
        {
            Cliente cliente1 = new Cliente("Juan", "Pérez", "juan.perez@example.com", "pass123sdsd");
            Cliente cliente2 = new Cliente("María", "González", "maria.gonzalez@example.com", "password456sdsd");
            Cliente cliente3 = new Cliente("Carlos", "Ramírez", "carlos.ramirez@example.com", "qwerty789sdsd");
            Cliente cliente4 = new Cliente("Ana", "López", "ana.lopez@example.com", "pass987sdsd");
            Cliente cliente5 = new Cliente("Pedro", "Martínez", "pedro.martinez@example.com", "abc123defsdsd");
            Cliente cliente6 = new Cliente("Laura", "Hernández", "laura.hernandez@example.com", "password321");
            Cliente cliente7 = new Cliente("Luis", "Rodríguez", "luis.rodriguez@example.com", "1234abcdsdsd");
            Cliente cliente8 = new Cliente("Elena", "Fernández", "elena.fernandez@example.com", "myPass2024");
            Cliente cliente9 = new Cliente("Miguel", "Sánchez", "miguel.sanchez@example.com", "safePass456");
            Cliente cliente10 = new Cliente("Sofía", "Castro", "sofia.castro@example.com", "pass654321");

            cliente1.Saldo = 3565;
            cliente2.Saldo = 9780;
            cliente3.Saldo = 11200;
            cliente4.Saldo = 1950;
            cliente5.Saldo = 1340;
            cliente6.Saldo = 1890;
            cliente7.Saldo = 2460;
            cliente8.Saldo = 7020;
            cliente9.Saldo = 1050;
            cliente10.Saldo = 630;

            this.AgregarCliente(cliente1);
            this.AgregarCliente(cliente2);
            this.AgregarCliente(cliente3);
            this.AgregarCliente(cliente4);
            this.AgregarCliente(cliente5);
            this.AgregarCliente(cliente6);
            this.AgregarCliente(cliente7);
            this.AgregarCliente(cliente8);
            this.AgregarCliente(cliente9);
            this.AgregarCliente(cliente10);
        }

        private void PrecargarAdministradores()
        {
            Administrador admin1 = new Administrador("Roberto", "Suárez", "roberto.suarez@example.com", "adminPass123");
            Administrador admin2 = new Administrador("Lucía", "Martínez", "lucia.martinez@example.com", "secureAdmin456");

            this.AgregarAdministrador(admin1);
            this.AgregarAdministrador(admin2);
        }

        private void PrecargarArticulos()
        {
            Articulo articulo1 = new Articulo("Televisor", Categoria.Electronica, 500);
            Articulo articulo2 = new Articulo("Lámpara de mesa", Categoria.Hogar, 35);
            Articulo articulo3 = new Articulo("Sudadera", Categoria.Ropa, 40);
            Articulo articulo4 = new Articulo("Bicicleta", Categoria.Deportes, 300);
            Articulo articulo5 = new Articulo("Peluche", Categoria.Juguetes, 20);
            Articulo articulo6 = new Articulo("Smartphone", Categoria.Electronica, 800);
            Articulo articulo7 = new Articulo("Sofá", Categoria.Hogar, 600);
            Articulo articulo8 = new Articulo("Pantalón de mezclilla", Categoria.Ropa, 45);
            Articulo articulo9 = new Articulo("Pelota de fútbol", Categoria.Deportes, 25);
            Articulo articulo10 = new Articulo("Muñeca", Categoria.Juguetes, 30);
            Articulo articulo11 = new Articulo("Tablet", Categoria.Electronica, 350);
            Articulo articulo12 = new Articulo("Tostadora", Categoria.Hogar, 50);
            Articulo articulo13 = new Articulo("Camisa", Categoria.Ropa, 30);
            Articulo articulo14 = new Articulo("Cinta para correr", Categoria.Deportes, 800);
            Articulo articulo15 = new Articulo("Rompecabezas", Categoria.Juguetes, 15);
            Articulo articulo16 = new Articulo("Laptop", Categoria.Electronica, 1000);
            Articulo articulo17 = new Articulo("Mesa de comedor", Categoria.Hogar, 250);
            Articulo articulo18 = new Articulo("Vestido", Categoria.Ropa, 60);
            Articulo articulo19 = new Articulo("Raqueta de tenis", Categoria.Deportes, 70);
            Articulo articulo20 = new Articulo("Carrito de juguete", Categoria.Juguetes, 12);
            Articulo articulo21 = new Articulo("Auriculares", Categoria.Electronica, 150);
            Articulo articulo22 = new Articulo("Silla de oficina", Categoria.Hogar, 120);
            Articulo articulo23 = new Articulo("Chaqueta", Categoria.Ropa, 80);
            Articulo articulo24 = new Articulo("Mancuernas", Categoria.Deportes, 50);
            Articulo articulo25 = new Articulo("Cubo Rubik", Categoria.Juguetes, 10);
            Articulo articulo26 = new Articulo("Cámara", Categoria.Electronica, 600);
            Articulo articulo27 = new Articulo("Aspiradora", Categoria.Hogar, 200);
            Articulo articulo28 = new Articulo("Sombrero", Categoria.Ropa, 25);
            Articulo articulo29 = new Articulo("Patineta", Categoria.Deportes, 90);
            Articulo articulo30 = new Articulo("Monopatín eléctrico", Categoria.Juguetes, 350);
            Articulo articulo31 = new Articulo("Monitor", Categoria.Electronica, 300);
            Articulo articulo32 = new Articulo("Cafetera", Categoria.Hogar, 80);
            Articulo articulo33 = new Articulo("Falda", Categoria.Ropa, 35);
            Articulo articulo34 = new Articulo("Guantes de boxeo", Categoria.Deportes, 60);
            Articulo articulo35 = new Articulo("Drone", Categoria.Juguetes, 400);
            Articulo articulo36 = new Articulo("Consola de videojuegos", Categoria.Electronica, 500);
            Articulo articulo37 = new Articulo("Refrigerador", Categoria.Hogar, 700);
            Articulo articulo38 = new Articulo("Zapatos", Categoria.Ropa, 100);
            Articulo articulo39 = new Articulo("Balón de baloncesto", Categoria.Deportes, 30);
            Articulo articulo40 = new Articulo("Set de construcción", Categoria.Juguetes, 50);
            Articulo articulo41 = new Articulo("Smartwatch", Categoria.Electronica, 200);
            Articulo articulo42 = new Articulo("Microondas", Categoria.Hogar, 90);
            Articulo articulo43 = new Articulo("Bufanda", Categoria.Ropa, 20);
            Articulo articulo44 = new Articulo("Tienda de campaña", Categoria.Deportes, 150);
            Articulo articulo45 = new Articulo("Juguete interactivo", Categoria.Juguetes, 40);
            Articulo articulo46 = new Articulo("Bocina bluetooth", Categoria.Electronica, 120);
            Articulo articulo47 = new Articulo("Colchón", Categoria.Hogar, 400);
            Articulo articulo48 = new Articulo("Traje", Categoria.Ropa, 200);
            Articulo articulo49 = new Articulo("Pelota de tenis", Categoria.Deportes, 10);
            Articulo articulo50 = new Articulo("Juego de mesa", Categoria.Juguetes, 25);

            this.AgregarArticulo(articulo1);
            this.AgregarArticulo(articulo2);
            this.AgregarArticulo(articulo3);
            this.AgregarArticulo(articulo4);
            this.AgregarArticulo(articulo5);
            this.AgregarArticulo(articulo6);
            this.AgregarArticulo(articulo7);
            this.AgregarArticulo(articulo8);
            this.AgregarArticulo(articulo9);
            this.AgregarArticulo(articulo10);
            this.AgregarArticulo(articulo11);
            this.AgregarArticulo(articulo12);
            this.AgregarArticulo(articulo13);
            this.AgregarArticulo(articulo14);
            this.AgregarArticulo(articulo15);
            this.AgregarArticulo(articulo16);
            this.AgregarArticulo(articulo17);
            this.AgregarArticulo(articulo18);
            this.AgregarArticulo(articulo19);
            this.AgregarArticulo(articulo20);
            this.AgregarArticulo(articulo21);
            this.AgregarArticulo(articulo22);
            this.AgregarArticulo(articulo23);
            this.AgregarArticulo(articulo24);
            this.AgregarArticulo(articulo25);
            this.AgregarArticulo(articulo26);
            this.AgregarArticulo(articulo27);
            this.AgregarArticulo(articulo28);
            this.AgregarArticulo(articulo29);
            this.AgregarArticulo(articulo30);
            this.AgregarArticulo(articulo31);
            this.AgregarArticulo(articulo32);
            this.AgregarArticulo(articulo33);
            this.AgregarArticulo(articulo34);
            this.AgregarArticulo(articulo35);
            this.AgregarArticulo(articulo36);
            this.AgregarArticulo(articulo37);
            this.AgregarArticulo(articulo38);
            this.AgregarArticulo(articulo39);
            this.AgregarArticulo(articulo40);
            this.AgregarArticulo(articulo41);
            this.AgregarArticulo(articulo42);
            this.AgregarArticulo(articulo43);
            this.AgregarArticulo(articulo44);
            this.AgregarArticulo(articulo45);
            this.AgregarArticulo(articulo46);
            this.AgregarArticulo(articulo47);
            this.AgregarArticulo(articulo48);
            this.AgregarArticulo(articulo49);
            this.AgregarArticulo(articulo50);

        }

        private void PrecargarVentas()
        {
            Venta venta1 = new Venta("Experiencia Gamer", true);
            Venta venta2 = new Venta("Oficina en Casa", false);
            Venta venta3 = new Venta("Fitness en Casa", false);
            Venta venta4 = new Venta("Ropa Deportiva", false);
            Venta venta5 = new Venta("Cocina Moderna", false);
            Venta venta6 = new Venta("Día de Picnic", false);
            Venta venta7 = new Venta("Entretenimiento Infantil", true);
            Venta venta8 = new Venta("Aventura al Aire Libre", false);
            Venta venta9 = new Venta("Gamer Pro", false);
            Venta venta10 = new Venta("Decoración Elegante", false);


            // Venta 1 - Experiencia Gamer
            venta1.AgregarArticulo(BuscarArticuloPorNombre("Televisor"));
            venta1.AgregarArticulo(BuscarArticuloPorNombre("Consola de videojuegos"));
            venta1.AgregarArticulo(BuscarArticuloPorNombre("Auriculares"));

            // Venta 2 - Oficina en Casa
            venta2.AgregarArticulo(BuscarArticuloPorNombre("Laptop"));
            venta2.AgregarArticulo(BuscarArticuloPorNombre("Silla de oficina"));
            venta2.AgregarArticulo(BuscarArticuloPorNombre("Monitor"));

            // Venta 3 - Fitness en Casa
            venta3.AgregarArticulo(BuscarArticuloPorNombre("Cinta para correr"));
            venta3.AgregarArticulo(BuscarArticuloPorNombre("Mancuernas"));
            venta3.AgregarArticulo(BuscarArticuloPorNombre("Guantes de boxeo"));

            // Venta 4 - Ropa Deportiva
            venta4.AgregarArticulo(BuscarArticuloPorNombre("Sudadera"));
            venta4.AgregarArticulo(BuscarArticuloPorNombre("Pantalón de mezclilla"));
            venta4.AgregarArticulo(BuscarArticuloPorNombre("Zapatos"));

            // Venta 5 - Cocina Moderna
            venta5.AgregarArticulo(BuscarArticuloPorNombre("Tostadora"));
            venta5.AgregarArticulo(BuscarArticuloPorNombre("Microondas"));
            venta5.AgregarArticulo(BuscarArticuloPorNombre("Cafetera"));

            // Venta 6 - Día de Picnic
            venta6.AgregarArticulo(BuscarArticuloPorNombre("Tienda de campaña"));
            venta6.AgregarArticulo(BuscarArticuloPorNombre("Bicicleta"));
            venta6.AgregarArticulo(BuscarArticuloPorNombre("Pelota de fútbol"));

            // Venta 7 - Entretenimiento Infantil
            venta7.AgregarArticulo(BuscarArticuloPorNombre("Peluche"));
            venta7.AgregarArticulo(BuscarArticuloPorNombre("Muñeca"));
            venta7.AgregarArticulo(BuscarArticuloPorNombre("Juguete interactivo"));

            // Venta 8 - Aventura al Aire Libre
            venta8.AgregarArticulo(BuscarArticuloPorNombre("Patineta"));
            venta8.AgregarArticulo(BuscarArticuloPorNombre("Raqueta de tenis"));
            venta8.AgregarArticulo(BuscarArticuloPorNombre("Pelota de tenis"));

            // Venta 9 - Gamer Pro
            venta9.AgregarArticulo(BuscarArticuloPorNombre("Smartwatch"));
            venta9.AgregarArticulo(BuscarArticuloPorNombre("Tablet"));
            venta9.AgregarArticulo(BuscarArticuloPorNombre("Bocina bluetooth"));

            // Venta 10 - Decoración Elegante
            venta10.AgregarArticulo(BuscarArticuloPorNombre("Lámpara de mesa"));
            venta10.AgregarArticulo(BuscarArticuloPorNombre("Sofá"));
            venta10.AgregarArticulo(BuscarArticuloPorNombre("Mesa de comedor"));

            venta1.FechaPublicacion = DateTime.Parse("19-04-2024");
            venta2.FechaPublicacion = DateTime.Parse("09-09-2024");
            venta3.FechaPublicacion = DateTime.Parse("23-04-2024");
            venta4.FechaPublicacion = DateTime.Parse("25-02-2024");
            venta5.FechaPublicacion = DateTime.Parse("08-07-2024");
            venta6.FechaPublicacion = DateTime.Parse("11-06-2024");
            venta7.FechaPublicacion = DateTime.Parse("18-03-2024");
            venta8.FechaPublicacion = DateTime.Parse("21-07-2024");
            venta9.FechaPublicacion = DateTime.Parse("07-06-2024");
            venta10.FechaPublicacion = DateTime.Parse("14-02-2024");

            venta3.Estado = EstadoPublicacion.Cancelada;
            venta5.Estado = EstadoPublicacion.Cerrada;
            venta7.Estado = EstadoPublicacion.Cancelada;
            venta10.Estado = EstadoPublicacion.Cancelada;

            this.AgregarVenta(venta1);
            this.AgregarVenta(venta2);
            this.AgregarVenta(venta3);
            this.AgregarVenta(venta4);
            this.AgregarVenta(venta5);
            this.AgregarVenta(venta6);
            this.AgregarVenta(venta7);
            this.AgregarVenta(venta8);
            this.AgregarVenta(venta9);
            this.AgregarVenta(venta10);
        }

        private void PrecargarSubastas()
        {
            Subasta subasta1 = new Subasta("Ropa de Invierno");
            Subasta subasta2 = new Subasta("Home Theater");
            Subasta subasta3 = new Subasta("Moda Formal");
            Subasta subasta4 = new Subasta("Juegos de Mesa y Estrategia");
            Subasta subasta5 = new Subasta("Deporte y Tecnología");
            Subasta subasta6 = new Subasta("Diversión al Aire Libre");
            Subasta subasta7 = new Subasta("Entretenimiento Digital");
            Subasta subasta8 = new Subasta("Tecnología Portátil");
            Subasta subasta9 = new Subasta("Ambiente Acogedor en el Hogar");
            Subasta subasta10 = new Subasta("Hogar Inteligente");

            // Subasta 1 - Ropa de Invierno
            subasta1.AgregarArticulo(BuscarArticuloPorNombre("Chaqueta"));
            subasta1.AgregarArticulo(BuscarArticuloPorNombre("Bufanda"));
            subasta1.AgregarArticulo(BuscarArticuloPorNombre("Sombrero"));

            // Subasta 2 - Home Theater
            subasta2.AgregarArticulo(BuscarArticuloPorNombre("Televisor"));
            subasta2.AgregarArticulo(BuscarArticuloPorNombre("Bocina bluetooth"));
            subasta2.AgregarArticulo(BuscarArticuloPorNombre("Auriculares"));

            // Subasta 3 - Moda Formal
            subasta3.AgregarArticulo(BuscarArticuloPorNombre("Traje"));
            subasta3.AgregarArticulo(BuscarArticuloPorNombre("Camisa"));
            subasta3.AgregarArticulo(BuscarArticuloPorNombre("Zapatos"));

            // Subasta 4 - Juegos de Mesa y Estrategia
            subasta4.AgregarArticulo(BuscarArticuloPorNombre("Rompecabezas"));
            subasta4.AgregarArticulo(BuscarArticuloPorNombre("Cubo Rubik"));
            subasta4.AgregarArticulo(BuscarArticuloPorNombre("Juego de mesa"));

            // Subasta 5 - Deporte y Tecnología
            subasta5.AgregarArticulo(BuscarArticuloPorNombre("Smartwatch"));
            subasta5.AgregarArticulo(BuscarArticuloPorNombre("Raqueta de tenis"));
            subasta5.AgregarArticulo(BuscarArticuloPorNombre("Pelota de tenis"));

            // Subasta 6 - Diversión al Aire Libre
            subasta6.AgregarArticulo(BuscarArticuloPorNombre("Patineta"));
            subasta6.AgregarArticulo(BuscarArticuloPorNombre("Bicicleta"));
            subasta6.AgregarArticulo(BuscarArticuloPorNombre("Tienda de campaña"));

            // Subasta 7 - Entretenimiento Digital
            subasta7.AgregarArticulo(BuscarArticuloPorNombre("Tablet"));
            subasta7.AgregarArticulo(BuscarArticuloPorNombre("Consola de videojuegos"));
            subasta7.AgregarArticulo(BuscarArticuloPorNombre("Televisor"));

            // Subasta 8 - Tecnología Portátil
            subasta8.AgregarArticulo(BuscarArticuloPorNombre("Smartwatch"));
            subasta8.AgregarArticulo(BuscarArticuloPorNombre("Tablet"));
            subasta8.AgregarArticulo(BuscarArticuloPorNombre("Bocina bluetooth"));

            // Subasta 9 - Ambiente Acogedor en el Hogar
            subasta9.AgregarArticulo(BuscarArticuloPorNombre("Colchón"));
            subasta9.AgregarArticulo(BuscarArticuloPorNombre("Lámpara de mesa"));
            subasta9.AgregarArticulo(BuscarArticuloPorNombre("Aspiradora"));

            // Subasta 10 - Hogar Inteligente
            subasta10.AgregarArticulo(BuscarArticuloPorNombre("Refrigerador"));
            subasta10.AgregarArticulo(BuscarArticuloPorNombre("Microondas"));
            subasta10.AgregarArticulo(BuscarArticuloPorNombre("Bocina bluetooth"));

            Oferta oferta1 = new Oferta((Cliente)_usuarios[0], 100);
            Oferta oferta2 = new Oferta((Cliente)_usuarios[1], 200);
            Oferta oferta3 = new Oferta((Cliente)_usuarios[2], 300);
            Oferta oferta4 = new Oferta((Cliente)_usuarios[3], 400);
            Oferta oferta5 = new Oferta((Cliente)_usuarios[4], 500);
            Oferta oferta6 = new Oferta((Cliente)_usuarios[5], 600);
            Oferta oferta7 = new Oferta((Cliente)_usuarios[6], 700);
            Oferta oferta8 = new Oferta((Cliente)_usuarios[7], 800);

            subasta3.AgregarOferta(oferta1);
            subasta3.AgregarOferta(oferta2);
            subasta3.AgregarOferta(oferta3);
            subasta3.AgregarOferta(oferta4);

            subasta5.AgregarOferta(oferta1);
            subasta5.AgregarOferta(oferta2);
            subasta5.AgregarOferta(oferta3);
            subasta5.AgregarOferta(oferta4);

            subasta7.AgregarOferta(oferta5);
            subasta7.AgregarOferta(oferta6);
            subasta7.AgregarOferta(oferta7);
            subasta7.AgregarOferta(oferta8);

            subasta9.AgregarOferta(oferta5);
            subasta9.AgregarOferta(oferta6);
            subasta9.AgregarOferta(oferta7);
            subasta9.AgregarOferta(oferta8);

            subasta1.FechaPublicacion = DateTime.Parse("15-03-2024");
            subasta2.FechaPublicacion = DateTime.Parse("30-08-2024");
            subasta3.FechaPublicacion = DateTime.Parse("05-05-2024");
            subasta4.FechaPublicacion = DateTime.Parse("12-04-2024");
            subasta5.FechaPublicacion = DateTime.Parse("19-06-2024");
            subasta6.FechaPublicacion = DateTime.Parse("25-07-2024");
            subasta7.FechaPublicacion = DateTime.Parse("22-04-2024");
            subasta8.FechaPublicacion = DateTime.Parse("10-06-2024");
            subasta9.FechaPublicacion = DateTime.Parse("28-05-2024");
            subasta10.FechaPublicacion = DateTime.Parse("16-02-2024");

            subasta2.Estado = EstadoPublicacion.Cerrada;
            subasta3.Estado = EstadoPublicacion.Cancelada;
            subasta5.Estado = EstadoPublicacion.Cerrada;

            this.AgregarSubasta(subasta1);
            this.AgregarSubasta(subasta2);
            this.AgregarSubasta(subasta3);
            this.AgregarSubasta(subasta4);
            this.AgregarSubasta(subasta5);
            this.AgregarSubasta(subasta6);
            this.AgregarSubasta(subasta7);
            this.AgregarSubasta(subasta8);
            this.AgregarSubasta(subasta9);
            this.AgregarSubasta(subasta10);
        }

        /*Verifica que el nombre del articulo exista a la hora de hacer la precarga
        Los nombres de los articulos precargados son unicos*/
        public Articulo BuscarArticuloPorNombre(string nombre)
        {
            foreach (Articulo unArticulo in this._articulos)
            {
                if (unArticulo.Nombre == nombre) return unArticulo;
            }
            throw new Exception("No existe un articulo con ese nombre");
        }

        //Verificar credenciales y carga el usuario activo
        public void Login(string email, string pass)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(pass))
                throw new Exception("Complete el email y el password.");
            foreach (Usuario unUsuario in this._usuarios)
            {
                if (unUsuario.Email.ToLower() == email.ToLower() && unUsuario.Pass == pass)
                    return;
            }
            throw new Exception("Usuario y/o contraseña incorrectos");
        }


        //Verificar si el email ya esta registrado
        public bool ExisteEmail(string email)
        {
            foreach (Usuario unUsuario in this._usuarios)
            {
                if (unUsuario.Email.ToLower() == email.ToLower()) return true;
            }
            return false;
        }

        //Obtener usuario por email
        public Usuario ObtenerUsuarioPorEmail(string email)
        {
            foreach (Usuario unUsuario in this._usuarios)
            {
                if (unUsuario.Email == email)
                    return unUsuario;
            }
            throw new Exception("El usuario no existe.");
        }

        //Listar todas las subastas
        public List<Subasta> ListarSubastas()
        {
            List<Subasta> aRetornar = new List<Subasta>();
            //Listar subastas
            foreach (Publicacion unaSubasta in this._publicaciones)
            {
                if (unaSubasta is Subasta)
                    aRetornar.Add((Subasta)unaSubasta);
            }
            aRetornar.Sort();
            return aRetornar;
        }

        //Retornar subasta por ID
        public Publicacion ObtenerPublicacionPorId(int id)
        {
            foreach (Publicacion unaPublicacion in this._publicaciones)
            {
                if (unaPublicacion.Id == id)
                    return unaPublicacion;
            }
            return null;
        }
    }
}
