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
            Console.WriteLine("\nLista de clientes");
            Console.WriteLine("\n" + sistema.ListarClientes());
            Console.Write("\nPresione enter para continuar");
            Console.ReadLine();
            break;
        case "2":
            Console.WriteLine("\nArticulos");
            Categoria laCategoria = SeleccionarCategoria();
            Console.WriteLine("\n" + laCategoria);
            Console.WriteLine("\n" + sistema.ListarArticulos(laCategoria));
            Console.Write("Presione enter para continuar");
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
            Console.WriteLine("\n" + sistema.ListarPublicaciones(primerFecha, segundaFecha));
            Console.Write("\nPresione enter para continuar");
            Console.ReadLine();
            break;
        default:
            Console.WriteLine("\nOpcion inválida");
            Console.Write("\nPresione enter para continuar");
            Console.ReadLine();
            break;
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