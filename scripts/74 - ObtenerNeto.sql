/****** Object:  UserDefinedFunction [dbo].[ObtenerItemsVta]    Script Date: 14/09/2022 15:34:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION ObtenerNeto
(
    @total decimal(18,2)
)
RETURNS DECIMAL(18,2)
AS BEGIN
	declare @dummy decimal(18,2) = 0
	set @dummy = @total - (@total * 0.7458)
	return round(@dummy,2)
END

