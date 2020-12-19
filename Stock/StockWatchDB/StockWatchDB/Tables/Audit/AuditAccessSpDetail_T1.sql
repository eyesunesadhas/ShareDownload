CREATE TABLE dbo.AuditAccessSpDetail_T1
(
   Seq_NUMB               BIGINT IDENTITY (1, 1) NOT NULL,
   Application_NAME       VARCHAR (50) NOT NULL,
   Unique_ID              VARCHAR (35) NOT NULL,
   Access_DATE            DATE DEFAULT SYSDATETIME (),
   Access_DTTM            DATETIME2 DEFAULT SYSUTCDATETIME (),
   AccessByUser_ID        VARCHAR (36) NOT NULL,
   Application_ID         VARCHAR (16) NULL,
   StoredProcedure_NAME   VARCHAR (400) NOT NULL,
   StartTime_DTTM         DATETIME2 (7) NOT NULL,
   EndTime_DTTM           DATETIME2 (7) NOT NULL,
   Sql_TEXT               VARCHAR (MAX) NOT NULL,
   Error_TEXT             VARCHAR (8000) NOT NULL,
   CONSTRAINT SPLG_I1 PRIMARY KEY CLUSTERED (Seq_NUMB ASC)
)
GO