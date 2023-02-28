/****** Object:  StoredProcedure [dbo].[SParticuloPorDesc]    Script Date: 19/04/2020 19:46:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SParticuloPorDesc] (
	@DescArti	varchar(40)
)
AS
declare @bit bit =0
select a.IDARTI,A.RUBRARTI,R.DESCRUBR,a.COBAARTI,a.DESCARTI,a.BASEARTI,a.SUGEARTI,A.STOCKARTI,a.ESTAARTI,A.PORCIVAARTI,a.PORCGANANCIAARTI,@bit
from ARTICULO A
INNER JOIN RUBRO R ON A.RUBRARTI=R.CODIRUBR
where A.DESCARTI like '%'+@DescArti+'%' AND A.ESTAARTI=0