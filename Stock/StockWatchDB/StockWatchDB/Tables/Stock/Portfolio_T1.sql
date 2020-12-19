﻿CREATE TABLE Portfolio_T1
(
	Trade_CODE VARCHAR(15) NOT NULL,
	Account_ID INT NOT NULL ,
	Shares_CNT NUMERIC(11,4) NOT NULL,
	CostBasis_AMNT MONEY NOT NULL,
    TransactionEventSeq_NUMB   NUMERIC (19) NOT NULL,
    Update_DTTM                DATETIME2 (7) DEFAULT SYSUTCDATETIME (),
    WorkerUpdate_ID            VARCHAR (36) NULL,
    BeginValidity_DTTM         DATETIME2 (7)    GENERATED ALWAYS AS ROW START NOT NULL,
    EndValidity_DTTM           DATETIME2 (7)  GENERATED ALWAYS AS ROW END   NOT NULL,
    CONSTRAINT PFOL_I1 PRIMARY KEY CLUSTERED (Trade_CODE,Account_ID),
    PERIOD FOR SYSTEM_TIME (BeginValidity_DTTM, EndValidity_DTTM)
)
WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE=dbo.PortfolioHist_T1, DATA_CONSISTENCY_CHECK=OFF));