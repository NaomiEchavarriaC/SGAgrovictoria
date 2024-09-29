/*

    El Model en el patrón MVC (Model-View-Controller) es la parte que se encarga de la lógica de negocio y 
    la gestión de datos. En términos simples, el Model es responsable de representar y manejar los datos 
    que utiliza tu aplicación.

    1. ¿Qué hace el Model?
    
        El Model representa los datos de tu aplicación y se comunica directamente con la base de datos o 
        cualquier otra fuente de datos. Su trabajo es obtener, procesar y almacenar la información que 
        se necesita en la aplicación. Por ejemplo, si estás construyendo una tienda en línea, el Model 
        puede encargarse de manejar datos como los productos, los usuarios o los pedidos.

    2. Relación con la Base de Datos
        
        El Model también gestiona la interacción con la base de datos. En .NET, esto se hace a menudo 
        usando Entity Framework (EF), un framework que te permite trabajar con la base de datos sin 
        necesidad de escribir directamente SQL.

    3. Lógica de Negocio
        
        El Model no solo almacena datos, también puede contener la lógica de negocio, que son las reglas 
        que definen cómo deben funcionar las operaciones de la aplicación. Por ejemplo, podrías tener un 
        método que calcule descuentos en productos o que valide si el stock es suficiente antes de 
        realizar una compra.

    4. Flujo del Model en MVC
        
        Recibe una solicitud del Controller para obtener, actualizar o eliminar datos.
        
        Consulta la base de datos o cualquier otra fuente de datos (como una API externa).
        
        Procesa la información aplicando reglas de negocio, como cálculos o validaciones.
        
        Devuelve los datos procesados al Controller para que este los envíe a la View (interfaz de usuario).

    5. Dapper en el Model

        Dapper es un micro ORM (Object-Relational Mapper) para .NET que facilita la interacción con 
        bases de datos. A diferencia de Entity Framework, Dapper es más ligero y rápido, pero no genera 
        automáticamente las tablas ni maneja por completo las relaciones entre ellas. Dapper es ideal si 
        quieres tener más control sobre las consultas SQL mientras mantienes una capa 
        de abstracción sobre los datos.

        ¿Qué hace el Model con Dapper?

            En el contexto de un patrón MVC, el Model es la parte encargada de representar y manejar 
            los datos de la aplicación. Con Dapper, la idea es escribir manualmente las consultas SQL 
            para interactuar con la base de datos, pero simplificando el proceso de mapear los resultados 
            de esas consultas a objetos C#.
    
    6. Ejemplo de un modelo llamando a la base de datos

        Respuesta respuesta = new Respuesta();

        using (var db = new SqlConnection(iConfiguration.GetSection("ConnectionStrings:DefaultConnection").Value))
        {
            var resultado = db.Query<Ubicacion>("SP_GET_UBICACIONES", new { }, commandType: System.Data.CommandType.StoredProcedure);
        
            if (resultado.Count() > 0)
            {
                respuesta.Codigo = 1;
                respuesta.Mensaje = "La información de las ubicaciones se ha encontrado exitosamente";
                respuesta.Contenido = resultado;
                return respuesta;
            }
            else
            {
                respuesta.Codigo = 0;
                respuesta.Mensaje = "Ha ocurrido un error al cargar las ubicaciones";
                respuesta.Contenido = false;
                return respuesta;
            }
        }

        6.1. Creación de una respuesta:
        
            Respuesta respuesta = new Respuesta();
            
            Aquí se crea una instancia de la clase Respuesta, que se utiliza para 
            estructurar la respuesta que se enviará de vuelta al cliente. Esta clase 
            podría tener propiedades como Codigo, Mensaje y Contenido.
        
        6.2. Conexión a la base de datos:
                
            using (var db = new SqlConnection(iConfiguration.GetSection("ConnectionStrings:DefaultConnection").Value))
            
            Se utiliza SqlConnection de Microsoft.Data.SqlClient para conectarse a 
            la base de datos.
            
            iConfiguration es un objeto que probablemente se usa para acceder a la 
            configuración de la aplicación, incluyendo cadenas de conexión.
            
            GetSection("ConnectionStrings:DefaultConnection").Value recupera la 
            cadena de conexión de la base de datos, que se define en un archivo de 
            configuración (como appsettings.json).
        
        6.3. Consulta a la base de datos:
        
            var resultado = db.Query<Ubicacion>("SP_GET_UBICACIONES", new { }, commandType: System.Data.CommandType.StoredProcedure);
            
            db.Query<Ubicacion> usa Dapper para ejecutar una consulta SQL. Aquí se 
            llama a un procedimiento almacenado llamado SP_GET_UBICACIONES.
            
            new { } se usa para pasar parámetros al procedimiento almacenado, pero en 
            este caso, no se pasan parámetros (se deja vacío).
            
            commandType: System.Data.CommandType.StoredProcedure indica que se está 
            llamando a un procedimiento almacenado.
        
        6.4. Verificación del resultado:
        
            if (resultado.Count() > 0)
            
            Aquí se verifica si hay resultados devueltos por la consulta. resultado 
            es una colección de objetos de tipo Ubicacion, y Count() cuenta cuántos 
            elementos hay.
        
        6.5. Construcción de la respuesta:
        
            Si se encontraron resultados:
            
                respuesta.Codigo = 1;
                respuesta.Mensaje = "La información de las ubicaciones se ha encontrado exitosamente";
                respuesta.Contenido = resultado;
                return respuesta;
                
                Codigo = 1 indica éxito.
                
                Mensaje proporciona información al usuario.
                
                Contenido se establece con el resultado de la consulta, que son 
                las ubicaciones encontradas.
            
            Si no se encontraron resultados:
            
                respuesta.Codigo = 0;
                respuesta.Mensaje = "Ha ocurrido un error al cargar las ubicaciones";
                respuesta.Contenido = false;
                return respuesta;
                
                Codigo = 0 indica un error.
                Mensaje explica el problema.
                Contenido se establece en false, lo que puede ser una manera de indicar 
                que no hay datos disponibles.
        
        6.6. Resumen
        
            Este código se conecta a una base de datos usando Dapper para ejecutar 
            un procedimiento almacenado que recupera ubicaciones. Dependiendo de si 
            se encontraron o no resultados, devuelve una respuesta estructurada que
            contiene un código, un mensaje y el contenido de los datos recuperados o
            un indicador de error.

 */