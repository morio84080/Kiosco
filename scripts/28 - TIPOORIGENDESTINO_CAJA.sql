/****** Object:  Table [dbo].[TIPOORIGENDESTINO_CAJA]    Script Date: 25/02/2021 08:24:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TIPOORIGENDESTINO_CAJA](
	[IDTODC] [smallint] NOT NULL,
	[NOMBRETODC] [varchar](30) NULL,
 CONSTRAINT [PK_TIPOORIGENDESTINO_CAJA] PRIMARY KEY CLUSTERED 
(
	[IDTODC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


