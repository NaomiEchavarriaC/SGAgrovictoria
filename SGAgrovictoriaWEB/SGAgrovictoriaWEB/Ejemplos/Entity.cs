/*

    En .NET las Entities suelen ser clases que representan "entidades" o "objetos" reales del mundo. 
    Estas clases tienen propiedades (atributos) que describen las características de ese objeto.

    Ejemplo de un Entity que representa un "Producto":

        public class Producto
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public decimal Precio { get; set; }
            public int Stock { get; set; }
        }
        
        En este ejemplo:        
        
            El Producto es una clase que describe un producto en la tienda.
            
            Tiene propiedades como Id, Nombre, Precio, y Stock que contienen información sobre cada producto.

*/