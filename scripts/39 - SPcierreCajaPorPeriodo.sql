/****** Object:  StoredProcedure [dbo].[SPcierreCajaPorPeriodo]    Script Date: 27/02/2021 10:48:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[SPcierreCajaPorPeriodo] (
	@fechaIni	datetime,
	@fechaFin	datetime
)
AS
select * from CIERRECAJA where FECHACICA between @fechaIni and @fechaFin

GO


