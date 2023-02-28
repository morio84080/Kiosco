/****** Object:  StoredProcedure [dbo].[SParticuloPorRubroAndDesc]    Script Date: 20/04/2020 07:36:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SParticuloPorRubroAndDesc] (
	@DescArti	varchar(40),
	@RubrArti	int
)
AS
declare @bit bit =0
IF (@RubrArti<>-1) BEGIN
	select a.IDARTI,A.RUBRARTI,R.DESCRUBR,a.COBAARTI,a.DESCARTI,a.BASEARTI,a.SUGEARTI,A.STOCKARTI,a.ESTAARTI,a.PRINTARTI,a.PORCIVAARTI,a.PORCGANANCIAARTI,@bit
	from ARTICULO A
	INNER JOIN RUBRO R ON A.RUBRARTI=R.CODIRUBR
	where A.DESCARTI like '%'+@DescArti+'%' AND A.ESTAARTI=0 and a.RUBRARTI=@RubrArti
END ELSE BEGIN
	select a.IDARTI,A.RUBRARTI,R.DESCRUBR,a.COBAARTI,a.DESCARTI,a.BASEARTI,a.SUGEARTI,A.STOCKARTI,a.ESTAARTI,a.PRINTARTI,a.PORCIVAARTI,a.PORCGANANCIAARTI,@bit
	from ARTICULO A
	INNER JOIN RUBRO R ON A.RUBRARTI=R.CODIRUBR
	where A.DESCARTI like '%'+@DescArti+'%' AND A.ESTAARTI=0
END