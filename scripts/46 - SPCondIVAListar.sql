/****** Object:  StoredProcedure [dbo].[SPCondIVAListar]    Script Date: 05/03/2021 08:14:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[SPCondIVAListar]
AS
select * from CONDICIONIVA where eliminadociva=0
GO


