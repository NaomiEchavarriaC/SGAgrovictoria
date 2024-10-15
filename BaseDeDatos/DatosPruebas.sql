USE [SGAgroVictoriaDB]
GO

-------------------------------------------------------------------------
-- INSERTAR DATOS EN LA TABLA CLIENTES
-------------------------------------------------------------------------

INSERT INTO Clientes (IdDistrito, Estado, NombreCliente, ApellidoCliente, Genero, Edad, Correo, Telefono, Identificacion, RutaImagen)
VALUES 
(10101, 1, 'Juan', 'Pérez', 'Masculino', 30, 'juan.perez@email.com', '1234567890', 12345678, 'ruta/imagen/juan.jpg'),

(10102, 1, 'María', 'Gómez', 'Femenino', 28, 'maria.gomez@email.com', '0987654321', 23456789, 'ruta/imagen/maria.jpg'),

(10103, 0, 'Carlos', 'López', 'Masculino', 35, 'carlos.lopez@email.com', '1122334455', 34567890, 'ruta/imagen/carlos.jpg'),

(10104, 1, 'Ana', 'Martínez', 'Femenino', 22, 'ana.martinez@email.com', '2233445566', 45678901, NULL),

(10105, 1, 'Luis', 'Fernández', 'Masculino', 40, 'luis.fernandez@email.com', '3344556677', 56789012, 'ruta/imagen/luis.jpg'),

(10101, 1, 'Sofía', 'Castillo', 'Femenino', 31, 'sofia.castillo@email.com', '4455667788', 67890123, 'ruta/imagen/sofia.jpg'),

(10102, 0, 'José', 'Ramírez', 'Masculino', 27, 'jose.ramirez@email.com', '5566778899', 78901234, NULL),

(10103, 1, 'Claudia', 'Torres', 'Femenino', 33, 'claudia.torres@email.com', '6677889900', 89012345, 'ruta/imagen/claudia.jpg');

-------------------------------------------------------------------------
-- INSERTAR DATOS EN LA TABLA DESCUENTOS
-------------------------------------------------------------------------
INSERT INTO Descuentos (Estado, NombreDescuento, DescripcionDescuento, FechaInicio, FechaFin)
VALUES
(1, 'Descuento de Verano', '20% de descuento en todos los productos de verano', '2024-06-01 00:00:00', '2024-08-31 23:59:59'),
(1, 'Descuento por Primera Compra', '15% de descuento para nuevos clientes', '2024-01-01 00:00:00', NULL),
(1, 'Descuento de Fin de Año', '30% de descuento en productos seleccionados', '2024-12-01 00:00:00', '2024-12-31 23:59:59'),
(0, 'Descuento de Navidad', '10% de descuento en artículos de Navidad', '2023-12-01 00:00:00', '2023-12-25 23:59:59'),
(1, 'Descuento Estudiantil', '10% de descuento para estudiantes con identificación', '2024-01-01 00:00:00', NULL),
(1, 'Black Friday', '50% de descuento en toda la tienda', '2024-11-25 00:00:00', '2024-11-25 23:59:59'),
(0, 'Descuento de Primavera', '15% de descuento en productos de primavera', '2024-03-01 00:00:00', '2024-05-31 23:59:59');

-------------------------------------------------------------------------
-- INSERTAR DATOS EN LA TABLA ORDENES
-------------------------------------------------------------------------

INSERT INTO Ordenes (IdDescuento, IdCliente, Estado, FechaOrden)
VALUES
(1, 1, 1, '2024-07-15 14:30:00'),  -- Descuento de Verano
(2, 2, 1, '2024-01-05 10:15:00'),  -- Descuento por Primera Compra
(3, 1, 1, '2024-12-05 16:45:00'),  -- Descuento de Fin de Año
(4, 3, 0, '2023-12-20 09:00:00'),  -- Descuento de Navidad
(5, 2, 1, '2024-02-10 11:30:00'),  -- Descuento Estudiantil
(6, 1, 1, '2024-11-25 18:00:00'),  -- Black Friday
(7, 3, 0, '2024-04-15 12:00:00');  -- Descuento de Primavera

-------------------------------------------------------------------------
-- TABLA Categorias
-------------------------------------------------------------------------

INSERT INTO Categorias (Estado, NombreCategoria, DescripcionCategoria, RutaImagen) VALUES
(1, 'Electrónica', 'Dispositivos y gadgets electrónicos de última generación.', 'imagenes/electronica.jpg'),
(1, 'Ropa', 'Moda y vestimenta para todas las edades y estilos.', 'imagenes/ropa.jpg'),
(1, 'Hogar', 'Artículos y muebles para el hogar, decoraciones y más.', 'imagenes/hogar.jpg'),
(1, 'Juguetes', 'Juguetes y juegos para niños de todas las edades.', 'imagenes/juguetes.jpg'),
(1, 'Deportes', 'Equipos y accesorios para diversas actividades deportivas.', 'imagenes/deportes.jpg'),
(0, 'Ofertas', 'Categoría de productos en descuento y promociones especiales.', 'imagenes/ofertas.jpg');


-------------------------------------------------------------------------
-- TABLA Productos
-------------------------------------------------------------------------

