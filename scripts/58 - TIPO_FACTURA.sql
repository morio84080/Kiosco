/****** Object:  Table [dbo].[TIPO_FACTURA]    Script Date: 06/03/2021 10:00:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TIPO_FACTURA](
	[IDTIFA] [smallint] NOT NULL,
	[NOMBRETIFA] [varchar](50) NULL,
	[ELIMINADOTIFA] [bit] NULL CONSTRAINT [DF_TIPO_FACTURA_ELIMINADOTIFA]  DEFAULT ((0)),
 CONSTRAINT [PK_TIPO_FACTURA] PRIMARY KEY CLUSTERED 
(
	[IDTIFA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

