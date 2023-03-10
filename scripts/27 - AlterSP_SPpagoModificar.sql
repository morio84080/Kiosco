/****** Object:  StoredProcedure [dbo].[SPpagoModificar]    Script Date: 25/02/2021 08:22:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[SPpagoModificar] (
	@NumePACL	INT,
	@CliePACL	int,
	@DetaPACL	varchar(30),
	@ImpoPACL	real,
	@FechPACL	smalldatetime,
	@TipoPACL	smallint,
	@EliminadoPACL	bit
)
AS
UPDATE PAGO_CLIENTE SET
 FECHPACL=@FechPACL,
 CLIEPACL=@CliePACL,
 DETAPACL=@DetaPACL,
 IMPOPACL=@ImpoPACL,
 ELIMINADOPACL=@EliminadoPACL,
 TIPOPACL=@TipoPACL
WHERE NUMEPACL=@NumePACL
