CREATE PROCEDURE SPinteresPorRubroTipoPago (
	@RubroId	numeric(3,0),
	@TipoPagoId	smallint,
	@PorcInteres decimal(18,2) output
)
AS
set @PorcInteres = ISNULL((select PorcInteres from INTERES where RubroId=@RubroId and TipoPagoId=@TipoPagoId),0)