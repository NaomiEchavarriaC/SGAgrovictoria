/*

    Las interfaces son un concepto fundamental en la programación orientada a objetos, 
    y se utilizan frecuentemente en el patrón MVC (Model-View-Controller) para promover la 
    separación de responsabilidades y la flexibilidad en el diseño de software. Aquí te explico 
    detalladamente qué son las interfaces y cómo se utilizan en un contexto MVC.
    
    1. ¿Qué es una interfaz?
    
        Una interfaz es un contrato que define un conjunto de métodos, propiedades y eventos que 
        una clase debe implementar. En otras palabras, una interfaz especifica qué operaciones 
        están disponibles, pero no proporciona la implementación de esas operaciones. Las clases 
        que implementan una interfaz se comprometen a proporcionar una funcionalidad específica.
    
    2. ¿Por qué usar Interfaces?
    
        Las interfaces se utilizan por varias razones:
    
            Abstracción: Permiten definir qué funcionalidades debe tener una clase sin especificar 
            cómo se implementan esas funcionalidades.
            
            Flexibilidad: Puedes cambiar la implementación de una interfaz sin afectar 
            al código que la utiliza.
            
            Desacoplamiento: Facilitan la separación de las dependencias, lo que hace que tu código 
            sea más fácil de mantener y probar.
            
            Separación de responsabilidades: Las interfaces ayudan a dividir el código en diferentes 
            capas, manteniendo el modelo, la vista y el controlador organizados y enfocados 
            en sus respectivas tareas.
    
    3. Beneficios de usar interfaces en MVC
    
        Mantenibilidad: Al usar interfaces, es más fácil realizar cambios en el código sin 
        afectar a otros componentes de la aplicación. Por ejemplo, si decides cambiar de Dapper 
        a Entity Framework, solo necesitas cambiar la implementación del repositorio, 
        no el controlador.
        
        Pruebas: Las pruebas unitarias se simplifican porque puedes usar simulaciones (mocks) 
        de las interfaces para probar el controlador sin depender de la lógica 
        de la base de datos.
        
        Interoperabilidad: Las interfaces permiten que diferentes clases trabajen juntas de 
        manera eficiente, lo que facilita la expansión de la aplicación.

*/