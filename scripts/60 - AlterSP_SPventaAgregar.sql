/****** Object:  StoredProcedure [dbo].[SPventaAgregar]    Script Date: 06/03/2021 10:14:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[SPventaAgregar] (
	@TotaVta		real,
	@TipoVta		bit,
	@TicketFiscal	decimal(18,0),
	@Cliente		int,
	@Retira			varchar(60),
	@Letra			varchar(3),
	@Condicion		smallint,
	@Cae			varchar(30),
	@fechaVto		smalldatetime,
	@Ret			decimal output
)
AS
INSERT INTO VENTA (TOTAVTA,TIPOVTA,TICKETFISCALVTA,LETRAVTA,TIPOPAGOVTA,CAEVTA,FECHVTOCAEVTA) 
VALUES (@TotaVta,@TipoVta,@TicketFiscal,@Letra,@Condicion,@Cae,@fechaVto)
set @Ret= @@identity

IF (@Cliente>0 AND @Condicion=2) BEGIN
	IF (@Retira<>'') BEGIN
		IF (@TicketFiscal=-1) BEGIN
			INSERT INTO VENTA_CLIENTE (IDVTAVECL,IDCLIEVECL,DETALLEVECL,IMPOVECL)
			VALUES (@Ret,@Cliente,'VENTA Nº ' + CAST(@Ret AS varchar(8)) + ' - Retira: ' + @Retira,@TotaVta)
		END ELSE BEGIN
			INSERT INTO VENTA_CLIENTE (IDVTAVECL,IDCLIEVECL,DETALLEVECL,IMPOVECL)
			VALUES (@Ret,@Cliente,'VENTA Nº ' + CAST(@Ret AS varchar(8)) + ' - TICKET: ' + CAST(@TicketFiscal AS nvarchar(18)) + ' - Retira: ' + @Retira,@TotaVta)
		END
	END ELSE BEGIN
		IF (@TicketFiscal=-1) BEGIN
			INSERT INTO VENTA_CLIENTE (IDVTAVECL,IDCLIEVECL,DETALLEVECL,IMPOVECL)
			VALUES (@Ret,@Cliente,'VENTA Nº ' + CAST(@Ret AS varchar(8)) ,@TotaVta)
		END ELSE BEGIN
			INSERT INTO VENTA_CLIENTE (IDVTAVECL,IDCLIEVECL,DETALLEVECL,IMPOVECL)
			VALUES (@Ret,@Cliente,'VENTA Nº ' + CAST(@Ret AS varchar(8)) + ' - TICKET: ' + CAST(@TicketFiscal AS nvarchar(18)),@TotaVta)
		END
	END
END



