CREATE TABLE RefMaintenance_T1
(
   Table_ID                   VARCHAR (10) NOT NULL,
   TableSub_ID                VARCHAR (10) NOT NULL,
   SystemTable_INDC           CHAR (1) NULL,
   DescriptionTable_TEXT      VARCHAR (30) NULL,
   DispOrder_NUMB             SMALLINT NULL,
   Value_CODE                 VARCHAR (10) NOT NULL,
   DescriptionValue_TEXT      VARCHAR (70) NULL,
   BeginValidity_DATE         DATE NOT NULL DEFAULT SYSDATETIME (),
   Update_DTTM                DATETIME2 (7) NOT NULL DEFAULT SYSUTCDATETIME (),
   WorkerUpdate_ID            VARCHAR (36) NULL,
   TransactionEventSeq_NUMB   NUMERIC (19) NULL,
   CONSTRAINT REFM_I1 PRIMARY KEY
      CLUSTERED
      (Table_ID, TableSub_ID, Value_CODE)
);
GO