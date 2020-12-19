CREATE TABLE AuditAccessErrorDetail_T1
(
   Seq_NUMB                   BIGINT IDENTITY (1, 1) NOT NULL,
   Unique_ID                  CHAR (35) NOT NULL,
   Access_DATE                DATE DEFAULT SYSDATETIME (),
   Access_DTTM                DATETIME2 DEFAULT SYSUTCDATETIME (),
   AccessByUser_ID            VARCHAR (36) NOT NULL,
   Type_TEXT                  CHAR (10) NOT NULL,
   Application_ID             VARCHAR (16) NULL,
   ServerIP_TEXT              VARCHAR (35) NULL,
   ClientIp_TEXT              VARCHAR (15) NULL,
   Agent_TEXT                 VARCHAR (400) NULL,
   Input_JSON                 VARCHAR (8000) NULL,
   Status_JSON                VARCHAR (8000) NULL,
   ScriptError_TEXT           VARCHAR (8000) NOT NULL,
   StackTrace_TEXT            VARCHAR (8000) NOT NULL,
   BaseException_TEXT         VARCHAR (4000) NOT NULL,
   InnerException_TEXT        VARCHAR (4000) NOT NULL,
   InnerExceptionStack_TEXT   VARCHAR (8000) NOT NULL,
   CONSTRAINT ERLG_I1 PRIMARY KEY CLUSTERED (Seq_NUMB ASC)
)