INSERT INTO Productos (IdCategoria, Estado, NombreProducto, PrecioUnitario, Color, RutaImagen) VALUES
(1, 1, 'Smartphone XYZ', 299.99, 'Negro', 'imagenes/smartphone_xyz.jpg'),
(1, 2, 'Laptop ABC', 899.99, 'Plata', 'imagenes/laptop_abc.jpg'),
(2, 3, 'Camiseta Casual', 19.99, 'Azul', 'imagenes/camiseta_casual.jpg'),
(2, 4, 'Jeans Slim Fit', 49.99, 'Negro', 'imagenes/jeans_slim_fit.jpg'),
(3, 2, 'Sofá Modular', 499.99, 'Gris', 'imagenes/sofa_modular.jpg'),
(4, 3, 'Juguete de Construcción', 29.99, 'Multicolor', 'imagenes/juguete_construccion.jpg'),
(5, 2, 'Pelota de Fútbol', 24.99, 'Blanco y Negro', 'imagenes/pelota_futbol.jpg');

-------------------------------------------------------------------------
-- TABLA Detalles ordenes
-------------------------------------------------------------------------

INSERT INTO DetallesOrdenes (IdProducto, IdOrden, Total, SubTotal, Cantidad) VALUES
(1, 1, 299.99, 299.99, 1),
(2, 1, 899.99, 899.99, 1),
(3, 2, 19.99, 19.99, 2),
(4, 2, 49.99, 49.99, 1),
(5, 3, 499.99, 499.99, 1),
(6, 3, 24.99, 24.99, 3);

-------------------------------------------------------------------------
-- TABLA Proveedores
-------------------------------------------------------------------------

INSERT INTO Proveedores (IdDistrito, Estado, NombreProveedor, DescripcionProveedor, Telefono, Correo, RutaImagen) VALUES
(1, 1, 'Proveedor A', 'Suministros de oficina y papelería.', '555-1234', 'contacto@proveedora.com', 'imagenes/proveedor_a.jpg'),
(2, 1, 'Proveedor B', 'Materiales de construcción y ferretería.', '555-5678', 'info@proveedorb.com', 'imagenes/proveedor_b.jpg'),
(3, 1, 'Proveedor C', 'Electrodomésticos y artículos electrónicos.', '555-8765', 'ventas@proveedorc.com', 'imagenes/proveedor_c.jpg'),
(4, 1, 'Proveedor D', 'Ropa y accesorios de moda.', '555-4321', 'contacto@proveedord.com', 'imagenes/proveedor_d.jpg'),
(5, 1, 'Proveedor E', 'Productos de limpieza y desinfección.', '555-6789', 'info@proveedore.com', NULL);

-------------------------------------------------------------------------
-- TABLA Inventario
-------------------------------------------------------------------------

INSERT INTO Inventarios (IdProveedor, IdProducto, Stock, CantidadIngresada, FechaIngreso) VALUES
(10005, 1, 50, 50, '2024-01-15 10:30:00'),
(10004, 2, 30, 30, '2024-01-20 11:00:00'),
(10003, 3, 20, 20, '2024-02-05 09:15:00'),
(10005, 4, 100, 100, '2024-02-10 14:45:00'),
(10004, 5, 75, 75, '2024-03-01 08:30:00');

-------------------------------------------------------------------------
-- TABLA credenciales
-------------------------------------------------------------------------

INSERT INTO TiposCredenciales (Estado, NombreTipoCredencial, DescripcionTipoCredencial, RutaImagen) VALUES
(1, 'Administrador', 'Acceso total a todas las funciones del sistema.', 'imagenes/admin.jpg'),
(1, 'Usuario', 'Acceso limitado a funciones específicas.', 'imagenes/usuario.jpg'),
(1, 'Editor', 'Puede crear y editar contenido, pero no gestionar usuarios.', 'imagenes/editor.jpg'),
(0, 'Visitante', 'Acceso de solo lectura a ciertas secciones.', 'imagenes/visitante.jpg');

-------------------------------------------------------------------------
-- TABLA EMPLEADOS
-------------------------------------------------------------------------

INSERT INTO Empleados (IdDistrito, Estado, NombreEmpleado, ApellidoEmpleado, Edad, Correo, Identificacion, Ausencias, RutaImagen) VALUES
(10101, 1, 'Juan', 'Pérez', 30, 'juan.perez@example.com', 12345678, 2, 'imagenes/juan_perez.jpg'),
(10102, 1, 'Ana', 'Gómez', 28, 'ana.gomez@example.com', 87654321, 1, 'imagenes/ana_gomez.jpg'),
(10103, 1, 'Carlos', 'López', 35, 'carlos.lopez@example.com', 11223344, 0, NULL),
(10101, 1, 'Marta', 'Sánchez', 40, 'marta.sanchez@example.com', 44332211, 3, 'imagenes/marta_sanchez.jpg'),
(10102, 1, 'Luis', 'Martínez', 25, 'luis.martinez@example.com', 55667788, 1, NULL);

-------------------------------------------------------------------------
-- TABLA CREDENCIALES
-------------------------------------------------------------------------

INSERT INTO Credenciales (IdEmpleado, IdTipoCredencial, Estado, Usuario, Clave) VALUES
(1, 1, 1, 'juan.perez', 'juan'),
(2, 2, 1, 'ana.gomez', 'ana'),
(3, 1, 1, 'carlos.lopez', 'carlos'),
(4, 3, 1, 'marta.sanchez', 'marta'),
(5, 2, 1, 'luis.martinez', 'luis');

