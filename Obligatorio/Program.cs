using LogicaNegocio;
Sistema sistema = Sistema.Instancia;
string seleccion = "";
while (seleccion != "0")
{
    Console.Clear();
    MostrarMenu();
    seleccion = Console.ReadLine();
    switch (seleccion)
    {
        case "0":
            Console.WriteLine("\nHasta luego");
            Console.Write("\nPresione enter para continuar");
            Console.ReadLine();
            break;
        case "1":
            Console.WriteLine("\nLista de clientes\n");
            foreach (Cliente unCliente in sistema.ListarClientes())
            {
                Console.WriteLine(unCliente.ToString());
            }
            Console.Write("\nPresione enter para continuar");
            Console.ReadLine();
            break;
        case "2":
            Console.WriteLine("\nArticulos");
            Categoria laCategoria = SeleccionarCategoria();
            Console.WriteLine("\n" + laCategoria + "\n");
            foreach (Articulo unArticulo2 in sistema.ListarArticulos(laCategoria))
            {
                Console.WriteLine(unArticulo2.ToString());
            }
            Console.Write("\nPresione enter para continuar");
            Console.ReadLine();
            break;
        case "3":
            Console.WriteLine("\nCrear articulo");

            Console.Write("\nIngrese el nombre: ");
            string nombre = CampoObligatorio("El nombre no puede estar vacio");
            Categoria laCategoria2 = SeleccionarCategoria();
            int precio = SolicitarInt(1, int.MaxValue, "Ingrese el precio: ");

            Articulo unArticulo = new Articulo(nombre, laCategoria2, precio);
            sistema.AgregarArticulo(unArticulo);
            Console.WriteLine("\nArticulo creado con éxito");

            Console.Write("\nPresione enter para continuar");
            Console.ReadLine();
            break;
        case "4":
            Console.WriteLine("\nPublicaciones");
            Console.Write("\nIngrese primer fecha: ");
            DateTime? primerFecha = SolicitarFecha();
            Console.Write("Ingrese segunda fecha: ");
            DateTime? segundaFecha = SolicitarFecha();
            foreach (Publicacion unaPublicacion in sistema.ListarPublicaciones(primerFecha, segundaFecha))
            {
                Console.WriteLine(unaPublicacion.ToString() + "\n");
                Console.WriteLine("-----------------------------------------------------------");
            }
            Console.Write("Presione enter para continuar");
            Console.ReadLine();
            break;
        case "5":
            OtrasOpciones();
            break;
        default:
            Console.WriteLine("\nOpcion inválida");
            Console.Write("\nPresione enter para continuar");
            Console.ReadLine();
            break;
    }
}

