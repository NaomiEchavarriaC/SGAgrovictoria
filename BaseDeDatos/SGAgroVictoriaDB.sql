
USE [master]
GO

CREATE DATABASE [SGAgroVictoriaDB];
GO

USE [SGAgroVictoriaDB]
GO

-------------------------------------------------------------------------
-- TABLA PROVINCIAS
-------------------------------------------------------------------------

CREATE TABLE PROVINCIAS (
    ID_PROVINCIA                        BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    NOMBRE_PROVINCIA                    VARCHAR(120) NOT NULL
);
GO


-------------------------------------------------------------------------
-- TABLA CANTONES
-------------------------------------------------------------------------

CREATE TABLE CANTONES (
    ID_CANTON                           BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    ID_PROVINCIA                        BIGINT NOT NULL,
    NOMBRE_CANTON                       VARCHAR(120) NOT NULL,
    CONSTRAINT FK_CANTONES_PROVINCIAS FOREIGN KEY (ID_PROVINCIA)
        REFERENCES PROVINCIAS(ID_PROVINCIA)
);
GO


-------------------------------------------------------------------------
-- TABLA DISTRITOS
-------------------------------------------------------------------------

CREATE TABLE DISTRITOS (
    ID_DISTRITO                         BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    ID_CANTON                           BIGINT NOT NULL,
    NOMBRE_DISTRITO                     VARCHAR(120) NOT NULL,
    CONSTRAINT FK_DISTRITOS_CANTONES FOREIGN KEY (ID_CANTON)
        REFERENCES CANTONES(ID_CANTON)
);
GO


-------------------------------------------------------------------------
-- TABLA CLIENTES
-------------------------------------------------------------------------

CREATE TABLE CLIENTES (
    ID_CLIENTE                          BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    ID_DISTRITO                         BIGINT NOT NULL,
    ESTADO                              BIT NOT NULL,
    NOMBRE_CLIENTE                      VARCHAR(120) NOT NULL,
    APELLIDO_CLIENTE                    VARCHAR(120) NOT NULL,
    GENERO                              VARCHAR(12) NOT NULL,
    EDAD                                INT NOT NULL,
    CORREO                              VARCHAR(180) NOT NULL,
    TELEFONO                            VARCHAR(16) NOT NULL,
    IDENTIFICACION                      INT NOT NULL,
    RUTA_IMAGEN                         VARCHAR(255) NULL,
    CONSTRAINT FK_CLIENTES_DISTRITOS FOREIGN KEY (ID_DISTRITO)
        REFERENCES DISTRITOS(ID_DISTRITO)
);
GO


-------------------------------------------------------------------------
-- TABLA DESCUENTOS
-------------------------------------------------------------------------

CREATE TABLE DESCUENTOS (
    ID_DESCUENTO                        BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    ESTADO                              BIT NOT NULL,
    NOMBRE_DESCUENTO                    VARCHAR(120) NOT NULL,
    DESCRIPCION_DESCUENTO               VARCHAR(120) NOT NULL,
    FECHA_INICIO                        DATETIME NOT NULL,
    FECHA_FIN                           DATETIME NULL
);
GO


-------------------------------------------------------------------------
-- TABLA ORDENES
-------------------------------------------------------------------------

CREATE TABLE ORDENES (
    ID_ORDEN                            BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    ID_DESCUENTO                        BIGINT NOT NULL,
    ID_CLIENTE                          BIGINT NOT NULL,
    ESTADO                              BIT NOT NULL,
    FECHA_ORDEN                         DATETIME NOT NULL,
    CONSTRAINT FK_ORDENES_CLIENTES FOREIGN KEY (ID_CLIENTE)
        REFERENCES CLIENTES(ID_CLIENTE),
    CONSTRAINT FK_ORDENES_DESCUENTOS FOREIGN KEY (ID_DESCUENTO)
        REFERENCES DESCUENTOS(ID_DESCUENTO)
);
GO


-------------------------------------------------------------------------
-- TABLA CATEGORIAS
-------------------------------------------------------------------------

CREATE TABLE CATEGORIAS (
    ID_CATEGORIA                        BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    ESTADO                              BIT NOT NULL,
    NOMBRE_CATEGORIA                    VARCHAR(42) NOT NULL,
    DESCRIPCION_CATEGORIA               VARCHAR(180) NOT NULL,
    RUTA_IMAGEN                         VARCHAR(255) NULL
);
GO


-------------------------------------------------------------------------
-- TABLA PRODUCTOS
-------------------------------------------------------------------------

CREATE TABLE PRODUCTOS (
    ID_PRODUCTO                         BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    ID_CATEGORIA                        BIGINT NOT NULL,
    ESTADO                              BIT NOT NULL,
    NOMBRE_PRODUCTO                     VARCHAR(120) NOT NULL,
    PRECIO_UNITARIO                     FLOAT NOT NULL,
    COLOR                               VARCHAR(24) NOT NULL,
    RUTA_IMAGEN                         VARCHAR(255) NULL,
    CONSTRAINT FK_PRODUCTOS_CATEGORIAS FOREIGN KEY (ID_CATEGORIA)
        REFERENCES CATEGORIAS(ID_CATEGORIA)
);
GO


