/****** Object:  StoredProcedure [dbo].[SParticuloPorID]    Script Date: 16/11/2022 16:04:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SParticuloPorID] (
	@ID	int
)
AS
select a.IDARTI,A.RUBRARTI,R.DESCRUBR,A.MARCAARTI,M.NOMBREMARC,a.COBAARTI,a.DESCARTI,a.BASEARTI,a.SUGEARTI,A.STOCKARTI,a.ESTAARTI,a.PORCGANANCIAARTI,a.PORCIVAARTI, a.STOCKMINARTI
from ARTICULO A
INNER JOIN RUBRO R ON A.RUBRARTI=R.CODIRUBR
INNER JOIN MARCA M ON A.MARCAARTI=M.IDMARC
where A.IDARTI=@ID