/****** Object:  StoredProcedure [dbo].[SPcajaById]    Script Date: 25/02/2021 10:17:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[SPcajaById] (
	@id	numeric(18,0)
)
AS
select * from CAJA where IDCAJA=@id
GO


