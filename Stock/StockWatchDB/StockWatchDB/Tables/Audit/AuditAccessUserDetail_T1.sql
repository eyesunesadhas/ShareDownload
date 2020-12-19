CREATE TABLE AuditAccessUserDetail_T1
(
   Seq_NUMB          BIGINT IDENTITY (1, 1) NOT NULL,
   Unique_ID         VARCHAR (35) NOT NULL,
   Access_DATE       DATE DEFAULT SYSDATETIME (),
   Access_DTTM       DATETIME2 DEFAULT SYSUTCDATETIME (),
   AccessByUser_ID   VARCHAR (36) NOT NULL,
   PageLocation      VARCHAR (100) NULL,
   [Service_NAME]    VARCHAR (35) NULL,
   Method_NAME       VARCHAR (100) NULL,
   Application_ID    VARCHAR (16) NULL,
   ServerIP_TEXT     VARCHAR (35) NULL,
   ClientIp_TEXT     VARCHAR (15) NULL,
   Agent_TEXT        VARCHAR (400) NULL,
   HttpStatus        NUMERIC (3, 0) NULL,
   StartTime_DTTM    DATETIME2 (7) NOT NULL,
   EndTime_DTTM      DATETIME2 (7) NOT NULL,
   Input_JSON        VARCHAR (8000) NULL,
   Status_JSON       VARCHAR (8000) NULL,
   CONSTRAINT ACLG_I1 PRIMARY KEY CLUSTERED (Seq_NUMB ASC)
)