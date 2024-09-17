
USE [CasoEstudioJN]
GO

/****** Object:  Table [dbo].[CasasSistema]    Script Date: 17/9/2024 15:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CasasSistema](
	[IdCasa] [bigint] IDENTITY(1,1) NOT NULL,
	[DescripcionCasa] [varchar](30) NOT NULL,
	[PrecioCasa] [decimal](10, 2) NOT NULL,
	[UsuarioAlquiler] [varchar](30) NULL,
	[FechaAlquiler] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCasa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[AlquilarCasa]    Script Date: 17/9/2024 15:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedimiento almacenado para alquilar una casa
CREATE PROCEDURE [dbo].[AlquilarCasa]
@IdCasa				BIGINT,
@UsuarioAlquiler	VARCHAR(30)
AS
BEGIN
	UPDATE CasasSistema
	SET	   UsuarioAlquiler = @UsuarioAlquiler,
		   FechaAlquiler = GETDATE()
	WHERE IdCasa = @IdCasa
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarCasa]    Script Date: 17/9/2024 15:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedimiento almacenado para consultar los atributos de una casa
CREATE PROCEDURE [dbo].[ConsultarCasa]
@IdCasa				BIGINT
AS
BEGIN	
	SELECT	IdCasa, 
		DescripcionCasa, 
		PrecioCasa
	FROM CasasSistema
	WHERE IdCasa = @IdCasa
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarCasas]    Script Date: 17/9/2024 15:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedimiento almacenado para consultar casas
CREATE PROCEDURE [dbo].[ConsultarCasas]
AS
BEGIN
	SELECT IdCasa, DescripcionCasa, PrecioCasa, UsuarioAlquiler, Estado, FechaAlquiler
	FROM (
		SELECT	IdCasa, 
			DescripcionCasa, 
			PrecioCasa,
			ISNULL(UsuarioAlquiler, 'Sin cliente') 'UsuarioAlquiler',
			CASE 
				WHEN UsuarioAlquiler IS NOT NULL
				THEN 'Reservada'
				ELSE 'Disponible'
			END AS 'Estado',
			CAST(ISNULL(FORMAT(FechaAlquiler, 'dd/MM/yyyy'), 'Sin fecha') AS VARCHAR) AS 'FechaAlquiler'
	FROM CasasSistema
	WHERE PrecioCasa <= 180000.00
	AND	  PrecioCasa >= 115000.00
	)X
	ORDER BY Estado ASC	
END
GO
/****** Object:  StoredProcedure [dbo].[ListaCasas]    Script Date: 17/9/2024 15:49:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedimiento almacenado para mostrar la lista de casas
CREATE PROCEDURE [dbo].[ListaCasas]
AS
BEGIN
		SELECT	IdCasa, 
				DescripcionCasa
		FROM CasasSistema
		WHERE UsuarioAlquiler IS NULL
END
GO
