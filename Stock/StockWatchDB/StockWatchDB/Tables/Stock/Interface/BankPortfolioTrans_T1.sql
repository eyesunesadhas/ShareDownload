CREATE TABLE BankPortfolioTrans_T1
(
	  BankAccount_ID   VARCHAR(20) NOT NULL ,
	  Trade_CODE       VARCHAR(15) NOT NULL,
	  Trade_NAME       VARCHAR(255) NULL,
	  Trade_ID         VARCHAR(45) NULL, /* Trade_CODE-TractionAction_DATE-SEQ*/
	  TransAction_CODE VARCHAR(10)  NULL,
      TransAction_DATE DATE  NULL,
	  Settlement_DATE  DATE NULL,  
	  Shares_CNT       NUMERIC(11,4)  NULL,
	  CostBasis_AMNT   MONEY  NULL,
	  Value_AMNT       MONEY NULL,
	  Export_DATE      DATE NULL,
	  Seq_NUMB         INT  NULL ,
	  Account_ID       INT NULL ,
	  Update_DTTM      DATETIME2 (7) DEFAULT SYSUTCDATETIME ()
)
