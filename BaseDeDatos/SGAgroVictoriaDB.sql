USE [master]
GO

CREATE DATABASE [SGAgroVictoriaDB];
GO

USE [SGAgroVictoriaDB]
GO

-------------------------------------------------------------------------
-- TABLA Provincias
-------------------------------------------------------------------------

CREATE TABLE Provincias (
    IdProvincia                        BIGINT NOT NULL PRIMARY KEY,
    NombreProvincia                    VARCHAR(120) NOT NULL
);
GO

-------------------------------------------------------------------------
-- TABLA Cantones
-------------------------------------------------------------------------

CREATE TABLE Cantones (
    IdCanton                           BIGINT NOT NULL PRIMARY KEY,
    IdProvincia                        BIGINT NOT NULL,
    NombreCanton                       VARCHAR(120) NOT NULL,
    CONSTRAINT FkCantonesProvincias FOREIGN KEY (IdProvincia)
        REFERENCES Provincias(IdProvincia)
);
GO

-------------------------------------------------------------------------
-- TABLA Distritos
-------------------------------------------------------------------------

CREATE TABLE Distritos (
    IdDistrito                         BIGINT NOT NULL PRIMARY KEY,
    IdCanton                           BIGINT NOT NULL,
    NombreDistrito                     VARCHAR(120) NOT NULL,
    CONSTRAINT FkDistritosCantones FOREIGN KEY (IdCanton)
        REFERENCES Cantones(IdCanton)
);
GO

-------------------------------------------------------------------------
-- TABLA Clientes
-------------------------------------------------------------------------

CREATE TABLE Clientes (
    IdCliente                          BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    IdDistrito                         BIGINT NOT NULL,
    Estado                             BIT NOT NULL,
    NombreCliente                      VARCHAR(120) NOT NULL,
    ApellidoCliente                    VARCHAR(120) NOT NULL,
    Genero                             VARCHAR(12) NOT NULL,
    Edad                               INT NOT NULL,
    Correo                             VARCHAR(180) NOT NULL,
    Telefono                           VARCHAR(16) NOT NULL,
    Identificacion                     INT NOT NULL,
    RutaImagen                         VARCHAR(255) NULL,
    CONSTRAINT FkClientesDistritos FOREIGN KEY (IdDistrito)
        REFERENCES Distritos(IdDistrito)
);
GO

-------------------------------------------------------------------------
-- TABLA Descuentos
-------------------------------------------------------------------------

CREATE TABLE Descuentos (
    IdDescuento                        BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Estado                             BIT NOT NULL,
    NombreDescuento                    VARCHAR(120) NOT NULL,
    DescripcionDescuento               VARCHAR(120) NOT NULL,
    FechaInicio                        DATETIME NOT NULL,
    FechaFin                           DATETIME NULL
);
GO

-------------------------------------------------------------------------
-- TABLA Ordenes
-------------------------------------------------------------------------

CREATE TABLE Ordenes (
    IdOrden                            BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    IdDescuento                        BIGINT NOT NULL,
    IdCliente                          BIGINT NOT NULL,
    Estado                             BIT NOT NULL,
    FechaOrden                         DATETIME NOT NULL,
    CONSTRAINT FkOrdenesClientes FOREIGN KEY (IdCliente)
        REFERENCES Clientes(IdCliente),
    CONSTRAINT FkOrdenesDescuentos FOREIGN KEY (IdDescuento)
        REFERENCES Descuentos(IdDescuento)
);
GO

-------------------------------------------------------------------------
-- TABLA Categorias
-------------------------------------------------------------------------

CREATE TABLE Categorias (
    IdCategoria                        BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Estado                             BIT NOT NULL,
    NombreCategoria                    VARCHAR(42) NOT NULL,
    DescripcionCategoria               VARCHAR(180) NOT NULL,
    RutaImagen                         VARCHAR(255) NULL
);
GO

-------------------------------------------------------------------------
-- TABLA Productos
-------------------------------------------------------------------------

CREATE TABLE Productos (
    IdProducto                         BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    IdCategoria                        BIGINT NOT NULL,
    Estado                             BIT NOT NULL,
    NombreProducto                     VARCHAR(120) NOT NULL,
    PrecioUnitario                     FLOAT NOT NULL,
    Color                              VARCHAR(24) NOT NULL,
    RutaImagen                         VARCHAR(255) NULL,
    CONSTRAINT FkProductosCategorias FOREIGN KEY (IdCategoria)
        REFERENCES Categorias(IdCategoria)
);
GO

