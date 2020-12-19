CREATE TABLE dbo.AuditAccessLogin_T1
(
   Seq_NUMB        BIGINT IDENTITY (1, 1) NOT NULL,
   Unique_ID       VARCHAR (35),
   [User_ID]       VARCHAR (36),
   Ticket_ID       VARCHAR(1000) NULL,
   AuthType_CODE   CHAR (10),
   ClientIp_TEXT   VARCHAR (15),
   Attempt_CNT     TINYINT,
   Error_CODE      CHAR (18),
   Error_TEXT      VARCHAR (300),
   Access_DATE     DATE  DEFAULT SYSDATETIME() ,
   Access_DTTM     DATETIME2 DEFAULT SYSUTCDATETIME(),
   CONSTRAINT AULG_I1 PRIMARY KEY CLUSTERED (Seq_NUMB ASC)
)