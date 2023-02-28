/****** Object:  StoredProcedure [dbo].[SPorigenDestinoByTipoCaja]    Script Date: 25/02/2021 10:00:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SPorigenDestinoByTipoCaja] (
	@tipoCaja	bit
)
AS
if (@tipoCaja=0) 
	select IDODC,NOMBREODC from ORIGENDESTINO_CAJA where TIPOODC in (1,3) and ELIMINADOODC=0
else
	select IDODC,NOMBREODC from ORIGENDESTINO_CAJA where TIPOODC in (2,3) and ELIMINADOODC=0
	 
GO


