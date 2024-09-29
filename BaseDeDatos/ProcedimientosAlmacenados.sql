
-------------------------------------------------------------------------
-- PROCEDIMIENTOS ALMACENADOS DE DISTRITOS
-------------------------------------------------------------------------

USE [SGAgroVictoriaDB]
GO

CREATE PROCEDURE SP_GET_UBICACION
AS
BEGIN
    SELECT 		
		D.NOMBRE_DISTRITO,
		D.ID_CANTON,
		C.NOMBRE_CANTON,
		C.ID_CANTON,
		P.NOMBRE_PROVINCIA,
		P.ID_PROVINCIA
    FROM 
        DISTRITOS D
    INNER JOIN 
        CANTONES C
			ON C.ID_CANTON = D.ID_CANTON
    INNER JOIN 
        PROVINCIAS P
			ON C.ID_PROVINCIA = P.ID_PROVINCIA
    ORDER BY 
        P.ID_PROVINCIA, 
        C.ID_CANTON, 
        D.ID_DISTRITO;
END;
GO

-------------------------------------------------------------------------
-- PROCEDIMIENTOS ALMACENADOS DE CREDENCIALES
-------------------------------------------------------------------------

-->



-------------------------------------------------------------------------
-- PROCEDIMIENTOS ALMACENADOS DE PROVEEDORES
-------------------------------------------------------------------------

-->