USE [SomaDev1]
GO

/****** Object:  Table [dbo].[AppChannel]    Script Date: 18.01.2023 23:43:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AppChannel](
                                   [ID] [bigint] IDENTITY(1,1) NOT NULL,
                                   [NAME] [varchar](100) NOT NULL,
                                   CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED
                                       (
                                        [ID] ASC
                                           )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[AppRegistry](
                                    [ID] [bigint] IDENTITY(1,1) NOT NULL,
                                    [NAME] [varchar](500) NOT NULL,
                                    [VERSION] [varchar](100) NOT NULL,
                                    [FILE] [varbinary](max) NOT NULL,
                                    [CHANNEL_ID] [bigint] NULL,
                                    [FILE_NAME] [varchar](1000) NULL,
                                    CONSTRAINT [PK_dbo.AppRegistry] PRIMARY KEY CLUSTERED
                                        (
                                         [ID] ASC
                                            )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


