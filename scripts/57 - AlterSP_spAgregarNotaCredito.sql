/****** Object:  StoredProcedure [dbo].[spAgregarNotaCredito]    Script Date: 06/03/2021 09:22:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[spAgregarNotaCredito] (
	@NUMEVTA		DECIMAL(18,0),
	@NUMENC			DECIMAL(18,0),
	@CAE			VARCHAR(30),
	@FECHAVTOCAE	SMALLDATETIME
)
AS
INSERT INTO NOTA_CREDITO (NUMEVTANOCR,TICKETFISCALNOCR,CAENOCR,FECHAVTOCAENOCR) VALUES (@NUMEVTA,@NUMENC,@CAE,@FECHAVTOCAE)
UPDATE VENTA SET ELIMINADOVTA=1 WHERE NUMEVTA=@NUMEVTA

DECLARE @ARTIVEAR INT, @CANTVEAR INT

DECLARE ventaArt_cursor CURSOR FOR 
SELECT ARTIVEAR,CANTVEAR
FROM VENTA_ARTICULO
WHERE NUMEVEAR=@NUMEVTA

OPEN ventaArt_cursor

FETCH NEXT FROM ventaArt_cursor 
INTO @ARTIVEAR, @CANTVEAR

WHILE @@FETCH_STATUS = 0
BEGIN
	UPDATE ARTICULO SET 
	STOCKARTI = STOCKARTI + @CANTVEAR 
	WHERE ARTICULO.IDARTI=@ARTIVEAR
	
	INSERT INTO STOCK (TIPOINGRESOSTK,TIPOMOVSTK,ARTICULOSTK,CANTIDADSTK,FECHASTK,DETALLESTK) VALUES (0,3,@ARTIVEAR,@CANTVEAR,GETDATE(),'Venta Eliminada')
	
    FETCH NEXT FROM ventaArt_cursor 
    INTO @ARTIVEAR, @CANTVEAR
END 
CLOSE ventaArt_cursor;
DEALLOCATE ventaArt_cursor;



