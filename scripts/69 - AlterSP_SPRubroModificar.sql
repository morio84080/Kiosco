/****** Object:  StoredProcedure [dbo].[SPRubroModificar]    Script Date: 25/05/2021 19:59:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[SPRubroModificar] (
	@CodiRubr	numeric(3,0),
	@DescRubr	varchar(30),
	@PorcGananciaRubr decimal(18,2),
	@ActivoRubr		bit,
	@PorcDtoRubr decimal(18,2)
)
AS
DECLARE @oldPorcGanancia DECIMAL(18,2)=(SELECT PORCGANANCIARUBR FROM RUBRO WHERE CODIRUBR=@CodiRubr)
UPDATE RUBRO SET DESCRUBR=@DescRubr,ACTIVORUBR=@ActivoRubr,PORCGANANCIARUBR=@PorcGananciaRubr,PORCDTORUBR=@PorcDtoRubr WHERE CODIRUBR=@CodiRubr

UPDATE ARTICULO SET
PORCGANANCIAARTI=@PorcGananciaRubr,
SUGEARTI=ROUND((BASEARTI+ (BASEARTI * (PORCIVAARTI/100))) + ( (BASEARTI+ (BASEARTI * (PORCIVAARTI/100))) *(@PorcGananciaRubr/100) ),0),
FECHAUPDARTI=GETDATE(),
PRINTARTI=1
WHERE RUBRARTI=@CodiRubr