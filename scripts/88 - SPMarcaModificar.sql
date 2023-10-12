
/****** Object:  StoredProcedure [dbo].[SPMarcaModificar]    Script Date: 06/04/2023 09:45:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[SPMarcaModificar] (
	@CodiMarc	numeric(4,0),
	@DescMarc	varchar(30),
	@ActivoMarc		bit
)
AS
UPDATE MARCA SET DESCMARC=@DescMarc,ACTIVOMARC=@ActivoMarc WHERE CODIMARC=@CodiMarc


GO


