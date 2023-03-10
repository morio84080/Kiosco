
/****** Object:  StoredProcedure [dbo].[SPpagoClieAgregar]    Script Date: 25/02/2021 08:20:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[SPpagoClieAgregar] (
	@CliePACL	int,
	@DetaPACL	varchar(30),
	@ImpoPACL	real,
	@FechPACL	smalldatetime,
	@TipoPACL	smallint,
	@Ret		int output
)
AS
insert into PAGO_CLIENTE (FECHPACL,CLIEPACL,DETAPACL,IMPOPACL,TIPOPACL) 
values (@FechPACL,@CliePACL,@DetaPACL,@ImpoPACL,@TipoPACL)

set @Ret= @@identity
