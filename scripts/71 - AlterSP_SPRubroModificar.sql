/****** Object:  StoredProcedure [dbo].[SPRubroModificar]    Script Date: 01/06/2021 12:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[SPRubroModificar] (
	@CodiRubr	numeric(3,0),
	@DescRubr	varchar(30),
	@PorcGananciaRubr decimal(18,2),
	@ActivoRubr		bit,
	@PorcDtoRubr decimal(18,2),
	@ActualizaPrecio bit
)
AS
DECLARE @oldPorcGanancia DECIMAL(18,2)=(SELECT PORCGANANCIARUBR FROM RUBRO WHERE CODIRUBR=@CodiRubr)
UPDATE RUBRO SET DESCRUBR=@DescRubr,ACTIVORUBR=@ActivoRubr,PORCGANANCIARUBR=@PorcGananciaRubr,PORCDTORUBR=@PorcDtoRubr WHERE CODIRUBR=@CodiRubr

if (@ActualizaPrecio=1) begin
	UPDATE ARTICULO SET
	PORCGANANCIAARTI=@PorcGananciaRubr,
	SUGEARTI=ROUND((BASEARTI+ (BASEARTI * (PORCIVAARTI/100))) + ( (BASEARTI+ (BASEARTI * (PORCIVAARTI/100))) *(@PorcGananciaRubr/100) ),0),
	FECHAUPDARTI=GETDATE(),
	PRINTARTI=1
	WHERE RUBRARTI=@CodiRubr
end