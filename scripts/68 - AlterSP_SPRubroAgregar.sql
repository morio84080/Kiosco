/****** Object:  StoredProcedure [dbo].[SPRubroAgregar]    Script Date: 25/05/2021 19:54:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER procedure SPRubroAgregar (
	@DescRubr	varchar(60),
	@PorcGananciaRubr decimal(18,2),
	@PorcDtoRubr decimal(18,2)
)
AS
insert into RUBRO (DESCRUBR,PORCGANANCIARUBR,PORCDTORUBR) values (@DescRubr,@PorcGananciaRubr,@PorcDtoRubr)

