/****** Object:  StoredProcedure [dbo].[SParticuloModificar]    Script Date: 16/11/2022 15:47:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[SParticuloModificar] (
	@RubrArti	numeric(3,0),
	@MarcaArti	int,
	@CobaArti	varchar(20),
	@DescArti	varchar(64),
	@BaseArti	real,
	@SugeArti	real,
	@StockArti	int,
	@EstaArti	bit,
	@IdArti		int,
	@PrintArti	bit,
	@PorcGananciaArti real,
	@PorcIVAArti	decimal(18,2),
	@StockMinArti	int	
)
AS
UPDATE ARTICULO SET 
	RUBRARTI=@RubrArti,
	MARCAARTI=@MarcaArti,
	COBAARTI=@CobaArti,
	DESCARTI=@DescArti,
	BASEARTI=@BaseArti,
	SUGEARTI=@SugeArti,
	STOCKARTI=@StockArti,
	ESTAARTI=@EstaArti,
	PRINTARTI=@PrintArti,
	PORCGANANCIAARTI=@PorcGananciaArti,
	PORCIVAARTI=@PorcIVAArti,
	STOCKMINARTI=@StockMinArti
WHERE IDARTI=@IdArti
