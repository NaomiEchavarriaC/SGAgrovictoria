/*

    La View en el patrón MVC (Model-View-Controller) es la parte encargada de mostrar la interfaz de usuario. 
    Su función principal es presentar los datos que el Controller y el Model han preparado para el usuario, 
    de una forma amigable y accesible. En otras palabras, la View es el lugar donde los usuarios interactúan 
    con la aplicación, como formularios, listas, botones, etc.

    1. ¿Qué es una View?

        Una View en una aplicación web es básicamente una página HTML que puede contener código dinámico para 
        mostrar datos que vienen del Model. En el caso de .NET, se suelen usar Razor Views, que son archivos 
        .cshtml que combinan HTML y C# para crear contenido dinámico.

    2. ¿Cómo se conecta la View con el Controller?

        El Controller pasa los datos al View utilizando el método View() en el que se le puede pasar 
        un modelo de datos. Estos datos luego son procesados y renderizados en el archivo .cshtml 
        que corresponde a la vista.

        Por ejemplo, en un Controller:

            public class ProductosController : Controller
            {
                public IActionResult Lista()
                {
                    var productos = ObtenerTodosLosProductos(); // Datos desde el Model
                    return View(productos); // Pasa los datos a la View
                }
            }

            En este caso, la acción Lista() del Controller obtiene los productos y los envía a la View. 
            La View se encargará de mostrar esos productos de manera visual.

    3. Razor: Código Dinámico en HTML

        Razor es un motor de plantillas que te permite insertar código C# dentro de HTML de manera sencilla. 
        La View usa Razor para hacer las páginas dinámicas, es decir, para mostrar datos que provienen de la 
        base de datos, realizar cálculos o interactuar con el usuario.

        3.1 Sintaxis Razor Básica  
        
            @Model: Se refiere al objeto que el Controller ha pasado a la View.
            
            @foreach: Bucle para recorrer listas.
            
            @if: Estructura de control para condicionales.
            
            @Html: Métodos de ayuda que facilitan la creación de controles HTML.

    4. Pasar Datos a la View

        Existen varias formas de pasar datos desde el Controller a la View:

        4.1 View con Modelo
            
            El Controller pasa un modelo completo (por ejemplo, una lista de productos) a la View. La View 
            utiliza ese modelo para generar el contenido dinámico.

                public IActionResult Lista()
                {
                    var productos = ObtenerTodosLosProductos(); // Lista de productos desde el Model
                    return View(productos); // Pasa los productos a la View
                }

                --------------------------------------------------------------------------------------

                @model IEnumerable<Producto>
                
                <h1>Lista de Productos</h1>
                
                @foreach (var producto in Model)
                {
                    <p>Nombre: @producto.Nombre, Precio: @producto.Precio</p>
                }

        4.2 ViewBag o ViewData
            
            Además de usar el modelo, puedes pasar datos adicionales utilizando ViewBag o ViewData. 
            Esto es útil si solo necesitas pasar pequeños fragmentos de información y no quieres modificar 
            el modelo principal.

                public IActionResult Lista()
                {
                    ViewBag.Mensaje = "Bienvenido a la lista de productos";
                    var productos = ObtenerTodosLosProductos();
                    return View(productos);
                }

                -----------------------------------------------------------------------------------------

                <h1>@ViewBag.Mensaje</h1>

                @model IEnumerable<Producto>
                @foreach (var producto in Model)
                {
                    <p>Nombre: @producto.Nombre, Precio: @producto.Precio</p>
                }

    5. HTML Helpers
    
        Los HTML Helpers son métodos que simplifican la creación de elementos HTML en Razor. Proporcionan 
        una forma más fácil de generar controles de formulario, enlaces y otros elementos comunes, ayudando 
        a mantener el código limpio y fácil de leer.

        5.1 Ejemplo de HTML Helpers

            Supongamos que queremos crear un formulario para agregar un nuevo producto. En lugar de escribir 
            el HTML manualmente, podemos usar HTML Helpers:
 
            @model Producto <!-- Indica que esta View recibirá un objeto de tipo Producto -->
            
            <!DOCTYPE html>
            <html>
            <head>
                <title>Agregar Producto</title>
            </head>
            <body>
                <h1>Agregar Nuevo Producto</h1>
                @using (Html.BeginForm()) <!-- Inicia un formulario -->
                {
                    <div>
                        @Html.LabelFor(m => m.Nombre) <!-- Crea una etiqueta para el campo Nombre -->
                        @Html.TextBoxFor(m => m.Nombre) <!-- Crea un cuadro de texto para el Nombre -->
                    </div>
                    <div>
                        @Html.LabelFor(m => m.Precio) <!-- Crea una etiqueta para el campo Precio -->
                        @Html.TextBoxFor(m => m.Precio) <!-- Crea un cuadro de texto para el Precio -->
                    </div>
                    <div>
                        @Html.LabelFor(m => m.Stock) <!-- Crea una etiqueta para el campo Stock -->
                        @Html.TextBoxFor(m => m.Stock) <!-- Crea un cuadro de texto para el Stock -->
                    </div>
                    <button type="submit">Agregar Producto</button> <!-- Botón para enviar el formulario -->
                }
            </body>
            </html>

    6. Cómo funcionan los HTML Helpers

        Html.BeginForm(): Crea un formulario HTML que enviará los datos al servidor. 
        Por defecto, se envía mediante una solicitud POST.

        Html.LabelFor(): Crea una etiqueta <label> asociada con una propiedad del modelo. 
        Esto mejora la accesibilidad y la usabilidad.

        Html.TextBoxFor(): Crea un campo de entrada <input> para una propiedad del modelo. 
        Se asocia automáticamente con el nombre de la propiedad, lo que simplifica el enlace de datos.

    7. Ventajas de usar Razor y HTML Helpers

        Menos código HTML manual: Los HTML Helpers generan automáticamente el HTML correcto y aseguran 
        que esté bien formateado.
    
        Vinculación automática: Cuando el formulario se envía, ASP.NET MVC puede vincular automáticamente 
        los datos del formulario a las propiedades del modelo.
    
        Facilidad de mantenimiento: El código Razor es más fácil de leer y mantener, lo que facilita 
        las actualizaciones y cambios.

*/