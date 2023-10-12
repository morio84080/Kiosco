
/****** Object:  StoredProcedure [dbo].[SPMarcaAgregar]    Script Date: 06/04/2023 09:47:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[SPMarcaAgregar] (
	@DescMarc	varchar(30)
)
AS
insert into MARCA (DESCMARC) values (@DescMarc)


GO


