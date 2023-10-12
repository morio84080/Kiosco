
/****** Object:  StoredProcedure [dbo].[SPmarcasListar]    Script Date: 06/04/2023 09:09:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[SPmarcasListar]
AS
select * from MARCA where ACTIVOMARC=1 order by DESCMARC
GO