//Menu que muestra las opciones extras
static void OtrasOpciones()
{
    Sistema sistema = Sistema.Instancia;
    Console.Clear();
    Console.WriteLine("1 - Realizar compra (finalizar venta)");
    Console.WriteLine("\nPara esta opción loguearse como comprador con las siguientes credenciales\n");
    Console.WriteLine("Email: juan.perez@example.com");
    Console.WriteLine("Contraseña: pass123\n");
    Console.WriteLine("---------------------------------------------------------------------------------------------");
    Console.WriteLine("\n2 - Finalizar subasta");
    Console.WriteLine("\nPara esta opción loguearse como administrador con las siguientes credenciales\n");
    Console.WriteLine("Email: roberto.suarez@example.com");
    Console.WriteLine("Contraseña: adminPass123\n");
    Console.WriteLine("---------------------------------------------------------------------------------------------");

    sistema.Login();

    //Acceder a las opciones segun el tipo de usuario
    if (!sistema.UsuarioEsAdministrador(sistema.UsuarioActivo))
    {
        Console.Clear();
        Console.WriteLine("Ventas abiertas\n");
        foreach (Venta unaVenta in sistema.ListarVentasAbiertas())
        {
            Console.WriteLine(unaVenta.ToString() + "\n");
            Console.WriteLine("-----------------------------------------------------------");
        }

        //Seleccionar el ID de la lista///////////////////////////////////////////////////////////
        bool esCorrecto = false;
        int id = 0;
        while (!esCorrecto)
        {
            try
            {
                Console.Write("\nIngrese el ID de la venta: ");
                id = int.Parse(Console.ReadLine());
                foreach (Venta unaVenta in sistema.ListarVentasAbiertas())
                {
                    if (unaVenta.Id == id)
                    {
                        esCorrecto = true;
                        break;
                    }
                }
                if (!esCorrecto)
                    Console.WriteLine("\nEl ID seleccionado no esta en la lista");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Solo se aceptan numeros");
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////////
        sistema.DevolverVentaPorId(id).CerrarVenta();
        
        Console.Write("\nPresione enter para continuar");
        Console.ReadLine();
    }
    else
    {
        Console.Clear();
        Console.WriteLine("Subastas abiertas\n");
        foreach (Subasta unaSubasta in sistema.ListarSubastasAbiertas())
        {
            Console.WriteLine(unaSubasta.ToString() + "\n");
            Console.WriteLine("-----------------------------------------------------------");
        }

        //Seleccionar el ID de la lista///////////////////////////////////////////////////////////
        bool esCorrecto = false;
        int id = 0;
        while (!esCorrecto)
        {
            try
            {
                Console.Write("\nIngrese el ID de la subasta: ");
                id = int.Parse(Console.ReadLine());
                foreach (Subasta unaSubasta in sistema.ListarSubastasAbiertas())
                {
                    if (unaSubasta.Id == id)
                    {
                        esCorrecto = true;
                        break;
                    }
                }
                if (!esCorrecto)
                    Console.WriteLine("\nEl ID seleccionado no esta en la lista");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Solo se aceptan numeros");
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////////
        sistema.DevolverSubastaPorId(id).CerrarSubasta();
        Console.WriteLine("\nSubasta finalizada");

        Console.Write("\nPresione enter para continuar");
        Console.ReadLine();
    }
}

static DateTime? SolicitarFecha()
{
    bool esCorrecto = false;
    while (!esCorrecto)
    {
        try
        {
            DateTime fecha = DateTime.Parse(Console.ReadLine());
            return fecha;
        }
        catch (Exception e)
        {
            Console.Write("Formato invalido, vuelva a ingresar: ");
        }
    }
    return null;
}

static string CampoObligatorio(string mensaje)
{
    string campo = Console.ReadLine();
    while (campo == "")
    {
        Console.Write(mensaje + " vuelva a ingresarlo: ");
        campo = Console.ReadLine();
    }
    return campo;
}

static Categoria SeleccionarCategoria()
{
    Console.WriteLine("\nSelecciona una categoria\n");
    int i = 0;
    foreach (string unaCategoria in Enum.GetNames(typeof(Categoria)))
    {
        i++;
        Console.WriteLine(i + " - " + unaCategoria);
    }
    int categoria = SolicitarInt(1, Enum.GetNames(typeof(Categoria)).Length, "Ingrese la categoria: ") - 1;
    return (Categoria)categoria;
}


static void MostrarMenu()
{
    Console.WriteLine("1 - Listar clientes");
    Console.WriteLine("2 - Listar articulos");
    Console.WriteLine("3 - Crear articulo");
    Console.WriteLine("4 - Listar publicaciones");
    Console.WriteLine("5 - Otras opciones");
    Console.WriteLine("0 - Salir");
    Console.Write("\nIngrese una opción: ");
}

static int SolicitarInt(int min, int max, string mensaje)
{
    bool esCorrecto = false;
    while (!esCorrecto)
    {
        try
        {
            Console.Write("\n" + mensaje);
            int seleccion = int.Parse(Console.ReadLine());
            if (seleccion >= min && seleccion <= max)
            {
                return seleccion;
            }
            Console.WriteLine($"El número debe ser mayor que {min} y menor que {max}");
        }
        catch (Exception e)
        {
            Console.WriteLine("Solo se aceptan números");
        }
    }
    return 0;
}