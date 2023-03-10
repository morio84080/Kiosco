alter PROCEDURE SPactualizarPrecioPorTipo (
	@idArti	int,
	@tipoUpd smallint,
	@valor	decimal(18,0)
)
AS
IF (@tipoUpd=0) --FIJA UN VALOR AL PRECIO DE COSTO
	UPDATE ARTICULO SET BASEARTI = @valor, SUGEARTI=round((@valor + (@valor*(PORCGANANCIAARTI/100))),0), FECHAUPDARTI=GETDATE() where IDARTI=@idArti
ELSE IF (@tipoUpd=1) -- FIJA UN VALOR AL PRECIO DE VENTA
	--UPDATE ARTICULO SET SUGEARTI=@valor, PORCGANANCIAARTI=round(((@valor/BASEARTI)-1)*100,2), FECHAUPDARTI=GETDATE() where IDARTI=@idArti
	UPDATE ARTICULO SET SUGEARTI=@valor,BASEARTI=ROUND((@valor/(1+(PORCGANANCIAARTI/100))),0), FECHAUPDARTI=GETDATE() where IDARTI=@idArti
ELSE IF (@tipoUpd=2) --AUMENTA UN % AL PRECIO DE COSTO
	UPDATE ARTICULO SET BASEARTI=ROUND(BASEARTI+ BASEARTI* (@valor/100),0), SUGEARTI=ROUND(SUGEARTI+ SUGEARTI* (@valor/100),0), FECHAUPDARTI=GETDATE() where IDARTI=@idArti
ELSE IF (@tipoUpd=3) --AUMENTA UN % AL PRECIO DE VENTA
	UPDATE ARTICULO SET SUGEARTI=ROUND(SUGEARTI+ SUGEARTI* (@valor/100),0), PORCGANANCIAARTI=round((((ROUND(SUGEARTI+ SUGEARTI* (@valor/100),0))/BASEARTI)-1)*100,2), FECHAUPDARTI=GETDATE() where IDARTI=@idArti