-------------------------------------------------------------------------
-- TABLA DetallesOrdenes
-------------------------------------------------------------------------

CREATE TABLE DetallesOrdenes (
    IdDetalleOrden                     BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    IdProducto                         BIGINT NOT NULL,
    IdOrden                            BIGINT NOT NULL,
    Total                              FLOAT NOT NULL,
    SubTotal                           FLOAT NOT NULL,
    Cantidad                           INT NOT NULL,
    CONSTRAINT FkDetallesOrdenesOrdenes FOREIGN KEY (IdOrden)
        REFERENCES Ordenes(IdOrden),
    CONSTRAINT FkDetallesOrdenesProductos FOREIGN KEY (IdProducto)
        REFERENCES Productos(IdProducto)
);
GO

-------------------------------------------------------------------------
-- TABLA Proveedores
-------------------------------------------------------------------------

CREATE TABLE Proveedores (
    IdProveedor                        BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    IdDistrito                         BIGINT NOT NULL,
	Estado                             BIT NOT NULL,
    NombreProveedor                    VARCHAR(42) NOT NULL,
    DescripcionProveedor               VARCHAR(180) NOT NULL,
    Telefono                           VARCHAR(45) NOT NULL,
    Correo                             VARCHAR(180) NOT NULL,
    RutaImagen                         VARCHAR(255) NULL,
    CONSTRAINT FkProveedoresDistritos FOREIGN KEY (IdDistrito)
        REFERENCES Distritos(IdDistrito)
);
GO

-------------------------------------------------------------------------
-- TABLA Inventarios
-------------------------------------------------------------------------

CREATE TABLE Inventarios (
    IdInventario                       BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    IdProveedor                        BIGINT NOT NULL,
    IdProducto                         BIGINT NOT NULL,
    Stock                              INT NOT NULL,
    CantidadIngresada                  INT NOT NULL,
    FechaIngreso                       DATETIME NOT NULL,
    CONSTRAINT FkInventariosProductos FOREIGN KEY (IdProducto)
        REFERENCES Productos(IdProducto),
    CONSTRAINT FkInventariosProveedores FOREIGN KEY (IdProveedor)
        REFERENCES Proveedores(IdProveedor)
);
GO

-------------------------------------------------------------------------
-- TABLA TiposCredenciales
-------------------------------------------------------------------------

CREATE TABLE TiposCredenciales (
    IdTipoCredencial                   BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Estado                             BIT NOT NULL,
    NombreTipoCredencial               VARCHAR(42) NOT NULL,
    DescripcionTipoCredencial          VARCHAR(180) NOT NULL,
    RutaImagen                         VARCHAR(255) NULL
);
GO

-------------------------------------------------------------------------
-- TABLA Empleados
-------------------------------------------------------------------------

CREATE TABLE Empleados (
    IdEmpleado                         BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    IdDistrito                         BIGINT NOT NULL,
    Estado                             BIT NOT NULL,
    NombreEmpleado                     VARCHAR(120) NOT NULL,
    ApellidoEmpleado                   VARCHAR(120) NOT NULL,
    Edad                               INT NOT NULL,
    Correo                             VARCHAR(180) NOT NULL,
    Identificacion                     INT NOT NULL,
    Ausencias                          INT NOT NULL,
    RutaImagen                         VARCHAR(255) NULL,
    CONSTRAINT FkEmpleadosDistritos FOREIGN KEY (IdDistrito)
        REFERENCES Distritos(IdDistrito)
);
GO

-------------------------------------------------------------------------
-- TABLA Credenciales
-------------------------------------------------------------------------

CREATE TABLE Credenciales (
    IdCredencial                       BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    IdEmpleado                         BIGINT NOT NULL,
    IdTipoCredencial                   BIGINT NOT NULL,
    Estado                             BIT NOT NULL,
    Usuario                            VARCHAR(42) NOT NULL,
    Clave                              VARCHAR(60) NOT NULL,
    CONSTRAINT FkCredencialesTiposCredenciales FOREIGN KEY (IdTipoCredencial)
        REFERENCES TiposCredenciales(IdTipoCredencial),
    CONSTRAINT FkCredencialesEmpleados FOREIGN KEY (IdEmpleado)
        REFERENCES Empleados(IdEmpleado)
);
GO