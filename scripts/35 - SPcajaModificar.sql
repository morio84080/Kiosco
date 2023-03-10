CREATE procedure [dbo].[SPcajaModificar] (
	@idCaja			numeric(18,0),
	@FechaCaja		datetime,
	@TipoCaja		bit,
	@OriDesCaja		int,
	@NroFactCaja	varchar(20),
	@SubtotaCaja	decimal(18,2),
	@PorcIvaCaja	decimal(18,2),
	@IvaCaja		decimal(18,2),
	@TotaCaja		decimal(18,2),
	@TipoCtaCaja	bit,
	@DetalleCaja	varchar(200)
)
AS
update Caja set 
FECHACaja=@FechaCaja,
NROFACTCaja=@NroFactCaja, 
TIPOCAJA=@TipoCaja, 
ORIDESCAJA=@OriDesCaja,
DETALLECAJA=@DetalleCaja,
SUBTOTALCAJA=@SubtotaCaja,
PORCIVACaja=@PorcIvaCaja,
IVACaja=@IvaCaja,
TOTALCaja=@TotaCaja,
TIPOCTACAJA=@TipoCtaCaja
where IDCAJA=@idCaja