﻿CREATE TABLE [dbo].[TUBE]
(
	[TUBE_RECID] INT NOT NULL PRIMARY KEY, 
    [TUBE_CODE] NVARCHAR(128) NOT NULL, 
    [TUBE_NAME] NVARCHAR(128) NOT NULL, 
    [TUBE_VOLUME] INT NOT NULL,
)
