﻿CREATE TABLE [dbo].[CLINIC]
(
	[CLINIC_ID] INT NOT NULL PRIMARY KEY, 
    [CLINIC_CODE] NVARCHAR(10) NULL, 
    [CLINIC_NAME] NVARCHAR(128) NULL, 
    [CLINIC_LOCATION] NVARCHAR(128) NULL
)
