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

*/