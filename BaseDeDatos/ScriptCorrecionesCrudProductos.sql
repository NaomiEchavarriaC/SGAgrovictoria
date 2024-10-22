alter table productos
add Stock int not null,
FechaIngreso datetime,
UltimoIngreso datetime not null;

INSERT INTO [dbo].[Categorias] (Estado, NombreCategoria, DescripcionCategoria, RutaImagen)
VALUES 
(1, 'Alimentos para Mascotas', 'Productos alimenticios para perros, gatos y otras mascotas, como comida seca y húmeda.', 'images/alimentos.jpg'),
(1, 'Juguetes para Mascotas', 'Juguetes interactivos y masticables diseñados para mantener a las mascotas activas y entretenidas.', 'images/juguetes.jpg'),
(1, 'Cuidado y Salud', 'Productos para la salud y el cuidado de las mascotas, como suplementos, medicamentos y tratamientos antipulgas.', 'images/cuidado-salud.jpg'),
(1, 'Accesorios para Mascotas', 'Accesorios varios para mascotas, incluyendo collares, correas, camas y transportadoras.', 'images/accesorios.jpg'),
(1, 'Higiene y Limpieza', 'Artículos para la higiene de las mascotas, como champús, cepillos, arena para gatos y productos de limpieza.', 'images/higiene-limpieza.jpg'),
(1, 'Ropa para Mascotas', 'Ropa y prendas para mascotas de diferentes tamaños y razas, incluyendo abrigos y disfraces.', 'images/ropa.jpg');

ALTER TABLE [dbo].[Productos]
DROP COLUMN [Color];

INSERT INTO [dbo].[Productos] (IdCategoria, Estado, NombreProducto, PrecioUnitario,  RutaImagen, Stock, FechaIngreso, UltimoIngreso)
VALUES 
-- Alimentos para Mascotas
(1, 1, 'Royal Canin Comida para Gatos Adultos', 15000,  'images/royal-canin-gato.jpg', 150, '2024-10-12 10:30:00', '2024-10-12 10:30:00'),
(1, 1, 'Purina Dog Chow para Perros Adultos', 12500,  'images/purina-dog-chow.jpg', 200, '2024-10-12 11:00:00', '2024-10-12 11:00:00'),

-- Juguetes para Mascotas
(2, 1, 'KONG Classic Juguete para Perros', 8000, 'images/kong-classic.jpg', 75, '2024-10-11 09:45:00', '2024-10-11 09:45:00'),
(2, 1, 'Pelota Interactiva para Gatos', 5000, 'images/pelota-gato.jpg', 100, '2024-10-13 10:00:00', '2024-10-13 10:00:00'),

-- Cuidado y Salud
(3, 1, 'Frontline Plus para el Control de Pulgas y Garrapatas', 23400,  'images/frontline-plus.jpg', 60, '2024-10-12 12:00:00', '2024-10-12 12:00:00'),
(3, 1, 'Advantage II Antipulgas para Gatos', 22000,  'images/advantage-ii.jpg', 50, '2024-10-13 09:00:00', '2024-10-13 09:00:00'),

-- Accesorios para Mascotas
(4, 1, 'Collar Reflectante para Perros', 6900, 'images/collar-reflectante.jpg', 80, '2024-10-13 08:30:00', '2024-10-13 08:30:00'),
(4, 1, 'Transportadora para Gatos y Perros Pequeños', 30000,  'images/transportadora.jpg', 40, '2024-10-13 10:15:00', '2024-10-13 10:15:00'),

-- Higiene y Limpieza
(5, 1, 'Champú para Perros con Aloe Vera', 6000,  'images/champu-aloe-vera.jpg', 90, '2024-10-13 11:00:00', '2024-10-13 11:00:00'),
(5, 1, 'Arena para Gatos sin Aroma', 5000,  'images/arena-gato.jpg', 120, '2024-10-13 09:45:00', '2024-10-13 09:45:00'),

-- Ropa para Mascotas
(6, 1, 'Abrigo Impermeable para Perros', 3000,  'images/abrigo-impermeable.jpg', 30, '2024-10-12 07:30:00', '2024-10-12 07:30:00'),
(6, 1, 'Disfraz de Halloween para Gatos', 10000,  'images/disfraz-halloween-gato.jpg', 45, '2024-10-13 11:30:00', '2024-10-13 11:30:00');


ALTER TABLE productos
ALTER COLUMN FechaIngreso datetime2;

ALTER TABLE productos
ALTER COLUMN UltimoIngreso datetime2;
