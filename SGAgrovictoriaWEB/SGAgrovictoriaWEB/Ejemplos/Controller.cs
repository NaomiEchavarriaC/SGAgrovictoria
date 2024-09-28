/*
        
    El Controller en el patrón MVC(Model-View-Controller) es el componente que actúa como intermediario 
    entre el usuario, el modelo de datos y las vistas(la interfaz de usuario). 
    Para explicarlo de manera sencilla y detallada:
    
    1. Responsabilidad del Controller
    
        El Controller tiene la función de manejar todas las solicitudes del usuario, que pueden ser acciones como 
        hacer clic en un botón o ingresar una URL en el navegador. Cada vez que el usuario interactúa con 
        la aplicación web, esas interacciones llegan al Controller, que decide qué hacer con ellas.
    
    2. Procesamiento de Solicitudes
    
        Cuando un usuario envía una solicitud a la aplicación (por ejemplo, para ver una lista de productos), 
        esa solicitud es enviada a un Controller específico. Este controller "escucha" la solicitud y ejecuta 
        el código adecuado. En un proyecto de .NET, cada controller es una clase que contiene métodos 
        llamados "acciones" (actions). Cada acción maneja una solicitud específica.
        
        Ejemplo de un Controller en .NET:
        
            public class ProductosController : Controller
            {
                public IActionResult Lista()
                {
                    // Aquí podrías obtener la lista de productos del Model (base de datos)
                    var productos = ObtenerTodosLosProductos();
        
                    // Luego pasas esos productos a la vista
                    return View(productos);
                }
            }
        
            En este ejemplo:
        
                El Controller es ProductosController.
        
                La acción es Lista(), que devuelve una lista de productos.
        
                Usa View(productos) para enviar los datos a la vista, donde serán mostrados al usuario.
        
    3. Flujo de Trabajo del Controller
    
        Recibir Solicitud: El Controller recibe una solicitud del navegador. En el ejemplo anterior, 
        la URL /Productos/Lista activaría el método Lista() en el ProductosController.
    
        Lógica del Negocio: El Controller puede pedir al Model que obtenga datos de la base de datos 
        o realice alguna lógica del negocio.
    
        Devolver Respuesta: Una vez que el Controller obtiene los datos, decide qué vista mostrar al usuario, 
        pasándole los datos correspondientes. La vista genera el HTML que se mostrará en el navegador.
    
    4. Acciones y Métodos HTTP
    
        Cada acción del Controller está asociada a un método HTTP. Por ejemplo:
    
            GET: Para obtener datos. Ejemplo: Ver la lista de productos.
            
            POST: Para enviar datos al servidor. Ejemplo: Enviar un formulario para crear un nuevo producto.
    
    Ejemplo de un Controller con varias acciones:
    
        public class ProductosController : Controller
        {
            // Muestra la lista de productos (GET)
            [HttpGet]
            public IActionResult Lista()
            {
                var productos = ObtenerTodosLosProductos();
                return View(productos);
            }
        
            // Muestra el formulario para agregar un producto (GET)
            [HttpGet]
            public IActionResult Agregar()
            {
                return View();
            }
        
            // Procesa el formulario enviado para agregar un producto (POST)
            [HttpPost]
            public IActionResult Agregar(Producto nuevoProducto)
            {
                GuardarProducto(nuevoProducto);
                return RedirectToAction("Lista");
            }
        }
    
        Aquí se manejan dos acciones:
    
            Lista(): Maneja una solicitud GET para ver todos los productos.
    
            Agregar(): Maneja una solicitud POST para guardar un nuevo producto en la base de datos.
    
    5. Conclusión
    
        El Controller es el "cerebro" que conecta el frontend (vista) con el backend (modelo de datos). 
        Recibe solicitudes del usuario, interactúa con el modelo para obtener o modificar datos, 
        y luego decide qué mostrar en la vista.
        
        Debes pensar en el Controller como el "control remoto" que decide qué hacer cada vez que el usuario 
        hace algo en la aplicación.

*/