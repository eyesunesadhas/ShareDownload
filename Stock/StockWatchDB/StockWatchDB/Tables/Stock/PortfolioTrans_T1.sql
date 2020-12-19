CREATE TABLE PortfolioTrans_T1
(
	Trade_CODE VARCHAR(15) NOT NULL,
	Account_ID INT NOT NULL ,
	Shares_CNT NUMERIC(11,4) NOT NULL,
    TransAction_CODE VARCHAR(10) NOT NULL,
    TransAction_DATE DATE  NULL,
    Settlement_DATE  DATE NULL,  
	CostBasis_AMNT MONEY NOT NULL,
    Trans_ID     INT IDENTITY(1,1)  NOT NULL ,
    Trade_ID     VARCHAR(45) NULL, /* Trade_CODE-TractionAction_DATE-SEQ*/
    TransactionEventSeq_NUMB   NUMERIC (19) NOT NULL,
    Update_DTTM                DATETIME2 (7) DEFAULT SYSUTCDATETIME (),
    WorkerUpdate_ID            VARCHAR (36) NULL,
    BeginValidity_DTTM         DATETIME2 (7)  GENERATED ALWAYS AS ROW START NOT NULL,
    EndValidity_DTTM           DATETIME2 (7)  GENERATED ALWAYS AS ROW END   NOT NULL,
    CONSTRAINT PFOT_I1 PRIMARY KEY CLUSTERED (Trade_CODE,Account_ID,Trans_ID),
    PERIOD FOR SYSTEM_TIME (BeginValidity_DTTM, EndValidity_DTTM)
)
