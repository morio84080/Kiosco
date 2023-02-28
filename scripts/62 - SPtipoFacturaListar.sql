/****** Object:  StoredProcedure [dbo].[SPtipoFacturaListar]    Script Date: 09/03/2021 15:11:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SPtipoFacturaListar]
AS
select * from TIPO_FACTURA where ELIMINADOTIFA=0
GO


