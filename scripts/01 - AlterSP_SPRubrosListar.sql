/****** Object:  StoredProcedure [dbo].[SPRubrosListar]    Script Date: 18/04/2020 12:39:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[SPRubrosListar]
AS
select * from RUBRO where ACTIVORUBR=1 order by DESCRUBR