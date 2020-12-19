CREATE TABLE GlobalEvent_T1
(
   TransactionEventSeq_NUMB  NUMERIC (19) IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
   Process_ID                VARCHAR (50) NULL,
   EventFunctionalSeq_NUMB   SMALLINT NULL,
   EffectiveEvent_DATE       DATE NULL DEFAULT SYSDATETIME (),
   Event_DTTM                DATETIME2 (7) NOT NULL DEFAULT SYSUTCDATETIME (),
   WorkerUpdate_ID           VARCHAR (36) NULL,
   CONSTRAINT [GLEC_I1] PRIMARY KEY CLUSTERED (TransactionEventSeq_NUMB)
);