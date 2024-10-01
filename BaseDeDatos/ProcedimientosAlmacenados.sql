
USE [SGAgroVictoriaDB]
GO

-------------------------------------------------------------------------
-- PROCEDIMIENTOS ALMACENADOS DE UBICACIONES
-------------------------------------------------------------------------

CREATE PROCEDURE SP_Consultar_Ubicaciones
AS
BEGIN
    SELECT 	
        P.IdProvincia,
        P.NombreProvincia,				
        C.IdCanton,
        C.NombreCanton,
        D.IdDistrito,
        D.NombreDistrito			
    FROM 
        Provincias P
    LEFT JOIN 
        Cantones C
            ON P.IdProvincia = C.IdProvincia
    LEFT JOIN 
        Distritos D
            ON C.IdCanton = D.IdCanton
    ORDER BY 
        P.IdProvincia, 
        C.IdCanton, 
        D.IdDistrito;
END;
GO

-------------------------------------------------------------------------
-- PROCEDIMIENTOS ALMACENADOS DE EMPLEADOS
-------------------------------------------------------------------------

CREATE PROCEDURE SP_Consultar_Empleados	
AS
BEGIN	
    SELECT	
        E.IdEmpleado,
        E.Identificacion,
        E.NombreEmpleado,
        E.ApellidoEmpleado,
        E.Edad,
        E.Correo,
        D.IdDistrito,
        D.NombreDistrito
    FROM	
        Empleados E
    INNER JOIN
        Distritos D
            ON E.IdDistrito = D.IdDistrito;
END;
GO

CREATE PROCEDURE SP_Insertar_Empleados
    @IdDistrito                BIGINT,
    @Estado                    BIT,
    @NombreEmpleado            VARCHAR(120),
    @ApellidoEmpleado          VARCHAR(120),
    @Edad                      INT,
    @Correo                    VARCHAR(180),
    @Identificacion            INT
AS
BEGIN	
    IF NOT EXISTS(SELECT 1 FROM Empleados WHERE Identificacion = @Identificacion)
    BEGIN
        INSERT INTO Empleados
        (
            IdDistrito,
            Estado,
            NombreEmpleado,
            ApellidoEmpleado,
            Edad,
            Correo,
            Identificacion,
            Ausencias
        )
        VALUES 
        (
            @IdDistrito,
            @Estado,
            @NombreEmpleado,
            @ApellidoEmpleado,
            @Edad,
            @Correo,
            @Identificacion,
            0
        )
    END
END;
GO

-------------------------------------------------------------------------
-- PROCEDIMIENTOS ALMACENADOS DE TIPOS CREDENCIALES
-------------------------------------------------------------------------

CREATE PROCEDURE SP_Consultar_TiposCredenciales	
AS
BEGIN	
    SELECT	
        IdTipoCredencial,
        NombreTipoCredencial,
        DescripcionTipoCredencial,
        CASE WHEN Estado = 1 THEN 'Activo' ELSE 'Inactivo' END 'Estado' 
    FROM	
        TiposCredenciales;
END;
GO

CREATE PROCEDURE SP_Insertar_TiposCredenciales
    @Estado                    BIT,
    @NombreTipoCredencial      VARCHAR(42),
    @DescripcionTipoCredencial VARCHAR(180)
AS
BEGIN	
    IF NOT EXISTS(SELECT 1 FROM TiposCredenciales WHERE NombreTipoCredencial = @NombreTipoCredencial)
    BEGIN
        INSERT INTO TiposCredenciales
        (        
            Estado,                     
            NombreTipoCredencial,     
            DescripcionTipoCredencial			
        )
        VALUES
        (
            @Estado,                     
            @NombreTipoCredencial,     
            @DescripcionTipoCredencial
        )
    END
END;
GO

-------------------------------------------------------------------------
-- PROCEDIMIENTOS ALMACENADOS DE CREDENCIALES
-------------------------------------------------------------------------

CREATE PROCEDURE SP_Consultar_Credenciales
AS
BEGIN	
    SELECT	
        E.IdEmpleado,
        E.Identificacion,
        E.NombreEmpleado,
        E.ApellidoEmpleado,
        T.IdTipoCredencial,
        T.NombreTipoCredencial,
        C.IdCredencial,
        CASE WHEN C.Estado = 1 THEN 'Activo' ELSE 'Inactivo' END 'Estado' 
    FROM             	
        Credenciales C
    INNER JOIN
        TiposCredenciales T
            ON C.IdTipoCredencial = T.IdTipoCredencial
    INNER JOIN
        Empleados E
            ON C.IdEmpleado = E.IdEmpleado
    INNER JOIN
        Distritos D
            ON E.IdDistrito = D.IdDistrito;
END;
GO

CREATE PROCEDURE SP_Insertar_Credenciales
    @IdEmpleado              BIGINT,
    @IdTipoCredencial        BIGINT,
    @Estado                  BIT,
    @Usuario                 VARCHAR(42),
    @Clave                   VARCHAR(60)
AS
BEGIN	
    IF NOT EXISTS(SELECT 1 FROM Credenciales WHERE IdEmpleado = @IdEmpleado)
    BEGIN
        INSERT INTO Credenciales
        (        
            IdEmpleado,    
            IdTipoCredencial, 
            Estado,         
            Usuario,
            Clave  
        )
        VALUES 
        (
            @IdEmpleado,        
            @IdTipoCredencial, 
            @Estado,
            @Usuario,
            @Clave
        )
    END
END;
GO

CREATE PROCEDURE SP_Actualizar_EstadoCredencial
@IdCredencial					BIGINT
AS
BEGIN	
	UPDATE Credenciales
	SET Estado = CASE WHEN Estado = 1 
				 THEN 0 
				 ELSE 1 
	END
	WHERE IdCredencial = @IdCredencial
END;
GO

-------------------------------------------------------------------------
-- PROCEDIMIENTOS ALMACENADOS DE PROVEEDORES
-------------------------------------------------------------------------

CREATE PROCEDURE SP_Consultar_Proveedores
AS
BEGIN	
    SELECT	
        P.IdProveedor,
        P.NombreProveedor,
        P.Telefono,
        P.Correo,
		CASE WHEN P.Estado = 1 THEN 'Activo' ELSE 'Inactivo' END 'Estado',
        D.IdDistrito,
        D.NombreDistrito        
    FROM             	
        Proveedores P
    INNER JOIN
        Distritos D
            ON P.IdDistrito = D.IdDistrito;
END;
GO

CREATE PROCEDURE SP_Actualizar_EstadoProveedor
@IdProveedor					BIGINT
AS
BEGIN	
	UPDATE Proveedores
	SET Estado = CASE WHEN Estado = 1 
				 THEN 0 
				 ELSE 1 
	END
	WHERE IdProveedor = @IdProveedor
END;
GO