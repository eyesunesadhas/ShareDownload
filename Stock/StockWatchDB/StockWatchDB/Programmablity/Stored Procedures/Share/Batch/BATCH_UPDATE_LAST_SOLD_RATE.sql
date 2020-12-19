CREATE PROCEDURE BATCH_UPDATE_LAST_SOLD_RATE
AS
 BEGIN 
   DECLARE @SoldRate_P1 TABLE
	(   Trade_CODE                 VARCHAR (15) NOT NULL,
	    SoldAt_AMNT                MONEY  NULL DEFAULT 0,
        SoldOn_DATE                DATE   NULL
	);

	INSERT INTO @SoldRate_P1(Trade_CODE,SoldAt_AMNT,SoldOn_DATE)
	SELECT T.Trade_CODE,
           T.CostBasis_AMNT,
           T.TransAction_DATE
    FROM (
        SELECT T.Trade_CODE,
               T.CostBasis_AMNT,
               T.TransAction_DATE,
               ROW_NUMBER ()
               OVER (PARTITION BY T.Trade_CODE
                     ORDER BY T.TransAction_DATE DESC, T.CostBasis_AMNT DESC)  Row_NUMB
          FROM PortfolioTrans_T1 T
         WHERE T.TransAction_CODE = 'SELL' ) T
     WHERE T.Row_NUMB =1;

     UPDATE SM 
       SET  SoldAt_AMNT =  SR.SoldAt_AMNT ,
            SoldOn_DATE =  SR.SoldOn_DATE
       FROM ShareMaster_T1 SM 
         JOIN @SoldRate_P1 SR
           ON SM.Trade_CODE = SR.Trade_CODE
        Where IsNull(SM.SoldOn_DATE,'1/1/0001') < SR.SoldOn_DATE ;
 END
