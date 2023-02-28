
/****** Object:  Table [dbo].[LOGINCMS]    Script Date: 06/03/2021 08:08:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[LOGINCMS](
	[id] [smallint] IDENTITY(1,1) NOT NULL,
	[generationTime] [datetime] NULL,
	[expirationTime] [datetime] NULL,
	[token] [varchar](max) NULL,
	[sign] [varchar](max) NULL,
 CONSTRAINT [PK_LOGINCMS] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


