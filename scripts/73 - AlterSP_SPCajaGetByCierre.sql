/****** Object:  StoredProcedure [dbo].[SPCajaGetByCierre]    Script Date: 31/08/2022 08:54:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[SPCajaGetByCierre] (
	@idCierre int
)
AS

declare @iniDate datetime
declare @endDate datetime
declare @efectivo decimal(18,2)
declare @efectivoVta decimal(18,2)
declare @tarjetaDebito decimal(18,2)
declare @tarjetaCredito decimal(18,2)
declare @mercadoPago decimal(18,2)
declare @CtaCte	decimal(18,2)
declare @ingreso decimal (18,2)
declare @egreso decimal (18,2)
declare @ventas decimal (18,2)
declare @NotaCredito decimal (18,2)
declare @saldoAnterior decimal (18,2)


if (@idCierre=0) begin
	--set @iniDate = CONVERT(varchar, GETDATE(), 103) + ' 00:00:00' 
	set @iniDate = ISNULL((select top 1 FECHACICA from CIERRECAJA order by IDCICA desc), CONVERT(varchar, GETDATE(), 103) + ' 00:00:00' )
	set @endDate = CONVERT(varchar, GETDATE(), 103) + ' 23:59:59' 

	set @efectivo = isnull((SELECT sum(PA.IMPOPACL)
							FROM PAGO_CLIENTE PA
							WHERE (PA.FECHPACL BETWEEN @iniDate AND @endDate) AND ELIMINADOPACL=0 and TIPOPACL=1),0)
	set @efectivoVta = isnull((SELECT sum(PA.TOTAVTA)
								  FROM VENTA PA  
								  WHERE (PA.FECHVTA BETWEEN @iniDate AND @endDate) AND PA.TIPOPAGOVTA=1 AND ELIMINADOVTA=0 AND NOT EXISTS (SELECT * FROM NOTA_CREDITO NC WHERE NC.NUMEVTANOCR=PA.NUMEVTA)),0)

	set @tarjetaDebito = isnull((SELECT sum(PA.TOTAVTA)
								 FROM VENTA PA 
								 WHERE (PA.FECHVTA BETWEEN @iniDate AND @endDate) AND PA.TIPOPAGOVTA=4 AND ELIMINADOVTA=0),0)

	set @mercadoPago = isnull((SELECT sum(PA.TOTAVTA)
								 FROM VENTA PA 
								 WHERE (PA.FECHVTA BETWEEN @iniDate AND @endDate) AND PA.TIPOPAGOVTA=7 AND ELIMINADOVTA=0),0)

	set @tarjetaCredito = isnull((SELECT sum(PA.TOTAVTA)
								  FROM VENTA PA 
								  WHERE (PA.FECHVTA BETWEEN @iniDate AND @endDate) AND PA.TIPOPAGOVTA=3 AND ELIMINADOVTA=0),0)

	set @CtaCte = isnull((SELECT sum(PA.TOTAVTA)
						  FROM VENTA PA 
					      WHERE (PA.FECHVTA BETWEEN @iniDate AND @endDate) AND PA.TIPOPAGOVTA=2 AND ELIMINADOVTA=0),0)

	set @ingreso = isnull((select sum(TOTALCAJA)
							from CAJA C
							INNER JOIN ORIGENDESTINO_CAJA ODC ON C.ORIDESCAJA=ODC.IDODC
							WHERE (C.FECHACAJA BETWEEN @iniDate AND @endDate) and TIPOCAJA=0 and c.ELIMINADOCAJA=0),0)
	set @egreso = isnull((select sum(TOTALCAJA)
							from CAJA C
							INNER JOIN ORIGENDESTINO_CAJA ODC ON C.ORIDESCAJA=ODC.IDODC
							WHERE (C.FECHACAJA BETWEEN @iniDate AND @endDate) and TIPOCAJA=1 and c.ELIMINADOCAJA=0),0)

	set @ventas = isnull((SELECT sum(PA.TOTAVTA)
						  FROM VENTA PA
					      WHERE (PA.FECHVTA BETWEEN @iniDate AND @endDate)  AND ELIMINADOVTA=0),0)

	set @NotaCredito = isnull((SELECT sum(V.TOTAVTA)
							   FROM NOTA_CREDITO PA INNER JOIN VENTA V ON PA.NUMEVTANOCR=V.NUMEVTA
							   WHERE (PA.FECHANOCR BETWEEN @iniDate AND @endDate)  AND ELIMINADO=0 AND ELIMINADOVTA=0),0)

	select 0 IDCICA, GETDATE() FECHACICA,@efectivoVta EFECTIVOCICA , @tarjetaCredito TARJCREDITOCICA, @tarjetaDebito TARJDEBITOCICA, @mercadoPago MERCADOPAGOCICA , @CtaCte CTACTECICA, isnull((select top 1 SALDOCICA from CIERRECAJA order by IDCICA desc),0) SALDOCICA, @ventas TOTALVTACICA, @NotaCredito TOTALNOTACREDITOCICA, @ingreso + @efectivo INGRESOSCAJACICA, @egreso EGRESOSCAJACICA
end else begin

	select * from CIERRECAJA WHERE IDCICA=@idCierre
end




