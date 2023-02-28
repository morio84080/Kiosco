
/****** Object:  StoredProcedure [dbo].[SParticuloPorCoBarra]    Script Date: 16/11/2022 16:09:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SParticuloPorCoBarra] (
	@CodBarra	varchar(20)
)
AS
declare @bit bit =0
select a.IDARTI,A.RUBRARTI,R.DESCRUBR,A.MARCAARTI,M.NOMBREMARC,a.COBAARTI,a.DESCARTI,a.BASEARTI,a.SUGEARTI,A.STOCKARTI,a.ESTAARTI,a.PRINTARTI,a.PORCIVAARTI,a.PORCGANANCIAARTI, STOCKMINARTI,@bit
from ARTICULO A
INNER JOIN RUBRO R ON A.RUBRARTI=R.CODIRUBR
INNER JOIN MARCA M ON A.MARCAARTI=M.IDMARC
where A.COBAARTI=@CodBarra and ESTAARTI=0