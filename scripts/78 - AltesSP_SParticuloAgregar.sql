/****** Object:  StoredProcedure [dbo].[SParticuloAgregar]    Script Date: 16/11/2022 15:44:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[SParticuloAgregar] (
	@RubrArti	numeric(3,0),
	@MarcaArti	int,
	@CobaArti	varchar(20),
	@DescArti	varchar(64),
	@BaseArti	real,
	@SugeArti	real,
	@StockArti	int	,
	@PorcGananciaArti real,
	@PorcIVAArti	decimal(18,2),
	@StockMinArti	int	,
	@Ret		int output
)
AS
insert into ARTICULO (RUBRARTI,MARCAARTI,COBAARTI,DESCARTI,BASEARTI,SUGEARTI,STOCKARTI,PORCGANANCIAARTI,PORCIVAARTI,STOCKMINARTI) 
values (@RubrArti,@MarcaArti,@CobaArti,@DescArti,@BaseArti,@SugeArti,@StockArti,@PorcGananciaArti,21,@StockMinArti)

set @Ret= @@identity
