﻿CREATE TABLE [dbo].[ORDER]
(
	[ORDER_ID] INT NOT NULL PRIMARY KEY, 
    [ORDER_ORDERNUMBER] INT NULL, 
    [ORDER_PATIENTID] INT NULL, 
    [ORDER_CLINICID] INT NULL, 
    [ORDER_TESTID] INT NULL, 
    [ORDER_SPECIMENID] INT NULL, 
    [ORDER_TUBEID] INT NULL, 
    CONSTRAINT [FK_ORDER_TUBEID] FOREIGN KEY ([ORDER_TUBEID]) REFERENCES [TUBE]([TUBE_ID]), 
    CONSTRAINT [FK_ORDER_SPECIMENID] FOREIGN KEY ([ORDER_SPECIMENID]) REFERENCES [SPECIMEN]([SPECIMEN_ID]),
	CONSTRAINT [FK_ORDER_TESTID] FOREIGN KEY ([ORDER_TESTID]) REFERENCES [TEST]([TEST_ID]),
	CONSTRAINT [FK_ORDER_PATIENTID] FOREIGN KEY ([ORDER_PATIENTID]) REFERENCES [PATIENT]([PATIENT_ID]),
	CONSTRAINT [FK_ORDER_CLINICID] FOREIGN KEY ([ORDER_CLINICID]) REFERENCES [CLINIC]([CLINIC_ID]),
)