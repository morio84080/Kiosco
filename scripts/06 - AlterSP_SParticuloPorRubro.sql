/****** Object:  StoredProcedure [dbo].[SParticuloPorRubro]    Script Date: 19/04/2020 19:51:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SParticuloPorRubro] (
	@RubrArti	numeric(3,0)
)
AS
declare @bit bit =0
IF @RubrArti<>-1 BEGIN
	select a.IDARTI,A.RUBRARTI,R.DESCRUBR,a.COBAARTI,a.DESCARTI,a.BASEARTI,a.SUGEARTI,A.STOCKARTI,a.ESTAARTI,a.PRINTARTI,a.PORCIVAARTI,a.PORCGANANCIAARTI,@bit
	from ARTICULO A
	INNER JOIN RUBRO R ON A.RUBRARTI=R.CODIRUBR
	where A.RUBRARTI=@RubrArti and ESTAARTI=0
END ELSE BEGIN
	select a.IDARTI,A.RUBRARTI,R.DESCRUBR,a.COBAARTI,a.DESCARTI,a.BASEARTI,a.SUGEARTI,A.STOCKARTI,a.ESTAARTI,a.PRINTARTI,a.PORCIVAARTI,a.PORCGANANCIAARTI,@bit
	from ARTICULO A
	INNER JOIN RUBRO R ON A.RUBRARTI=R.CODIRUBR	and ESTAARTI=0
END