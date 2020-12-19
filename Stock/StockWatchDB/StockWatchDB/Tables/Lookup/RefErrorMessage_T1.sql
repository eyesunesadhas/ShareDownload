CREATE TABLE dbo.RefErrorMessage_T1
(
   Error_CODE              CHAR (20) NOT NULL,
   DescriptionError_TEXT   VARCHAR (300) NOT NULL,
   TypeError_CODE          CHAR (1) NOT NULL,
   BeginValidity_DATE      DATE NOT NULL DEFAULT SYSDATETIME (),
   Update_DTTM             DATETIME2 (7) NOT NULL DEFAULT SYSUTCDATETIME (),
   WorkerUpdate_ID         VARCHAR (36) NULL,
   TransactionEventSeq_NUMB   NUMERIC (19) NULL,
   CONSTRAINT EMSG_I1 PRIMARY KEY CLUSTERED (Error_CODE ASC)
);