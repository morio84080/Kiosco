/****** Object:  StoredProcedure [dbo].[SPCierreCajaUltimo]    Script Date: 27/02/2021 10:48:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[SPCierreCajaUltimo]
AS
select top 1 * from CIERRECAJA order by idcica desc

GO


