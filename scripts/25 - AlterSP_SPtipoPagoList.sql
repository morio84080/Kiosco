/****** Object:  StoredProcedure [dbo].[SPtipoPagoList]    Script Date: 25/02/2021 08:07:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SPtipoPagoList] (
	@tipo int
)
AS
if (@tipo=1)
	select * from TIPO_PAGO WHERE ELIMINADOTIPA=0
else
	select * from TIPO_PAGO WHERE IDTIPA<>2 and ELIMINADOTIPA=0