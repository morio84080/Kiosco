/****** Object:  StoredProcedure [dbo].[SParticuloPorRubros]    Script Date: 19/05/2020 17:24:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[SParticuloPorRubros] (
	@rubros	varchar(256)
)
AS
declare @sql  varchar(max)

set @sql =
'declare @bit bit =0
	select a.IDARTI,A.RUBRARTI,R.DESCRUBR,a.COBAARTI,a.DESCARTI,a.BASEARTI,a.SUGEARTI,A.STOCKARTI,a.ESTAARTI,a.PRINTARTI,a.PORCIVAARTI,a.PORCGANANCIAARTI,@bit
	from ARTICULO A
	INNER JOIN RUBRO R ON A.RUBRARTI=R.CODIRUBR
	where A.RUBRARTI in ('+@rubros+')  and ESTAARTI=0 order by R.DESCRUBR,a.DESCARTI'

execute(@sql)
