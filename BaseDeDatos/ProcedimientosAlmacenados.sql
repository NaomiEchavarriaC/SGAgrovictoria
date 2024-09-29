
-------------------------------------------------------------------------
-- PROCEDIMIENTOS ALMACENADOS DE UBICACIONES
-------------------------------------------------------------------------

USE [SGAgroVictoriaDB]
GO

CREATE PROCEDURE SP_GET_UBICACIONES
AS
BEGIN
    SELECT 	
		P.ID_PROVINCIA,
		P.NOMBRE_PROVINCIA,				
		C.ID_CANTON,
		C.NOMBRE_CANTON,
		D.ID_DISTRITO,
		D.NOMBRE_DISTRITO			
    FROM 
        PROVINCIAS P
    LEFT JOIN 
        CANTONES C
			ON P.ID_PROVINCIA = C.ID_PROVINCIA
    LEFT JOIN 
        DISTRITOS D
			ON C.ID_CANTON = D.ID_CANTON
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