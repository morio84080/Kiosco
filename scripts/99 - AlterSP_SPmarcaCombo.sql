
/****** Object:  StoredProcedure [dbo].[SPmarcaCombo]    Script Date: 06/04/2023 11:54:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[SPmarcaCombo] 
AS
select * from MARCA where ACTIVOMARC=1