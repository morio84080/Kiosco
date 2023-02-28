/****** Object:  StoredProcedure [dbo].[SPrubroCombo]    Script Date: 18/04/2020 16:35:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SPrubroCombo]
AS
select -1 CODIRUBR, 'Seleccione un Rubro' DESCRUBR
UNION
select CODIRUBR, DESCRUBR
from RUBRO 
where ACTIVORUBR=1
order by DESCRUBR


