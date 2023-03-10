/****** Object:  StoredProcedure [dbo].[SPcajaAgregar]    Script Date: 25/02/2021 10:12:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SPcajaAgregar] (
	@FechaCaja		datetime,
	@TipoCaja		bit,
	@OriDesCaja		int,
	@NroFactCaja	varchar(20),
	@SubtotaCaja	decimal(18,2),
	@PorcIvaCaja	decimal(18,2),
	@IvaCaja		decimal(18,2),
	@TotaCaja		decimal(18,2),
	@DetalleCaja	varchar(200),
	@TipoCtaCaja	bit,
	@Ret			int output
)
AS
insert into Caja(FECHACaja,NROFACTCaja, TIPOCAJA, ORIDESCAJA,DETALLECAJA,SUBTOTALCAJA,PORCIVACaja,IVACaja,TOTALCaja,TIPOCTACAJA) 
values (@FechaCaja,@NroFactCaja,@TipoCaja,@OriDesCaja,@DetalleCaja,@SubtotaCaja,@PorcIvaCaja,@IvaCaja,@TotaCaja,@TipoCtaCaja)

set @Ret= @@identity
