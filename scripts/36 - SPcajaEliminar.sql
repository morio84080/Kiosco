CREATE procedure [dbo].[SPcajaEliminar] (
	@idCaja			numeric(18,0)
)
AS
update Caja set 
ELIMINADOCAJA=1
where IDCAJA=@idCaja