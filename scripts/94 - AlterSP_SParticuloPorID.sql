
/****** Object:  StoredProcedure [dbo].[SParticuloPorID]    Script Date: 06/04/2023 10:02:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SParticuloPorID] (
	@ID	int
)
AS
select a.IDARTI,A.RUBRARTI,R.DESCRUBR,A.MARCAARTI,M.DESCMARC,a.COBAARTI,a.DESCARTI,a.BASEARTI,a.SUGEARTI,A.STOCKARTI,a.ESTAARTI,a.PORCGANANCIAARTI,a.PORCIVAARTI, a.STOCKMINARTI
from ARTICULO A
INNER JOIN RUBRO R ON A.RUBRARTI=R.CODIRUBR
INNER JOIN MARCA M ON A.MARCAARTI=M.CODIMARC
where A.IDARTI=@ID