-------------------------------------------------------------------------
-- TABLA DETALLES_ORDENES
-------------------------------------------------------------------------

CREATE TABLE DETALLES_ORDENES (
    ID_DETALLE_ORDEN                    BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    ID_PRODUCTO                         BIGINT NOT NULL,
    ID_ORDEN                            BIGINT NOT NULL,
    TOTAL                               FLOAT NOT NULL,
    SUB_TOTAL                           FLOAT NOT NULL,
    CANTIDAD                            INT NOT NULL,
    CONSTRAINT FK_DETALLES_ORDENES_ORDENES FOREIGN KEY (ID_ORDEN)
        REFERENCES ORDENES(ID_ORDEN),
    CONSTRAINT FK_DETALLES_ORDENES_PRODUCTOS FOREIGN KEY (ID_PRODUCTO)
        REFERENCES PRODUCTOS(ID_PRODUCTO)
);
GO


-------------------------------------------------------------------------
-- TABLA PROVEEDORES
-------------------------------------------------------------------------

CREATE TABLE PROVEEDORES (
    ID_PROVEEDOR                        BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    ID_DISTRITO                         BIGINT NOT NULL,
    NOMBRE_PROVEEDOR                    VARCHAR(42) NOT NULL,
    DESCRIPCION_PROVEEDOR               VARCHAR(180) NOT NULL,
    TELEFONO                            VARCHAR(45) NOT NULL,
    CORREO                              VARCHAR(180) NOT NULL,
    RUTA_IMAGEN                         VARCHAR(255) NULL,
    CONSTRAINT FK_PROVEEDORES_DISTRITOS FOREIGN KEY (ID_DISTRITO)
        REFERENCES DISTRITOS(ID_DISTRITO)
);
GO


-------------------------------------------------------------------------
-- TABLA INVENTARIOS
-------------------------------------------------------------------------

CREATE TABLE INVENTARIOS (
    ID_INVENTARIO                       BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    ID_PROVEEDOR                        BIGINT NOT NULL,
    ID_PRODUCTO                         BIGINT NOT NULL,
    STOCK                               INT NOT NULL,
    CANTIDAD_INGRESADA                  INT NOT NULL,
    FECHA_INGRESO                       DATETIME NOT NULL,
    CONSTRAINT FK_INVENTARIOS_PRODUCTOS FOREIGN KEY (ID_PRODUCTO)
        REFERENCES PRODUCTOS(ID_PRODUCTO),
    CONSTRAINT FK_INVENTARIOS_PROVEEDORES FOREIGN KEY (ID_PROVEEDOR)
        REFERENCES PROVEEDORES(ID_PROVEEDOR)
);
GO


-------------------------------------------------------------------------
-- TABLA TIPOS_CREDENCIALES
-------------------------------------------------------------------------

CREATE TABLE TIPOS_CREDENCIALES (
    ID_TIPO_CREDENCIAL                  BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    ESTADO                              BIT NOT NULL,
    NOMBRE_TIPO_CREDENCIAL              VARCHAR(42) NOT NULL,
    DESCRIPCION_TIPO_CREDENCIAL         VARCHAR(180) NOT NULL,
    RUTA_IMAGEN                         VARCHAR(255) NULL
);
GO


-------------------------------------------------------------------------
-- TABLA EMPLEADOS
-------------------------------------------------------------------------

CREATE TABLE EMPLEADOS (
    ID_EMPLEADO                         BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    ID_DISTRITO                         BIGINT NOT NULL,
    ESTADO                              BIT NOT NULL,
    NOMBRE_EMPLEADO                     VARCHAR(120) NOT NULL,
    APELLIDO_EMPLEADO                   VARCHAR(120) NOT NULL,
    EDAD                                INT NOT NULL,
    CORREO                              VARCHAR(180) NOT NULL,
    IDENTIFICACION                      INT NOT NULL,
    AUSENCIAS                           INT NOT NULL,
    RUTA_IMAGEN                         VARCHAR(255) NULL,
    CONSTRAINT FK_EMPLEADOS_DISTRITOS FOREIGN KEY (ID_DISTRITO)
        REFERENCES DISTRITOS(ID_DISTRITO)
);
GO


-------------------------------------------------------------------------
-- TABLA CREDENCIALES
-------------------------------------------------------------------------

CREATE TABLE CREDENCIALES (
    ID_CREDENCIAL                       BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    ID_EMPLEADO                         BIGINT NOT NULL,
    ID_TIPO_CREDENCIAL                  BIGINT NOT NULL,
    ESTADO                              BIT NOT NULL,
    USUARIO                             VARCHAR(42) NOT NULL,
    CLAVE                               VARCHAR(60) NOT NULL,
    CONSTRAINT FK_CREDENCIALES_TIPOS_CREDENCIALES FOREIGN KEY (ID_TIPO_CREDENCIAL)
        REFERENCES TIPOS_CREDENCIALES(ID_TIPO_CREDENCIAL),
    CONSTRAINT FK_CREDENCIALES_EMPLEADOS FOREIGN KEY (ID_EMPLEADO)
        REFERENCES EMPLEADOS(ID_EMPLEADO)
);
GO
