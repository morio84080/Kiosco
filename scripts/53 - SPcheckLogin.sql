/****** Object:  StoredProcedure [dbo].[SPcheckLogin]    Script Date: 06/03/2021 08:11:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[SPcheckLogin] (
	@ret int output
)
AS
set @ret = ISNULL((select count(*) from LOGINCMS where expirationTime<GETDATE()),0)




GO


