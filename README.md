## Proyecto: https://obligatoriop2-339182.azurewebsites.net/

### Credenciales de administrador

Email: `roberto.suarez@example.com`

Password: `adminPass123`


# Requisitos del proyecto

## Punto 1: Diseño

1. **Diagrama de clases**: Diagrama completo del dominio siguiendo el estándar UML, que modele la realidad planteada, con todos los cambios necesarios para cumplir con los nuevos requerimientos.
2. **Diagrama de casos de uso**: Debe presentarse en formato ASTAH e incluirse también en la documentación digital.

## Punto 2: Implementación

Implementación en **ASP.NET 8.0 / MVC** con **C#**, utilizando **Visual Studio 2022**, de las siguientes funcionalidades, dependiendo del rol del usuario:

### Usuario Anónimo

3. **Registrarse como cliente**: El sistema solicitará todos los datos necesarios, y quedará registrado como cliente. La contraseña deberá ser alfanumérica y tener un largo mínimo de 8 caracteres.
4. **Login**: El usuario ingresará su email y contraseña. Si son válidos, se le permitirá acceder a las funcionalidades correspondientes a su rol.

### Usuario Cliente

5. **Ver todas las publicaciones**: El cliente podrá ver todas las publicaciones, mostrando su nombre, estado, y precio (en subastas será el valor de la oferta más alta). Las publicaciones en estado "Abierta" permitirán al cliente comprar o realizar una oferta, dependiendo del tipo de publicación. El precio de cada publicación se calculará según lo establecido en el primer obligatorio.
6. **Comprar una publicación de tipo venta**: El cliente podrá realizar la compra si cuenta con suficiente dinero. Esta acción dispara la lógica de finalización de la publicación.
7. **Ofertar en una subasta**: El cliente podrá ofertar en una subasta un valor superior al más alto hasta el momento.
8. **Cargar saldo en la billetera electrónica**: El cliente podrá cargar saldo en su billetera electrónica, el valor no debe ser negativo.
9. **Logout**: El cliente cerrará la sesión.

### Usuario Administrador

10. **Ver todas las subastas**: El administrador verá una lista de subastas abiertas y cerradas, ordenadas por fecha de publicación. Para las subastas abiertas, tendrá la opción de cerrarlas. Se mostrará el nombre, tipo, fecha de publicación, estado y precio (para las subastas, será el valor de la mejor oferta realizada).
11. **Cerrar una subasta**: El administrador podrá cerrar una subasta, adjudicándola al mejor oferente, y disparar la lógica de finalización de la publicación.
12. **Logout**: El administrador cerrará la sesión.
